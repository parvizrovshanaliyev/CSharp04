-- =====================================================
-- Week 42: SQL INNER JOINS Practice
-- Course: CSharp04 .NET Development
-- Date: 16.08.2025
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- =====================================================
-- STUDENT STUDY GUIDE
-- =====================================================

/*
STUDY ORDER:
1. First read and understand the examples
2. Then write the exercises yourself
3. Check the solutions
4. Try the additional difficulty level exercises
*/

-- =====================================================
-- PART 1: UNDERSTANDING INNER JOINS
-- =====================================================

/*
WHAT IS AN INNER JOIN?
- INNER JOIN returns only the rows that have matching values in both tables
- It combines rows from two or more tables based on a related column
- Only records that exist in BOTH tables are returned
- Records without matches are excluded from the result

SYNTAX:
SELECT columns
FROM table1
INNER JOIN table2 ON table1.column = table2.column
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Table A:     Table B:     INNER JOIN Result:
ID  Name     ID  City     ID  Name  City
1   John     1   Baku     1   John  Baku
2   Mary     3   Ganja    3   Bob   Ganja
3   Bob      5   Shaki

Note: Only records with matching IDs (1 and 3) appear in the result.
*/

-- =====================================================
-- PART 2: SETUP - USING SHOPPING DATABASE
-- =====================================================

-- Use the existing ShoppingDB database
USE ShoppingDB;
GO

-- Verify our tables exist and have data
SELECT 'Customer' AS TableName, COUNT(*) AS RecordCount FROM Customer
UNION ALL
SELECT 'Product', COUNT(*) FROM Product
UNION ALL
SELECT '[Order]', COUNT(*) FROM [Order]
UNION ALL
SELECT 'OrderDetail', COUNT(*) FROM OrderDetail;

-- =====================================================
-- PART 3: INNER JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic INNER JOIN - Customer with their Orders
-- This shows which customers have placed orders
SELECT 
    c.ID AS CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName, o.OrderDate;

-- Example 2: INNER JOIN with WHERE condition
-- Show only delivered orders with customer information
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    o.OrderDate,
    o.TotalAmount,
    o.ShippingAddress
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.Status = 'Delivered'
ORDER BY o.TotalAmount DESC;

-- Example 3: Multiple INNER JOINS - Customer, Order, and Order Details
-- Show what products each customer ordered
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    o.ID AS OrderID,
    o.OrderDate,
    p.ProductName,
    od.Quantity,
    od.UnitPrice,
    od.TotalPrice
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
INNER JOIN OrderDetail od ON o.ID = od.OrderID
INNER JOIN Product p ON od.ProductID = p.ID
ORDER BY c.FirstName, o.OrderDate, p.ProductName;

-- Example 4: INNER JOIN with Aggregation
-- Calculate total spent by each customer
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    COUNT(o.ID) AS TotalOrders,
    SUM(o.TotalAmount) AS TotalSpent,
    AVG(o.TotalAmount) AS AverageOrderValue
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.FirstName, c.LastName, c.City
ORDER BY TotalSpent DESC;

-- Example 5: INNER JOIN with Product Category Analysis
-- Show which categories are most popular by customer city
SELECT 
    c.City,
    p.Category,
    COUNT(od.ID) AS TotalItemsOrdered,
    SUM(od.Quantity) AS TotalQuantity,
    SUM(od.TotalPrice) AS TotalRevenue
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
INNER JOIN OrderDetail od ON o.ID = od.OrderID
INNER JOIN Product p ON od.ProductID = p.ID
GROUP BY c.City, p.Category
ORDER BY c.City, TotalRevenue DESC;

-- =====================================================
-- PART 4: INNER JOIN EXERCISES
-- =====================================================

-- Exercise 1: Customer Order Summary
-- Write a query to show each customer's name, email, and their total number of orders

-- Exercise 2: Product Performance Analysis
-- Write a query to show product name, category, and how many times it was ordered

-- Exercise 3: City-Based Sales Report
-- Write a query to show total sales amount for each city where customers live

-- Exercise 4: High-Value Orders
-- Write a query to show customer details for orders with total amount greater than 2000

-- Exercise 5: Product Category Popularity
-- Write a query to show which product categories are most popular (by number of orders)

-- Exercise 6: Customer Purchase History
-- Write a query to show each customer's purchase history including product names and quantities

-- Exercise 7: Order Status Analysis
-- Write a query to show how many orders are in each status for each city

-- Exercise 8: Product Revenue Analysis
-- Write a query to show each product's total revenue (sum of all order details)

-- Exercise 9: Customer Loyalty Analysis
-- Write a query to show customers who have placed more than 1 order

-- Exercise 10: Brand Performance
-- Write a query to show total sales by product brand

-- =====================================================
-- PART 5: ADVANCED INNER JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Customer Segmentation
-- Write a query to categorize customers as:
-- 'High Value' (total spent > 3000)
-- 'Medium Value' (total spent between 1000-3000)
-- 'Low Value' (total spent < 1000)

-- Advanced Exercise 2: Product Cross-Selling Analysis
-- Write a query to show which products are often bought together in the same order

-- Advanced Exercise 3: Seasonal Analysis
-- Write a query to show sales performance by month (extract month from OrderDate)

-- Advanced Exercise 4: Customer Retention Analysis
-- Write a query to show customers who have placed orders in multiple months

-- Advanced Exercise 5: Product Category Mix
-- Write a query to show customers who have ordered products from multiple categories

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: Inventory Management
-- Write a query to identify products that have been ordered but have low stock

-- Scenario 2: Customer Service
-- Write a query to show pending orders with customer contact information

-- Scenario 3: Marketing Analysis
-- Write a query to identify the most valuable customers for a loyalty program

-- Scenario 4: Shipping Optimization
-- Write a query to show orders grouped by shipping city with total shipping volume

-- Scenario 5: Product Performance
-- Write a query to show products that haven't been ordered yet

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
INNER JOIN BEST PRACTICES:

1. Always use table aliases for better readability
   Example: Customer c, [Order] o

2. Use meaningful column names in SELECT
   Example: c.FirstName + ' ' + c.LastName AS CustomerName

3. Always specify the JOIN condition clearly
   Example: ON c.ID = o.CustomerID

4. Use WHERE clauses to filter data before joining when possible

5. Consider the order of tables in multiple joins for performance

6. Use appropriate data types for join columns

7. Always test your joins with small datasets first

COMMON MISTAKES TO AVOID:

1. Forgetting the ON clause
2. Using wrong column names in join conditions
3. Not considering NULL values
4. Joining on columns with different data types
5. Not using table aliases in complex queries
*/

-- =====================================================
-- PART 8: VERIFICATION QUERIES
-- =====================================================

-- Verify our data relationships
SELECT 
    'Customer-Order Relationship' AS CheckType,
    COUNT(*) AS MatchingRecords
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID;

SELECT 
    'Order-OrderDetail Relationship' AS CheckType,
    COUNT(*) AS MatchingRecords
FROM [Order] o
INNER JOIN OrderDetail od ON o.ID = od.OrderID;

SELECT 
    'Product-OrderDetail Relationship' AS CheckType,
    COUNT(*) AS MatchingRecords
FROM Product p
INNER JOIN OrderDetail od ON p.ID = od.ProductID;

-- =====================================================
-- END OF WEEK 42 INNER JOINS PRACTICE
-- =====================================================
