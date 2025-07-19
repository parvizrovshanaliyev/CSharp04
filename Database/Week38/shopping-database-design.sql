-- =====================================================
-- Shopping Database Design
-- Week38-Day01 - 06.07.2025
-- Course: CSharp04 .NET Development
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- Create the Shopping Database
CREATE DATABASE ShoppingDB;
GO

-- Use the Shopping Database
USE ShoppingDB;
GO

-- =====================================================
-- 1. CUSTOMER TABLE
-- =====================================================
-- This table stores customer information
CREATE TABLE Customer (
    ID INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing unique ID
    FirstName NVARCHAR(50) NOT NULL,           -- Customer first name
    LastName NVARCHAR(50) NOT NULL,            -- Customer last name
    Email NVARCHAR(100) UNIQUE NOT NULL,       -- Unique email address
    Phone NVARCHAR(20),                        -- Phone number
    Address NVARCHAR(200),                     -- Address
    City NVARCHAR(50),                         -- City
    Country NVARCHAR(50) DEFAULT 'Azerbaijan', -- Country (default: Azerbaijan)
    RegistrationDate DATETIME DEFAULT GETDATE(), -- Registration date
    IsActive BIT DEFAULT 1                      -- Is active? (1=yes, 0=no)
);

-- =====================================================
-- 2. PRODUCT TABLE
-- =====================================================
-- This table stores product information
CREATE TABLE Product (
    ID INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing unique ID
    ProductName NVARCHAR(100) NOT NULL,        -- Product name
    Description NVARCHAR(500),                 -- Product description
    Price DECIMAL(10,2) NOT NULL,              -- Price (10 digits, 2 decimals)
    StockQuantity INT NOT NULL DEFAULT 0,      -- Stock quantity
    Category NVARCHAR(50),                     -- Category (Electronics, Clothing, etc.)
    Brand NVARCHAR(50),                        -- Brand
    CreatedDate DATETIME DEFAULT GETDATE(),    -- Creation date
    IsActive BIT DEFAULT 1                     -- Is active?
);

-- =====================================================
-- 3. ORDER TABLE
-- =====================================================
-- This table stores order information
-- Each order belongs to a customer (connected via CustomerID)
CREATE TABLE [Order] (
    ID INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing unique ID
    CustomerID INT NOT NULL,                   -- Which customer's order?
    OrderDate DATETIME DEFAULT GETDATE(),      -- Order date
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0, -- Total amount
    Status NVARCHAR(20) DEFAULT 'Pending',     -- Order status
    ShippingAddress NVARCHAR(200),             -- Shipping address
    ShippingCity NVARCHAR(50),                 -- Shipping city
    ShippingCountry NVARCHAR(50),              -- Shipping country
    Notes NVARCHAR(500),                       -- Notes
    
    -- Foreign Key: Which customer does this order belong to?
    -- Connects to Customer table
    CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerID) 
        REFERENCES Customer(ID)
);

-- =====================================================
-- 4. ORDER DETAIL TABLE
-- =====================================================
-- This table stores details of each product in an order
-- An order can have multiple products
CREATE TABLE OrderDetail (
    ID INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing unique ID
    OrderID INT NOT NULL,                       -- Which order does this belong to?
    ProductID INT NOT NULL,                     -- Which product?
    Quantity INT NOT NULL,                      -- How many?
    UnitPrice DECIMAL(10,2) NOT NULL,          -- Unit price
    Discount DECIMAL(5,2) DEFAULT 0,           -- Discount percentage
    TotalPrice AS (Quantity * UnitPrice * (1 - Discount/100)), -- Total price (auto-calculated)
    
    -- Foreign Key: Which order does this detail belong to?
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderID) 
        REFERENCES [Order](ID),
    
    -- Foreign Key: Which product does this detail belong to?
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductID) 
        REFERENCES Product(ID)
);

-- =====================================================
-- 6. SAMPLE DATA INSERTION
-- =====================================================

-- Insert Sample Customers
INSERT INTO Customer (FirstName, LastName, Email, Phone, Address, City) VALUES
('Ahmad', 'Aliyev', 'ahmad.aliyev@email.com', '+994501234567', 'Nizami Street 123', 'Baku'),
('Leyla', 'Mammadova', 'leyla.mammadova@email.com', '+994507654321', 'Fountain Square 45', 'Baku'),
('Rashad', 'Huseynov', 'rashad.huseynov@email.com', '+994551234567', 'Ganja Avenue 78', 'Ganja'),
('Aysu', 'Karimova', 'aysu.karimova@email.com', '+994557654321', 'Shaki Street 90', 'Shaki'),
('Elvin', 'Safarov', 'elvin.safarov@email.com', '+994501112223', 'Sumgayit Road 12', 'Sumgayit');

-- Insert Sample Products
INSERT INTO Product (ProductName, Description, Price, StockQuantity, Category, Brand) VALUES
('iPhone 15 Pro', 'Latest Apple smartphone with advanced features', 2999.99, 50, 'Electronics', 'Apple'),
('Samsung Galaxy S24', 'Android flagship smartphone', 1899.99, 45, 'Electronics', 'Samsung'),
('MacBook Air M2', 'Lightweight laptop for professionals', 3999.99, 30, 'Computers', 'Apple'),
('Dell XPS 13', 'Premium Windows laptop', 2499.99, 25, 'Computers', 'Dell'),
('Nike Air Max', 'Comfortable running shoes', 299.99, 100, 'Footwear', 'Nike'),
('Adidas Ultraboost', 'Professional running shoes', 399.99, 80, 'Footwear', 'Adidas'),
('Sony WH-1000XM5', 'Noise-cancelling headphones', 599.99, 60, 'Electronics', 'Sony'),
('Canon EOS R6', 'Professional mirrorless camera', 3499.99, 20, 'Electronics', 'Canon');

-- Insert Sample Orders
INSERT INTO [Order] (CustomerID, TotalAmount, Status, ShippingAddress, ShippingCity) VALUES
(1, 3299.98, 'Delivered', 'Nizami Street 123', 'Baku'),
(2, 1899.99, 'Processing', 'Fountain Square 45', 'Baku'),
(3, 599.99, 'Shipped', 'Ganja Avenue 78', 'Ganja'),
(4, 3999.99, 'Pending', 'Shaki Street 90', 'Shaki'),
(5, 2499.99, 'Delivered', 'Sumgayit Road 12', 'Sumgayit');

-- Insert Sample Order Details
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(1, 1, 1, 2999.99, 0),    -- iPhone 15 Pro
(1, 7, 1, 299.99, 0),     -- Sony Headphones
(2, 2, 1, 1899.99, 0),    -- Samsung Galaxy S24
(3, 7, 1, 599.99, 0),     -- Sony Headphones
(4, 3, 1, 3999.99, 5),    -- MacBook Air M2 with 5% discount
(5, 4, 1, 2499.99, 0);    -- Dell XPS 13

-- =====================================================
-- 7. PRACTICE QUERIES
-- =====================================================

-- Query 1: Get all customers
-- This query shows all customers in the database
SELECT 
    ID,
    FirstName + ' ' + LastName AS FullName,  -- Combine first and last name
    Email,
    Phone,
    City,
    Country
FROM Customer
ORDER BY FirstName;                           -- Sort by first name

-- Query 2: Get all products
-- This query shows all products in the database
SELECT 
    ID,
    ProductName,
    Category,
    Price,
    StockQuantity
FROM Product
ORDER BY ProductName;                         -- Sort by product name

-- Query 3: Get all orders
-- This query shows all orders in the database
SELECT 
    ID,
    CustomerID,                               -- Which customer made this order
    OrderDate,
    Status,
    TotalAmount
FROM [Order]
ORDER BY OrderDate DESC;                      -- Sort by date descending

-- Query 4: Get all order details
-- This query shows all order details in the database
SELECT 
    ID,
    OrderID,                                  -- Which order this detail belongs to
    ProductID,                                -- Which product was ordered
    Quantity,
    UnitPrice,
    Discount,
    TotalPrice
FROM OrderDetail
ORDER BY OrderID;                             -- Sort by order ID

-- Query 5: Get products with low stock (less than 30 items)
-- This query shows products that need restocking
SELECT 
    ID,
    ProductName,
    Category,
    Price,
    StockQuantity
FROM Product
WHERE StockQuantity < 30                      -- Products with stock less than 30
ORDER BY StockQuantity ASC;                   -- Sort by stock quantity ascending

-- =====================================================
-- 8. TABLE RELATIONSHIPS
-- =====================================================
/*
TABLE RELATIONSHIPS:

1. Customer (1) -----> (Many) Order
   - One customer can have multiple orders
   - Each order belongs to exactly one customer
   - Connected via CustomerID (references Customer.ID)

2. Order (1) -----> (Many) OrderDetail
   - One order can have multiple products
   - Each order detail belongs to exactly one order
   - Connected via OrderID (references Order.ID)

3. Product (1) -----> (Many) OrderDetail
   - One product can be in multiple orders
   - Each order detail belongs to exactly one product
   - Connected via ProductID (references Product.ID)

BASIC CONCEPTS:
- Primary Key: Unique ID in each table
- Foreign Key: Field that references another table
- CONSTRAINT: Rules that maintain data integrity
*/

-- =====================================================
-- 9. CLEANUP (Optional - for testing)
-- =====================================================
/*
-- Remove the -- signs at the beginning of these lines to drop the database (use with caution!)
-- DROP DATABASE ShoppingDB;
*/

-- =====================================================
-- END OF SHOPPING DATABASE DESIGN
-- ===================================================== 