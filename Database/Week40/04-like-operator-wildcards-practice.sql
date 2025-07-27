-- =====================================================
-- SQL LIKE Operator and Wildcards Practice
-- Week40-Day01 - 27.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- 1. LIKE OPERATOR BASICS
-- =====================================================

-- LIKE operator is used for pattern matching
-- Syntax: WHERE column LIKE pattern

-- =====================================================
-- 2. WILDCARD CHARACTERS
-- =====================================================

-- % (Percent): Matches any sequence of characters (0 or more)
-- _ (Underscore): Matches exactly one character
-- [charlist]: Matches any single character in the list
-- [^charlist]: Matches any single character NOT in the list

-- =====================================================
-- 3. % WILDCARD EXAMPLES
-- =====================================================

-- Find customers whose first name starts with 'A'
SELECT 
    FirstName,
    LastName,
    Email,
    City
FROM Customer
WHERE FirstName LIKE 'A%'
ORDER BY FirstName;

-- Find customers whose last name ends with 'v'
SELECT 
    FirstName,
    LastName,
    Email,
    City
FROM Customer
WHERE LastName LIKE '%v'
ORDER BY LastName;

-- Find products containing 'phone' anywhere in the name
SELECT 
    ProductName,
    Price,
    Category,
    Brand
FROM Product
WHERE ProductName LIKE '%phone%'
ORDER BY ProductName;

-- Find customers with email from specific domain
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE Email LIKE '%@email.com'
ORDER BY Email;

-- =====================================================
-- 4. _ WILDCARD EXAMPLES
-- =====================================================

-- Find products with exactly 4 characters in brand name
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE Brand LIKE '____'
ORDER BY Brand;

-- Find customers with 5-letter first names
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '_____'
ORDER BY FirstName;

-- Find products where brand starts with 'A' and has exactly 5 characters
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE Brand LIKE 'A____'
ORDER BY Brand;

-- =====================================================
-- 5. COMBINING % AND _ WILDCARDS
-- =====================================================

-- Find products with 'i' as second letter and 'e' as fourth letter
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName LIKE '_i_e%'
ORDER BY ProductName;

-- Find customers with 'a' as third letter in first name
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '__a%'
ORDER BY FirstName;

-- Find products with 'o' as second to last letter
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName LIKE '%o_'
ORDER BY ProductName;

-- =====================================================
-- 6. CHARACTER LIST WILDCARDS [charlist]
-- =====================================================

-- Find customers with first name starting with A, B, or C
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '[ABC]%'
ORDER BY FirstName;

-- Find products with brand ending in 'e' or 'y'
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE Brand LIKE '%[ey]'
ORDER BY Brand;

-- Find customers with 'a' or 'e' as second letter in first name
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '_[ae]%'
ORDER BY FirstName;

-- =====================================================
-- 7. NEGATIVE CHARACTER LIST [^charlist]
-- =====================================================

-- Find customers with first name NOT starting with A, B, or C
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '[^ABC]%'
ORDER BY FirstName;

-- Find products with brand NOT ending in 'e' or 'y'
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE Brand LIKE '%[^ey]'
ORDER BY Brand;

-- =====================================================
-- 8. ESCAPING SPECIAL CHARACTERS
-- =====================================================

-- To search for literal % or _ characters, use ESCAPE clause
-- Find products with % in the name (if any)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName LIKE '%\%%' ESCAPE '\'
ORDER BY ProductName;

-- Find products with _ in the name (if any)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName LIKE '%\_%' ESCAPE '\'
ORDER BY ProductName;

-- =====================================================
-- 9. CASE SENSITIVITY
-- =====================================================

-- LIKE is case-insensitive in SQL Server by default
-- Find products containing 'phone' (case insensitive)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName LIKE '%phone%'
ORDER BY ProductName;

-- For case-sensitive search, use COLLATE
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE ProductName COLLATE Latin1_General_CS_AS LIKE '%Phone%'
ORDER BY ProductName;

-- =====================================================
-- 10. PRACTICAL EXAMPLES WITH SHOPPING DATABASE
-- =====================================================

-- Find all Apple products
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE Brand LIKE 'Apple'
ORDER BY Price DESC;

-- Find customers from cities starting with 'B'
SELECT 
    FirstName,
    LastName,
    City,
    Email
FROM Customer
WHERE City LIKE 'B%'
ORDER BY City, FirstName;

-- Find products with 'Pro' in the name
SELECT 
    ProductName,
    Price,
    Brand,
    Category
FROM Product
WHERE ProductName LIKE '%Pro%'
ORDER BY ProductName;

-- Find customers with phone numbers starting with '+99450'
SELECT 
    FirstName,
    LastName,
    Phone
FROM Customer
WHERE Phone LIKE '+99450%'
ORDER BY FirstName;

-- Find products in Electronics category with 'S' brands
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE Category = 'Electronics' AND Brand LIKE 'S%'
ORDER BY Brand, ProductName;

-- =====================================================
-- 11. COMPLEX PATTERN MATCHING
-- =====================================================

-- Find products with price pattern (e.g., 299.99, 1999.99)
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE CAST(Price AS VARCHAR) LIKE '%.99'
ORDER BY Price;

-- Find customers with email pattern (name.surname@domain.com)
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE Email LIKE '%.%@%.%'
ORDER BY Email;

-- Find products with specific naming pattern
SELECT 
    ProductName,
    Brand,
    Category
FROM Product
WHERE ProductName LIKE '% % %'  -- Contains at least 2 spaces
ORDER BY ProductName;

-- =====================================================
-- 12. PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: Find all products with 'Samsung' brand
/*
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE Brand LIKE 'Samsung'
ORDER BY ProductName;
*/

-- Exercise 2: Find customers with first name containing 'a'
/*
SELECT 
    FirstName,
    LastName,
    Email
FROM Customer
WHERE FirstName LIKE '%a%'
ORDER BY FirstName;
*/

-- Exercise 3: Find products with price ending in .99
/*
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE CAST(Price AS VARCHAR) LIKE '%.99'
ORDER BY Price;
*/

-- Exercise 4: Find customers from cities with 4 letters
/*
SELECT 
    FirstName,
    LastName,
    City
FROM Customer
WHERE City LIKE '____'
ORDER BY City;
*/

-- Exercise 5: Find products with 'Air' in the name
/*
SELECT 
    ProductName,
    Brand,
    Price
FROM Product
WHERE ProductName LIKE '%Air%'
ORDER BY ProductName;
*/

-- =====================================================
-- 13. PERFORMANCE CONSIDERATIONS
-- =====================================================

-- Using LIKE with leading wildcard can be slow
-- This query might be slow on large datasets:
-- WHERE ProductName LIKE '%phone%'

-- Better performance with leading character:
-- WHERE ProductName LIKE 'iPhone%'

-- Using indexes effectively
-- Create index on ProductName for better performance
-- CREATE INDEX IX_Product_ProductName ON Product(ProductName);

-- =====================================================
-- 14. ALTERNATIVES TO LIKE
-- =====================================================

-- Using CHARINDEX for more complex pattern matching
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE CHARINDEX('phone', ProductName) > 0
ORDER BY ProductName;

-- Using PATINDEX for pattern matching with wildcards
SELECT 
    ProductName,
    Price,
    Category
FROM Product
WHERE PATINDEX('%phone%', ProductName) > 0
ORDER BY ProductName;

-- =====================================================
-- 15. BEST PRACTICES
-- =====================================================
/*
BEST PRACTICES FOR LIKE OPERATOR:

1. Avoid leading wildcards when possible (%pattern vs pattern%)
2. Use appropriate indexes on searched columns
3. Consider using full-text search for complex text searches
4. Be aware of case sensitivity settings
5. Use ESCAPE clause for literal wildcard characters
6. Consider performance impact on large datasets

COMMON MISTAKES:
- Using LIKE when exact match is needed (=)
- Forgetting to escape special characters
- Not considering case sensitivity
- Using leading wildcards without indexes
*/

-- =====================================================
-- END OF LIKE OPERATOR AND WILDCARDS PRACTICE
-- ===================================================== 