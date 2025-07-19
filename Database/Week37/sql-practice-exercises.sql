-- =====================================================
-- SQL PRACTICE EXERCISES - FUNDAMENTALS ONLY
-- Week 37 - Day 01 (28.06.2025)
-- C# .NET Development Course
-- =====================================================

-- This script contains practice exercises for SQL fundamentals:
-- - SELECT statement basics
-- - DISTINCT keyword for unique values
-- - WHERE clause with comparison operators
-- - ORDER BY for sorting (ASC/DESC)
-- - Logical operators (AND/OR/NOT)
-- - SQL Data Types overview

-- =====================================================
-- PREREQUISITE: RUN THE DEMO SCRIPT FIRST
-- =====================================================

-- Before starting these exercises, make sure you have run:
-- sql-fundamentals-demo.sql
-- This will create the necessary tables and sample data

-- =====================================================
-- EXERCISE 1: BASIC SELECT STATEMENTS
-- =====================================================

PRINT '=== EXERCISE 1: BASIC SELECT STATEMENTS ===';

-- Task 1.1: Select all students with their full names
-- Write a query to display FirstName, LastName, and Email for all students
-- Expected: 10 rows with student information

-- Your code here:
-- SELECT ...

-- Task 1.2: Select only active courses
-- Write a query to display CourseName and Credits for all active courses
-- Expected: 10 rows with course information

-- Your code here:
-- SELECT ...

-- Task 1.3: Create a custom column alias
-- Write a query to display student information with custom column names:
-- - FirstName as "Student First Name"
-- - LastName as "Student Last Name" 
-- - GPA as "Grade Point Average"
-- Expected: 10 rows with custom column headers

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 2: DISTINCT KEYWORD
-- =====================================================

PRINT '=== EXERCISE 2: DISTINCT KEYWORD ===';

-- Task 2.1: Find unique departments
-- Write a query to find all unique departments in the Courses table
-- Expected: 2 rows (Computer Science, Information Technology)

-- Your code here:
-- SELECT ...

-- Task 2.2: Find unique credit values
-- Write a query to find all unique credit values in the Courses table
-- Expected: 2 rows (3, 4)

-- Your code here:
-- SELECT ...

-- Task 2.3: Find unique department-credit combinations
-- Write a query to find all unique combinations of Department and Credits
-- Expected: 4 rows showing different department-credit combinations

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 3: WHERE CLAUSE WITH COMPARISON OPERATORS
-- =====================================================

PRINT '=== EXERCISE 3: WHERE CLAUSE WITH COMPARISON OPERATORS ===';

-- Task 3.1: Find students with GPA greater than 3.8
-- Write a query to find students with GPA > 3.8
-- Expected: Students with high GPA

-- Your code here:
-- SELECT ...

-- Task 3.2: Find courses with exactly 4 credits
-- Write a query to find courses that have exactly 4 credits
-- Expected: 4-credit courses

-- Your code here:
-- SELECT ...

-- Task 3.3: Find students with GPA between 3.5 and 3.8 (inclusive)
-- Write a query to find students with GPA between 3.5 and 3.8
-- Expected: Students with moderate GPA

-- Your code here:
-- SELECT ...

-- Task 3.4: Find students whose first name starts with 'J'
-- Write a query to find students whose first name starts with 'J'
-- Expected: Students with names like John, James, Jennifer

-- Your code here:
-- SELECT ...

-- Task 3.5: Find courses in Computer Science department
-- Write a query to find all courses in the Computer Science department
-- Expected: Computer Science courses only

-- Your code here:
-- SELECT ...

-- Task 3.6: Find students with GPA not equal to 3.75
-- Write a query to find students whose GPA is not equal to 3.75
-- Expected: Students with GPA other than 3.75

-- Your code here:
-- SELECT ...

-- Task 3.7: Find courses with credits greater than or equal to 4
-- Write a query to find courses with 4 or more credits
-- Expected: Courses with 4 credits

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 4: ORDER BY FOR SORTING
-- =====================================================

PRINT '=== EXERCISE 4: ORDER BY FOR SORTING ===';

-- Task 4.1: Sort students by GPA in descending order
-- Write a query to display students sorted by GPA from highest to lowest
-- Expected: Students ordered by GPA (highest first)

-- Your code here:
-- SELECT ...

-- Task 4.2: Sort courses by credits in ascending order, then by course name
-- Write a query to sort courses by credits (ascending), then by course name
-- Expected: Courses ordered by credits first, then alphabetically

-- Your code here:
-- SELECT ...

-- Task 4.3: Sort students by last name, then by first name
-- Write a query to sort students alphabetically by last name, then by first name
-- Expected: Students ordered alphabetically

-- Your code here:
-- SELECT ...

-- Task 4.4: Sort courses by department, then by credits descending
-- Write a query to sort courses by department first, then by credits (highest first)
-- Expected: Courses grouped by department, sorted by credits within each department

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 5: LOGICAL OPERATORS (AND, OR, NOT)
-- =====================================================

PRINT '=== EXERCISE 5: LOGICAL OPERATORS ===';

-- Task 5.1: Find Computer Science courses with 4 credits
-- Write a query to find courses that are both in Computer Science department AND have 4 credits
-- Expected: 4-credit Computer Science courses

-- Your code here:
-- SELECT ...

-- Task 5.2: Find students with GPA 3.75 OR 3.90
-- Write a query to find students with GPA equal to 3.75 OR 3.90
-- Expected: Students with specific GPA values

-- Your code here:
-- SELECT ...

-- Task 5.3: Find courses with 3 credits AND active status
-- Write a query to find courses that have 3 credits AND are active
-- Expected: Active 3-credit courses

-- Your code here:
-- SELECT ...

-- Task 5.4: Find students NOT born in 2000
-- Write a query to find students who are NOT born in the year 2000
-- Expected: Students born in years other than 2000

-- Your code here:
-- SELECT ...

-- Task 5.5: Find courses in Computer Science OR Information Technology with 4 credits
-- Write a query to find courses that are in Computer Science OR Information Technology AND have 4 credits
-- Expected: 4-credit courses from both departments

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 6: COMBINING CONCEPTS
-- =====================================================

PRINT '=== EXERCISE 6: COMBINING CONCEPTS ===';

-- Task 6.1: Find top 3 students by GPA
-- Write a query to find the top 3 students with the highest GPA
-- Expected: 3 students with highest GPA

-- Your code here:
-- SELECT ...

-- Task 6.2: Find Information Technology courses sorted by name
-- Write a query to find all Information Technology courses, sorted alphabetically
-- Expected: IT courses in alphabetical order

-- Your code here:
-- SELECT ...

-- Task 6.3: Find students with GPA > 3.5, sorted by GPA descending
-- Write a query to find students with GPA greater than 3.5, sorted by GPA from highest to lowest
-- Expected: High-performing students ordered by GPA

-- Your code here:
-- SELECT ...

-- Task 6.4: Find unique student names starting with 'J' or 'M'
-- Write a query to find unique first names that start with 'J' OR 'M'
-- Expected: Names starting with J or M

-- Your code here:
-- SELECT ...

-- Task 6.5: Find courses with 'Programming' in the name, sorted by credits
-- Write a query to find courses containing 'Programming' in the name, sorted by credits
-- Expected: Programming courses ordered by credit count

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 7: DATA TYPE PRACTICE
-- =====================================================

PRINT '=== EXERCISE 7: DATA TYPE PRACTICE ===';

-- Task 7.1: Find students born in 2000
-- Write a query to find students born in the year 2000
-- Hint: Use YEAR() function or date comparison
-- Expected: Students born in 2000

-- Your code here:
-- SELECT ...

-- Task 7.2: Find courses with specific credit ranges
-- Write a query to find courses with credits between 3 and 4 (inclusive)
-- Expected: Courses with 3 or 4 credits

-- Your code here:
-- SELECT ...

-- Task 7.3: Find students with valid email addresses
-- Write a query to find students who have email addresses (not NULL)
-- Expected: Students with email addresses

-- Your code here:
-- SELECT ...

-- Task 7.4: Find students with phone numbers
-- Write a query to find students who have phone numbers (not NULL)
-- Expected: Students with phone numbers

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 8: PATTERN MATCHING
-- =====================================================

PRINT '=== EXERCISE 8: PATTERN MATCHING ===';

-- Task 8.1: Find students with last names ending in 'son'
-- Write a query to find students whose last name ends with 'son'
-- Expected: Students with last names like Johnson, Wilson

-- Your code here:
-- SELECT ...

-- Task 8.2: Find courses with 'Programming' in the name
-- Write a query to find courses that contain the word 'Programming'
-- Expected: Programming-related courses

-- Your code here:
-- SELECT ...

-- Task 8.3: Find students with first names containing 'a' (case insensitive)
-- Write a query to find students whose first name contains the letter 'a'
-- Expected: Students with 'a' in their first name

-- Your code here:
-- SELECT ...

-- Task 8.4: Find courses with names starting with 'A'
-- Write a query to find courses whose names start with the letter 'A'
-- Expected: Courses starting with A

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 9: COMPREHENSIVE CHALLENGES
-- =====================================================

PRINT '=== EXERCISE 9: COMPREHENSIVE CHALLENGES ===';

-- Task 9.1: Find students with highest and lowest GPA
-- Write a query to find the student(s) with the highest GPA and the student(s) with the lowest GPA
-- Hint: Use subqueries or multiple queries
-- Expected: Students with extreme GPA values

-- Your code here:
-- SELECT ...

-- Task 9.2: Find all active Computer Science courses with 4 credits, sorted by name
-- Write a query to find active Computer Science courses with exactly 4 credits, sorted alphabetically
-- Expected: Active 4-credit CS courses in alphabetical order

-- Your code here:
-- SELECT ...

-- Task 9.3: Find students with GPA between 3.5 and 4.0, sorted by last name
-- Write a query to find students with GPA in the range 3.5-4.0, sorted by last name
-- Expected: High-performing students ordered by last name

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 10: FINAL CHALLENGE
-- =====================================================

PRINT '=== EXERCISE 10: FINAL CHALLENGE ===';

-- Task 10.1: Create a comprehensive student report
-- Write a query that shows:
-- - Student full name (FirstName + LastName)
-- - GPA
-- - Email
-- - Phone Number
-- Only for students with GPA > 3.5 AND born in 2000
-- Sorted by GPA descending, then by last name
-- Expected: Comprehensive student report for high-performing students born in 2000

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE SOLUTIONS (Uncomment to see answers)
-- =====================================================

/*
-- =====================================================
-- EXERCISE 1 SOLUTIONS: BASIC SELECT STATEMENTS
-- =====================================================

-- Exercise 1.1 Solution: Select all students with their full names
SELECT FirstName, LastName, Email FROM Students;

-- Exercise 1.2 Solution: Select only active courses
SELECT CourseName, Credits FROM Courses WHERE IsActive = 1;

-- Exercise 1.3 Solution: Create a custom column alias
SELECT 
    FirstName AS 'Student First Name',
    LastName AS 'Student Last Name',
    GPA AS 'Grade Point Average'
FROM Students;

-- =====================================================
-- EXERCISE 2 SOLUTIONS: DISTINCT KEYWORD
-- =====================================================

-- Exercise 2.1 Solution: Find unique departments
SELECT DISTINCT Department FROM Courses;

-- Exercise 2.2 Solution: Find unique credit values
SELECT DISTINCT Credits FROM Courses;

-- Exercise 2.3 Solution: Find unique department-credit combinations
SELECT DISTINCT Department, Credits FROM Courses;

-- =====================================================
-- EXERCISE 3 SOLUTIONS: WHERE CLAUSE WITH COMPARISON OPERATORS
-- =====================================================

-- Exercise 3.1 Solution: Find students with GPA greater than 3.8
SELECT FirstName, LastName, GPA FROM Students WHERE GPA > 3.8;

-- Exercise 3.2 Solution: Find courses with exactly 4 credits
SELECT CourseName, Credits FROM Courses WHERE Credits = 4;

-- Exercise 3.3 Solution: Find students with GPA between 3.5 and 3.8 (inclusive)
SELECT FirstName, LastName, GPA FROM Students WHERE GPA BETWEEN 3.5 AND 3.8;

-- Exercise 3.4 Solution: Find students whose first name starts with 'J'
SELECT FirstName, LastName FROM Students WHERE FirstName LIKE 'J%';

-- Exercise 3.5 Solution: Find courses in Computer Science department
SELECT CourseName, Credits FROM Courses WHERE Department = 'Computer Science';

-- Exercise 3.6 Solution: Find students with GPA not equal to 3.75
SELECT FirstName, LastName, GPA FROM Students WHERE GPA <> 3.75;

-- Exercise 3.7 Solution: Find courses with credits greater than or equal to 4
SELECT CourseName, Credits FROM Courses WHERE Credits >= 4;

-- =====================================================
-- EXERCISE 4 SOLUTIONS: ORDER BY FOR SORTING
-- =====================================================

-- Exercise 4.1 Solution: Sort students by GPA in descending order
SELECT FirstName, LastName, GPA FROM Students ORDER BY GPA DESC;

-- Exercise 4.2 Solution: Sort courses by credits in ascending order, then by course name
SELECT CourseName, Credits FROM Courses ORDER BY Credits ASC, CourseName ASC;

-- Exercise 4.3 Solution: Sort students by last name, then by first name
SELECT FirstName, LastName FROM Students ORDER BY LastName ASC, FirstName ASC;

-- Exercise 4.4 Solution: Sort courses by department, then by credits descending
SELECT CourseName, Department, Credits FROM Courses ORDER BY Department ASC, Credits DESC;

-- =====================================================
-- EXERCISE 5 SOLUTIONS: LOGICAL OPERATORS (AND, OR, NOT)
-- =====================================================

-- Exercise 5.1 Solution: Find Computer Science courses with 4 credits
SELECT CourseName, Credits FROM Courses 
WHERE Department = 'Computer Science' AND Credits = 4;

-- Exercise 5.2 Solution: Find students with GPA 3.75 OR 3.90
SELECT FirstName, LastName, GPA FROM Students 
WHERE GPA = 3.75 OR GPA = 3.90;

-- Exercise 5.3 Solution: Find courses with 3 credits AND active status
SELECT CourseName, Credits FROM Courses 
WHERE Credits = 3 AND IsActive = 1;

-- Exercise 5.4 Solution: Find students NOT born in 2000
SELECT FirstName, LastName, DateOfBirth FROM Students 
WHERE YEAR(DateOfBirth) != 2000;

-- Exercise 5.5 Solution: Find courses in Computer Science OR Information Technology with 4 credits
SELECT CourseName, Department, Credits FROM Courses 
WHERE (Department = 'Computer Science' OR Department = 'Information Technology') AND Credits = 4;

-- =====================================================
-- EXERCISE 6 SOLUTIONS: COMBINING CONCEPTS
-- =====================================================

-- Exercise 6.1 Solution: Find top 3 students by GPA
SELECT TOP 3 FirstName, LastName, GPA 
FROM Students 
ORDER BY GPA DESC;

-- Exercise 6.2 Solution: Find Information Technology courses sorted by name
SELECT CourseName, Credits 
FROM Courses 
WHERE Department = 'Information Technology' 
ORDER BY CourseName ASC;

-- Exercise 6.3 Solution: Find students with GPA > 3.5, sorted by GPA descending
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA > 3.5 
ORDER BY GPA DESC;

-- Exercise 6.4 Solution: Find unique student names starting with 'J' or 'M'
SELECT DISTINCT FirstName 
FROM Students 
WHERE FirstName LIKE 'J%' OR FirstName LIKE 'M%';

-- Exercise 6.5 Solution: Find courses with 'Programming' in the name, sorted by credits
SELECT CourseName, Credits 
FROM Courses 
WHERE CourseName LIKE '%Programming%' 
ORDER BY Credits;

-- =====================================================
-- EXERCISE 7 SOLUTIONS: DATA TYPE PRACTICE
-- =====================================================

-- Exercise 7.1 Solution: Find students born in 2000
SELECT FirstName, LastName, DateOfBirth 
FROM Students 
WHERE YEAR(DateOfBirth) = 2000;

-- Exercise 7.2 Solution: Find courses with specific credit ranges
SELECT CourseName, Credits 
FROM Courses 
WHERE Credits BETWEEN 3 AND 4;

-- Exercise 7.3 Solution: Find students with valid email addresses
SELECT FirstName, LastName, Email 
FROM Students 
WHERE Email IS NOT NULL;

-- Exercise 7.4 Solution: Find students with phone numbers
SELECT FirstName, LastName, PhoneNumber 
FROM Students 
WHERE PhoneNumber IS NOT NULL;

-- =====================================================
-- EXERCISE 8 SOLUTIONS: PATTERN MATCHING
-- =====================================================

-- Exercise 8.1 Solution: Find students with last names ending in 'son'
SELECT FirstName, LastName 
FROM Students 
WHERE LastName LIKE '%son';

-- Exercise 8.2 Solution: Find courses with 'Programming' in the name
SELECT CourseName, Credits 
FROM Courses 
WHERE CourseName LIKE '%Programming%';

-- Exercise 8.3 Solution: Find students with first names containing 'a' (case insensitive)
SELECT FirstName, LastName 
FROM Students 
WHERE FirstName LIKE '%a%';

-- Exercise 8.4 Solution: Find courses with names starting with 'A'
SELECT CourseName, Credits 
FROM Courses 
WHERE CourseName LIKE 'A%';

-- =====================================================
-- EXERCISE 9 SOLUTIONS: COMPREHENSIVE CHALLENGES
-- =====================================================

-- Exercise 9.1 Solution: Find students with highest and lowest GPA
-- Students with highest GPA
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = (SELECT MAX(GPA) FROM Students);

-- Students with lowest GPA
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = (SELECT MIN(GPA) FROM Students);

-- Exercise 9.2 Solution: Find all active Computer Science courses with 4 credits, sorted by name
SELECT CourseName, Credits 
FROM Courses 
WHERE Department = 'Computer Science' AND Credits = 4 AND IsActive = 1
ORDER BY CourseName;

-- Exercise 9.3 Solution: Find students with GPA between 3.5 and 4.0, sorted by last name
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA BETWEEN 3.5 AND 4.0
ORDER BY LastName;

-- =====================================================
-- EXERCISE 10 SOLUTIONS: FINAL CHALLENGE
-- =====================================================

-- Exercise 10.1 Solution: Create a comprehensive student report
SELECT 
    FirstName + ' ' + LastName AS 'Full Name',
    GPA,
    Email,
    PhoneNumber
FROM Students
WHERE GPA > 3.5 AND YEAR(DateOfBirth) = 2000
ORDER BY GPA DESC, LastName;
*/

PRINT '=== SQL FUNDAMENTALS PRACTICE EXERCISES COMPLETE ===';
PRINT 'Uncomment the solutions section above to see all the answers!';
PRINT 'Try to solve the exercises first, then check your answers against the solutions.';
PRINT 'These exercises focus on SQL fundamentals: SELECT, DISTINCT, WHERE, ORDER BY, and logical operators.'; 