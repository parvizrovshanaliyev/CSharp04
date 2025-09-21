-- =====================================================
-- Week 42: SQL LEFT JOIN Practice
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
-- PART 1: UNDERSTANDING LEFT JOIN
-- =====================================================

/*
WHAT IS A LEFT JOIN?
- LEFT JOIN returns ALL rows from the left table and matching rows from the right table
- If there's no match in the right table, NULL values are returned for right table columns
- It preserves all records from the left table regardless of matches
- Useful for finding records that may or may not have related data

SYNTAX:
SELECT columns
FROM left_table
LEFT JOIN right_table ON left_table.column = right_table.column
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Left Table:    Right Table:   LEFT JOIN Result:
ID  Name       ID  City       ID  Name  City
1   John       1   Baku       1   John  Baku
2   Mary       3   Ganja      2   Mary  NULL
3   Bob        5   Shaki      3   Bob   Ganja

Note: All records from left table are preserved, NULL for non-matches.
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
-- PART 3: LEFT JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic LEFT JOIN - All Customers with their Orders
-- This shows ALL customers, even those who haven't placed orders
SELECT 
    c.ID AS CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName, o.OrderDate;

-- Example 2: LEFT JOIN with WHERE condition - Customers without Orders
-- Find customers who have never placed an order
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    c.RegistrationDate,
    o.ID AS OrderID
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.ID IS NULL
ORDER BY c.FirstName;

-- Example 3: LEFT JOIN with Aggregation - Customer Order Summary
-- Calculate order statistics for all customers (including those with no orders)
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    COUNT(o.ID) AS TotalOrders,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent,
    ISNULL(AVG(o.TotalAmount), 0) AS AverageOrderValue,
    CASE 
        WHEN COUNT(o.ID) = 0 THEN 'No Orders'
        WHEN COUNT(o.ID) = 1 THEN 'Single Order'
        WHEN COUNT(o.ID) > 1 THEN 'Multiple Orders'
    END AS OrderStatus
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName, c.City
ORDER BY TotalSpent DESC;

-- Example 4: Multiple LEFT JOINs - Complete Customer Analysis
-- Show all customers with their order and product details
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    p.ProductName,
    od.Quantity,
    od.UnitPrice
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
LEFT JOIN OrderDetail od ON o.ID = od.OrderID
LEFT JOIN Product p ON od.ProductID = p.ID
ORDER BY c.FirstName, o.OrderDate, p.ProductName;

-- Example 5: LEFT JOIN with Date Filtering - Recent Customer Activity
-- Show all customers and their orders from the last 30 days
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status,
    DATEDIFF(day, o.OrderDate, GETDATE()) AS DaysSinceOrder
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID 
    AND o.OrderDate >= DATEADD(day, -30, GETDATE())
ORDER BY c.FirstName, o.OrderDate DESC;

-- =====================================================
-- PART 4: LEFT JOIN EXERCISES
-- =====================================================

-- Exercise 1: Customer Registration Analysis
-- Write a query to show all customers and their first order date (NULL if no orders)

-- Exercise 2: Product Popularity Analysis
-- Write a query to show all products and how many times they've been ordered

-- Exercise 3: City-Based Customer Analysis
-- Write a query to show all cities and the number of customers in each city

-- Exercise 4: Order Status Analysis
-- Write a query to show all customers and their order status summary

-- Exercise 5: Product Category Analysis
-- Write a query to show all product categories and their order statistics

-- Exercise 6: Customer Contact Analysis
-- Write a query to show all customers and their preferred contact method

-- Exercise 7: Order History Analysis
-- Write a query to show all customers and their order history summary

-- Exercise 8: Product Performance Analysis
-- Write a query to show all products and their performance metrics

-- Exercise 9: Customer Segmentation
-- Write a query to categorize all customers based on their order behavior

-- Exercise 10: Inventory Analysis
-- Write a query to show all products and their order frequency

-- =====================================================
-- PART 5: ADVANCED LEFT JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Customer Lifetime Value Analysis
-- Write a query to calculate lifetime value for all customers (including those with no orders)

-- Advanced Exercise 2: Product Market Analysis
-- Write a query to analyze market penetration for all products

-- Advanced Exercise 3: Geographic Analysis
-- Write a query to show sales performance by geographic region

-- Advanced Exercise 4: Customer Retention Analysis
-- Write a query to analyze customer retention patterns

-- Advanced Exercise 5: Product Recommendation Analysis
-- Write a query to identify products that might interest customers

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: Customer Service
-- Write a query to identify customers who might need follow-up

-- Scenario 2: Marketing Campaigns
-- Write a query to identify target customers for marketing

-- Scenario 3: Inventory Management
-- Write a query to identify products that need promotion

-- Scenario 4: Business Analysis
-- Write a query to create a comprehensive business dashboard

-- Scenario 5: Data Quality
-- Write a query to identify data inconsistencies

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
LEFT JOIN BEST PRACTICES:

1. Use LEFT JOIN when you need to preserve all records from the left table
   Example: All customers, even those without orders

2. Always handle NULL values in your SELECT and WHERE clauses
   Example: ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent

3. Use meaningful column names to distinguish between tables
   Example: c.FirstName + ' ' + c.LastName AS CustomerName

4. Consider performance implications with large datasets
   - LEFT JOIN can be slower than INNER JOIN
   - Use appropriate indexes on join columns

5. Use WHERE clauses to filter NULL values when needed
   Example: WHERE o.ID IS NULL (to find customers without orders)

6. Be careful with aggregation functions
   - COUNT(*) counts all rows including NULLs
   - Use COUNT(column) to count non-NULL values

COMMON MISTAKES TO AVOID:

1. Forgetting to handle NULL values in calculations
2. Using COUNT(*) instead of COUNT(column) for non-NULL counts
3. Not considering the impact of NULL values on WHERE clauses
4. Using LEFT JOIN when INNER JOIN would be more appropriate
5. Not using table aliases in complex queries
*/

-- =====================================================
-- PART 8: VERIFICATION QUERIES
-- =====================================================

-- Verify our data relationships
SELECT 
    'Total Customers' AS CheckType,
    COUNT(*) AS Count
FROM Customer;

SELECT 
    'Customers with Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID;

SELECT 
    'Customers without Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.ID IS NULL;

SELECT 
    'Total Products' AS CheckType,
    COUNT(*) AS Count
FROM Product;

SELECT 
    'Products with Orders' AS CheckType,
    COUNT(*) AS Count
FROM Product p
INNER JOIN OrderDetail od ON p.ID = od.ProductID;

SELECT 
    'Products without Orders' AS CheckType,
    COUNT(*) AS Count
FROM Product p
LEFT JOIN OrderDetail od ON p.ID = od.ProductID
WHERE od.ID IS NULL;

-- =====================================================
-- END OF WEEK 42 LEFT JOIN PRACTICE
-- =====================================================
