-- =====================================================
-- SQL Aggregate Functions Practice
-- Week40-Day01 - 27.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- 1. COUNT() FUNCTION
-- =====================================================

-- COUNT() function counts the number of rows
-- COUNT(*) counts all rows including NULL values
-- COUNT(column_name) counts only non-NULL values in that column

-- Count total number of customers
-- This counts all customers in the table
SELECT COUNT(*) AS TotalCustomers FROM Customer;

-- Count active customers only
-- This counts only customers where IsActive = 1
-- WHERE clause filters the data before counting
SELECT COUNT(*) AS ActiveCustomers 
FROM Customer 
WHERE IsActive = 1;

-- Count customers by city
-- This groups customers by city and counts how many are in each city
-- GROUP BY City creates separate groups for each unique city
-- ORDER BY CustomerCount DESC shows cities with most customers first
SELECT 
    City,
    COUNT(*) AS CustomerCount
FROM Customer
GROUP BY City
ORDER BY CustomerCount DESC;

-- Count customers with orders
-- COUNT(DISTINCT CustomerID) counts unique customer IDs
-- This tells us how many different customers have placed orders
-- DISTINCT prevents counting the same customer multiple times
SELECT COUNT(DISTINCT CustomerID) AS CustomersWithOrders 
FROM [Order];

-- Count products by category
SELECT 
    Category,
    COUNT(*) AS ProductCount
FROM Product
GROUP BY Category
ORDER BY ProductCount DESC;

-- =====================================================
-- 2. SUM() FUNCTION
-- =====================================================

-- SUM() function adds up all values in a column
-- Only works with numeric columns
-- Ignores NULL values automatically

-- Total revenue from all orders
-- This adds up all order amounts to get total revenue
-- Useful for business reporting and analysis
SELECT SUM(TotalAmount) AS TotalRevenue 
FROM [Order];

-- Total revenue by status
-- This groups orders by status and calculates total revenue for each status
-- Shows which order statuses generate the most revenue
-- Useful for understanding order processing patterns
SELECT 
    Status,
    SUM(TotalAmount) AS TotalRevenue
FROM [Order]
GROUP BY Status
ORDER BY TotalRevenue DESC;

-- Total spent by each customer
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's calculate total spent per customer ID
SELECT 
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- Total value of inventory
SELECT SUM(Price * StockQuantity) AS TotalInventoryValue 
FROM Product;

-- =====================================================
-- 3. AVG() FUNCTION
-- =====================================================

-- AVG() function calculates the average (mean) of values in a column
-- Only works with numeric columns
-- Ignores NULL values automatically
-- Formula: SUM of all values / COUNT of non-NULL values

-- Average order amount
-- This calculates the typical order size
-- Useful for understanding customer spending patterns
SELECT AVG(TotalAmount) AS AverageOrderAmount 
FROM [Order];

-- Average order amount by status
SELECT 
    Status,
    AVG(TotalAmount) AS AverageOrderAmount,
    COUNT(*) AS OrderCount
FROM [Order]
GROUP BY Status
ORDER BY AverageOrderAmount DESC;

-- Average product price by category
SELECT 
    Category,
    AVG(Price) AS AveragePrice,
    COUNT(*) AS ProductCount
FROM Product
GROUP BY Category
ORDER BY AveragePrice DESC;

-- Average customer spending
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's calculate average spending per customer
SELECT 
    CustomerID,
    AVG(TotalAmount) AS AverageSpending
FROM [Order]
GROUP BY CustomerID
ORDER BY AverageSpending DESC;

-- =====================================================
-- 4. MAX() FUNCTION
-- =====================================================

-- MAX() function finds the highest value in a column
-- Works with numeric, text, and date columns
-- For text: finds the "highest" value alphabetically
-- For dates: finds the most recent date

-- Most expensive product
-- This finds the product with the highest price
-- Uses a subquery to find the maximum price, then finds products with that price
-- (Subqueries will be covered in advanced topics)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE Price = (SELECT MAX(Price) FROM Product);

-- Highest order amount
SELECT 
    ID,
    CustomerID,
    TotalAmount,
    OrderDate
FROM [Order]
WHERE TotalAmount = (SELECT MAX(TotalAmount) FROM [Order]);

-- Maximum stock quantity by category
SELECT 
    Category,
    MAX(StockQuantity) AS MaxStock
FROM Product
GROUP BY Category
ORDER BY MaxStock DESC;

-- =====================================================
-- 5. MIN() FUNCTION
-- =====================================================

-- MIN() function finds the lowest value in a column
-- Works with numeric, text, and date columns
-- For text: finds the "lowest" value alphabetically
-- For dates: finds the earliest date

-- Cheapest product
-- This finds the product with the lowest price
-- Uses a subquery to find the minimum price, then finds products with that price
-- (Subqueries will be covered in advanced topics)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE Price = (SELECT MIN(Price) FROM Product);

-- Lowest order amount
SELECT 
    ID,
    CustomerID,
    TotalAmount,
    OrderDate
FROM [Order]
WHERE TotalAmount = (SELECT MIN(TotalAmount) FROM [Order]);

-- Minimum stock quantity by category
SELECT 
    Category,
    MIN(StockQuantity) AS MinStock
FROM Product
GROUP BY Category
ORDER BY MinStock ASC;

-- =====================================================
-- 6. MULTIPLE AGGREGATE FUNCTIONS TOGETHER
-- =====================================================

-- You can use multiple aggregate functions in the same query
-- This provides comprehensive statistics in one result set
-- Very useful for business analysis and reporting

-- Product statistics by category
-- This provides a complete overview of each product category
-- Shows count, average price, price range, and total stock
SELECT 
    Category,
    COUNT(*) AS ProductCount,
    AVG(Price) AS AveragePrice,
    MIN(Price) AS MinPrice,
    MAX(Price) AS MaxPrice,
    SUM(StockQuantity) AS TotalStock
FROM Product
GROUP BY Category
ORDER BY AveragePrice DESC;

-- Customer order statistics
-- This uses JOIN and GROUP BY which will be covered later
-- For now, let's calculate order statistics per customer ID
SELECT 
    CustomerID,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalSpent,
    AVG(TotalAmount) AS AverageOrderAmount,
    MIN(TotalAmount) AS MinOrderAmount,
    MAX(TotalAmount) AS MaxOrderAmount
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- =====================================================
-- 7. AGGREGATE FUNCTIONS WITH HAVING
-- =====================================================

-- HAVING clause filters results after aggregation
-- WHERE filters individual rows before grouping
-- HAVING filters groups after grouping
-- Only use HAVING with GROUP BY

-- Categories with more than 2 products
-- This finds categories that have more than 2 products
-- HAVING COUNT(*) > 2 filters out categories with 2 or fewer products
SELECT 
    Category,
    COUNT(*) AS ProductCount
FROM Product
GROUP BY Category
HAVING COUNT(*) > 2
ORDER BY ProductCount DESC;

-- Customers who spent more than average
-- This uses subqueries which will be covered later
-- For now, let's just show customers by total spending
SELECT 
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- Products with average price higher than overall average
-- This uses subqueries which will be covered later
-- For now, let's just show average price by category
SELECT 
    Category,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
ORDER BY AveragePrice DESC;

-- =====================================================
-- 8. AGGREGATE FUNCTIONS WITH SUBQUERIES
-- =====================================================

-- Products priced above average
-- This uses subqueries which will be covered later
-- For now, let's just show products ordered by price
SELECT 
    ProductName,
    Price,
    Category
FROM Product
ORDER BY Price DESC;

-- Customers with above-average spending
-- This uses complex subqueries which will be covered later
-- For now, let's just show customers by total spending
SELECT 
    CustomerID,
    SUM(TotalAmount) AS TotalSpent
FROM [Order]
GROUP BY CustomerID
ORDER BY TotalSpent DESC;

-- =====================================================
-- 9. CONDITIONAL AGGREGATION
-- =====================================================

-- Count of orders by month
SELECT 
    YEAR(OrderDate) AS OrderYear,
    MONTH(OrderDate) AS OrderMonth,
    COUNT(*) AS OrderCount,
    SUM(TotalAmount) AS TotalRevenue
FROM [Order]
GROUP BY YEAR(OrderDate), MONTH(OrderDate)
ORDER BY OrderYear, OrderMonth;

-- Revenue by product category
-- This uses JOIN which will be covered later
-- For now, let's calculate revenue by product
SELECT 
    p.Category,
    COUNT(*) AS ProductCount,
    SUM(p.Price * p.StockQuantity) AS InventoryValue
FROM Product p
GROUP BY p.Category
ORDER BY InventoryValue DESC;

-- =====================================================
-- 10. PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: Find the total number of products in each brand
/*
SELECT 
    Brand,
    COUNT(*) AS ProductCount
FROM Product
GROUP BY Brand
ORDER BY ProductCount DESC;
*/

-- Exercise 2: Calculate average order amount for each customer
/*
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    AVG(o.TotalAmount) AS AverageOrderAmount
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName
ORDER BY AverageOrderAmount DESC;
*/

-- Exercise 3: Find categories with average price above 1000
/*
SELECT 
    Category,
    AVG(Price) AS AveragePrice
FROM Product
GROUP BY Category
HAVING AVG(Price) > 1000
ORDER BY AveragePrice DESC;
*/

-- Exercise 4: Calculate total revenue by city
/*
SELECT 
    c.City,
    SUM(o.TotalAmount) AS TotalRevenue,
    COUNT(o.ID) AS OrderCount
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.City
ORDER BY TotalRevenue DESC;
*/

-- Exercise 5: Find products with stock below average
/*
SELECT 
    ProductName,
    StockQuantity
FROM Product
WHERE StockQuantity < (SELECT AVG(StockQuantity) FROM Product)
ORDER BY StockQuantity ASC;
*/

-- =====================================================
-- 11. ADVANCED AGGREGATION EXAMPLES
-- =====================================================

-- Running totals (using window functions)
-- This uses window functions which will be covered later
-- For now, let's just show products ordered by price
SELECT 
    ProductName,
    Price,
    Category
FROM Product
ORDER BY Price;

-- Percentage of total
-- This uses subqueries which will be covered later
-- For now, let's just count products by category
SELECT 
    Category,
    COUNT(*) AS ProductCount
FROM Product
GROUP BY Category
ORDER BY ProductCount DESC;

-- Rank products by price within each category
-- This uses window functions which will be covered later
-- For now, let's show products ordered by category and price
SELECT 
    ProductName,
    Price,
    Category
FROM Product
ORDER BY Category, Price DESC;

-- =====================================================
-- 12. PERFORMANCE TIPS
-- =====================================================
/*
PERFORMANCE TIPS FOR AGGREGATE FUNCTIONS:

1. Use appropriate indexes on GROUP BY columns
2. Avoid using DISTINCT with COUNT(*) when possible
3. Use HAVING instead of WHERE for aggregate conditions
4. Consider using window functions for complex aggregations
5. Use appropriate data types for calculations
6. Be careful with NULL values in aggregations

COMMON MISTAKES:
- Using WHERE instead of HAVING for aggregate conditions
- Forgetting to handle NULL values
- Using COUNT(*) when COUNT(column) is more appropriate
- Not considering the order of operations
*/

-- =====================================================
-- END OF AGGREGATE FUNCTIONS PRACTICE
-- ===================================================== 