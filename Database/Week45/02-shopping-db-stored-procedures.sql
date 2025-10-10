-- =====================================================
-- Shopping Database: Stored Procedures Practice
-- Week45-Day01 - 28.09.2025
-- Course: CSharp04 .NET Development
-- =====================================================

/*
STORED PROCEDURES OVERVIEW:
--------------------------
A stored procedure is a prepared SQL code that can be saved and reused.
Benefits:
1. Better Performance - Cached execution plans
2. Security - Control access to database objects
3. Data Integrity - Ensure consistent business logic
4. Network Traffic - Reduce data sent between application and database
5. Code Reusability - Write once, use many times

HOW TO ALTER EXISTING PROCEDURES:
--------------------------------
1. Using CREATE OR ALTER (SQL Server 2016+):
   - Simplest method
   - Automatically handles procedure existence
   - Example: CREATE OR ALTER PROCEDURE proc_name

2. Using DROP and CREATE:
   - Traditional method
   - Need to check existence first
   - Example:
     IF OBJECT_ID('proc_name', 'P') IS NOT NULL
         DROP PROCEDURE proc_name
     GO
     CREATE PROCEDURE proc_name

3. Using ALTER PROCEDURE:
   - Direct modification
   - Procedure must exist
   - Example: ALTER PROCEDURE proc_name

Best Practice: Use CREATE OR ALTER as it's safer and more concise
*/

USE ShoppingDB;
GO

-- =====================================================
-- PART 1: Basic Stored Procedures
-- =====================================================

/*
PROCEDURE: sp_GetCustomerOrders
PURPOSE: Retrieves all orders for a specific customer with detailed information
PARAMETERS: 
    @CustomerID INT - The ID of the customer to get orders for
RETURNS: Result set containing order details
USAGE: EXEC sp_GetCustomerOrders @CustomerID = 1

TRANSACTION MANAGEMENT:
----------------------
This procedure doesn't use transactions because:
1. It's a read-only operation (SELECT only)
2. No data modifications are performed
3. Doesn't require atomic operations
4. Uses default transaction isolation level (READ COMMITTED)
*/
CREATE OR ALTER PROCEDURE sp_GetCustomerOrders
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;  -- Prevents returning affected rows count, reduces network traffic
    
    SELECT 
        o.ID AS OrderID,
        o.OrderDate,
        o.Status,
        p.ProductName,
        od.Quantity,
        od.UnitPrice,
        od.Discount,
        od.TotalPrice,
        (od.Quantity * od.UnitPrice * (1 - od.Discount/100)) AS FinalPrice
    FROM [Order] o
    JOIN OrderDetail od ON o.ID = od.OrderID
    JOIN Product p ON od.ProductID = p.ID
    WHERE o.CustomerID = @CustomerID
    ORDER BY o.OrderDate DESC;
END;
GO

/*
PROCEDURE: sp_CreateOrder
PURPOSE: Creates a new order with multiple products
PARAMETERS:
    @CustomerID INT - Customer placing the order
    @ShippingAddress NVARCHAR(200) - Delivery address
    @ShippingCity NVARCHAR(50) - Delivery city
    @ProductTable - Table containing ProductID and Quantity for each item
FEATURES:
    - Transaction management
    - Error handling
    - Stock validation
    - Automatic price calculation

TRANSACTION MANAGEMENT:
----------------------
This procedure uses transactions because it performs multiple related operations:
1. Creates order header
2. Inserts order details
3. Updates product stock levels
4. Calculates and updates order total

Why Transaction is Critical Here:
1. Data Consistency: All operations must succeed or none
2. Stock Management: Prevent overselling
3. Financial Accuracy: Ensure order totals match details
4. Error Recovery: Automatic rollback on failure

Transaction Flow:
1. BEGIN TRANSACTION
   - Marks start of atomic operation
   - Creates save point
2. Multiple Operations
   - Each operation depends on others
   - Must all succeed together
3. COMMIT or ROLLBACK
   - COMMIT if all succeed
   - ROLLBACK if any fail
*/

-- First, create a user-defined table type for order items
IF NOT EXISTS (SELECT * FROM sys.types WHERE name = 'ProductOrderType')
CREATE TYPE ProductOrderType AS TABLE
(
    ProductID INT,
    Quantity INT
);
GO

CREATE OR ALTER PROCEDURE sp_CreateOrder
    @CustomerID INT,
    @ShippingAddress NVARCHAR(200),
    @ShippingCity NVARCHAR(50),
    @ProductTable AS ProductOrderType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    DECLARE @OrderID INT;
    
    /*
    Transaction Block:
    -----------------
    The following operations must be atomic:
    1. Validate customer and stock
    2. Create order header
    3. Insert order details
    4. Update product stock
    5. Calculate and update total amount
    
    Using TRY-CATCH ensures:
    - Error handling
    - Proper rollback
    - Clean error messages
    */
    BEGIN TRY
        BEGIN TRANSACTION;
            
            -- Validate customer exists
            IF NOT EXISTS (SELECT 1 FROM Customer WHERE ID = @CustomerID)
                THROW 50001, 'Customer does not exist.', 1;
                
            /*
            Stock Validation:
            ----------------
            - Check before processing
            - Prevents overselling
            - Maintains inventory accuracy
            */
            IF EXISTS (
                SELECT 1 
                FROM @ProductTable pt
                JOIN Product p ON pt.ProductID = p.ID
                WHERE pt.Quantity > p.StockQuantity
            )
            BEGIN
                SELECT @ErrorMessage = 'Insufficient stock for product: ' + p.ProductName
                FROM @ProductTable pt
                JOIN Product p ON pt.ProductID = p.ID
                WHERE pt.Quantity > p.StockQuantity;
                
                THROW 50002, @ErrorMessage, 1;
            END
            
            -- Create order header
            INSERT INTO [Order] (
                CustomerID, 
                ShippingAddress, 
                ShippingCity, 
                Status,
                OrderDate
            )
            VALUES (
                @CustomerID, 
                @ShippingAddress, 
                @ShippingCity,
                'Pending',
                GETDATE()
            );
            
            SET @OrderID = SCOPE_IDENTITY();
            
            /*
            Order Details and Pricing:
            ------------------------
            - Bulk insert for performance
            - Automatic discount calculation
            - Price from current product table
            */
            INSERT INTO OrderDetail (
                OrderID, 
                ProductID, 
                Quantity, 
                UnitPrice,
                Discount
            )
            SELECT 
                @OrderID,
                pt.ProductID,
                pt.Quantity,
                p.Price,
                CASE 
                    WHEN pt.Quantity >= 10 THEN 10  -- 10% discount for bulk orders
                    WHEN pt.Quantity >= 5 THEN 5    -- 5% discount for medium orders
                    ELSE 0 
                END
            FROM @ProductTable pt
            JOIN Product p ON pt.ProductID = p.ID;
            
            /*
            Stock Update:
            ------------
            - Atomic update with order
            - Maintains stock accuracy
            - Part of transaction
            */
            UPDATE p
            SET StockQuantity = p.StockQuantity - pt.Quantity
            FROM Product p
            JOIN @ProductTable pt ON p.ID = pt.ProductID;
            
            -- Calculate and update order total
            UPDATE [Order]
            SET TotalAmount = (
                SELECT SUM(TotalPrice)
                FROM OrderDetail
                WHERE OrderID = @OrderID
            )
            WHERE ID = @OrderID;
            
        COMMIT TRANSACTION;
        
        -- Return the created order details
        SELECT 
            o.ID AS OrderID,
            o.OrderDate,
            o.Status,
            o.TotalAmount,
            c.FirstName + ' ' + c.LastName AS CustomerName
        FROM [Order] o
        JOIN Customer c ON o.CustomerID = c.ID
        WHERE o.ID = @OrderID;
        
    END TRY
    BEGIN CATCH
        -- Rollback transaction if error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();
            
        -- Re-throw the error with additional information
        THROW 50000, @ErrorMessage, 1;
    END CATCH;
END;
GO

/*
PROCEDURE: sp_ManageProductStock
PURPOSE: Manages product stock levels with full audit trail
PARAMETERS:
    @ProductID INT - Product to update
    @Quantity INT - Amount to add/remove
    @Operation CHAR(1) - 'A' for Add, 'R' for Remove
    @SupplierID INT - Optional supplier ID for stock additions
FEATURES:
    - Stock validation
    - Transaction management
    - Audit logging
    - Supplier tracking
*/
-- First, create audit table for stock changes
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'StockAudit')
CREATE TABLE StockAudit (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    Operation CHAR(1),
    Quantity INT,
    OldStock INT,
    NewStock INT,
    SupplierID INT NULL,
    AuditDate DATETIME DEFAULT GETDATE(),
    UserName NVARCHAR(100) DEFAULT SYSTEM_USER
);
GO

CREATE OR ALTER PROCEDURE sp_ManageProductStock
    @ProductID INT,
    @Quantity INT,
    @Operation CHAR(1),
    @SupplierID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate parameters
    IF @Operation NOT IN ('A', 'R')
        THROW 50001, 'Invalid operation. Use ''A'' for Add or ''R'' for Remove.', 1;
        
    IF @Quantity <= 0
        THROW 50002, 'Quantity must be greater than zero.', 1;
        
    DECLARE @OldStock INT;
    DECLARE @NewStock INT;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Get current stock
        SELECT @OldStock = StockQuantity
        FROM Product WITH (UPDLOCK)  -- Lock row for update
        WHERE ID = @ProductID;
        
        IF @OldStock IS NULL
            THROW 50003, 'Product not found.', 1;
            
        -- Calculate new stock
        IF @Operation = 'A'
            SET @NewStock = @OldStock + @Quantity;
        ELSE
        BEGIN
            SET @NewStock = @OldStock - @Quantity;
            IF @NewStock < 0
                THROW 50004, 'Insufficient stock quantity.', 1;
        END
        
        -- Update product stock
        UPDATE Product
        SET StockQuantity = @NewStock
        WHERE ID = @ProductID;
        
        -- Record audit trail
        INSERT INTO StockAudit (
            ProductID,
            Operation,
            Quantity,
            OldStock,
            NewStock,
            SupplierID
        )
        VALUES (
            @ProductID,
            @Operation,
            @Quantity,
            @OldStock,
            @NewStock,
            @SupplierID
        );
        
        -- If adding stock from supplier, record it
        IF @Operation = 'A' AND @SupplierID IS NOT NULL
        BEGIN
            -- Ensure supplier exists
            IF NOT EXISTS (SELECT 1 FROM Supplier WHERE ID = @SupplierID)
                THROW 50005, 'Supplier not found.', 1;
                
            -- Update or insert supplier product relationship
            MERGE ProductSupplier AS target
            USING (SELECT @ProductID AS ProductID, @SupplierID AS SupplierID) AS source
            ON (target.ProductID = source.ProductID AND target.SupplierID = source.SupplierID)
            WHEN MATCHED THEN
                UPDATE SET SupplyDate = GETDATE()
            WHEN NOT MATCHED THEN
                INSERT (ProductID, SupplierID, SupplyDate)
                VALUES (@ProductID, @SupplierID, GETDATE());
        END
        
        COMMIT TRANSACTION;
        
        -- Return updated stock information
        SELECT 
            p.ProductName,
            p.StockQuantity AS CurrentStock,
            s.CompanyName AS LastSupplier,
            sa.AuditDate AS LastUpdate
        FROM Product p
        LEFT JOIN StockAudit sa ON p.ID = sa.ProductID
        LEFT JOIN Supplier s ON sa.SupplierID = s.ID
        WHERE p.ID = @ProductID;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        THROW;
    END CATCH;
END;
GO

-- =====================================================
-- PART 2: Testing and Usage Examples
-- =====================================================

-- Example 1: Get customer orders
EXEC sp_GetCustomerOrders @CustomerID = 1;

-- Example 2: Create a new order
DECLARE @OrderItems AS ProductOrderType;
INSERT INTO @OrderItems VALUES (1, 2), (2, 1);

EXEC sp_CreateOrder 
    @CustomerID = 1,
    @ShippingAddress = 'Test Address',
    @ShippingCity = 'Baku',
    @ProductTable = @OrderItems;

-- Example 3: Add stock from supplier
EXEC sp_ManageProductStock 
    @ProductID = 1,
    @Quantity = 10,
    @Operation = 'A',
    @SupplierID = 1;

-- =====================================================
-- PART 3: Best Practices and Notes
-- =====================================================

/*
STORED PROCEDURE BEST PRACTICES:

1. Naming Conventions:
   - Use consistent prefix (sp_, usp_, etc.)
   - Use descriptive names that indicate purpose
   - Avoid special characters and spaces

2. Parameter Handling:
   - Always validate input parameters
   - Use appropriate data types
   - Consider NULL handling
   - Use default values where appropriate

3. Error Handling:
   - Always use TRY-CATCH blocks
   - Include transaction management
   - Return meaningful error messages
   - Log errors appropriately

4. Performance:
   - Use SET NOCOUNT ON
   - Avoid cursors when possible
   - Use appropriate indexes
   - Consider using table-valued parameters for bulk operations

5. Security:
   - Use EXECUTE AS with appropriate permissions
   - Validate input to prevent SQL injection
   - Grant minimum required permissions

6. Maintenance:
   - Document purpose and usage
   - Include version control comments
   - Use consistent formatting
   - Keep procedures focused and simple

7. Testing:
   - Test with various input scenarios
   - Include edge cases
   - Verify transaction rollback
   - Test concurrent execution
*/

-- =====================================================
-- PART 4: Maintenance Queries
-- =====================================================

-- List all stored procedures with their definitions
SELECT 
    OBJECT_NAME(object_id) AS ProcedureName,
    OBJECT_DEFINITION(object_id) AS ProcedureDefinition
FROM sys.procedures
WHERE is_ms_shipped = 0;

-- Get procedure parameters
SELECT 
    OBJECT_NAME(object_id) AS ProcedureName,
    name AS ParameterName,
    type_name(user_type_id) AS ParameterType,
    max_length,
    is_output
FROM sys.parameters
WHERE object_id IN (
    SELECT object_id 
    FROM sys.procedures 
    WHERE is_ms_shipped = 0
)
ORDER BY ProcedureName, parameter_id;