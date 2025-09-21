-- =====================================================
-- Week 44: SQL EXISTS, ANY, ALL, CASE, and NULL Functions Practice
-- Course: CSharp04 .NET Development
-- Date: 21.09.2025
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- =====================================================
-- STUDENT STUDY GUIDE
-- =====================================================

/*
STUDY ORDER:
1. First read and understand the examples for each concept
2. Then write the exercises yourself
3. Check the solutions
4. Try the additional difficulty level exercises
5. Practice with real-world scenarios
*/

-- =====================================================
-- PART 1: SETUP - USING SHOPPING DATABASE
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
-- PART 2: UNDERSTANDING EXISTS OPERATOR
-- =====================================================

/*
WHAT IS EXISTS?
- EXISTS is a logical operator that returns TRUE if a subquery returns at least one row
- It returns FALSE if the subquery returns no rows
- EXISTS is often used to check for the existence of related data
- It's more efficient than using COUNT(*) > 0

SYNTAX:
SELECT columns
FROM table1
WHERE EXISTS (SELECT 1 FROM table2 WHERE condition);

KEY POINTS:
- EXISTS stops as soon as it finds the first matching row
- The subquery can return any columns (we usually use SELECT 1)
- EXISTS is often used with correlated subqueries
- It's useful for checking relationships between tables
*/

-- Example 1: Basic EXISTS - Find customers who have placed orders
SELECT 
    c.ID,
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City
FROM Customer c
WHERE EXISTS (
    SELECT 1 
    FROM [Order] o 
    WHERE o.CustomerID = c.ID
)
ORDER BY c.FirstName;

-- Example 2: EXISTS with conditions - Find customers with high-value orders
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City
FROM Customer c
WHERE EXISTS (
    SELECT 1 
    FROM [Order] o 
    WHERE o.CustomerID = c.ID 
    AND o.TotalAmount > 2000
)
ORDER BY c.FirstName;

-- Example 3: EXISTS with multiple conditions - Find products that have been ordered
SELECT 
    p.ProductName,
    p.Category,
    p.Price,
    p.StockQuantity
FROM Product p
WHERE EXISTS (
    SELECT 1 
    FROM OrderDetail od 
    WHERE od.ProductID = p.ID
)
ORDER BY p.ProductName;

-- Example 4: NOT EXISTS - Find customers who have never placed an order
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    c.RegistrationDate
FROM Customer c
WHERE NOT EXISTS (
    SELECT 1 
    FROM [Order] o 
    WHERE o.CustomerID = c.ID
)
ORDER BY c.FirstName;

-- =====================================================
-- PART 3: UNDERSTANDING ANY AND ALL OPERATORS
-- =====================================================

/*
WHAT ARE ANY AND ALL?
- ANY and ALL are comparison operators used with subqueries
- ANY returns TRUE if the comparison is true for ANY value in the subquery
- ALL returns TRUE if the comparison is true for ALL values in the subquery
- They are often used with comparison operators (=, >, <, >=, <=, !=)

SYNTAX:
WHERE column operator ANY (subquery)
WHERE column operator ALL (subquery)

COMMON OPERATORS:
- = ANY (equivalent to IN)
- != ANY (not equivalent to NOT IN)
- > ANY (greater than any value)
- < ALL (less than all values)
- >= ALL (greater than or equal to all values)
*/

-- Example 1: ANY operator - Find customers who have orders with specific amounts
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City
FROM Customer c
WHERE c.ID = ANY (
    SELECT CustomerID 
    FROM [Order] 
    WHERE TotalAmount > 1500
)
ORDER BY c.FirstName;

-- Example 2: ANY with IN - Find customers from specific cities (equivalent to IN)
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City
FROM Customer c
WHERE c.City = ANY ('Baku', 'Ganja', 'Shaki')
ORDER BY c.City, c.FirstName;

-- Example 3: ALL operator - Find products more expensive than all products in a category
SELECT 
    p.ProductName,
    p.Category,
    p.Price
FROM Product p
WHERE p.Price > ALL (
    SELECT Price 
    FROM Product 
    WHERE Category = 'Footwear'
)
ORDER BY p.Price;

-- Example 4: ALL with comparison - Find customers whose all orders are above average
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email
FROM Customer c
WHERE c.ID = ALL (
    SELECT CustomerID 
    FROM [Order] o1
    WHERE o1.CustomerID = c.ID
    AND o1.TotalAmount > (
        SELECT AVG(TotalAmount) 
        FROM [Order] o2
    )
)
ORDER BY c.FirstName;

-- =====================================================
-- PART 4: UNDERSTANDING CASE EXPRESSIONS
-- =====================================================

/*
WHAT IS CASE?
- CASE is a conditional expression that allows you to perform conditional logic in SQL
- It's similar to if-else statements in programming languages
- CASE can be used in SELECT, WHERE, ORDER BY, and other clauses
- There are two types: Simple CASE and Searched CASE

SYNTAX:
-- Simple CASE
CASE column
    WHEN value1 THEN result1
    WHEN value2 THEN result2
    ELSE default_result
END

-- Searched CASE
CASE 
    WHEN condition1 THEN result1
    WHEN condition2 THEN result2
    ELSE default_result
END
*/

-- Example 1: Simple CASE - Categorize products by price range
SELECT 
    ProductName,
    Price,
    Category,
    CASE 
        WHEN Price < 500 THEN 'Budget'
        WHEN Price BETWEEN 500 AND 1500 THEN 'Mid-Range'
        WHEN Price > 1500 THEN 'Premium'
        ELSE 'Unknown'
    END AS PriceCategory
FROM Product
ORDER BY Price;

-- Example 2: Searched CASE - Categorize customers by order count
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    COUNT(o.ID) AS OrderCount,
    CASE 
        WHEN COUNT(o.ID) = 0 THEN 'No Orders'
        WHEN COUNT(o.ID) = 1 THEN 'Single Order'
        WHEN COUNT(o.ID) BETWEEN 2 AND 3 THEN 'Regular Customer'
        WHEN COUNT(o.ID) > 3 THEN 'Frequent Customer'
        ELSE 'Unknown'
    END AS CustomerType
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName, c.Email, c.City
ORDER BY OrderCount DESC;

-- Example 3: CASE in ORDER BY - Sort products by category priority
SELECT 
    ProductName,
    Category,
    Price,
    Brand
FROM Product
ORDER BY 
    CASE Category
        WHEN 'Electronics' THEN 1
        WHEN 'Computers' THEN 2
        WHEN 'Footwear' THEN 3
        ELSE 4
    END,
    Price DESC;

-- Example 4: CASE with aggregation - Calculate order statistics by status
SELECT 
    CASE 
        WHEN o.Status IS NULL THEN 'No Orders'
        ELSE o.Status
    END AS OrderStatus,
    COUNT(*) AS OrderCount,
    SUM(ISNULL(o.TotalAmount, 0)) AS TotalAmount,
    AVG(ISNULL(o.TotalAmount, 0)) AS AverageAmount
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY o.Status
ORDER BY OrderCount DESC;

-- =====================================================
-- PART 5: UNDERSTANDING NULL FUNCTIONS
-- =====================================================

/*
WHAT ARE NULL FUNCTIONS?
- NULL functions help handle NULL values in SQL queries
- Common NULL functions: ISNULL, COALESCE, NULLIF, IS NULL, IS NOT NULL
- NULL represents missing or unknown data
- NULL functions help provide default values and handle missing data

COMMON NULL FUNCTIONS:
- ISNULL(expression, replacement) - Replace NULL with a value
- COALESCE(value1, value2, ...) - Return first non-NULL value
- NULLIF(expression1, expression2) - Return NULL if expressions are equal
- IS NULL - Check if value is NULL
- IS NOT NULL - Check if value is not NULL
*/

-- Example 1: ISNULL - Replace NULL values with default text
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    ISNULL(c.Phone, 'No Phone') AS Phone,
    ISNULL(c.Address, 'No Address') AS Address,
    c.City
FROM Customer c
ORDER BY c.FirstName;

-- Example 2: COALESCE - Use first non-NULL value from multiple columns
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COALESCE(c.Phone, c.Email, 'No Contact Info') AS ContactInfo,
    COALESCE(c.ShippingAddress, c.Address, 'No Address') AS FullAddress
FROM Customer c
ORDER BY c.FirstName;

-- Example 3: NULLIF - Convert specific values to NULL
SELECT 
    ProductName,
    Price,
    NULLIF(StockQuantity, 0) AS StockQuantity, -- Convert 0 to NULL
    Category
FROM Product
ORDER BY ProductName;

-- Example 4: IS NULL and IS NOT NULL - Filter based on NULL values
-- Find customers with missing phone numbers
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.Phone
FROM Customer c
WHERE c.Phone IS NULL
ORDER BY c.FirstName;

-- Find customers with complete contact information
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.Phone,
    c.Address
FROM Customer c
WHERE c.Phone IS NOT NULL 
AND c.Address IS NOT NULL
ORDER BY c.FirstName;

-- =====================================================
-- PART 6: COMBINED EXAMPLES
-- =====================================================

-- Example 1: EXISTS with CASE - Categorize customers based on order history
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    c.Email,
    c.City,
    CASE 
        WHEN EXISTS (SELECT 1 FROM [Order] o WHERE o.CustomerID = c.ID AND o.TotalAmount > 2000) 
        THEN 'High Value Customer'
        WHEN EXISTS (SELECT 1 FROM [Order] o WHERE o.CustomerID = c.ID) 
        THEN 'Regular Customer'
        ELSE 'No Orders'
    END AS CustomerCategory
FROM Customer c
ORDER BY CustomerCategory, c.FirstName;

-- Example 2: ANY with CASE and NULL handling - Product analysis
SELECT 
    p.ProductName,
    p.Category,
    p.Price,
    ISNULL(p.Brand, 'Unknown Brand') AS Brand,
    CASE 
        WHEN p.Price > ALL (SELECT Price FROM Product WHERE Category = 'Footwear') 
        THEN 'More Expensive Than All Footwear'
        WHEN p.Price > ANY (SELECT Price FROM Product WHERE Category = 'Electronics') 
        THEN 'More Expensive Than Some Electronics'
        ELSE 'Budget Product'
    END AS PriceComparison
FROM Product p
ORDER BY p.Price DESC;

-- Example 3: Complex CASE with COALESCE - Order summary with NULL handling
SELECT 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COALESCE(c.Phone, 'No Phone') AS Phone,
    COUNT(o.ID) AS OrderCount,
    CASE 
        WHEN COUNT(o.ID) = 0 THEN 'No Orders'
        WHEN COUNT(o.ID) = 1 THEN 'Single Order'
        WHEN COUNT(o.ID) > 1 AND AVG(o.TotalAmount) > 1000 THEN 'High Value Regular'
        WHEN COUNT(o.ID) > 1 THEN 'Regular Customer'
        ELSE 'Unknown'
    END AS CustomerType,
    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
GROUP BY c.ID, c.FirstName, c.LastName, c.Phone
ORDER BY TotalSpent DESC;

-- =====================================================
-- PART 7: PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: EXISTS Practice
-- Write a query to find all products that have been ordered at least once

-- Exercise 2: NOT EXISTS Practice
-- Write a query to find customers who have never placed an order

-- Exercise 3: ANY Practice
-- Write a query to find customers who have orders with amounts greater than 1000

-- Exercise 4: ALL Practice
-- Write a query to find products that are more expensive than all products in the 'Electronics' category

-- Exercise 5: CASE Practice
-- Write a query to categorize orders as 'Small' (< 1000), 'Medium' (1000-3000), or 'Large' (> 3000)

-- Exercise 6: NULL Functions Practice
-- Write a query to show customer information with 'Not Provided' for NULL phone numbers

-- Exercise 7: COALESCE Practice
-- Write a query to show the best contact method for each customer (phone, email, or 'No Contact')

-- Exercise 8: Complex CASE Practice
-- Write a query to categorize customers as 'VIP' (total spent > 3000), 'Gold' (1000-3000), 'Silver' (500-1000), or 'Bronze' (< 500)

-- Exercise 9: EXISTS with Conditions
-- Write a query to find customers who have placed orders in the last 30 days

-- Exercise 10: Combined Practice
-- Write a query to show product performance with categories: 'Best Seller' (ordered > 5 times), 'Popular' (2-5 times), 'Rare' (1 time), 'Never Ordered'

-- =====================================================
-- PART 8: ADVANCED EXERCISES
-- =====================================================

-- Advanced Exercise 1: Customer Segmentation
-- Create a comprehensive customer segmentation using CASE, EXISTS, and NULL functions

-- Advanced Exercise 2: Product Analysis
-- Analyze products using ANY, ALL, and CASE to determine market position

-- Advanced Exercise 3: Order Analysis
-- Create detailed order analysis with multiple CASE statements and NULL handling

-- Advanced Exercise 4: Inventory Management
-- Create inventory alerts using EXISTS and CASE statements

-- Advanced Exercise 5: Business Intelligence
-- Create a comprehensive business report combining all concepts

-- =====================================================
-- PART 9: REAL-WORLD SCENARIOS
-- =====================================================

-- Scenario 1: E-commerce Analytics
-- Create a query to identify high-value customers and their preferences

-- Scenario 2: Inventory Management
-- Create alerts for products that need restocking or are overstocked

-- Scenario 3: Customer Service
-- Identify customers who might need follow-up based on their order history

-- Scenario 4: Marketing Campaigns
-- Segment customers for targeted marketing campaigns

-- Scenario 5: Business Reporting
-- Create executive summary reports with key business metrics

-- =====================================================
-- PART 10: TIPS AND BEST PRACTICES
-- =====================================================

/*
EXISTS BEST PRACTICES:
1. Use EXISTS instead of COUNT(*) > 0 for better performance
2. EXISTS stops at the first match, making it efficient
3. Use correlated subqueries with EXISTS for complex conditions
4. Always test EXISTS with small datasets first

ANY/ALL BEST PRACTICES:
1. ANY is equivalent to IN for equality comparisons
2. ALL is useful for comparisons with all values in a set
3. Be careful with NULL values in ANY/ALL subqueries
4. Consider performance implications with large datasets

CASE BEST PRACTICES:
1. Always include an ELSE clause to handle unexpected values
2. Order WHEN conditions from most specific to most general
3. Use CASE in SELECT, WHERE, ORDER BY, and GROUP BY clauses
4. Consider using CASE for data transformation and categorization

NULL FUNCTIONS BEST PRACTICES:
1. Use ISNULL for simple NULL replacement
2. Use COALESCE for multiple value checking
3. Always handle NULL values explicitly
4. Consider the impact of NULL values on calculations
5. Use IS NULL and IS NOT NULL for filtering

COMMON MISTAKES TO AVOID:
1. Forgetting to handle NULL values in calculations
2. Using = instead of IS NULL for NULL comparisons
3. Not considering NULL values in ANY/ALL subqueries
4. Missing ELSE clauses in CASE statements
5. Using COUNT(*) instead of EXISTS for existence checks
*/

-- =====================================================
-- PART 11: VERIFICATION QUERIES
-- =====================================================

-- Verify our data relationships and NULL values
SELECT 
    'Customers with Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
WHERE EXISTS (SELECT 1 FROM [Order] o WHERE o.CustomerID = c.ID);

SELECT 
    'Customers without Orders' AS CheckType,
    COUNT(*) AS Count
FROM Customer c
WHERE NOT EXISTS (SELECT 1 FROM [Order] o WHERE o.CustomerID = c.ID);

SELECT 
    'Products with Orders' AS CheckType,
    COUNT(*) AS Count
FROM Product p
WHERE EXISTS (SELECT 1 FROM OrderDetail od WHERE od.ProductID = p.ID);

SELECT 
    'NULL Phone Numbers' AS CheckType,
    COUNT(*) AS Count
FROM Customer
WHERE Phone IS NULL;

SELECT 
    'NULL Addresses' AS CheckType,
    COUNT(*) AS Count
FROM Customer
WHERE Address IS NULL;

-- =====================================================
-- END OF WEEK 44 PRACTICE
-- =====================================================

/*
CONGRATULATIONS!
You have completed the Week 44 SQL practice covering:
- EXISTS operator for checking data existence
- ANY and ALL operators for comparisons
- CASE expressions for conditional logic
- NULL functions for handling missing data

These concepts are essential for:
- Data analysis and reporting
- Business intelligence queries
- Complex data filtering
- Data quality management
- Performance optimization

Keep practicing these concepts with real-world scenarios!
*/
