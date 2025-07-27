# Week 40 - SQL Advanced Practice

**Date:** 27.07.2025  
**Course:** CSharp04 .NET Development  
**Instructor:** Parviz Rovshan Aliyev  

## Overview

This week covers advanced SQL concepts including DELETE statements, TOP/LIMIT/FETCH FIRST/ROWNUM clauses, aggregate functions, and LIKE operator with wildcards. All exercises use the Shopping Database created in previous weeks.

## Topics Covered

### 1. DELETE Statement
- Basic DELETE syntax and safety practices
- DELETE with multiple conditions
- DELETE with date conditions
- DELETE with subqueries
- Cascade DELETE operations
- Transaction safety for DELETE operations

### 2. TOP, LIMIT, FETCH FIRST, ROWNUM
- SQL Server TOP clause
- TOP WITH TIES
- TOP with percentage
- FETCH FIRST (SQL Standard)
- OFFSET and FETCH for pagination
- ROW_NUMBER() for ranking
- Performance considerations

### 3. Aggregate Functions
- COUNT(), SUM(), AVG(), MAX(), MIN()
- Multiple aggregate functions together
- Aggregate functions with HAVING
- Aggregate functions with subqueries
- Conditional aggregation
- Advanced aggregation examples

### 4. LIKE Operator and Wildcards
- % (Percent) wildcard
- _ (Underscore) wildcard
- Character list wildcards [charlist]
- Negative character list [^charlist]
- Escaping special characters
- Case sensitivity
- Performance considerations

## Files in This Directory

### 1. `01-delete-statement-practice.sql`
**Focus:** DELETE statement operations
- Safe DELETE practices
- Multiple condition DELETE
- Date-based DELETE
- Subquery DELETE
- Cascade DELETE
- Transaction examples
- Practice exercises

### 2. `02-top-limit-fetch-first-rownum-practice.sql`
**Focus:** Row limiting and pagination
- SQL Server TOP clause
- TOP WITH TIES
- TOP with percentage
- FETCH FIRST (SQL Standard)
- OFFSET and FETCH pagination
- ROW_NUMBER() ranking
- Performance comparisons

### 3. `03-aggregate-functions-practice.sql`
**Focus:** Aggregate functions and calculations
- COUNT(), SUM(), AVG(), MAX(), MIN()
- Multiple aggregates together
- HAVING clause usage
- Subquery aggregates
- Conditional aggregation
- Advanced examples with window functions

### 4. `04-like-operator-wildcards-practice.sql`
**Focus:** Pattern matching and search
- % and _ wildcards
- Character list patterns
- Negative character lists
- Escaping special characters
- Case sensitivity
- Performance considerations
- Alternatives to LIKE

### 5. `05-comprehensive-practice-exercises.sql`
**Focus:** Real-world scenarios combining all topics
- Customer analysis
- Product inventory analysis
- Order analysis and cleanup
- Search and filter analysis
- Comprehensive reporting
- Data cleanup and maintenance
- Advanced analytical queries

## Prerequisites

Before starting Week 40 exercises, ensure you have:

1. **Shopping Database Setup**
   - Run the Week 38 shopping database creation script
   - Run the Week 39 INSERT/UPDATE practice script
   - Verify all tables have sample data

2. **SQL Server Management Studio (SSMS)**
   - Connected to your SQL Server instance
   - ShoppingDB database selected

3. **Previous Knowledge**
   - Basic SELECT statements
   - WHERE clause usage
   - JOIN operations
   - Basic INSERT/UPDATE operations

## How to Use These Scripts

### 1. Sequential Learning
Start with the individual topic scripts in order:
1. `01-delete-statement-practice.sql`
2. `02-top-limit-fetch-first-rownum-practice.sql`
3. `03-aggregate-functions-practice.sql`
4. `04-like-operator-wildcards-practice.sql`

### 2. Comprehensive Practice
After completing individual topics, work through:
- `05-comprehensive-practice-exercises.sql`

### 3. Safety First
- All DELETE operations are commented out for safety
- Always test with SELECT before DELETE
- Use transactions for important operations
- Backup your database before major changes

## Key Learning Objectives

### DELETE Statement Mastery
- Understand when and how to use DELETE
- Implement safe DELETE practices
- Handle foreign key relationships
- Use basic safety patterns (subqueries and transactions will be covered later)

### Row Limiting Techniques
- Choose appropriate row limiting method
- Implement pagination effectively
- Understand performance implications
- Use ranking functions for complex scenarios

### Aggregate Function Proficiency
- Calculate meaningful business metrics
- Use HAVING clause effectively
- Combine multiple aggregates
- Apply basic aggregation (conditional aggregation will be covered later)

### Pattern Matching Skills
- Implement effective search functionality
- Use wildcards appropriately
- Consider performance implications
- Handle special characters correctly

## Practice Exercises

### Basic Level
1. Delete customers from a specific city
2. Find top 5 most expensive products
3. Calculate average order amount
4. Search for products containing "phone"

### Intermediate Level
1. Delete old orders with basic conditions
2. Implement pagination for customer list
3. Calculate customer spending statistics
4. Search with multiple wildcard patterns

### Advanced Level
1. Basic customer analysis
2. Inventory calculations
3. Product category analysis
4. Data cleanup and maintenance

## Safety Guidelines

### Before Running DELETE Operations
1. **Always test with SELECT first**
2. **Use WHERE clause (never DELETE all rows)**
3. **Check foreign key relationships**
4. **Use transactions for important operations**
5. **Backup your database**

### Example Safe DELETE Pattern
```sql
-- Step 1: Check what will be deleted
SELECT * FROM Customer WHERE City = 'TestCity';

-- Step 2: Perform DELETE (carefully!)
DELETE FROM Customer WHERE City = 'TestCity';

-- Step 3: Verify results
SELECT COUNT(*) FROM Customer;

-- Note: Transactions will be covered in advanced SQL topics
```

## Performance Tips

### DELETE Operations
- Use appropriate indexes
- Delete in batches for large datasets
- Consider using TOP with DELETE
- Always test with SELECT first

### Row Limiting
- Use TOP for simple cases
- Use OFFSET/FETCH for pagination
- Consider ROW_NUMBER() for complex ranking
- Index ORDER BY columns

### Aggregate Functions
- Index GROUP BY columns
- Use HAVING instead of WHERE for aggregates
- Consider window functions for complex scenarios
- Handle NULL values appropriately

### LIKE Operations
- Avoid leading wildcards when possible
- Use appropriate indexes
- Consider full-text search for complex patterns
- Be aware of case sensitivity

## Common Mistakes to Avoid

### DELETE Mistakes
- `DELETE FROM TableName;` (deletes ALL rows!)
- Forgetting to check foreign key relationships
- Not testing WHERE conditions first
- Deleting without backup

### Row Limiting Mistakes
- Using TOP without ORDER BY
- Confusing TOP with LIMIT syntax
- Not considering tied values
- Ignoring performance implications

### Aggregate Mistakes
- Using WHERE instead of HAVING for aggregates
- Forgetting to handle NULL values
- Using COUNT(*) when COUNT(column) is better
- Not considering order of operations

### LIKE Mistakes
- Using LIKE when exact match is needed
- Forgetting to escape special characters
- Not considering case sensitivity
- Using leading wildcards without indexes

## Next Steps

After completing Week 40:

1. **Review and Practice**
   - Re-run exercises with different data
   - Create your own scenarios
   - Experiment with different approaches

2. **Advanced Topics**
   - Window functions
   - Common Table Expressions (CTEs)
   - Stored procedures
   - Triggers

3. **Real-World Application**
   - Apply concepts to your own projects
   - Practice with larger datasets
   - Implement in C# applications

## Resources

### Official Documentation
- [SQL Server DELETE](https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql)
- [SQL Server TOP](https://docs.microsoft.com/en-us/sql/t-sql/queries/top-transact-sql)
- [SQL Server Aggregate Functions](https://docs.microsoft.com/en-us/sql/t-sql/functions/aggregate-functions-transact-sql)
- [SQL Server LIKE](https://docs.microsoft.com/en-us/sql/t-sql/language-elements/like-transact-sql)

### Additional Learning
- [SQL Server Performance Tuning](https://docs.microsoft.com/en-us/sql/relational-databases/performance/)
- [SQL Server Best Practices](https://docs.microsoft.com/en-us/sql/sql-server/best-practices-for-sql-server)
- [Database Design Guidelines](https://docs.microsoft.com/en-us/sql/relational-databases/database-design/)

---

**Note:** All scripts are designed to work with the Shopping Database created in Week 38. Ensure you have the database properly set up before running these exercises. 