-- =====================================================
-- SQL Comprehensive Practice Exercises
-- Week40-Day01 - 27.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- COMPREHENSIVE PRACTICE EXERCISES
-- Combining DELETE, TOP, Aggregate Functions, and LIKE
-- =====================================================

-- =====================================================
-- EXERCISE 1: CUSTOMER ANALYSIS
-- =====================================================

-- Task: Analyze customers and their spending patterns
-- Requirements:
-- 1. Find top 5 customers by total spent
-- 2. Calculate average spending per customer
-- 3. Find customers with spending above average
-- 4. Delete inactive customers with no orders

-- Step 1: Find top 5 customers by total spent
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's find top 5 customers by total amount
SELECT TOP 5
    CustomerID,
    SUM(TotalAmount) AS TotalSpent,
    COUNT(*) AS OrderCount
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- Step 2: Calculate average spending per customer
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's calculate average spending per customer
SELECT 
    CustomerID,
    AVG(TotalAmount) AS AverageSpending
FROM [Order]
GROUP BY CustomerID
ORDER BY AverageSpending DESC;

-- Step 3: Find customers with spending above average
-- This uses subqueries which will be covered later
-- For now, let's just show customers by total spending
SELECT 
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- Step 4: Find inactive customers with no orders (for deletion)
-- This uses JOIN which will be covered later
-- For now, let's find inactive customers
SELECT 
    ID,
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    City,
    IsActive
FROM Customer
WHERE IsActive = 0;

-- Delete inactive customers with no orders (commented for safety)
/*
DELETE FROM Customer 
WHERE IsActive = 0;
*/

-- =====================================================
-- EXERCISE 2: PRODUCT INVENTORY ANALYSIS
-- =====================================================

-- Task: Analyze product inventory and pricing
-- Requirements:
-- 1. Find top 3 most expensive products by category
-- 2. Calculate inventory value by category
-- 3. Find products with low stock (below average)
-- 4. Delete products with zero stock and no orders

-- Step 1: Find top 3 most expensive products by category
-- This uses window functions which will be covered later
-- For now, let's show products ordered by category and price
SELECT 
    ProductName,
    Price,
    Category,
    Brand
FROM Product
ORDER BY Category, Price DESC;

-- Step 2: Calculate inventory value by category
SELECT 
    Category,
    COUNT(*) AS ProductCount,
    SUM(StockQuantity) AS TotalStock,
    SUM(Price * StockQuantity) AS InventoryValue,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
ORDER BY InventoryValue DESC;

-- Step 3: Find products with low stock (below average)
-- This uses subqueries which will be covered later
-- For now, let's just show products ordered by stock quantity
SELECT 
    ProductName,
    Category,
    StockQuantity
FROM Product
ORDER BY StockQuantity ASC;

-- Step 4: Find products with zero stock and no orders (for deletion)
-- This uses JOIN which will be covered later
-- For now, let's just find products with zero stock
SELECT 
    ID,
    ProductName,
    Category,
    StockQuantity
FROM Product
WHERE StockQuantity = 0;

-- Delete products with zero stock and no orders (commented for safety)
/*
DELETE FROM Product 
WHERE StockQuantity = 0;
*/

-- =====================================================
-- EXERCISE 3: ORDER ANALYSIS AND CLEANUP
-- =====================================================

-- Task: Analyze orders and clean up old data
-- Requirements:
-- 1. Find top 10% of orders by amount
-- 2. Calculate order statistics by status
-- 3. Find orders older than 30 days
-- 4. Delete old cancelled orders

-- Step 1: Find top 10% of orders by amount
SELECT TOP 10 PERCENT
    ID,
    CustomerID,
    TotalAmount,
    Status,
    OrderDate
FROM [Order]
ORDER BY TotalAmount DESC;

-- Step 2: Calculate order statistics by status

-- Ensure the Status column exists (run only once; comment out after adding)
-- ALTER TABLE [Order]
-- ADD Status NVARCHAR(50) NULL;

-- Set Status for existing orders if not already set
-- You can adjust the logic below to better reflect your business rules

-- Example 1: Set 'High Value' for orders over 1000, 'Standard' otherwise
UPDATE [Order]
SET Status = CASE 
    WHEN TotalAmount > 1000 THEN 'High Value'
    WHEN TotalAmount > 0 THEN 'Standard'
    ELSE 'Pending'
END
WHERE Status IS NULL;

-- Example 2: If you want all NULL statuses to be 'Pending' (uncomment if needed)
-- UPDATE [Order]
-- SET Status = 'Pending'
-- WHERE Status IS NULL;

-- Calculate order statistics grouped by status
SELECT 
    Status,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalRevenue,
    AVG(TotalAmount) AS AverageOrderAmount,
    MIN(TotalAmount) AS MinOrderAmount,
    MAX(TotalAmount) AS MaxOrderAmount
FROM [Order]
GROUP BY Status
ORDER BY TotalRevenue DESC;

-- For a more detailed breakdown, you can also include the percentage of total orders:
SELECT 
    Status,
    COUNT(*) AS OrderCount,
    CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(5,2)) AS OrderPercent,
    SUM(TotalAmount) AS TotalRevenue,
    AVG(TotalAmount) AS AverageOrderAmount,
    MIN(TotalAmount) AS MinOrderAmount,
    MAX(TotalAmount) AS MaxOrderAmount
FROM [Order]
GROUP BY Status
ORDER BY TotalRevenue DESC;

-- Step 3: Find orders older than 30 days
SELECT 
    ID,
    CustomerID,
    TotalAmount,
    Status,
    OrderDate,
    DATEDIFF(day, OrderDate, GETDATE()) AS DaysOld
FROM [Order]
WHERE OrderDate < DATEADD(day, -30, GETDATE())
ORDER BY OrderDate ASC;

-- Step 4: Find old cancelled orders (for deletion)
SELECT 
    o.ID,
    o.CustomerID,
    o.TotalAmount,
    o.Status,
    o.OrderDate
FROM [Order] o
WHERE o.Status = 'Cancelled' 
  AND o.OrderDate < DATEADD(day, -30, GETDATE());

-- Delete old cancelled orders (commented for safety)
/*
DELETE FROM OrderDetail 
WHERE OrderID IN (
    SELECT ID FROM [Order] 
    WHERE Status = 'Cancelled' 
      AND OrderDate < DATEADD(day, -30, GETDATE())
);

DELETE FROM [Order] 
WHERE Status = 'Cancelled' 
  AND OrderDate < DATEADD(day, -30, GETDATE());
*/

-- =====================================================
-- EXERCISE 4: SEARCH AND FILTER ANALYSIS
-- =====================================================

-- Task: Implement search and filter functionality
-- Requirements:
-- 1. Search products by name pattern
-- 2. Filter customers by city pattern
-- 3. Find products with specific price patterns
-- 4. Search orders by customer name pattern

-- Step 1: Search products by name pattern
SELECT 
    ProductName,
    Price,
    Category,
    Brand
FROM Product
WHERE ProductName LIKE '%Pro%' OR ProductName LIKE '%Air%'
ORDER BY ProductName;

-- Step 2: Filter customers by city pattern
SELECT 
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    City,
    Phone
FROM Customer
WHERE City LIKE 'B%' OR City LIKE 'G%'
ORDER BY City, FirstName;

-- Step 3: Find products with specific price patterns
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE CAST(Price AS VARCHAR) LIKE '%.99'
ORDER BY Price;

-- Step 4: Search orders by customer name pattern
-- This uses subqueries which will be covered later
-- For now, let's just show all orders
SELECT 
    ID,
    CustomerID,
    TotalAmount,
    Status,
    OrderDate
FROM [Order]
ORDER BY OrderDate DESC;

-- =====================================================
-- EXERCISE 5: COMPREHENSIVE REPORTING
-- =====================================================

-- Task: Create comprehensive business reports
-- Requirements:
-- 1. Monthly revenue report
-- 2. Top performing categories
-- 3. Customer retention analysis
-- 4. Inventory turnover analysis

-- Step 1: Monthly revenue report
SELECT 
    YEAR(OrderDate) AS OrderYear,
    MONTH(OrderDate) AS OrderMonth,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalRevenue,
    AVG(TotalAmount) AS AverageOrderAmount
FROM [Order]
GROUP BY YEAR(OrderDate), MONTH(OrderDate)
ORDER BY OrderYear, OrderMonth;

-- Step 2: Top performing categories
-- This uses JOIN which will be covered later
-- For now, let's analyze product categories
SELECT 
    Category,
    COUNT(*) AS ProductCount,
    SUM(Price * StockQuantity) AS InventoryValue,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
ORDER BY InventoryValue DESC;

-- Step 3: Customer retention analysis
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's analyze order patterns per customer
SELECT 
    CustomerID,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalSpent,
    MIN(OrderDate) AS FirstOrder,
    MAX(OrderDate) AS LastOrder,
    DATEDIFF(day, MIN(OrderDate), MAX(OrderDate)) AS CustomerLifetime
FROM [Order]
GROUP BY CustomerID
HAVING COUNT(*) > 1
ORDER BY TotalSpent DESC;

-- Step 4: Inventory turnover analysis
-- This uses JOIN which will be covered later
-- For now, let's analyze inventory by category
SELECT 
    Category,
    COUNT(*) AS ProductCount,
    SUM(StockQuantity) AS TotalStock,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
ORDER BY TotalStock DESC;

-- =====================================================
-- EXERCISE 6: DATA CLEANUP AND MAINTENANCE
-- =====================================================

-- Task: Perform data cleanup and maintenance
-- Requirements:
-- 1. Find duplicate email addresses
-- 2. Identify orphaned order details
-- 3. Find products with invalid prices
-- 4. Clean up old customer data

-- Step 1: Find duplicate email addresses
SELECT 
    Email,
    COUNT(*) AS DuplicateCount
FROM Customer
GROUP BY Email
HAVING COUNT(*) > 1
ORDER BY DuplicateCount DESC;

-- Step 2: Identify orphaned order details
-- This uses JOIN which will be covered later
-- For now, let's just show all order details
SELECT 
    ID,
    OrderID,
    ProductID
FROM OrderDetail;

-- Step 3: Find products with invalid prices
SELECT 
    ID,
    ProductName,
    Price,
    Category
FROM Product
WHERE Price <= 0 OR Price IS NULL
ORDER BY ProductName;

-- Step 4: Find old customer data (registered more than 1 year ago with no orders)
-- This uses JOIN which will be covered later
-- For now, let's just find old customers
SELECT 
    ID,
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    RegistrationDate
FROM Customer
WHERE RegistrationDate < DATEADD(year, -1, GETDATE());

-- =====================================================
-- EXERCISE 7: ADVANCED QUERIES
-- =====================================================

-- Task: Create advanced analytical queries
-- Requirements:
-- 1. Customer segmentation by spending
-- 2. Product performance ranking
-- 3. Seasonal order analysis
-- 4. Cross-selling analysis

-- Step 1: Customer segmentation by spending
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's analyze customers by total spending
SELECT 
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- Step 2: Product performance ranking
-- This uses window functions which will be covered later
-- For now, let's show products ordered by price
SELECT 
    ProductName,
    Category,
    Price
FROM Product
ORDER BY Price DESC;

-- Step 3: Seasonal order analysis
SELECT 
    DATEPART(month, OrderDate) AS OrderMonth,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalRevenue,
    AVG(TotalAmount) AS AverageOrderAmount
FROM [Order]
GROUP BY DATEPART(month, OrderDate)
ORDER BY OrderMonth;

-- Step 4: Cross-selling analysis
-- This uses complex JOIN operations which will be covered later
-- For now, let's analyze product categories
SELECT 
    Category,
    COUNT(*) AS ProductCount,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
ORDER BY ProductCount DESC;

-- =====================================================
-- END OF COMPREHENSIVE PRACTICE EXERCISES
-- ===================================================== 