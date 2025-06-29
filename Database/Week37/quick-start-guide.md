# SQL Quick Start Guide - Week 37

**For Students: Get up and running with SQL in 10 minutes!**

---

## 🚀 Quick Setup (5 minutes)

### Step 1: Install SQL Server Management Studio
1. Go to [Microsoft SQL Server Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. Download "SQL Server Management Studio (SSMS)"
3. Install with default settings
4. Launch SSMS

### Step 2: Connect to Database
1. Open SSMS
2. Click "Connect" → "Database Engine"
3. Server name: `localhost` or `(local)`
4. Authentication: "Windows Authentication"
5. Click "Connect"

### Step 3: Create Test Database
```sql
-- Copy and paste this in SSMS Query window
CREATE DATABASE StudentManagementDB;
USE StudentManagementDB;
```

---

## 📖 Quick Learning Path (10 minutes)

### 1. Basic SELECT (2 minutes)
```sql
-- Try these in order:
SELECT * FROM Students;                    -- See all data
SELECT FirstName, LastName FROM Students;  -- See specific columns
SELECT FirstName AS 'Name' FROM Students;  -- Use aliases
```

### 2. WHERE Clause (2 minutes)
```sql
-- Filter data:
SELECT * FROM Students WHERE GPA > 3.5;           -- High GPA students
SELECT * FROM Students WHERE FirstName LIKE 'J%'; -- Names starting with J
SELECT * FROM Students WHERE GPA BETWEEN 3.0 AND 4.0; -- GPA range
```

### 3. ORDER BY (2 minutes)
```sql
-- Sort results:
SELECT * FROM Students ORDER BY GPA DESC;         -- Highest GPA first
SELECT * FROM Students ORDER BY LastName, FirstName; -- Alphabetical
```

### 4. DISTINCT (2 minutes)
```sql
-- Get unique values:
SELECT DISTINCT Department FROM Courses;           -- Unique departments
SELECT DISTINCT Credits FROM Courses;              -- Unique credit values
```

### 5. Logical Operators (2 minutes)
```sql
-- Combine conditions:
SELECT * FROM Students WHERE GPA > 3.5 AND GPA < 4.0;  -- AND operator
SELECT * FROM Students WHERE GPA = 3.75 OR GPA = 3.90; -- OR operator
```

---

## 🎯 Essential Commands Cheat Sheet

### Basic Syntax
```sql
-- Select data
SELECT column1, column2 FROM table_name;

-- Filter data
SELECT * FROM table_name WHERE condition;

-- Sort data
SELECT * FROM table_name ORDER BY column_name;

-- Get unique values
SELECT DISTINCT column_name FROM table_name;
```

### Common Operators
```sql
-- Comparison
=    -- Equal
>    -- Greater than
<    -- Less than
>=   -- Greater than or equal
<=   -- Less than or equal
<>   -- Not equal

-- Logical
AND  -- Both conditions true
OR   -- At least one condition true
NOT  -- Negates condition

-- Pattern matching
LIKE 'pattern%'  -- Starts with
LIKE '%pattern'  -- Ends with
LIKE '%pattern%' -- Contains
```

### Data Types Quick Reference
```sql
-- Numeric
INT          -- Whole numbers
DECIMAL(3,2) -- Decimal numbers (3 total, 2 after decimal)
FLOAT        -- Floating point

-- Text
VARCHAR(50)  -- Variable length text (max 50 chars)
CHAR(10)     -- Fixed length text (10 chars)
TEXT         -- Large text

-- Date/Time
DATE         -- Date only
DATETIME     -- Date and time

-- Other
BIT          -- Boolean (0 or 1)
```

---

## 🔧 Common Issues & Solutions

### "Invalid object name" Error
**Problem:** Table doesn't exist
**Solution:** Run the demo script first to create tables

### "Incorrect syntax" Error
**Problem:** SQL syntax mistake
**Solution:** Check for missing commas, quotes, or semicolons

### "No results" Returned
**Problem:** WHERE condition too restrictive
**Solution:** Try simpler conditions first

### "Conversion failed" Error
**Problem:** Wrong data type comparison
**Solution:** Check data types in your WHERE clause

---

## 📝 Practice Exercises (Start Here!)

### Level 1: Basic Queries
```sql
-- 1. Show all students
SELECT * FROM Students;

-- 2. Show only student names and emails
SELECT FirstName, LastName, Email FROM Students;

-- 3. Show students with GPA > 3.5
SELECT FirstName, LastName, GPA FROM Students WHERE GPA > 3.5;
```

### Level 2: Filtering & Sorting
```sql
-- 4. Show top 3 students by GPA
SELECT TOP 3 FirstName, LastName, GPA FROM Students ORDER BY GPA DESC;

-- 5. Show Computer Science courses only
SELECT CourseName, Credits FROM Courses WHERE Department = 'Computer Science';

-- 6. Show unique departments
SELECT DISTINCT Department FROM Courses;
```

### Level 3: Combining Concepts
```sql
-- 7. Show high-performing CS students
SELECT s.FirstName, s.LastName, s.GPA
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE c.Department = 'Computer Science' AND s.GPA > 3.5
ORDER BY s.GPA DESC;
```

---

## 🎓 Next Steps

1. **Complete the full demo script** (`sql-fundamentals-demo.sql`)
2. **Work through practice exercises** (`sql-practice-exercises.sql`)
3. **Read the detailed README** for comprehensive learning
4. **Practice regularly** with the sample data

---

## 💡 Pro Tips

- **Always backup** before running scripts
- **Test queries** on small datasets first
- **Use comments** to document your SQL
- **Format your queries** for readability
- **Practice daily** to build confidence

---

**Ready to start? Open SSMS and run the demo script!** 🚀 