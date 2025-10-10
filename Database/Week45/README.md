# Week 45: SQL FOREIGN KEYs and Stored Procedures Practice

## 📚 Overview
This week's practice focuses on two fundamental SQL Server concepts that are crucial for building robust and maintainable databases:

### 1. FOREIGN KEY Constraints
Essential for maintaining data integrity and relationships between tables. They ensure that relationships between tables are valid and help maintain referential integrity in the database.

### 2. Stored Procedures
Precompiled SQL statements that can be reused, improving performance and maintainability while providing better security through encapsulation.

Both practices build upon our existing ShoppingDB database, extending its capabilities with advanced features and robust data integrity measures.

## 📁 Files Structure
- `01-shopping-db-foreign-keys.sql`: Comprehensive FOREIGN KEY implementation and practice
- `02-shopping-db-stored-procedures.sql`: Advanced stored procedures with transaction management

## 🔑 Part 1: FOREIGN KEY Constraints Practice

### Key Concepts
1. **Relationship Types**
   - One-to-Many (1:N)
     - Most common relationship type
     - Example: One Customer can have many Orders
     - Implementation: Simple FOREIGN KEY
   
   - Many-to-Many (M:N)
     - Requires junction/bridge table
     - Example: Products and Suppliers relationship
     - Implementation: Two FOREIGN KEYs in junction table
   
   - Self-Referencing
     - Table references itself
     - Example: Category hierarchy (parent-child)
     - Implementation: FOREIGN KEY referencing same table

2. **Constraint Behaviors**
   - CASCADE
     - Automatically propagates changes
     - Useful for maintaining data consistency
     - Example: Deleting order cascades to order details
   
   - NO ACTION
     - Prevents changes that would break relationships
     - Ensures referential integrity
     - Example: Can't delete product with active orders
   
   - SET NULL
     - Sets FOREIGN KEY to NULL when parent is deleted
     - Useful for optional relationships
     - Example: Category deletion sets product's category to NULL

### Practice Tasks with Explanations
1. **Warehouse Management**
   - Create Warehouse table with location tracking
   - Implement product-warehouse relationship
   - Handle stock transfers between warehouses
   - Consider inventory audit trail

2. **Customer Wishlist System**
   - Design many-to-many relationship
   - Track wish dates and priorities
   - Handle product availability notifications
   - Implement soft delete for wishes

3. **Shipping System Integration**
   - Add carrier tracking capabilities
   - Link orders with shipping details
   - Handle multiple shipments per order
   - Track shipping status changes

4. **Soft Delete Implementation**
   - Preserve referential integrity
   - Handle cascading soft deletes
   - Maintain historical data
   - Implement recovery procedures

5. **Product Bundle System**
   - Create bundle-product relationships
   - Handle pricing and inventory
   - Manage bundle modifications
   - Track bundle sales history

## 💾 Part 2: Stored Procedures Practice

### Advanced Concepts
1. **Core Fundamentals**
   - Parameter handling and validation
   - Return value management
   - Error handling patterns
   - Transaction management
   - Performance optimization

2. **Advanced Features**
   - Table-valued parameters
     - Handling bulk operations
     - Improving performance
     - Maintaining data integrity
   
   - Dynamic SQL
     - Building flexible queries
     - Handling dynamic filtering
     - Security considerations
   
   - Output Parameters
     - Returning multiple values
     - Status and result handling
     - Error information

3. **Transaction Management**
   - ACID properties
   - Error handling
   - Rollback strategies
   - Deadlock handling
   - Isolation levels

### Practice Tasks with Implementation Details
1. **Customer Management Procedures**
   - Customer CRUD operations
   - Address management
   - Purchase history tracking
   - Loyalty points calculation

2. **Order Processing System**
   - Order creation and validation
   - Stock level management
   - Price calculation
   - Discount application
   - Transaction handling

3. **Advanced Reporting**
   - Sales analytics
   - Inventory reports
   - Customer insights
   - Performance metrics

4. **Category Management**
   - Hierarchy management
   - Product categorization
   - Category merging
   - Impact analysis

5. **Loyalty Program**
   - Points calculation
   - Reward management
   - Member tiers
   - Expiration handling

## 🚀 Implementation Guide

### Setup and Prerequisites
1. **Environment Setup**
   - SQL Server 2016 or later
   - SQL Server Management Studio
   - Appropriate permissions
   - Test database backup

2. **Execution Order**
   ```sql
   -- 1. Execute Foreign Keys script
   EXECUTE 01-shopping-db-foreign-keys.sql
   
   -- 2. Execute Stored Procedures script
   EXECUTE 02-shopping-db-stored-procedures.sql
   ```

### Best Practices and Guidelines

1. **FOREIGN KEY Design**
   - Use meaningful constraint names
   - Plan cascading behaviors carefully
   - Index FOREIGN KEY columns
   - Consider impact on performance
   - Handle NULL values appropriately
   - Document relationships

2. **Stored Procedure Development**
   - Implement comprehensive error handling
   - Use appropriate transaction isolation
   - Follow consistent naming conventions
   - Document parameters and behavior
   - Consider performance implications
   - Include adequate logging
   - Handle edge cases
   - Validate all inputs

3. **Testing Strategy**
   - Unit test each procedure
   - Test with various data scenarios
   - Verify error handling
   - Check transaction rollback
   - Test concurrent execution
   - Validate data integrity
   - Performance testing

## 📚 Additional Resources

### Official Documentation
1. [SQL Server FOREIGN KEY Constraints](https://learn.microsoft.com/en-us/sql/relational-databases/tables/primary-and-foreign-key-constraints)
   - Complete guide to constraints
   - Best practices and examples
   - Performance considerations

2. [SQL Server Stored Procedures](https://learn.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-stored-procedures-database-engine)
   - Creation and management
   - Parameter handling
   - Security considerations

3. [Transaction Management](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/transactions-transact-sql)
   - ACID properties
   - Isolation levels
   - Error handling

4. [Error Handling in SQL Server](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/try-catch-transact-sql)
   - TRY-CATCH blocks
   - Error functions
   - Best practices

### Learning Resources
- [SQL Server Tutorial](https://www.sqlservertutorial.net/)
- [W3Schools SQL Tutorial](https://www.w3schools.com/sql/)
- [Microsoft Learn SQL Path](https://learn.microsoft.com/en-us/sql/)