-- =====================================================
-- Week 42: SQL FULL OUTER JOIN Practice
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
-- PART 1: UNDERSTANDING FULL OUTER JOIN
-- =====================================================

/*
WHAT IS A FULL OUTER JOIN?
- FULL OUTER JOIN returns ALL rows from BOTH tables
- If there's no match in either table, NULL values are returned for the other table's columns
- It preserves all records from both tables regardless of matches
- Useful for finding all records and identifying missing relationships
- Combines the results of both LEFT JOIN and RIGHT JOIN

SYNTAX:
SELECT columns
FROM left_table
FULL OUTER JOIN right_table ON left_table.column = right_table.column
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Left Table:    Right Table:   FULL OUTER JOIN Result:
ID  Name       ID  City       ID  Name  City
1   John       1   Baku       1   John  Baku
2   Mary       3   Ganja      2   Mary  NULL
3   Bob        5   Shaki      3   Bob   Ganja
                              NULL NULL Shaki

Note: All records from both tables are preserved, NULL for non-matches.
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
-- PART 3: FULL OUTER JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic FULL OUTER JOIN - All Customers and Orders
-- This shows ALL customers and ALL orders, with NULLs for non-matches
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
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName, o.OrderDate;

-- Example 2: FULL OUTER JOIN with Data Analysis - Complete Data Overview
-- Analyze all customers and orders to identify data patterns
SELECT 
    c.ID AS CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    CASE 
        WHEN c.ID IS NULL THEN 'Orphaned Order'
        WHEN o.ID IS NULL THEN 'Customer without Orders'
        ELSE 'Valid Relationship'
    END AS RelationshipType
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY RelationshipType, c.FirstName, o.OrderDate;

-- Example 3: FULL OUTER JOIN with Aggregation - Complete Business Analysis
-- Calculate comprehensive statistics for all customers and orders
SELECT 
    'Total Customers' AS Metric,
    COUNT(DISTINCT c.ID) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
UNION ALL
SELECT 
    'Total Orders',
    COUNT(DISTINCT o.ID)
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
UNION ALL
SELECT 
    'Customers with Orders',
    COUNT(DISTINCT c.ID)
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.ID IS NOT NULL
UNION ALL
SELECT 
    'Customers without Orders',
    COUNT(DISTINCT c.ID)
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.ID IS NULL
UNION ALL
SELECT 
    'Orphaned Orders',
    COUNT(DISTINCT o.ID)
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NULL;

-- Example 4: Multiple FULL OUTER JOINs - Complete Data Analysis
-- Show all customers, orders, and products with their relationships
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    o.ID AS OrderID,
    o.OrderDate,
    o.TotalAmount,
    p.ProductName,
    p.Category,
    od.Quantity,
    od.UnitPrice
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
FULL OUTER JOIN OrderDetail od ON o.ID = od.OrderID
FULL OUTER JOIN Product p ON od.ProductID = p.ID
ORDER BY c.FirstName, o.OrderDate, p.ProductName;

-- Example 5: FULL OUTER JOIN with Data Quality Analysis
-- Identify data quality issues and missing relationships
SELECT 
    CASE 
        WHEN c.ID IS NULL AND o.ID IS NOT NULL THEN 'Orphaned Order'
        WHEN c.ID IS NOT NULL AND o.ID IS NULL THEN 'Customer without Orders'
        WHEN c.ID IS NOT NULL AND o.ID IS NOT NULL THEN 'Valid Relationship'
        ELSE 'Unknown'
    END AS DataQualityIssue,
    COUNT(*) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY 
    CASE 
        WHEN c.ID IS NULL AND o.ID IS NOT NULL THEN 'Orphaned Order'
        WHEN c.ID IS NOT NULL AND o.ID IS NULL THEN 'Customer without Orders'
        WHEN c.ID IS NOT NULL AND o.ID IS NOT NULL THEN 'Valid Relationship'
        ELSE 'Unknown'
    END
ORDER BY Count DESC;

-- =====================================================
-- PART 4: FULL OUTER JOIN EXERCISES
-- =====================================================

-- Exercise 1: Complete Customer Analysis
-- Write a query to show all customers and their order history

-- Exercise 2: Product Order Analysis
-- Write a query to show all products and their order details

-- Exercise 3: Data Integrity Analysis
-- Write a query to identify all data integrity issues

-- Exercise 4: Business Overview
-- Write a query to create a comprehensive business overview

-- Exercise 5: Customer Segmentation
-- Write a query to categorize all customers based on their order behavior

-- Exercise 6: Product Performance Analysis
-- Write a query to analyze all products and their performance

-- Exercise 7: Order Analysis
-- Write a query to analyze all orders and their details

-- Exercise 8: Geographic Analysis
-- Write a query to analyze customer and order distribution by geography

-- Exercise 9: Temporal Analysis
-- Write a query to analyze patterns over time

-- Exercise 10: Revenue Analysis
-- Write a query to analyze revenue from all sources

-- =====================================================
-- PART 5: ADVANCED FULL OUTER JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Data Warehouse Analysis
-- Write a query to create a comprehensive data warehouse view

-- Advanced Exercise 2: Business Intelligence
-- Write a query to create executive-level business reports

-- Advanced Exercise 3: Data Quality Management
-- Write a query to identify and categorize data quality issues

-- Advanced Exercise 4: Performance Analysis
-- Write a query to analyze system performance and bottlenecks

-- Advanced Exercise 5: Predictive Analysis
-- Write a query to identify trends and patterns for forecasting

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: Data Migration
-- Write a query to analyze data before and after migration

-- Scenario 2: System Integration
-- Write a query to analyze data integration between systems

-- Scenario 3: Data Audit
-- Write a query to perform comprehensive data auditing

-- Scenario 4: Business Reporting
-- Write a query to create comprehensive business reports

-- Scenario 5: Data Quality Management
-- Write a query to identify and resolve data quality issues

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
FULL OUTER JOIN BEST PRACTICES:

1. Use FULL OUTER JOIN when you need to preserve all records from both tables
   Example: Complete data analysis, data quality checks

2. Always handle NULL values in your SELECT and WHERE clauses
   Example: ISNULL(c.FirstName, 'Unknown') AS CustomerName

3. Use meaningful column names to distinguish between tables
   Example: c.ID AS CustomerID, o.ID AS OrderID

4. Consider performance implications with large datasets
   - FULL OUTER JOIN can be slower than other join types
   - Use appropriate indexes on join columns

5. Use WHERE clauses to filter specific relationship types
   Example: WHERE c.ID IS NULL (to find orphaned orders)

6. Be careful with aggregation functions
   - COUNT(*) counts all rows including NULLs
   - Use COUNT(column) to count non-NULL values

7. Use CASE statements to categorize relationship types
   Example: CASE WHEN c.ID IS NULL THEN 'Orphaned Order' END

COMMON MISTAKES TO AVOID:

1. Forgetting to handle NULL values in calculations
2. Using COUNT(*) instead of COUNT(column) for non-NULL counts
3. Not considering the impact of NULL values on WHERE clauses
4. Using FULL OUTER JOIN when other join types would be more appropriate
5. Not using table aliases in complex queries
6. Confusing the order of tables in FULL OUTER JOIN

WHEN TO USE FULL OUTER JOIN:
- When you need to preserve all records from both tables
- When analyzing data quality and integrity
- When performing comprehensive data analysis
- When creating data warehouse views
- When auditing data relationships
- When integrating data from multiple sources
*/

-- =====================================================
-- PART 8: VERIFICATION QUERIES
-- =====================================================

-- Verify our data relationships
SELECT 
    'Total Records (Customers + Orders)' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID;

SELECT 
    'Valid Relationships' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NOT NULL AND o.ID IS NOT NULL;

SELECT 
    'Customers without Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NOT NULL AND o.ID IS NULL;

SELECT 
    'Orphaned Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID IS NULL AND o.ID IS NOT NULL;

-- =====================================================
-- END OF WEEK 42 FULL OUTER JOIN PRACTICE
-- =====================================================
