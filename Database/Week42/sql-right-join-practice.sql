-- =====================================================
-- Week 42: SQL RIGHT JOIN Practice
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
-- PART 1: UNDERSTANDING RIGHT JOIN
-- =====================================================

/*
WHAT IS A RIGHT JOIN?
- RIGHT JOIN returns ALL rows from the right table and matching rows from the left table
- If there's no match in the left table, NULL values are returned for left table columns
- It preserves all records from the right table regardless of matches
- Useful for finding records that may or may not have related data
- RIGHT JOIN is less commonly used than LEFT JOIN

SYNTAX:
SELECT columns
FROM left_table
RIGHT JOIN right_table ON left_table.column = right_table.column
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Left Table:    Right Table:   RIGHT JOIN Result:
ID  Name       ID  City       ID  Name  City
1   John       1   Baku       1   John  Baku
2   Mary       3   Ganja      3   Bob   Ganja
3   Bob        5   Shaki      NULL NULL Shaki

Note: All records from right table are preserved, NULL for non-matches.
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
-- PART 3: RIGHT JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic RIGHT JOIN - All Orders with their Customers
-- This shows ALL orders, even if customer information is missing
SELECT 
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status,
    c.ID AS CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY o.OrderDate DESC;

-- Example 2: RIGHT JOIN with WHERE condition - Orders without Customer Info
-- Find orders that might have orphaned customer references
SELECT 
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status,
    o.CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NULL
ORDER BY o.OrderDate;

-- Example 3: RIGHT JOIN with Aggregation - Order Analysis
-- Calculate order statistics for all orders (including potential orphaned orders)
SELECT 
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    CASE 
        WHEN c.ID IS NULL THEN 'Orphaned Order'
        ELSE 'Valid Order'
    END AS OrderStatus
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY o.OrderDate DESC;

-- Example 4: Multiple RIGHT JOINs - Complete Order Analysis
-- Show all orders with their details and product information
SELECT 
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    o.Status,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    p.ProductName,
    od.Quantity,
    od.UnitPrice,
    od.TotalPrice
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
RIGHT JOIN OrderDetail od ON o.ID = od.OrderID
RIGHT JOIN Product p ON od.ProductID = p.ID
ORDER BY o.OrderDate DESC, p.ProductName;

-- Example 5: RIGHT JOIN with Product Analysis - All Products and Orders
-- Show all products and their order history
SELECT 
    p.ProductName,
    p.Category,
    p.Price,
    p.StockQuantity,
    o.ID AS OrderID,
    o.OrderDate,
    od.Quantity AS OrderedQuantity,
    od.UnitPrice AS OrderPrice
FROM [Order] o
RIGHT JOIN OrderDetail od ON o.ID = od.OrderID
RIGHT JOIN Product p ON od.ProductID = p.ID
ORDER BY p.ProductName, o.OrderDate DESC;

-- =====================================================
-- PART 4: RIGHT JOIN EXERCISES
-- =====================================================

-- Exercise 1: Order Analysis
-- Write a query to show all orders and their customer information

-- Exercise 2: Product Order History
-- Write a query to show all products and their order history

-- Exercise 3: Order Detail Analysis
-- Write a query to show all order details with product and customer info

-- Exercise 4: Orphaned Data Detection
-- Write a query to find orders that might have data integrity issues

-- Exercise 5: Product Performance Analysis
-- Write a query to show all products and their performance metrics

-- Exercise 6: Order Status Analysis
-- Write a query to analyze order statuses across all orders

-- Exercise 7: Customer Order Analysis
-- Write a query to show all orders and their customer details

-- Exercise 8: Product Category Analysis
-- Write a query to show all product categories and their order statistics

-- Exercise 9: Order Date Analysis
-- Write a query to analyze order patterns by date

-- Exercise 10: Revenue Analysis
-- Write a query to show all orders and their revenue contribution

-- =====================================================
-- PART 5: ADVANCED RIGHT JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Data Integrity Analysis
-- Write a query to identify potential data integrity issues

-- Advanced Exercise 2: Order Lifecycle Analysis
-- Write a query to analyze the complete lifecycle of orders

-- Advanced Exercise 3: Product Market Analysis
-- Write a query to analyze product performance in the market

-- Advanced Exercise 4: Customer Behavior Analysis
-- Write a query to analyze customer behavior patterns

-- Advanced Exercise 5: Business Intelligence
-- Write a query to create comprehensive business reports

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: Data Quality Management
-- Write a query to identify data quality issues

-- Scenario 2: Order Processing
-- Write a query to analyze order processing efficiency

-- Scenario 3: Product Management
-- Write a query to analyze product performance

-- Scenario 4: Customer Service
-- Write a query to identify customer service opportunities

-- Scenario 5: Business Reporting
-- Write a query to create executive reports

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
RIGHT JOIN BEST PRACTICES:

1. Use RIGHT JOIN when you need to preserve all records from the right table
   Example: All orders, even if customer info is missing

2. Consider using LEFT JOIN instead for better readability
   - RIGHT JOIN can be confusing to read
   - LEFT JOIN is more commonly used and understood

3. Always handle NULL values in your SELECT and WHERE clauses
   Example: ISNULL(c.FirstName, 'Unknown') AS CustomerName

4. Use meaningful column names to distinguish between tables
   Example: o.ID AS OrderID, c.ID AS CustomerID

5. Consider performance implications with large datasets
   - RIGHT JOIN can be slower than INNER JOIN
   - Use appropriate indexes on join columns

6. Use WHERE clauses to filter NULL values when needed
   Example: WHERE c.ID IS NULL (to find orphaned orders)

COMMON MISTAKES TO AVOID:

1. Forgetting to handle NULL values in calculations
2. Using RIGHT JOIN when LEFT JOIN would be clearer
3. Not considering the impact of NULL values on WHERE clauses
4. Using RIGHT JOIN when INNER JOIN would be more appropriate
5. Not using table aliases in complex queries
6. Confusing the order of tables in RIGHT JOIN

WHEN TO USE RIGHT JOIN:
- When you need to preserve all records from the right table
- When analyzing data integrity issues
- When you want to find orphaned records
- When the right table is the primary focus of your analysis
*/

-- =====================================================
-- PART 8: VERIFICATION QUERIES
-- =====================================================

-- Verify our data relationships
SELECT 
    'Total Orders' AS CheckType,
    COUNT(*) AS Count
FROM [Order];

SELECT 
    'Orders with Customers' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID;

SELECT 
    'Orders without Customers' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NULL;

SELECT 
    'Total Order Details' AS CheckType,
    COUNT(*) AS Count
FROM OrderDetail;

SELECT 
    'Order Details with Products' AS CheckType,
    COUNT(*) AS Count
FROM OrderDetail od
INNER JOIN Product p ON od.ProductID = p.ID;

SELECT 
    'Order Details without Products' AS CheckType,
    COUNT(*) AS Count
FROM OrderDetail od
RIGHT JOIN Product p ON od.ProductID = p.ID
WHERE od.ID IS NULL;

-- =====================================================
-- END OF WEEK 42 RIGHT JOIN PRACTICE
-- =====================================================
