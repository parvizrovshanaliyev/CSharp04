-- =====================================================
-- SQL INSERT and UPDATE Practice
-- Week39-Day01 - 19.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- 1. INSERT COMMANDS PRACTICE
-- =====================================================

-- Insert new customers
-- This command adds new customers to the Customer table
INSERT INTO Customer (FirstName, LastName, Email, Phone, Address, City) VALUES
('Nigar', 'Hasanova', 'nigar.hasanova@email.com', '+994501234568', 'Baku Street 456', 'Baku'),
('Samir', 'Rzayev', 'samir.rzayev@email.com', '+994507654322', 'Ganja Road 89', 'Ganja'),
('Aynur', 'Mammadli', 'aynur.mammadli@email.com', '+994551234568', 'Shaki Avenue 12', 'Shaki');

-- Insert new products
-- This command adds new products to the Product table
INSERT INTO Product (ProductName, Description, Price, StockQuantity, Category, Brand) VALUES
('iPad Pro 12.9', 'Professional tablet for creative work', 2499.99, 15, 'Electronics', 'Apple'),
('Samsung Galaxy Tab S9', 'Android tablet for productivity', 1299.99, 25, 'Electronics', 'Samsung'),
('Microsoft Surface Pro', '2-in-1 laptop and tablet', 1899.99, 10, 'Computers', 'Microsoft'),
('Logitech MX Master 3', 'Premium wireless mouse', 99.99, 50, 'Electronics', 'Logitech'),
('Apple Watch Series 9', 'Smartwatch with health features', 799.99, 30, 'Electronics', 'Apple');

-- Insert new orders
-- This command adds new orders to the Order table
INSERT INTO [Order] (CustomerID, TotalAmount, Status, ShippingAddress, ShippingCity) VALUES
(6, 2599.98, 'Pending', 'Baku Street 456', 'Baku'),
(7, 1299.99, 'Processing', 'Ganja Road 89', 'Ganja'),
(8, 1899.99, 'Shipped', 'Shaki Avenue 12', 'Shaki');

-- Insert new order details
-- This command adds new order details to the OrderDetail table
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(6, 9, 1, 2499.99, 0),    -- iPad Pro 12.9
(6, 12, 1, 99.99, 0),     -- Logitech MX Master 3
(7, 10, 1, 1299.99, 0),   -- Samsung Galaxy Tab S9
(8, 11, 1, 1899.99, 0);   -- Microsoft Surface Pro

-- =====================================================
-- 2. UPDATE COMMANDS PRACTICE
-- =====================================================

-- Update customer information
-- This command changes customer phone number
UPDATE Customer 
SET Phone = '+994501234569'
WHERE Email = 'ahmad.aliyev@email.com';

-- Update product price
-- This command increases product price by 10%
UPDATE Product 
SET Price = Price * 1.10
WHERE ProductName = 'iPhone 15 Pro';

-- Update order status
-- This command changes order status from 'Pending' to 'Processing'
UPDATE [Order] 
SET Status = 'Processing'
WHERE Status = 'Pending' AND OrderDate < GETDATE();

-- Update product stock
-- This command decreases stock quantity when product is ordered
UPDATE Product 
SET StockQuantity = StockQuantity - 1
WHERE ProductName = 'iPad Pro 12.9';

-- Update customer address
-- This command changes customer address
UPDATE Customer 
SET Address = 'New Address 789', City = 'Baku'
WHERE FirstName = 'Leyla' AND LastName = 'Mammadova';

-- =====================================================
-- 3. PRACTICE EXERCISES
-- =====================================================

-- Exercise 1: Insert a new customer
-- Add a new customer with your own information
/*
INSERT INTO Customer (FirstName, LastName, Email, Phone, Address, City) VALUES
('YourName', 'YourLastName', 'your.email@example.com', '+994501234570', 'Your Address', 'Your City');
*/

-- Exercise 2: Insert a new product
-- Add a new product to the database
/*
INSERT INTO Product (ProductName, Description, Price, StockQuantity, Category, Brand) VALUES
('Your Product', 'Your product description', 299.99, 25, 'Your Category', 'Your Brand');
*/

-- Exercise 3: Update product price
-- Increase the price of all electronics by 5%
/*
UPDATE Product 
SET Price = Price * 1.05
WHERE Category = 'Electronics';
*/

-- Exercise 4: Update order status
-- Change all 'Processing' orders to 'Shipped'
/*
UPDATE [Order] 
SET Status = 'Shipped'
WHERE Status = 'Processing';
*/

-- Exercise 5: Update customer information
-- Change the email of a specific customer
/*
UPDATE Customer 
SET Email = 'new.email@example.com'
WHERE FirstName = 'Ahmad' AND LastName = 'Aliyev';
*/

-- =====================================================
-- 4. VERIFICATION QUERIES
-- =====================================================

-- Check if new customers were inserted
SELECT ID, FirstName, LastName, Email, City 
FROM Customer 
ORDER BY ID DESC;

-- Check if new products were inserted
SELECT ID, ProductName, Category, Price, StockQuantity 
FROM Product 
ORDER BY ID DESC;

-- Check if new orders were inserted
SELECT ID, CustomerID, OrderDate, Status, TotalAmount 
FROM [Order] 
ORDER BY ID DESC;

-- Check if new order details were inserted
SELECT ID, OrderID, ProductID, Quantity, UnitPrice, TotalPrice 
FROM OrderDetail 
ORDER BY ID DESC;

-- Check updated product prices
SELECT ProductName, Price 
FROM Product 
WHERE ProductName IN ('iPhone 15 Pro', 'iPad Pro 12.9');

-- Check updated order statuses
SELECT ID, Status, OrderDate 
FROM [Order] 
WHERE Status IN ('Processing', 'Shipped');

-- =====================================================
-- 5. BASIC CONCEPTS EXPLANATION
-- =====================================================
/*
INSERT COMMAND:
- Used to add new data to a table
- Syntax: INSERT INTO TableName (Column1, Column2, ...) VALUES (Value1, Value2, ...)
- You can insert multiple rows at once
- Always specify which columns you're inserting into

UPDATE COMMAND:
- Used to modify existing data in a table
- Syntax: UPDATE TableName SET Column1 = Value1, Column2 = Value2 WHERE Condition
- Always use WHERE clause to avoid updating all rows
- You can update multiple columns at once

IMPORTANT NOTES:
- Always backup your data before running UPDATE commands
- Test your WHERE conditions with SELECT first
- Be careful with UPDATE without WHERE clause (updates all rows)
- Use specific conditions in WHERE clause
*/

-- =====================================================
-- 6. COMMON MISTAKES TO AVOID
-- =====================================================
/*
COMMON MISTAKES:

1. Forgetting WHERE clause in UPDATE:
   UPDATE Product SET Price = 100;  -- Updates ALL products!

2. Wrong data types:
   INSERT INTO Product (Price) VALUES ('not a number');  -- Error!

3. Missing required columns:
   INSERT INTO Customer (FirstName) VALUES ('John');  -- Error if LastName is NOT NULL

4. Duplicate unique values:
   INSERT INTO Customer (Email) VALUES ('existing@email.com');  -- Error if email exists

5. Foreign key violations:
   INSERT INTO [Order] (CustomerID) VALUES (999);  -- Error if CustomerID 999 doesn't exist
*/

-- =====================================================
-- END OF SQL INSERT AND UPDATE PRACTICE
-- ===================================================== 