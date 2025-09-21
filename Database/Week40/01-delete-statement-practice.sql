-- =====================================================
-- SQL DELETE Statement Practice
-- Week40-Day01 - 27.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

Select *FROM Customer;
Select Count(1) FROm Customer;

Select * FROM Customer
Where FirstName='Test' 
AND Email='test.testov@email.com'

Delete FROM Customer Where ID=5

Delete FROM Customer 
Where FirstName='Test' 
AND Email='test.testov@email.com'

-- =====================================================
-- 1. DELETE STATEMENT BASICS
-- =====================================================

-- Basic DELETE syntax:
-- DELETE FROM TableName WHERE Condition;
-- 
-- IMPORTANT: Always use WHERE clause to avoid deleting all records!
-- DELETE FROM TableName; -- This would delete ALL records (dangerous!)
-- DELETE FROM TableName WHERE ID = 1; -- This deletes only specific record (safe)

-- =====================================================
-- 2. SAFE DELETE PRACTICES
-- =====================================================

-- ALWAYS check what you're about to delete first!
-- Use SELECT to preview the data before deleting
-- 
-- SAFE DELETE PATTERN:
-- 1. First, use SELECT to see what will be deleted
-- 2. Verify the results are correct
-- 3. Then run the DELETE statement
-- 4. This prevents accidental deletion of wrong data

-- Example 1: Check which customers are from Shaki before deleting
-- STEP 1: First, let's see which customers will be affected
SELECT ID, FirstName, LastName, Email, City 
FROM Customer 
WHERE City = 'Shaki';

-- STEP 2: After verifying the results, proceed with deletion
-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM Customer 
-- WHERE City = 'Shaki';

-- Example 2: Check which products have zero stock before deleting
-- STEP 1: First, let's see which products have zero stock
SELECT ID, ProductName, StockQuantity, Category 
FROM Product 
WHERE StockQuantity = 0;

-- STEP 2: After verifying the results, proceed with deletion
-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM Product 
-- WHERE StockQuantity = 0;

-- =====================================================
-- 3. DELETE WITH MULTIPLE CONDITIONS
-- =====================================================

-- Delete inactive customers from specific cities
-- Using AND operator to combine multiple conditions
-- This will delete customers who are BOTH inactive AND from Baku or Ganja
SELECT ID, FirstName, LastName, City, IsActive 
FROM Customer 
WHERE IsActive = 0 AND City IN ('Baku', 'Ganja');

-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM Customer 
-- WHERE IsActive = 0 AND City IN ('Baku', 'Ganja');

-- Delete expensive products with low stock
-- Using AND operator to combine price and stock conditions
-- This will delete products that are BOTH expensive (>2000) AND have low stock (<10)
SELECT ID, ProductName, Price, StockQuantity 
FROM Product 
WHERE Price > 2000 AND StockQuantity < 10;

-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM Product 
-- WHERE Price > 2000 AND StockQuantity < 10;

-- =====================================================
-- 4. DELETE WITH DATE CONDITIONS
-- =====================================================

-- Delete old orders (older than 30 days)
-- DATEADD(day, -30, GETDATE()) subtracts 30 days from current date
-- This helps clean up old data automatically

-- SELECT DATEADD(day, -30, GETDATE()) -- -> --'2025-06-27 13:21:53.693'

SELECT ID, OrderDate, Status, TotalAmount 
FROM [Order] 
WHERE OrderDate < DATEADD(day, -30, GETDATE());

-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM [Order] 
-- WHERE OrderDate < DATEADD(day, -30, GETDATE());

-- Delete products created more than 6 months ago
-- DATEADD(month, -6, GETDATE()) subtracts 6 months from current date
-- Useful for removing outdated product entries

SELECT DATEADD(month, -6, GETDATE())

SELECT ID, ProductName, CreatedDate 
FROM Product 
WHERE CreatedDate < DATEADD(month, -6, GETDATE());

-- (This is commented out for safety - uncomment when ready to delete)
-- DELETE FROM Product 
-- WHERE CreatedDate < DATEADD(month, -6, GETDATE());

-- =====================================================
-- 5. DELETE WITH SUBQUERIES
-- =====================================================

-- Delete order details for cancelled orders
-- This would normally use a subquery like:
-- DELETE FROM OrderDetail WHERE OrderID IN (SELECT ID FROM [Order] WHERE Status = 'Cancelled') -> (1,5)- SELECT ID FROM [Order] WHERE Status = 'Deliverd'
-- But since subqueries will be covered later, we'll just show the cancelled orders for now

-- First, find cancelled orders
SELECT * FROM [Order] WHERE Status = 'Delivered';
SELECT ID FROM [Order] WHERE Status = 'Delivered';

-- Then delete order details for those orders
-- This uses subqueries which will be covered later
-- For now, let's just show the cancelled orders
SELECT * FROM [Order] WHERE Status = 'Cancelled';

-- Delete customers who have no orders
-- This would normally use a subquery like:
-- DELETE FROM Customer WHERE ID NOT IN (SELECT DISTINCT CustomerID FROM [Order])
-- But since subqueries will be covered later, we'll just show customers with orders for now

-- First, find customers with orders
SELECT DISTINCT CustomerID FROM [Order];

-- Then delete customers who are not in that list
-- This uses subqueries which will be covered later
-- For now, let's just show customers with orders
SELECT DISTINCT CustomerID FROM [Order];

-- =====================================================
-- 6. CASCADE DELETE (Understanding Relationships)
-- =====================================================

-- When you delete a customer, you might want to delete their orders too
-- But first, check the relationships
-- 
-- IMPORTANT: When deleting related data, you must delete in the correct order:
-- 1. Delete child records first (OrderDetail)
-- 2. Then delete parent records (Order)
-- 3. Finally delete the main record (Customer)
-- This prevents foreign key constraint violations

-- Check how many orders each customer has
-- This is a more advanced query using GROUP BY (will be covered later)
-- For now, let's just count total orders per customer
-- This helps us understand which customers have the most orders
SELECT 
    CustomerID,
    COUNT(*) AS OrderCount
FROM [Order]
GROUP BY CustomerID
ORDER BY OrderCount DESC;

-- Delete a specific customer and their orders
-- This demonstrates the correct order for deleting related data
-- (This is commented out for safety - uncomment when ready to delete)

-- First, delete order details (child records)
-- DELETE FROM OrderDetail 
-- WHERE OrderID IN (
--     SELECT ID FROM [Order] WHERE CustomerID = 1
-- );

-- Then delete orders (parent records)
-- DELETE FROM [Order] 
-- WHERE CustomerID = 1;

-- Finally delete the customer (main record)
-- DELETE FROM Customer 
-- WHERE ID = 1;

-- =====================================================
-- 7. PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: Delete all products in 'Footwear' category
-- TASK: First, check which products are in the 'Footwear' category
-- Then, if the results look correct, delete them

-- SOLUTION:
-- Step 1: Check which products are in 'Footwear' category
SELECT * FROM Product WHERE Category = 'Footwear';

-- Step 2: If the results look correct, delete them
-- DELETE FROM Product WHERE Category = 'Footwear';

-- Exercise 2: Delete customers who registered more than 1 year ago
-- TASK: First, check which customers registered more than 1 year ago
-- Then, if the results look correct, delete them
-- HINT: Use DATEADD(year, -1, GETDATE()) to get date 1 year ago

-- SOLUTION:
-- Step 1: Check which customers registered more than 1 year ago
SELECT * FROM Customer WHERE RegistrationDate < DATEADD(year, -1, GETDATE());

-- Step 2: If the results look correct, delete them
-- DELETE FROM Customer WHERE RegistrationDate < DATEADD(year, -1, GETDATE());

-- Exercise 3: Delete order details with zero quantity
-- TASK: First, check which order details have zero quantity
-- Then, if the results look correct, delete them
-- HINT: This helps clean up invalid order entries

-- SOLUTION:
-- Step 1: Check which order details have zero quantity
SELECT * FROM OrderDetail WHERE Quantity = 0;

-- Step 2: If the results look correct, delete them
-- DELETE FROM OrderDetail WHERE Quantity = 0;

-- Exercise 4: Delete products with price less than 100
-- TASK: First, check which products have price less than 100
-- Then, if the results look correct, delete them
-- HINT: This helps remove very cheap or invalid products

-- SOLUTION:
-- Step 1: Check which products have price less than 100
SELECT * FROM Product WHERE Price < 100;

-- Step 2: If the results look correct, delete them
-- DELETE FROM Product WHERE Price < 100;

-- Exercise 5: Delete orders with status 'Pending' and amount less than 500
-- TASK: First, check which orders are pending and have low amounts
-- Then, if the results look correct, delete them
-- HINT: This helps clean up small pending orders that might be abandoned

-- SOLUTION:
-- Step 1: Check which orders are pending and have low amounts
SELECT * FROM [Order] WHERE Status = 'Pending' AND TotalAmount < 500;

-- Step 2: If the results look correct, delete them
-- DELETE FROM [Order] WHERE Status = 'Pending' AND TotalAmount < 500;

-- =====================================================
-- 7.1 ADDITIONAL PRACTICE EXERCISES
-- =====================================================

-- Exercise 6: Delete inactive customers from specific cities
-- TASK: Delete customers who are inactive AND from 'Baku' or 'Ganja'
-- SOLUTION:
-- Step 1: Check which customers are inactive and from specified cities
SELECT ID, FirstName, LastName, City, IsActive 
FROM Customer 
WHERE IsActive = 0 AND City IN ('Baku', 'Ganja');

-- Step 2: If the results look correct, delete them
-- DELETE FROM Customer 
-- WHERE IsActive = 0 AND City IN ('Baku', 'Ganja');

-- Exercise 7: Delete products with zero stock and high price
-- TASK: Delete products that have no stock AND price greater than 1000
-- SOLUTION:
-- Step 1: Check which products have zero stock and high price
SELECT ID, ProductName, Price, StockQuantity 
FROM Product 
WHERE StockQuantity = 0 AND Price > 1000;

-- Step 2: If the results look correct, delete them
-- DELETE FROM Product 
-- WHERE StockQuantity = 0 AND Price > 1000;

-- Exercise 8: Delete old cancelled orders
-- TASK: Delete orders that are cancelled AND older than 6 months
-- SOLUTION:
-- Step 1: Check which orders are cancelled and older than 6 months
SELECT ID, OrderDate, Status, TotalAmount 
FROM [Order] 
WHERE Status = 'Cancelled' AND OrderDate < DATEADD(month, -6, GETDATE());

-- Step 2: If the results look correct, delete them
-- DELETE FROM [Order] 
-- WHERE Status = 'Cancelled' AND OrderDate < DATEADD(month, -6, GETDATE());

-- Exercise 9: Delete order details for specific product
-- TASK: Delete order details for products with ID 5
-- SOLUTION:
-- Step 1: Check which order details are for product ID 5
SELECT * FROM OrderDetail WHERE ProductID = 5;

-- Step 2: If the results look correct, delete them
-- DELETE FROM OrderDetail WHERE ProductID = 5;

-- Exercise 10: Delete customers with no orders (using subquery)
-- TASK: Delete customers who have never placed an order
-- SOLUTION:
-- Step 1: Check which customers have no orders
SELECT c.ID, c.FirstName, c.LastName, c.Email
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
WHERE o.CustomerID IS NULL;

-- Step 2: If the results look correct, delete them
-- DELETE FROM Customer 
-- WHERE ID NOT IN (SELECT DISTINCT CustomerID FROM [Order] WHERE CustomerID IS NOT NULL);

-- =====================================================
-- 8. VERIFICATION QUERIES
-- =====================================================

-- After performing DELETE operations, it's good practice to verify the results
-- These queries help you confirm that the deletions worked as expected

-- Check remaining customers
SELECT COUNT(*) AS CustomerCount FROM Customer;

-- Check remaining products
SELECT COUNT(*) AS ProductCount FROM Product;

-- Check remaining orders
SELECT COUNT(*) AS OrderCount FROM [Order];

-- Check remaining order details
SELECT COUNT(*) AS OrderDetailCount FROM OrderDetail;

-- =====================================================
-- 9. IMPORTANT SAFETY TIPS
-- =====================================================
/*
SAFETY TIPS FOR DELETE OPERATIONS:

1. ALWAYS use WHERE clause (unless you really want to delete everything)
2. ALWAYS test with SELECT first to see what will be deleted
3. Use specific conditions in WHERE clause to avoid accidental deletions
4. Consider using transactions for important deletions (covered in advanced topics)
5. Backup your data before major deletions
6. Be aware of foreign key constraints - delete child records first
7. Use LIMIT or TOP to delete in batches for large datasets
8. Double-check your WHERE conditions before executing DELETE

COMMON MISTAKES:
- DELETE FROM TableName; (deletes ALL rows - very dangerous!)
- Forgetting to check foreign key relationships
- Not testing the WHERE condition first with SELECT
- Deleting without backup
- Using vague WHERE conditions that might delete too much data
*/

-- =====================================================
-- 9.1 ADVANCED DELETE SCENARIOS WITH SOLUTIONS
-- =====================================================

-- Advanced Exercise 1: Cascade Delete Pattern
-- TASK: Delete a customer and all their related data in correct order
-- SOLUTION:
-- Step 1: Check customer and their orders
SELECT c.ID, c.FirstName, c.LastName, COUNT(o.ID) AS OrderCount
FROM Customer c
LEFT JOIN [Order] o ON c.ID = o.CustomerID
WHERE c.ID = 1
GROUP BY c.ID, c.FirstName, c.LastName;

-- Step 2: Check order details for this customer
SELECT od.*
FROM OrderDetail od
INNER JOIN [Order] o ON od.OrderID = o.ID
WHERE o.CustomerID = 1;

-- Step 3: Delete in correct order (commented for safety)
-- DELETE FROM OrderDetail WHERE OrderID IN (SELECT ID FROM [Order] WHERE CustomerID = 1);
-- DELETE FROM [Order] WHERE CustomerID = 1;
-- DELETE FROM Customer WHERE ID = 1;

-- Advanced Exercise 2: Batch Delete with TOP
-- TASK: Delete oldest 5 orders to avoid performance issues
-- SOLUTION:
-- Step 1: Check the 5 oldest orders
SELECT TOP 5 ID, OrderDate, Status, TotalAmount
FROM [Order]
ORDER BY OrderDate ASC;

-- Step 2: Delete them (commented for safety)
-- DELETE FROM [Order] 
-- WHERE ID IN (
--     SELECT TOP 5 ID FROM [Order] ORDER BY OrderDate ASC
-- );

-- Advanced Exercise 3: Conditional Delete with EXISTS
-- TASK: Delete products that have never been ordered
-- SOLUTION:
-- Step 1: Check products that have never been ordered
SELECT p.ID, p.ProductName, p.Price
FROM Product p
WHERE NOT EXISTS (
    SELECT 1 FROM OrderDetail od WHERE od.ProductID = p.ID
);

-- Step 2: Delete them (commented for safety)
-- DELETE FROM Product 
-- WHERE NOT EXISTS (
--     SELECT 1 FROM OrderDetail od WHERE od.ProductID = Product.ID
-- );

-- Advanced Exercise 4: Delete with Date Range
-- TASK: Delete all data from a specific date range
-- SOLUTION:
-- Step 1: Check orders in date range
SELECT ID, OrderDate, Status, TotalAmount
FROM [Order]
WHERE OrderDate BETWEEN '2024-01-01' AND '2024-01-31';

-- Step 2: Delete order details first, then orders (commented for safety)
-- DELETE FROM OrderDetail 
-- WHERE OrderID IN (
--     SELECT ID FROM [Order] 
--     WHERE OrderDate BETWEEN '2024-01-01' AND '2024-01-31'
-- );
-- DELETE FROM [Order] 
-- WHERE OrderDate BETWEEN '2024-01-01' AND '2024-01-31';

-- =====================================================
-- 10. SAFE DELETE PATTERN (Without Transactions)
-- =====================================================

-- Safe deletion pattern without transactions
-- This is the recommended approach for beginners
-- 
-- Step 1: Always check what you're about to delete
-- This helps you verify the WHERE condition is correct
SELECT COUNT(*) AS RecordsToDelete 
FROM Customer 
WHERE City = 'TestCity';

-- Step 2: If the count looks correct, proceed with deletion
-- Uncomment the line below only after verifying the count
-- DELETE FROM Customer WHERE City = 'TestCity';

-- Step 3: Check the result after deletion
-- This confirms the deletion worked as expected
-- SELECT COUNT(*) AS RemainingCustomers FROM Customer;

-- Note: Transactions will be covered in advanced SQL topics
-- Transactions provide additional safety but are more complex

-- =====================================================
-- 11. COMPREHENSIVE SOLUTIONS SUMMARY
-- =====================================================

/*
SOLUTIONS SUMMARY:

Basic DELETE Patterns:
1. Simple DELETE: DELETE FROM Table WHERE condition
2. Multiple conditions: DELETE FROM Table WHERE condition1 AND condition2
3. Date-based DELETE: DELETE FROM Table WHERE date_column < DATEADD(unit, -value, GETDATE())
4. IN clause DELETE: DELETE FROM Table WHERE column IN (value1, value2, value3)

Advanced DELETE Patterns:
1. Cascade DELETE: Delete child records first, then parent records
2. Batch DELETE: Use TOP to limit records deleted at once
3. EXISTS/NOT EXISTS: Delete based on existence in other tables
4. Subquery DELETE: Use subqueries to determine what to delete

Safety Best Practices:
1. Always use SELECT first to preview what will be deleted
2. Use specific WHERE conditions to avoid accidental deletions
3. Consider foreign key relationships when deleting
4. Use batch processing for large deletions
5. Verify results after deletion

Common DELETE Scenarios:
- Clean up old/invalid data
- Remove test data
- Archive completed records
- Maintain data integrity
- Performance optimization
*/

-- =====================================================
-- END OF DELETE STATEMENT PRACTICE
-- ===================================================== 