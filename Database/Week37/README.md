# SQL Fundamentals - Week 37 Day 01

**Date:** 28.06.2025  
**Topic:** SQL Fundamentals - SELECT, DISTINCT, WHERE, ORDER BY, AND/OR/NOT Operators and SQL Data Types  
**Course:** C# .NET Development Course  

---

## 📚 Overview

This directory contains comprehensive SQL learning materials for Week 37, Day 01. You will learn the fundamental SQL concepts that are essential for database operations in C# applications.

### What You'll Learn

1. **SELECT Statement Basics** - Retrieving data from database tables
2. **DISTINCT Keyword** - Getting unique values from query results
3. **WHERE Clause** - Filtering data using comparison operators
4. **ORDER BY** - Sorting query results in ascending or descending order
5. **Logical Operators** - Combining conditions with AND, OR, NOT
6. **SQL Data Types** - Understanding different data types in SQL Server

---

## 📁 Files in This Directory

### 1. `sql-fundamentals-demo.sql`
**Purpose:** Comprehensive demonstration script with examples and explanations

**What it contains:**
- Complete database setup with sample tables
- Step-by-step examples for each SQL concept
- Sample data for practice
- Detailed comments explaining each concept
- Practical examples combining multiple concepts

**How to use:**
1. Open SQL Server Management Studio (SSMS)
2. Create a new database or use an existing one
3. Run this script to set up the sample database
4. Study each section and run queries to see results

### 2. `sql-practice-exercises.sql`
**Purpose:** Hands-on practice exercises for students

**What it contains:**
- 10 exercise sections with increasing difficulty
- 30+ individual tasks to practice
- Clear instructions and expected results
- Hints for challenging exercises
- Complete solutions (commented out)

**How to use:**
1. First run the demo script to set up the database
2. Work through each exercise section
3. Write your own SQL queries for each task
4. Check your solutions against the provided answers
5. Practice until you're comfortable with each concept

---

## 🚀 Getting Started

### Prerequisites
- SQL Server Management Studio (SSMS) installed
- Basic understanding of databases (covered in previous weeks)
- Familiarity with C# programming concepts

### Setup Instructions

1. **Install SQL Server Management Studio**
   - Download from Microsoft's official website
   - Install and configure for your SQL Server instance

2. **Create a Test Database**
   ```sql
   CREATE DATABASE StudentManagementDB;
   USE StudentManagementDB;
   ```

3. **Run the Demo Script**
   - Open `sql-fundamentals-demo.sql` in SSMS
   - Execute the script to create tables and sample data
   - Study the examples and comments

4. **Practice with Exercises**
   - Open `sql-practice-exercises.sql` in SSMS
   - Work through each exercise section
   - Write your own queries and test them

---

## 📖 Learning Path

### Step 1: Understanding SELECT Statements
- Basic SELECT syntax
- Selecting specific columns
- Using column aliases
- Retrieving all data with `*`

### Step 2: Working with DISTINCT
- Removing duplicate values
- Using DISTINCT with multiple columns
- Understanding when to use DISTINCT

### Step 3: Filtering with WHERE Clause
- Comparison operators (`=`, `>`, `<`, `>=`, `<=`, `<>`)
- BETWEEN operator for ranges
- IN operator for multiple values
- LIKE operator for pattern matching
- IS NULL and IS NOT NULL

### Step 4: Sorting with ORDER BY
- Ascending and descending order
- Sorting by multiple columns
- Using column positions in ORDER BY

### Step 5: Logical Operators
- AND operator (both conditions must be true)
- OR operator (at least one condition must be true)
- NOT operator (negates a condition)
- Combining operators with parentheses

### Step 6: SQL Data Types
- Numeric types (INT, DECIMAL, FLOAT)
- Character types (VARCHAR, CHAR, TEXT)
- Date/Time types (DATE, DATETIME)
- Other types (BIT, BINARY)

---

## 💡 Key Concepts Explained

### SELECT Statement
```sql
-- Basic syntax
SELECT column1, column2 FROM table_name;

-- Select all columns
SELECT * FROM table_name;

-- Using aliases
SELECT column1 AS 'Alias Name' FROM table_name;
```

### WHERE Clause
```sql
-- Basic filtering
SELECT * FROM table_name WHERE condition;

-- Multiple conditions
SELECT * FROM table_name 
WHERE condition1 AND condition2;

-- Pattern matching
SELECT * FROM table_name 
WHERE column_name LIKE 'pattern%';
```

### ORDER BY
```sql
-- Ascending order (default)
SELECT * FROM table_name ORDER BY column_name;

-- Descending order
SELECT * FROM table_name ORDER BY column_name DESC;

-- Multiple columns
SELECT * FROM table_name 
ORDER BY column1 ASC, column2 DESC;
```

### Logical Operators
```sql
-- AND: Both conditions must be true
WHERE condition1 AND condition2

-- OR: At least one condition must be true
WHERE condition1 OR condition2

-- NOT: Negates a condition
WHERE NOT condition

-- Combining with parentheses
WHERE (condition1 AND condition2) OR condition3
```

---

## 🎯 Practice Tips

### 1. Start Simple
- Begin with basic SELECT statements
- Gradually add WHERE clauses
- Practice with ORDER BY
- Combine concepts step by step

### 2. Use the Sample Data
- The demo script provides realistic data
- Practice with different scenarios
- Try modifying the data to test edge cases

### 3. Experiment with Queries
- Don't be afraid to make mistakes
- Try different approaches to the same problem
- Use the PRINT statements to understand query flow

### 4. Check Your Work
- Compare your results with expected outcomes
- Use the solution hints when stuck
- Review the commented solutions after attempting exercises

---

## 🔧 Common Mistakes to Avoid

### 1. Syntax Errors
- Missing commas between column names
- Incorrect operator usage (`=` vs `==`)
- Missing quotes around string values
- Forgetting semicolons at the end

### 2. Logical Errors
- Confusing AND/OR logic
- Not using parentheses for complex conditions
- Incorrect use of comparison operators
- Forgetting to handle NULL values

### 3. Performance Issues
- Using `SELECT *` when you only need specific columns
- Not using appropriate WHERE clauses
- Ignoring indexing considerations

---

## 📋 Assessment Checklist

After completing this module, you should be able to:

- [ ] Write basic SELECT statements
- [ ] Use DISTINCT to get unique values
- [ ] Filter data using WHERE clause with various operators
- [ ] Sort results using ORDER BY
- [ ] Combine conditions using AND, OR, NOT
- [ ] Understand different SQL data types
- [ ] Write queries that combine multiple concepts
- [ ] Debug and troubleshoot SQL syntax errors

---

## 🔗 Additional Resources

### Official Documentation
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [Transact-SQL Reference](https://docs.microsoft.com/en-us/sql/t-sql/language-reference)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/)

### Online Learning
- [W3Schools SQL Tutorial](https://www.w3schools.com/sql/)
- [SQL Server Tutorial](https://www.sqlservertutorial.net/)
- [Microsoft Learn - SQL](https://docs.microsoft.com/en-us/learn/paths/get-started-querying-with-transact-sql/)

### Practice Platforms
- [SQL Fiddle](http://sqlfiddle.com/)
- [HackerRank SQL](https://www.hackerrank.com/domains/sql)
- [LeetCode Database](https://leetcode.com/problemset/database/)

---

## 🆘 Getting Help

### If You're Stuck
1. Review the demo script examples
2. Check the solution hints in the practice file
3. Use SQL Server's error messages to debug issues
4. Practice with simpler queries first
5. Ask questions during class or office hours

### Common Error Messages
- **"Invalid column name"** - Check spelling and table structure
- **"Incorrect syntax"** - Review SQL syntax rules
- **"Conversion failed"** - Check data types in comparisons
- **"No results"** - Verify WHERE conditions and data

---

## 📝 Notes for Students

### Remember
- SQL is case-insensitive for keywords, but use consistent formatting
- Always test your queries with small datasets first
- Comments help document your SQL code
- Practice regularly to build confidence
- These fundamentals will be used extensively in C# database applications

### Next Steps
After mastering these fundamentals, you'll learn:
- JOIN operations (Week 37 Day 02)
- Aggregate functions (COUNT, SUM, AVG, etc.)
- GROUP BY and HAVING clauses
- Subqueries and advanced filtering
- Database design principles

---

**Good luck with your SQL learning journey! Remember, practice makes perfect.** 🚀 