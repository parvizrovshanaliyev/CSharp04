-- =====================================================
-- Week 42: SQL JOIN Comparison and Best Practices
-- Course: CSharp04 .NET Development
-- Date: 16.08.2025
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- =====================================================
-- STUDENT STUDY GUIDE
-- =====================================================

/*
STUDY ORDER:
1. First read and understand the comparison table
2. Then study the examples for each join type
3. Practice with the exercises
4. Review the best practices
5. Try the advanced scenarios
*/

-- =====================================================
-- PART 1: JOIN TYPES COMPARISON
-- =====================================================

/*
JOIN TYPES COMPARISON TABLE:

| Join Type        | Returns                    | Use Case                          | Performance | NULL Handling |
|------------------|----------------------------|-----------------------------------|-------------|---------------|
| INNER JOIN       | Matching rows only         | Find related data                 | Fast        | No NULLs      |
| LEFT JOIN        | All left + matching right  | Preserve left table data          | Medium      | NULLs for right|
| RIGHT JOIN       | All right + matching left  | Preserve right table data         | Medium      | NULLs for left |
| FULL OUTER JOIN  | All rows from both tables  | Complete data analysis            | Slow        | NULLs for both |
| CROSS JOIN       | Cartesian product          | Generate combinations             | Very Slow   | No NULLs      |
| SELF JOIN        | Table joined with itself   | Hierarchical relationships        | Medium      | Depends on type|

VISUAL COMPARISON:
Table A:     Table B:     INNER JOIN:    LEFT JOIN:     RIGHT JOIN:    FULL OUTER:
ID  Name     ID  City     ID  Name  City ID  Name  City ID  Name  City ID  Name  City
1   John     1   Baku     1   John  Baku  1   John  Baku  1   John  Baku  1   John  Baku
2   Mary     3   Ganja    3   Bob   Ganja 2   Mary  NULL  3   Bob   Ganja 2   Mary  NULL
3   Bob      5   Shaki                   3   Bob   Ganja 5   NULL  Shaki 3   Bob   Ganja
                                                             5   NULL  Shaki
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
-- PART 3: JOIN TYPE EXAMPLES COMPARISON
-- =====================================================

-- Example 1: INNER JOIN - Only matching records
-- Returns only customers who have placed orders
SELECT 
    'INNER JOIN' AS JoinType,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID,
    o.TotalAmount
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName;

-- Example 2: LEFT JOIN - All customers with their orders
-- Returns all customers, even those without orders
SELECT 
    'LEFT JOIN' AS JoinType,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    ISNULL(CAST(o.ID AS VARCHAR), 'No Orders') AS OrderID,
    ISNULL(CAST(o.TotalAmount AS VARCHAR), 'No Orders') AS TotalAmount
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName;

-- Example 3: RIGHT JOIN - All orders with their customers
-- Returns all orders, even if customer info is missing
SELECT 
    'RIGHT JOIN' AS JoinType,
    ISNULL(c.FirstName + ' ' + c.LastName, 'Unknown Customer') AS CustomerName,
    o.ID AS OrderID,
    o.TotalAmount
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY o.ID;

-- Example 4: FULL OUTER JOIN - All customers and all orders
-- Returns all customers and all orders
SELECT 
    'FULL OUTER JOIN' AS JoinType,
    ISNULL(c.FirstName + ' ' + c.LastName, 'Unknown Customer') AS CustomerName,
    ISNULL(CAST(o.ID AS VARCHAR), 'No Orders') AS OrderID,
    ISNULL(CAST(o.TotalAmount AS VARCHAR), 'No Orders') AS TotalAmount
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY c.FirstName, o.ID;

-- Example 5: CROSS JOIN - All possible combinations
-- Returns all possible customer-order combinations
SELECT 
    'CROSS JOIN' AS JoinType,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID,
    o.TotalAmount
FROM Customer c
CROSS JOIN [Order] o
ORDER BY c.FirstName, o.ID;

-- =====================================================
-- PART 4: PERFORMANCE COMPARISON
-- =====================================================

-- Performance Test 1: INNER JOIN
-- Measure execution time for INNER JOIN
SELECT 
    'INNER JOIN Performance' AS TestType,
    COUNT(*) AS RecordCount,
    'Fast - only matching records' AS PerformanceNote
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID;

-- Performance Test 2: LEFT JOIN
-- Measure execution time for LEFT JOIN
SELECT 
    'LEFT JOIN Performance' AS TestType,
    COUNT(*) AS RecordCount,
    'Medium - all left records' AS PerformanceNote
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID;

-- Performance Test 3: CROSS JOIN
-- Measure execution time for CROSS JOIN
SELECT 
    'CROSS JOIN Performance' AS TestType,
    COUNT(*) AS RecordCount,
    'Slow - all combinations' AS PerformanceNote
FROM Customer c
CROSS JOIN [Order] o;

-- =====================================================
-- PART 5: WHEN TO USE EACH JOIN TYPE
-- =====================================================

-- Scenario 1: INNER JOIN - When you need only related data
-- Use case: Find customers who have placed orders
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COUNT(o.ID) AS OrderCount,
    SUM(o.TotalAmount) AS TotalSpent
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName
ORDER BY TotalSpent DESC;

-- Scenario 2: LEFT JOIN - When you need to preserve left table data
-- Use case: Find all customers and their order statistics
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COUNT(o.ID) AS OrderCount,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent,
    CASE 
        WHEN COUNT(o.ID) = 0 THEN 'No Orders'
        ELSE 'Has Orders'
    END AS OrderStatus
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName
ORDER BY TotalSpent DESC;

-- Scenario 3: RIGHT JOIN - When you need to preserve right table data
-- Use case: Find all orders and their customer information
SELECT 
    ISNULL(c.FirstName + ' ' + c.LastName, 'Unknown Customer') AS CustomerName,
    o.ID AS OrderID,
    o.TotalAmount,
    o.Status
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY o.ID;

-- Scenario 4: FULL OUTER JOIN - When you need complete data analysis
-- Use case: Complete data analysis including orphaned records
SELECT 
    ISNULL(c.FirstName + ' ' + c.LastName, 'Unknown Customer') AS CustomerName,
    ISNULL(CAST(o.ID AS VARCHAR), 'No Orders') AS OrderID,
    ISNULL(CAST(o.TotalAmount AS VARCHAR), 'No Orders') AS TotalAmount,
    CASE 
        WHEN c.ID IS NULL THEN 'Orphaned Order'
        WHEN o.ID IS NULL THEN 'Customer without Orders'
        ELSE 'Valid Relationship'
    END AS RelationshipType
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY RelationshipType, c.FirstName, o.ID;

-- Scenario 5: CROSS JOIN - When you need all combinations
-- Use case: Generate test data or create matrices
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    p.ProductName,
    p.Price
FROM Customer c
CROSS JOIN Product p
WHERE c.City = 'Baku' AND p.Category = 'Electronics'
ORDER BY c.FirstName, p.ProductName;

-- =====================================================
-- PART 6: BEST PRACTICES FOR EACH JOIN TYPE
-- =====================================================

-- Best Practice 1: INNER JOIN
-- Always use appropriate indexes and clear join conditions
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.OrderDate,
    o.TotalAmount
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID  -- Clear join condition
WHERE o.OrderDate >= '2024-01-01'  -- Filter early for performance
ORDER BY o.OrderDate DESC;

-- Best Practice 2: LEFT JOIN
-- Always handle NULL values appropriately
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    ISNULL(COUNT(o.ID), 0) AS OrderCount,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName, c.City
ORDER BY TotalSpent DESC;

-- Best Practice 3: RIGHT JOIN
-- Consider using LEFT JOIN instead for better readability
-- This is equivalent to the RIGHT JOIN above but more readable
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID,
    o.TotalAmount
FROM [Order] o
LEFT JOIN Customer c ON o.CustomerID = c.ID
ORDER BY o.ID;

-- Best Practice 4: FULL OUTER JOIN
-- Use for data quality analysis and complete data views
SELECT 
    ISNULL(c.FirstName + ' ' + c.LastName, 'Unknown Customer') AS CustomerName,
    ISNULL(CAST(o.ID AS VARCHAR), 'No Orders') AS OrderID,
    CASE 
        WHEN c.ID IS NULL THEN 'Orphaned Order'
        WHEN o.ID IS NULL THEN 'Customer without Orders'
        ELSE 'Valid Relationship'
    END AS RelationshipType
FROM Customer c
FULL OUTER JOIN [Order] o ON c.ID = o.CustomerID
ORDER BY RelationshipType, c.FirstName, o.ID;

-- Best Practice 5: CROSS JOIN
-- Use sparingly and with appropriate filters
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    p.ProductName,
    p.Price
FROM Customer c
CROSS JOIN Product p
WHERE c.City = 'Baku'  -- Always use WHERE to limit results
AND p.Category = 'Electronics'
ORDER BY c.FirstName, p.ProductName;

-- =====================================================
-- PART 7: COMMON MISTAKES AND HOW TO AVOID THEM
-- =====================================================

-- Mistake 1: Using CROSS JOIN when you need INNER JOIN
-- WRONG: This creates too many rows
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID
FROM Customer c
CROSS JOIN [Order] o;  -- This creates all combinations

-- CORRECT: Use INNER JOIN for related data
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID;

-- Mistake 2: Not handling NULL values in LEFT JOIN
-- WRONG: This will cause issues with NULL values
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COUNT(o.ID) AS OrderCount,
    SUM(o.TotalAmount) AS TotalSpent  -- This will be NULL for customers without orders
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName;

-- CORRECT: Handle NULL values properly
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COUNT(o.ID) AS OrderCount,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent  -- Handle NULL values
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName;

-- Mistake 3: Using RIGHT JOIN when LEFT JOIN would be clearer
-- WRONG: This is harder to read
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID
FROM Customer c
RIGHT JOIN [Order] o ON c.ID = o.CustomerID;

-- CORRECT: Use LEFT JOIN for better readability
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.ID AS OrderID
FROM [Order] o
LEFT JOIN Customer c ON o.CustomerID = c.ID;

-- =====================================================
-- PART 8: PERFORMANCE OPTIMIZATION TIPS
-- =====================================================

-- Tip 1: Use appropriate indexes
-- Create indexes on join columns for better performance
-- CREATE INDEX IX_Order_CustomerID ON [Order](CustomerID);
-- CREATE INDEX IX_OrderDetail_OrderID ON OrderDetail(OrderID);
-- CREATE INDEX IX_OrderDetail_ProductID ON OrderDetail(ProductID);

-- Tip 2: Filter early in the query
-- Apply WHERE clauses before joins when possible
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    o.OrderDate,
    o.TotalAmount
FROM Customer c
INNER JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.OrderDate >= '2024-01-01'  -- Filter early
AND c.City = 'Baku'  -- Filter early
ORDER BY o.OrderDate DESC;

-- Tip 3: Use appropriate join types
-- Choose the most restrictive join type that meets your needs
-- INNER JOIN is faster than LEFT JOIN when you only need matching records

-- Tip 4: Avoid CROSS JOIN unless necessary
-- CROSS JOIN can create very large result sets
-- Always use WHERE clauses to limit results

-- =====================================================
-- PART 9: PRACTICAL EXERCISES
-- =====================================================

-- Exercise 1: Choose the Right Join
-- Write a query to find all customers and their order count (including customers with no orders)

-- Exercise 2: Performance Optimization
-- Write a query to find customers who have placed orders in the last 30 days

-- Exercise 3: Data Quality Analysis
-- Write a query to identify data quality issues using appropriate joins

-- Exercise 4: Business Intelligence
-- Write a query to create a comprehensive business report

-- Exercise 5: Join Comparison
-- Write the same query using different join types and compare results

-- =====================================================
-- PART 10: ADVANCED SCENARIOS
-- =====================================================

-- Advanced Scenario 1: Complex Business Analysis
-- Write a query to analyze customer behavior across multiple dimensions

-- Advanced Scenario 2: Data Warehouse Design
-- Write a query to create a fact table for data warehousing

-- Advanced Scenario 3: Performance Tuning
-- Write a query that demonstrates performance optimization techniques

-- Advanced Scenario 4: Data Quality Management
-- Write a query to identify and resolve data quality issues

-- Advanced Scenario 5: Business Intelligence
-- Write a query to create executive-level business reports

-- =====================================================
-- PART 11: SUMMARY AND RECOMMENDATIONS
-- =====================================================

/*
JOIN TYPE SELECTION GUIDE:

1. INNER JOIN - Use when:
   - You need only related data
   - Performance is critical
   - You want to exclude non-matching records

2. LEFT JOIN - Use when:
   - You need to preserve left table data
   - You want to include records without matches
   - You're analyzing customer behavior

3. RIGHT JOIN - Use when:
   - You need to preserve right table data
   - You're analyzing order data
   - Consider using LEFT JOIN instead for readability

4. FULL OUTER JOIN - Use when:
   - You need complete data analysis
   - You're checking data quality
   - You're creating data warehouse views

5. CROSS JOIN - Use when:
   - You need all possible combinations
   - You're generating test data
   - You're creating matrices
   - Always use WHERE clauses to limit results

6. SELF JOIN - Use when:
   - You're analyzing hierarchical relationships
   - You're comparing records within the same table
   - You're finding duplicates or similar records

PERFORMANCE RECOMMENDATIONS:

1. Use appropriate indexes on join columns
2. Filter early in the query
3. Choose the most restrictive join type
4. Avoid CROSS JOIN unless necessary
5. Use table aliases for clarity
6. Test with small datasets first
7. Monitor query execution plans
8. Consider query optimization techniques
*/

-- =====================================================
-- END OF WEEK 42 JOIN COMPARISON AND BEST PRACTICES
-- =====================================================
