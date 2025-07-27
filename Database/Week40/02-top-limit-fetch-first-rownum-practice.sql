-- =====================================================
-- SQL TOP, LIMIT, FETCH FIRST, ROWNUM Practice
-- Week40-Day01 - 27.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- 1. SQL SERVER TOP CLAUSE
-- =====================================================

-- TOP clause is specific to SQL Server
-- Syntax: SELECT TOP n [PERCENT] column1, column2, ... FROM table_name
-- 
-- IMPORTANT: TOP always requires ORDER BY clause
-- Without ORDER BY, the results are unpredictable
-- TOP n: Returns first n rows
-- TOP n PERCENT: Returns first n% of rows

-- Get top 5 most expensive products
-- This returns the 5 products with the highest prices
-- ORDER BY Price DESC ensures we get the most expensive first
SELECT TOP 5 
    ProductName,
    Price,
    Category,
    Brand
FROM Product
ORDER BY Price DESC;

-- Get top 10% of customers by registration date (oldest first)
-- This returns the oldest 10% of customers (those who registered first)
-- ORDER BY RegistrationDate ASC ensures oldest customers come first
-- PERCENT keyword calculates 10% of total customer count
SELECT TOP 10 PERCENT
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    RegistrationDate,
    City
FROM Customer
ORDER BY RegistrationDate ASC;

-- Get top 3 customers with most orders
-- This uses GROUP BY which will be covered later
-- For now, let's find top customers by order count
-- This query counts orders per customer and returns the top 3
-- ORDER BY OrderCount DESC ensures customers with most orders come first
SELECT TOP 3
    CustomerID,
    COUNT(*) AS OrderCount
FROM [Order]
GROUP BY CustomerID
ORDER BY OrderCount DESC;

-- =====================================================
-- 2. TOP WITH TIES
-- =====================================================

-- TOP WITH TIES includes rows that tie for the last position
-- If multiple products have the same price as the 3rd product,
-- WITH TIES will include all of them, not just the first 3
-- This is useful when you want to include all items that are "tied" for the last position
-- Get top 3 products by price, including ties
SELECT TOP 3 WITH TIES
    ProductName,
    Price,
    Category
FROM Product
ORDER BY Price DESC;

-- =====================================================
-- 3. TOP WITH PERCENTAGE
-- =====================================================

-- Get top 20% of orders by amount
-- This returns the 20% of orders with the highest amounts
-- Useful for finding the most valuable orders
-- PERCENT keyword automatically calculates 20% of total order count
SELECT TOP 20 PERCENT
    ID,
    CustomerID,
    TotalAmount,
    Status,
    OrderDate
FROM [Order]
ORDER BY TotalAmount DESC;

-- =====================================================
-- 4. TOP WITH MULTIPLE COLUMNS
-- =====================================================

-- Get top 5 customers by total spent
-- This uses GROUP BY which will be covered later
-- For now, let's find top customers by total amount
-- This query sums up all order amounts per customer and returns top 5
-- Useful for identifying your best customers
SELECT TOP 5
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- =====================================================
-- 5. TOP WITH WHERE CONDITIONS
-- =====================================================

-- Get top 5 active products with stock > 10
-- This combines TOP with WHERE conditions for more specific filtering
-- Only considers products that are active AND have sufficient stock
-- Then returns the 5 most expensive ones
SELECT TOP 5
    ProductName,
    Price,
    StockQuantity,
    Category
FROM Product
WHERE IsActive = 1 AND StockQuantity > 10
ORDER BY Price DESC;

-- Get top 3 customers from Baku with orders
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's find top orders from Baku customers
SELECT TOP 3
    o.CustomerID,
    o.TotalAmount
FROM [Order] o
WHERE o.CustomerID IN (
    SELECT ID FROM Customer WHERE City = 'Baku'
)
ORDER BY o.TotalAmount DESC;

-- =====================================================
-- 6. TOP WITH SUBQUERIES
-- =====================================================

-- Get customers who made top 3 most expensive orders
-- This uses JOIN which will be covered later
-- For now, let's find the top 3 most expensive orders
SELECT TOP 3
    ID,
    CustomerID,
    TotalAmount,
    OrderDate
FROM [Order]
ORDER BY TotalAmount DESC;

-- =====================================================
-- 7. FETCH FIRST (SQL Standard)
-- =====================================================

-- FETCH FIRST is the SQL standard way (SQL Server 2012+)
-- Syntax: SELECT ... ORDER BY ... FETCH FIRST n ROWS ONLY

-- Get first 5 products by name
SELECT 
    ProductName,
    Price,
    Category
FROM Product
ORDER BY ProductName
FETCH FIRST 5 ROWS ONLY;

-- Get first 10% of customers by registration
SELECT 
    FirstName + ' ' + LastName AS CustomerName,
    RegistrationDate
FROM Customer
ORDER BY RegistrationDate
FETCH FIRST 10 PERCENT ROWS ONLY;

-- =====================================================
-- 8. OFFSET AND FETCH (Pagination)
-- =====================================================

-- Get products with pagination (page 2, 5 items per page)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
ORDER BY ProductName
OFFSET 5 ROWS
FETCH FIRST 5 ROWS ONLY;

-- Get customers with pagination (page 3, 3 items per page)
SELECT 
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    City
FROM Customer
ORDER BY FirstName
OFFSET 6 ROWS
FETCH FIRST 3 ROWS ONLY;

-- =====================================================
-- 9. ROW_NUMBER() FOR RANKING
-- =====================================================

-- Use ROW_NUMBER() to get top N results
-- Get top 5 products by price using ROW_NUMBER()
SELECT 
    ProductName,
    Price,
    Category,
    ROW_NUMBER() OVER (ORDER BY Price DESC) AS PriceRank
FROM Product;

-- Get top 3 products by price
WITH RankedProducts AS (
    SELECT 
        ProductName,
        Price,
        Category,
        ROW_NUMBER() OVER (ORDER BY Price DESC) AS PriceRank
    FROM Product
)
SELECT 
    ProductName,
    Price,
    Category
FROM RankedProducts
WHERE PriceRank <= 3;

-- =====================================================
-- 10. PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: Get top 3 most expensive electronics
/*
SELECT TOP 3
    ProductName,
    Price,
    Brand
FROM Product
WHERE Category = 'Electronics'
ORDER BY Price DESC;
*/

-- Exercise 2: Get top 5 customers by total spent
/*
SELECT TOP 5
    c.FirstName + ' ' + c.LastName AS CustomerName,
    SUM(o.TotalAmount) AS TotalSpent
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName
ORDER BY TotalSpent DESC;
*/

-- Exercise 3: Get first 10 products alphabetically
/*
SELECT 
    ProductName,
    Category,
    Price
FROM Product
ORDER BY ProductName
FETCH FIRST 10 ROWS ONLY;
*/

-- Exercise 4: Get top 20% of orders by date (newest first)
/*
SELECT TOP 20 PERCENT
    ID,
    CustomerID,
    OrderDate,
    TotalAmount
FROM [Order]
ORDER BY OrderDate DESC;
*/

-- Exercise 5: Get customers with pagination (page 2, 4 items)
/*
SELECT 
    FirstName + ' ' + LastName AS CustomerName,
    Email,
    City
FROM Customer
ORDER BY LastName
OFFSET 4 ROWS
FETCH FIRST 4 ROWS ONLY;
*/

-- =====================================================
-- 11. COMPARISON OF DIFFERENT METHODS
-- =====================================================

-- Method 1: TOP (SQL Server specific)
SELECT TOP 5 ProductName, Price FROM Product ORDER BY Price DESC;

-- Method 2: FETCH FIRST (SQL Standard)
SELECT ProductName, Price FROM Product ORDER BY Price DESC FETCH FIRST 5 ROWS ONLY;

-- Method 3: ROW_NUMBER() (More flexible)
WITH RankedProducts AS (
    SELECT 
        ProductName,
        Price,
        ROW_NUMBER() OVER (ORDER BY Price DESC) AS Rank
    FROM Product
)
SELECT ProductName, Price FROM RankedProducts WHERE Rank <= 5;

-- =====================================================
-- 12. PERFORMANCE CONSIDERATIONS
-- =====================================================
/*
PERFORMANCE TIPS:

1. Always use ORDER BY with TOP/FETCH FIRST
2. Use appropriate indexes on ORDER BY columns
3. TOP is generally faster than ROW_NUMBER() for simple cases
4. Use TOP WITH TIES when you need to include tied values
5. Consider using OFFSET/FETCH for pagination instead of TOP
6. Be careful with TOP PERCENT on large datasets

WHEN TO USE EACH:
- TOP: SQL Server specific, simple cases
- FETCH FIRST: SQL standard, portable code
- ROW_NUMBER(): Complex ranking scenarios
- OFFSET/FETCH: Pagination scenarios
*/

-- =====================================================
-- END OF TOP, LIMIT, FETCH FIRST, ROWNUM PRACTICE
-- ===================================================== 