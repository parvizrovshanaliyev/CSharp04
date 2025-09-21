-- =====================================================
-- Week 42: SQL CROSS JOIN Practice
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
-- PART 1: UNDERSTANDING CROSS JOIN
-- =====================================================

/*
WHAT IS A CROSS JOIN?
- CROSS JOIN returns the Cartesian product of two tables
- Every row from the first table is combined with every row from the second table
- No join condition is needed (no ON clause)
- Results in M × N rows (M rows from first table × N rows from second table)
- Useful for generating combinations, permutations, and test data

SYNTAX:
SELECT columns
FROM table1
CROSS JOIN table2
WHERE conditions
ORDER BY columns;

VISUAL EXAMPLE:
Table A:     Table B:     CROSS JOIN Result:
ID  Name     ID  City     ID  Name  ID  City
1   John     1   Baku     1   John  1   Baku
2   Mary     2   Ganja    1   John  2   Ganja
              3   Shaki    2   Mary  1   Baku
                           2   Mary  2   Ganja
                           2   Mary  3   Shaki

Note: Every row from A is combined with every row from B.
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
-- PART 3: CROSS JOIN EXAMPLES
-- =====================================================

-- Example 1: Basic CROSS JOIN - All Customers with All Products
-- This shows every possible combination of customers and products
SELECT 
    c.ID AS CustomerID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    p.ID AS ProductID,
    p.ProductName,
    p.Category,
    p.Price
FROM Customer c
CROSS JOIN Product p
ORDER BY c.FirstName, p.ProductName;

-- Example 2: CROSS JOIN with Filtering - Specific Combinations
-- Show combinations of customers from specific cities with specific product categories
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    p.ProductName,
    p.Category,
    p.Price
FROM Customer c
CROSS JOIN Product p
WHERE c.City IN ('Baku', 'Ganja') 
AND p.Category IN ('Electronics', 'Computers')
ORDER BY c.City, p.Category, c.FirstName;

-- Example 3: CROSS JOIN for Data Generation - Create Test Scenarios
-- Generate all possible combinations for testing purposes
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    p.ProductName,
    p.Price,
    'Test Order' AS OrderType,
    GETDATE() AS OrderDate
FROM Customer c
CROSS JOIN Product p
WHERE c.City = 'Baku' AND p.Category = 'Electronics'
ORDER BY c.FirstName, p.ProductName;

-- Example 4: CROSS JOIN with Calculations - Price Analysis
-- Calculate potential revenue for all customer-product combinations
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    p.ProductName,
    p.Price,
    p.StockQuantity,
    CASE 
        WHEN p.StockQuantity > 0 THEN 'Available'
        ELSE 'Out of Stock'
    END AS Availability,
    p.Price * 0.1 AS PotentialDiscount,
    p.Price * 0.9 AS DiscountedPrice
FROM Customer c
CROSS JOIN Product p
ORDER BY c.FirstName, p.Price DESC;

-- Example 5: CROSS JOIN with Multiple Tables - Complete Combinations
-- Show all possible combinations of customers, products, and order statuses
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.City,
    p.ProductName,
    p.Category,
    p.Price,
    'Pending' AS OrderStatus
FROM Customer c
CROSS JOIN Product p
CROSS JOIN (SELECT 'Pending' AS Status UNION SELECT 'Processing' UNION SELECT 'Delivered') AS OrderStatuses
ORDER BY c.FirstName, p.ProductName;

-- =====================================================
-- PART 4: CROSS JOIN EXERCISES
-- =====================================================

-- Exercise 1: Customer Product Matrix
-- Write a query to show all possible customer-product combinations

-- Exercise 2: Price Analysis
-- Write a query to analyze all possible customer-product price combinations

-- Exercise 3: Geographic Analysis
-- Write a query to show all possible city-product combinations

-- Exercise 4: Category Analysis
-- Write a query to show all possible customer-category combinations

-- Exercise 5: Test Data Generation
-- Write a query to generate test data for all customer-product combinations

-- Exercise 6: Revenue Projection
-- Write a query to project potential revenue for all combinations

-- Exercise 7: Marketing Analysis
-- Write a query to analyze marketing opportunities for all combinations

-- Exercise 8: Inventory Analysis
-- Write a query to analyze inventory needs for all combinations

-- Exercise 9: Customer Segmentation
-- Write a query to segment customers based on product preferences

-- Exercise 10: Product Recommendation
-- Write a query to recommend products for all customers

-- =====================================================
-- PART 5: ADVANCED CROSS JOIN EXERCISES
-- =====================================================

-- Advanced Exercise 1: Business Intelligence
-- Write a query to create a comprehensive business intelligence matrix

-- Advanced Exercise 2: Data Warehouse
-- Write a query to create a data warehouse fact table

-- Advanced Exercise 3: Machine Learning
-- Write a query to prepare data for machine learning algorithms

-- Advanced Exercise 4: Performance Analysis
-- Write a query to analyze performance implications of CROSS JOIN

-- Advanced Exercise 5: Data Quality
-- Write a query to identify data quality issues using CROSS JOIN

-- =====================================================
-- PART 6: PRACTICAL SCENARIOS
-- =====================================================

-- Scenario 1: E-commerce Analysis
-- Write a query to analyze e-commerce opportunities

-- Scenario 2: Marketing Campaigns
-- Write a query to plan marketing campaigns

-- Scenario 3: Inventory Management
-- Write a query to manage inventory across all combinations

-- Scenario 4: Customer Service
-- Write a query to plan customer service strategies

-- Scenario 5: Business Planning
-- Write a query to create business plans

-- =====================================================
-- PART 7: TIPS AND BEST PRACTICES
-- =====================================================

/*
CROSS JOIN BEST PRACTICES:

1. Use CROSS JOIN when you need all possible combinations
   Example: Generating test data, creating matrices

2. Be careful with large datasets
   - CROSS JOIN can produce very large result sets
   - Always consider the M × N multiplication effect

3. Use WHERE clauses to limit results
   Example: WHERE c.City = 'Baku' AND p.Category = 'Electronics'

4. Use meaningful column names to distinguish between tables
   Example: c.ID AS CustomerID, p.ID AS ProductID

5. Consider performance implications
   - CROSS JOIN can be very slow with large tables
   - Use appropriate indexes and filters

6. Use CROSS JOIN for specific purposes
   - Data generation
   - Matrix creation
   - Test data creation
   - Business analysis

COMMON MISTAKES TO AVOID:

1. Using CROSS JOIN when other join types would be more appropriate
2. Not considering the size of the result set
3. Forgetting to use WHERE clauses to limit results
4. Using CROSS JOIN for regular business queries
5. Not using table aliases in complex queries
6. Confusing CROSS JOIN with other join types

WHEN TO USE CROSS JOIN:
- When you need all possible combinations
- When generating test data
- When creating matrices
- When performing business analysis
- When creating data warehouse fact tables
- When preparing data for machine learning

WHEN NOT TO USE CROSS JOIN:
- For regular business queries
- When you need specific relationships
- When working with large tables
- When performance is critical
- When you need filtered results
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
    'Total Products' AS CheckType,
    COUNT(*) AS Count
FROM Product;

SELECT 
    'Total CROSS JOIN Combinations' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
CROSS JOIN Product p;

SELECT 
    'CROSS JOIN with Filter' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
CROSS JOIN Product p
WHERE c.City = 'Baku' AND p.Category = 'Electronics';

-- =====================================================
-- PART 9: PERFORMANCE CONSIDERATIONS
-- =====================================================

-- Example: CROSS JOIN Performance Test
-- This query shows the impact of CROSS JOIN on performance
SELECT 
    'Performance Test' AS TestType,
    COUNT(*) AS TotalRows,
    'CROSS JOIN can be slow with large tables' AS Warning
FROM Customer c
CROSS JOIN Product p;

-- Example: CROSS JOIN with LIMIT (if supported)
-- This query limits the result set for better performance
SELECT TOP 100
    c.FirstName + ' ' + c.LastName AS CustomerName,
    p.ProductName,
    p.Price
FROM Customer c
CROSS JOIN Product p
ORDER BY c.FirstName, p.ProductName;

-- =====================================================
-- END OF WEEK 42 CROSS JOIN PRACTICE
-- =====================================================
