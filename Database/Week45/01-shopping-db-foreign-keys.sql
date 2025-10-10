-- =====================================================
-- Shopping Database: FOREIGN KEY Constraints Practice
-- Week45-Day01 - 28.09.2025
-- Course: CSharp04 .NET Development
-- =====================================================

/*
FOREIGN KEY CONSTRAINTS OVERVIEW:
-------------------------------
A FOREIGN KEY is a column or combination of columns that creates a link between data in two tables.
It establishes a relationship between tables that enforces referential integrity.

Key Benefits:
1. Data Integrity - Ensures data consistency across related tables
2. Relationship Enforcement - Prevents invalid data relationships
3. Cascading Actions - Automates related data maintenance
4. Business Rules - Implements business logic at database level

Types of Relationships:
1. One-to-Many (1:N) - Most common, e.g., Customer to Orders
2. Many-to-Many (M:N) - Requires junction table, e.g., Products to Suppliers
3. One-to-One (1:1) - Less common, e.g., User to UserProfile
4. Self-Referencing - Table references itself, e.g., Employee Manager
*/

USE ShoppingDB;
GO

-- =====================================================
-- PART 1: Adding FOREIGN KEYs to Existing Tables
-- =====================================================

/*
EXISTING TABLE STRUCTURE AND RELATIONSHIPS:
----------------------------------------
Our database has four main tables with the following relationships:

1. Customer (1) -----> (Many) Order
   - One customer can have multiple orders
   - Each order must belong to exactly one customer
   - Relationship enforced through CustomerID in Order table

2. Order (1) -----> (Many) OrderDetail
   - One order can have multiple order details
   - Each detail must belong to exactly one order
   - Relationship enforced through OrderID in OrderDetail table

3. Product (1) -----> (Many) OrderDetail
   - One product can be in multiple order details
   - Each detail must reference exactly one product
   - Relationship enforced through ProductID in OrderDetail table

IMPORTANT CONSIDERATIONS:
-----------------------
1. Existing Data: Must be valid before adding constraints
2. Performance: Adding FKs may impact INSERT/UPDATE operations
3. Maintenance: Consider impact on database maintenance tasks
4. Cascading Actions: Choose appropriate ON DELETE/UPDATE actions
*/

-- First, check and remove existing FOREIGN KEYs if they exist
-- This ensures script can be safely re-run
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Order_Customer')
    ALTER TABLE [Order] DROP CONSTRAINT FK_Order_Customer;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_OrderDetail_Order')
    ALTER TABLE OrderDetail DROP CONSTRAINT FK_OrderDetail_Order;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_OrderDetail_Product')
    ALTER TABLE OrderDetail DROP CONSTRAINT FK_OrderDetail_Product;

/*
FOREIGN KEY: FK_Order_Customer
----------------------------
Purpose:
- Links orders to their respective customers
- Ensures every order belongs to a valid customer
- Prevents orphaned orders

Behavior Settings:
1. ON DELETE NO ACTION
   - Prevents customer deletion if they have orders
   - Ensures customer history is preserved
   - Must delete orders first before deleting customer

2. ON UPDATE CASCADE
   - If customer ID changes, updates all related orders
   - Maintains referential integrity automatically
   - Useful for data maintenance operations
*/
ALTER TABLE [Order]
ADD CONSTRAINT FK_Order_Customer
FOREIGN KEY (CustomerID) REFERENCES Customer(ID)
ON DELETE NO ACTION  -- Prevent deletion of customer if they have orders
ON UPDATE CASCADE;   -- Update CustomerID in orders if Customer ID changes

/*
FOREIGN KEY: FK_OrderDetail_Order
------------------------------
Purpose:
- Links order details to their parent order
- Ensures each detail belongs to a valid order
- Maintains order integrity

Behavior Settings:
1. ON DELETE CASCADE
   - Automatically deletes details when order is deleted
   - Prevents orphaned order details
   - Simplifies order deletion process

2. ON UPDATE CASCADE
   - Updates order details if order ID changes
   - Maintains data consistency
   - Supports database maintenance operations
*/
ALTER TABLE OrderDetail
ADD CONSTRAINT FK_OrderDetail_Order
FOREIGN KEY (OrderID) REFERENCES [Order](ID)
ON DELETE CASCADE    -- Delete order details when order is deleted
ON UPDATE CASCADE;   -- Update OrderID in details if Order ID changes

/*
FOREIGN KEY: FK_OrderDetail_Product
--------------------------------
Purpose:
- Links order details to products
- Ensures only valid products can be ordered
- Maintains product integrity

Behavior Settings:
1. ON DELETE NO ACTION
   - Prevents deletion of products that are in orders
   - Preserves order history
   - Requires manual handling of product discontinuation

2. ON UPDATE CASCADE
   - Updates order details if product ID changes
   - Maintains referential integrity
   - Supports product data maintenance
*/
ALTER TABLE OrderDetail
ADD CONSTRAINT FK_OrderDetail_Product
FOREIGN KEY (ProductID) REFERENCES Product(ID)
ON DELETE NO ACTION  -- Prevent deletion of products that are in orders
ON UPDATE CASCADE;   -- Update ProductID in details if Product ID changes

-- =====================================================
-- PART 2: Creating New Table with FOREIGN KEYs
-- =====================================================

/*
CATEGORY TABLE DESIGN:
--------------------
Purpose:
- Organizes products into hierarchical categories
- Enables product classification and filtering
- Supports multi-level category structure

Key Features:
1. Self-Referencing FOREIGN KEY
   - Allows categories to have subcategories
   - Creates hierarchical structure
   - Flexible category depth

2. Soft Delete Support
   - IsActive flag for logical deletion
   - Preserves category hierarchy
   - Maintains historical data

3. Audit Trail
   - CreatedDate for tracking
   - Supports data analysis
   - Helps in troubleshooting
*/

-- First, check and drop if table exists
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Category')
    DROP TABLE Category;

-- Create Category table with self-referencing FOREIGN KEY
CREATE TABLE Category (
    ID INT IDENTITY(1,1),        -- Auto-incrementing unique ID
    Name NVARCHAR(50) NOT NULL,  -- Category name
    Description NVARCHAR(200),   -- Category description
    ParentCategoryID INT,        -- Parent category ID (self-referencing)
    IsActive BIT DEFAULT 1,      -- Is category active?
    CreatedDate DATETIME DEFAULT GETDATE(),  -- Creation date
    
    -- Define Primary Key
    CONSTRAINT PK_Category PRIMARY KEY (ID),
    
    /*
    SELF-REFERENCING FOREIGN KEY:
    ---------------------------
    Purpose:
    - Creates hierarchical category structure
    - Allows unlimited category levels
    - Maintains referential integrity

    Behavior:
    1. ON DELETE NO ACTION
       - Prevents deletion of parent categories
       - Forces explicit handling of subcategories
       - Maintains data integrity

    2. ON UPDATE CASCADE
       - Automatically updates child references
       - Maintains consistency during reorganization
       - Simplifies category management
    */
    CONSTRAINT FK_Category_ParentCategory 
    FOREIGN KEY (ParentCategoryID) REFERENCES Category(ID)
    ON DELETE NO ACTION  -- Prevent deletion of parent categories
    ON UPDATE CASCADE    -- Update ParentCategoryID if parent's ID changes
);

/*
ADDING CATEGORY SUPPORT TO PRODUCTS:
---------------------------------
Purpose:
- Links products to categories
- Enables product organization
- Supports product filtering and reporting

Implementation Steps:
1. Add CategoryID column
2. Create FOREIGN KEY constraint
3. Handle NULL categories
4. Set appropriate cascading rules
*/

-- Add CategoryID to Product table
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Product') AND name = 'CategoryID')
BEGIN
    -- Add the column
    ALTER TABLE Product
    ADD CategoryID INT;
    
    -- Add FOREIGN KEY constraint with specific behavior
    ALTER TABLE Product
    ADD CONSTRAINT FK_Product_Category
    FOREIGN KEY (CategoryID) REFERENCES Category(ID)
    ON DELETE SET NULL  -- Set product's category to NULL if category is deleted
    ON UPDATE CASCADE;  -- Update CategoryID in products if Category ID changes
END

-- =====================================================
-- PART 3: Sample Data and Testing Relationships
-- =====================================================

/*
SAMPLE DATA STRATEGY:
-------------------
Purpose:
- Demonstrates category hierarchy
- Tests FOREIGN KEY constraints
- Validates cascading behaviors

Structure:
1. Main Categories (Electronics, Clothing)
2. Subcategories (2 levels deep)
3. Product Categorization
*/

-- Insert sample categories with hierarchy
INSERT INTO Category (Name, Description, ParentCategoryID) VALUES
('Electronics', 'Electronic devices and accessories', NULL),
('Computers', 'Desktop and laptop computers', 1),        -- Subcategory of Electronics
('Phones', 'Mobile phones and accessories', 1),          -- Subcategory of Electronics
('Clothing', 'Apparel and fashion items', NULL),
('Men''s Clothing', 'Clothing for men', 4),             -- Subcategory of Clothing
('Women''s Clothing', 'Clothing for women', 4);         -- Subcategory of Clothing

-- Categorize existing products
UPDATE Product 
SET CategoryID = 3  -- Phones category
WHERE ProductName LIKE '%Phone%' OR ProductName LIKE '%Mobile%';

UPDATE Product 
SET CategoryID = 2  -- Computers category
WHERE ProductName LIKE '%Laptop%' OR ProductName LIKE '%Computer%';

[... Rest of the file remains the same ...]