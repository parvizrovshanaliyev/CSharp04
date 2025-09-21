-- =====================================================
-- Week 42: SQL SELF JOIN Practice
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
-- PART 1: UNDERSTANDING SELF JOIN
-- =====================================================

/*
WHAT IS A SELF JOIN?
- SELF JOIN is a join where a table is joined with itself
- It's used to compare rows within the same table
- Different aliases are used for the same table to distinguish between them
- Useful for finding hierarchical relationships, comparing records, and finding duplicates

SYNTAX:
SELECT columns
FROM table1 alias1
JOIN table1 alias2 ON alias1.column = alias2.column
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Original Table:    SELF JOIN Result:
ID  Name  ManagerID  ID  Name  ManagerID  ManagerName
1   John  NULL       1   John  NULL       NULL
2   Mary  1          2   Mary  1          John
3   Bob   1          3   Bob   1          John
4   Alice 2          4   Alice 2          Mary

Note: The table is joined with itself using different aliases.
*/

-- =====================================================
-- PART 2: SETUP - USING SHOPPING DATABASE
-- =====================================================

-- Use the existing ShoppingDB database
USE ShoppingDB;
GO

-- First, let's add some hierarchical data to demonstrate SELF JOIN
-- Add a ManagerID column to Customer table for demonstration
ALTER TABLE Customer ADD ManagerID INT NULL;
GO

-- Add some sample data with hierarchical relationships
UPDATE Customer SET ManagerID = NULL WHERE ID = 1; -- John is a manager
UPDATE Customer SET ManagerID = 1 WHERE ID = 2;    -- Mary reports to John
UPDATE Customer SET ManagerID = 1 WHERE ID = 3;    -- Bob reports to John
UPDATE Customer SET ManagerID = 2 WHERE ID = 4;    -- Alice reports to Mary
UPDATE Customer SET ManagerID = 2 WHERE ID = 5;    -- Elvin reports to Mary

-- Verify our tables exist and have data
SELECT 'Customer' AS TableName, COUNT(*) AS RecordCount FROM Customer
UNION ALL
SELECT 'Product', COUNT(*) FROM Product
UNION ALL
SELECT '[Order]', COUNT(*) FROM [Order]
UNION ALL
SELECT 'OrderDetail', COUNT(*) FROM OrderDetail;

-- =====================================================
-- PART 3: SELF JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic SELF JOIN - Customer Hierarchy
-- Show customers with their managers
SELECT 
    emp.ID AS EmployeeID,
    emp.FirstName + ' ' + emp.LastName AS EmployeeName,
    emp.City,
    mgr.ID AS ManagerID,
    mgr.FirstName + ' ' + mgr.LastName AS ManagerName,
    mgr.City AS ManagerCity
FROM Customer emp
LEFT JOIN Customer mgr ON emp.ManagerID = mgr.ID
ORDER BY emp.FirstName;

-- Example 2: SELF JOIN with Filtering - Find Managers
-- Show only customers who are managers
SELECT 
    mgr.ID AS ManagerID,
    mgr.FirstName + ' ' + mgr.LastName AS ManagerName,
    mgr.City,
    COUNT(emp.ID) AS NumberOfEmployees
FROM Customer mgr
INNER JOIN Customer emp ON mgr.ID = emp.ManagerID
GROUP BY mgr.ID, mgr.FirstName, mgr.LastName, mgr.City
ORDER BY NumberOfEmployees DESC;

-- Example 3: SELF JOIN for Comparison - Find Similar Customers
-- Find customers from the same city
SELECT 
    c1.FirstName + ' ' + c1.LastName AS Customer1,
    c2.FirstName + ' ' + c2.LastName AS Customer2,
    c1.City
FROM Customer c1
INNER JOIN Customer c2 ON c1.City = c2.City AND c1.ID < c2.ID
ORDER BY c1.City, c1.FirstName;

-- Example 4: SELF JOIN with Aggregation - Customer Analysis
-- Analyze customer relationships and hierarchy
SELECT 
    mgr.FirstName + ' ' + mgr.LastName AS ManagerName,
    mgr.City AS ManagerCity,
    COUNT(emp.ID) AS DirectReports,
    STRING_AGG(emp.FirstName + ' ' + emp.LastName, ', ') AS EmployeeNames
FROM Customer mgr
LEFT JOIN Customer emp ON mgr.ID = emp.ManagerID
GROUP BY mgr.ID, mgr.FirstName, mgr.LastName, mgr.City
ORDER BY DirectReports DESC;

-- Example 5: SELF JOIN for Duplicate Detection - Find Duplicate Customers
-- Find customers with similar information
SELECT 
    c1.ID AS Customer1ID,
    c1.FirstName + ' ' + c1.LastName AS Customer1Name,
    c1.Email AS Customer1Email,
    c2.ID AS Customer2ID,
    c2.FirstName + ' ' + c2.LastName AS Customer2Name,
    c2.Email AS Customer2Email,
    c1.City
FROM Customer c1
INNER JOIN Customer c2 ON c1.City = c2.City 
    AND c1.FirstName = c2.FirstName 
    AND c1.ID < c2.ID
ORDER BY c1.City, c1.FirstName;

-- =====================================================
-- PART 4: SELF JOIN EXERCISES
-- =====================================================

-- Exercise 1: Employee Hierarchy
-- Write a query to show the complete employee hierarchy

-- Exercise 2: Manager Analysis
-- Write a query to show managers and their team sizes

-- Exercise 3: Peer Analysis
-- Write a query to find customers who are peers (same manager)

-- Exercise 4: Duplicate Detection
-- Write a query to find potential duplicate customers

-- Exercise 5: Geographic Analysis
-- Write a query to find customers in the same city

-- Exercise 6: Order Comparison
-- Write a query to compare customers' order patterns

-- Exercise 7: Customer Relationships
-- Write a query to analyze customer relationships

-- Exercise 8: Performance Analysis
-- Write a query to compare customer performance

-- Exercise 9: Hierarchy Depth
-- Write a query to find the depth of the customer hierarchy

-- Exercise 10: Team Analysis
-- Write a query to analyze team structures

-- =====================================================
-- PART 5: ADVANCED SELF JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Recursive Hierarchy
-- Write a query to show the complete hierarchy tree

-- Advanced Exercise 2: Performance Comparison
-- Write a query to compare customer performance metrics

-- Advanced Exercise 3: Relationship Analysis
-- Write a query to analyze customer relationships

-- Advanced Exercise 4: Data Quality
-- Write a query to identify data quality issues

-- Advanced Exercise 5: Business Intelligence
-- Write a query to create business intelligence reports

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: Organizational Structure
-- Write a query to show the organizational structure

-- Scenario 2: Customer Segmentation
-- Write a query to segment customers based on relationships

-- Scenario 3: Data Quality Management
-- Write a query to identify data quality issues

-- Scenario 4: Business Analysis
-- Write a query to analyze business relationships

-- Scenario 5: Performance Management
-- Write a query to manage performance across teams

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
SELF JOIN BEST PRACTICES:

1. Always use different aliases for the same table
   Example: Customer emp, Customer mgr

2. Use meaningful alias names
   Example: emp for employee, mgr for manager

3. Be careful with the join condition
   Example: emp.ManagerID = mgr.ID

4. Use appropriate join types
   - INNER JOIN for required relationships
   - LEFT JOIN for optional relationships

5. Consider performance implications
   - SELF JOIN can be slow with large tables
   - Use appropriate indexes

6. Use WHERE clauses to filter results
   Example: WHERE emp.ID < mgr.ID (to avoid duplicates)

COMMON MISTAKES TO AVOID:

1. Using the same alias for both table references
2. Forgetting to use different aliases
3. Not considering the join condition carefully
4. Using SELF JOIN when other approaches would be better
5. Not handling NULL values properly
6. Creating infinite loops in recursive queries

WHEN TO USE SELF JOIN:
- When analyzing hierarchical relationships
- When comparing records within the same table
- When finding duplicates or similar records
- When analyzing organizational structures
- When performing data quality checks
- When creating recursive queries

WHEN NOT TO USE SELF JOIN:
- When you can use window functions instead
- When the relationship is not clear
- When performance is critical
- When simpler approaches exist
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
    'Customers with Managers' AS CheckType,
    COUNT(*) AS Count
FROM Customer
WHERE ManagerID IS NOT NULL;

SELECT 
    'Customers without Managers' AS CheckType,
    COUNT(*) AS Count
FROM Customer
WHERE ManagerID IS NULL;

SELECT 
    'Managers' AS CheckType,
    COUNT(*) AS Count
FROM Customer c1
WHERE EXISTS (SELECT 1 FROM Customer c2 WHERE c2.ManagerID = c1.ID);

-- =====================================================
-- PART 9: CLEANUP (Optional)
-- =====================================================

-- Remove the ManagerID column if you want to clean up
-- ALTER TABLE Customer DROP COLUMN ManagerID;

-- =====================================================
-- END OF WEEK 42 SELF JOIN PRACTICE
-- =====================================================
