-- =====================================================
-- SQL FUNDAMENTALS DEMONSTRATION SCRIPT
-- Week 37 - Day 01 (28.06.2025)
-- C# .NET Development Course
-- =====================================================

-- This script demonstrates the fundamental SQL concepts:
-- 1. SELECT statement basics
-- 2. DISTINCT keyword for unique values
-- 3. WHERE clause with comparison operators
-- 4. ORDER BY for sorting (ASC/DESC)
-- 5. Logical operators (AND/OR/NOT)
-- 6. SQL Data Types overview

-- =====================================================
-- PART 1: CREATING SAMPLE DATABASE AND TABLES
-- =====================================================

-- Create a sample database for demonstration
-- Note: In SQL Server, you might need to create this database first
-- CREATE DATABASE StudentManagementDB;
-- USE StudentManagementDB;

-- Create Students table with various data types
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),           -- Auto-incrementing primary key
    FirstName VARCHAR(50) NOT NULL,                    -- Variable-length string (max 50 chars)
    LastName VARCHAR(50) NOT NULL,                     -- Variable-length string (max 50 chars)
    Email VARCHAR(100) UNIQUE,                         -- Unique email address
    DateOfBirth DATE,                                  -- Date only (no time)
    EnrollmentDate DATETIME DEFAULT GETDATE(),         -- Date and time with default value
    GPA DECIMAL(3,2),                                  -- Decimal with 3 total digits, 2 after decimal
    IsActive BIT DEFAULT 1,                            -- Boolean (0 or 1)
    PhoneNumber VARCHAR(15),                           -- Phone number as string
    Address TEXT                                       -- Large text field
);

-- Create Courses table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Department VARCHAR(50),
    IsActive BIT DEFAULT 1
);

-- Create Enrollments table (Many-to-Many relationship)
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    EnrollmentDate DATETIME DEFAULT GETDATE(),
    Grade DECIMAL(3,2),
    Status VARCHAR(20) DEFAULT 'Active'
);

-- =====================================================
-- PART 2: INSERTING SAMPLE DATA
-- =====================================================

-- Insert sample students
INSERT INTO Students (FirstName, LastName, Email, DateOfBirth, GPA, PhoneNumber, Address) VALUES
('John', 'Smith', 'john.smith@email.com', '2000-05-15', 3.75, '555-0101', '123 Main St, City, State'),
('Sarah', 'Johnson', 'sarah.johnson@email.com', '1999-08-22', 3.90, '555-0102', '456 Oak Ave, City, State'),
('Michael', 'Brown', 'michael.brown@email.com', '2001-03-10', 3.45, '555-0103', '789 Pine Rd, City, State'),
('Emily', 'Davis', 'emily.davis@email.com', '2000-11-30', 3.80, '555-0104', '321 Elm St, City, State'),
('David', 'Wilson', 'david.wilson@email.com', '1999-12-05', 3.20, '555-0105', '654 Maple Dr, City, State'),
('Lisa', 'Anderson', 'lisa.anderson@email.com', '2001-07-18', 3.95, '555-0106', '987 Cedar Ln, City, State'),
('James', 'Taylor', 'james.taylor@email.com', '2000-01-25', 3.60, '555-0107', '147 Birch Way, City, State'),
('Jennifer', 'Martinez', 'jennifer.martinez@email.com', '1999-09-12', 3.85, '555-0108', '258 Spruce Ct, City, State'),
('Robert', 'Garcia', 'robert.garcia@email.com', '2001-04-08', 3.30, '555-0109', '369 Willow Pl, City, State'),
('Amanda', 'Rodriguez', 'amanda.rodriguez@email.com', '2000-06-20', 3.70, '555-0110', '741 Aspen Blvd, City, State');

-- Insert sample courses
INSERT INTO Courses (CourseName, Credits, Department) VALUES
('Introduction to Computer Science', 3, 'Computer Science'),
('Advanced Programming', 4, 'Computer Science'),
('Database Management', 3, 'Information Technology'),
('Web Development', 3, 'Computer Science'),
('Data Structures', 4, 'Computer Science'),
('Software Engineering', 3, 'Computer Science'),
('Network Security', 3, 'Information Technology'),
('Mobile App Development', 4, 'Computer Science'),
('Artificial Intelligence', 4, 'Computer Science'),
('Cloud Computing', 3, 'Information Technology');

-- Insert sample enrollments
INSERT INTO Enrollments (StudentID, CourseID, Grade, Status) VALUES
(1, 1, 3.8, 'Active'),
(1, 3, 3.9, 'Active'),
(2, 1, 4.0, 'Active'),
(2, 2, 3.7, 'Active'),
(3, 1, 3.2, 'Active'),
(3, 4, 3.5, 'Active'),
(4, 2, 3.8, 'Active'),
(4, 5, 3.9, 'Active'),
(5, 1, 3.1, 'Active'),
(5, 6, 3.3, 'Active'),
(6, 2, 4.0, 'Active'),
(6, 7, 3.8, 'Active'),
(7, 3, 3.6, 'Active'),
(7, 8, 3.7, 'Active'),
(8, 4, 3.9, 'Active'),
(8, 9, 3.8, 'Active'),
(9, 5, 3.2, 'Active'),
(9, 10, 3.4, 'Active'),
(10, 6, 3.7, 'Active'),
(10, 1, 3.6, 'Active');

-- =====================================================
-- PART 3: SELECT STATEMENT BASICS
-- =====================================================

-- Basic SELECT statement - retrieve all columns from a table
PRINT '=== BASIC SELECT STATEMENT ===';
SELECT * FROM Students;

-- SELECT specific columns
PRINT '=== SELECTING SPECIFIC COLUMNS ===';
SELECT FirstName, LastName, Email, GPA 
FROM Students;

-- Using column aliases (AS keyword)
PRINT '=== USING COLUMN ALIASES ===';
SELECT 
    FirstName AS 'First Name',
    LastName AS 'Last Name',
    GPA AS 'Grade Point Average'
FROM Students;

-- =====================================================
-- PART 4: DISTINCT KEYWORD
-- =====================================================

-- DISTINCT removes duplicate values
PRINT '=== DISTINCT KEYWORD - UNIQUE DEPARTMENTS ===';
SELECT DISTINCT Department 
FROM Courses;

-- DISTINCT with multiple columns
PRINT '=== DISTINCT WITH MULTIPLE COLUMNS ===';
SELECT DISTINCT Department, Credits 
FROM Courses;

-- =====================================================
-- PART 5: WHERE CLAUSE WITH COMPARISON OPERATORS
-- =====================================================

-- WHERE clause with equality operator (=)
PRINT '=== WHERE CLAUSE - EQUALITY ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = 3.75;

-- WHERE clause with greater than operator (>)
PRINT '=== WHERE CLAUSE - GREATER THAN ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA > 3.8;

-- WHERE clause with less than or equal operator (<=)
PRINT '=== WHERE CLAUSE - LESS THAN OR EQUAL ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA <= 3.5;

-- WHERE clause with not equal operator (<> or !=)
PRINT '=== WHERE CLAUSE - NOT EQUAL ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA <> 3.75;

-- WHERE clause with BETWEEN operator
PRINT '=== WHERE CLAUSE - BETWEEN ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA BETWEEN 3.5 AND 3.8;

-- WHERE clause with IN operator
PRINT '=== WHERE CLAUSE - IN ===';
SELECT FirstName, LastName, Department 
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE c.Department IN ('Computer Science', 'Information Technology');

-- WHERE clause with LIKE operator (pattern matching)
PRINT '=== WHERE CLAUSE - LIKE (STARTS WITH) ===';
SELECT FirstName, LastName 
FROM Students 
WHERE FirstName LIKE 'J%';

PRINT '=== WHERE CLAUSE - LIKE (ENDS WITH) ===';
SELECT FirstName, LastName 
FROM Students 
WHERE LastName LIKE '%n';

PRINT '=== WHERE CLAUSE - LIKE (CONTAINS) ===';
SELECT FirstName, LastName 
FROM Students 
WHERE FirstName LIKE '%a%';

-- WHERE clause with IS NULL
PRINT '=== WHERE CLAUSE - IS NULL ===';
SELECT FirstName, LastName, PhoneNumber 
FROM Students 
WHERE PhoneNumber IS NULL;

-- =====================================================
-- PART 6: ORDER BY FOR SORTING
-- =====================================================

-- ORDER BY ascending (ASC is default)
PRINT '=== ORDER BY ASCENDING (DEFAULT) ===';
SELECT FirstName, LastName, GPA 
FROM Students 
ORDER BY GPA;

-- ORDER BY descending
PRINT '=== ORDER BY DESCENDING ===';
SELECT FirstName, LastName, GPA 
FROM Students 
ORDER BY GPA DESC;

-- ORDER BY multiple columns
PRINT '=== ORDER BY MULTIPLE COLUMNS ===';
SELECT FirstName, LastName, GPA 
FROM Students 
ORDER BY GPA DESC, LastName ASC;

-- ORDER BY with column position
PRINT '=== ORDER BY WITH COLUMN POSITION ===';
SELECT FirstName, LastName, GPA 
FROM Students 
ORDER BY 3 DESC;  -- 3rd column (GPA)

-- =====================================================
-- PART 7: LOGICAL OPERATORS (AND, OR, NOT)
-- =====================================================

-- AND operator - both conditions must be true
PRINT '=== AND OPERATOR ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA >= 3.5 AND GPA <= 3.8;

-- OR operator - at least one condition must be true
PRINT '=== OR OPERATOR ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = 3.75 OR GPA = 3.90;

-- NOT operator - negates a condition
PRINT '=== NOT OPERATOR ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE NOT GPA < 3.5;

-- Combining logical operators with parentheses
PRINT '=== COMBINING LOGICAL OPERATORS ===';
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE (GPA >= 3.5 AND GPA <= 3.8) OR (GPA >= 3.9);

-- =====================================================
-- PART 8: PRACTICAL EXAMPLES
-- =====================================================

-- Example 1: Find all Computer Science students with GPA > 3.5
PRINT '=== EXAMPLE 1: COMPUTER SCIENCE STUDENTS WITH HIGH GPA ===';
SELECT DISTINCT s.FirstName, s.LastName, s.GPA
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE c.Department = 'Computer Science' AND s.GPA > 3.5
ORDER BY s.GPA DESC;

-- Example 2: Find courses with 4 credits in Computer Science department
PRINT '=== EXAMPLE 2: 4-CREDIT COMPUTER SCIENCE COURSES ===';
SELECT CourseName, Credits, Department
FROM Courses
WHERE Credits = 4 AND Department = 'Computer Science';

-- Example 3: Find students enrolled in multiple courses
PRINT '=== EXAMPLE 3: STUDENTS ENROLLED IN MULTIPLE COURSES ===';
SELECT s.FirstName, s.LastName, COUNT(e.CourseID) AS 'Number of Courses'
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
GROUP BY s.StudentID, s.FirstName, s.LastName
HAVING COUNT(e.CourseID) > 1
ORDER BY COUNT(e.CourseID) DESC;

-- Example 4: Find average GPA by department
PRINT '=== EXAMPLE 4: AVERAGE GPA BY DEPARTMENT ===';
SELECT c.Department, AVG(s.GPA) AS 'Average GPA'
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
GROUP BY c.Department
ORDER BY AVG(s.GPA) DESC;

-- =====================================================
-- PART 9: SQL DATA TYPES OVERVIEW
-- =====================================================

PRINT '=== SQL DATA TYPES OVERVIEW ===';
PRINT 'Numeric Types:';
PRINT '  - INT: Integer values (-2,147,483,648 to 2,147,483,647)';
PRINT '  - BIGINT: Large integer values';
PRINT '  - DECIMAL(p,s): Fixed-point decimal (p=precision, s=scale)';
PRINT '  - FLOAT: Floating-point numbers';
PRINT '  - MONEY: Currency values';

PRINT 'Character Types:';
PRINT '  - CHAR(n): Fixed-length string (n characters)';
PRINT '  - VARCHAR(n): Variable-length string (max n characters)';
PRINT '  - TEXT: Large variable-length string';

PRINT 'Date/Time Types:';
PRINT '  - DATE: Date only (YYYY-MM-DD)';
PRINT '  - DATETIME: Date and time';
PRINT '  - TIMESTAMP: Automatic timestamp';

PRINT 'Other Types:';
PRINT '  - BIT: Boolean (0 or 1)';
PRINT '  - BINARY: Binary data';
PRINT '  - UNIQUEIDENTIFIER: GUID';

-- =====================================================
-- PART 10: CLEANUP (OPTIONAL)
-- =====================================================

-- Uncomment the following lines to clean up the database
-- DROP TABLE Enrollments;
-- DROP TABLE Students;
-- DROP TABLE Courses;

PRINT '=== SQL FUNDAMENTALS DEMONSTRATION COMPLETE ===';
PRINT 'This script covered:';
PRINT '1. SELECT statement basics';
PRINT '2. DISTINCT keyword';
PRINT '3. WHERE clause with comparison operators';
PRINT '4. ORDER BY for sorting';
PRINT '5. Logical operators (AND, OR, NOT)';
PRINT '6. SQL Data Types overview';
PRINT '7. Practical examples with JOINs and aggregations'; 