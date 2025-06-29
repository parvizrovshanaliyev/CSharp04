-- =====================================================
-- SQL PRACTICE EXERCISES
-- Week 37 - Day 01 (28.06.2025)
-- C# .NET Development Course
-- =====================================================

-- This script contains practice exercises for SQL fundamentals:
-- Students should complete these exercises to reinforce their learning

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

-- Task 5.3: Find students NOT in Computer Science courses
-- Write a query to find students who are NOT enrolled in Computer Science courses
-- Hint: Use JOINs and NOT IN or NOT EXISTS
-- Expected: Students enrolled only in Information Technology courses

-- Your code here:
-- SELECT ...

-- Task 5.4: Find courses with 3 credits AND active status
-- Write a query to find courses that have 3 credits AND are active
-- Expected: Active 3-credit courses

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

-- Task 6.3: Find students with GPA > 3.5 enrolled in Computer Science courses
-- Write a query to find students with GPA > 3.5 who are enrolled in Computer Science courses
-- Expected: High-performing CS students

-- Your code here:
-- SELECT ...

-- Task 6.4: Find unique student names starting with 'J' or 'M'
-- Write a query to find unique first names that start with 'J' OR 'M'
-- Expected: Names starting with J or M

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 7: ADVANCED CHALLENGES
-- =====================================================

PRINT '=== EXERCISE 7: ADVANCED CHALLENGES ===';

-- Task 7.1: Find students enrolled in multiple courses
-- Write a query to find students who are enrolled in more than one course
-- Hint: Use JOINs, GROUP BY, and HAVING
-- Expected: Students with multiple enrollments

-- Your code here:
-- SELECT ...

-- Task 7.2: Find average GPA by department
-- Write a query to calculate the average GPA for students in each department
-- Hint: Use JOINs, GROUP BY, and aggregate functions
-- Expected: Average GPA for each department

-- Your code here:
-- SELECT ...

-- Task 7.3: Find courses with no enrollments
-- Write a query to find courses that have no students enrolled
-- Hint: Use LEFT JOIN and IS NULL
-- Expected: Courses with no enrollments (if any)

-- Your code here:
-- SELECT ...

-- Task 7.4: Find students with highest and lowest GPA
-- Write a query to find the student(s) with the highest GPA and the student(s) with the lowest GPA
-- Hint: Use subqueries or multiple queries
-- Expected: Students with extreme GPA values

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 8: DATA TYPE PRACTICE
-- =====================================================

PRINT '=== EXERCISE 8: DATA TYPE PRACTICE ===';

-- Task 8.1: Find students born in 2000
-- Write a query to find students born in the year 2000
-- Hint: Use YEAR() function or date comparison
-- Expected: Students born in 2000

-- Your code here:
-- SELECT ...

-- Task 8.2: Find courses with specific credit ranges
-- Write a query to find courses with credits between 3 and 4 (inclusive)
-- Expected: Courses with 3 or 4 credits

-- Your code here:
-- SELECT ...

-- Task 8.3: Find students with valid email addresses
-- Write a query to find students who have email addresses (not NULL)
-- Expected: Students with email addresses

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 9: PATTERN MATCHING
-- =====================================================

PRINT '=== EXERCISE 9: PATTERN MATCHING ===';

-- Task 9.1: Find students with last names ending in 'son'
-- Write a query to find students whose last name ends with 'son'
-- Expected: Students with last names like Johnson, Wilson

-- Your code here:
-- SELECT ...

-- Task 9.2: Find courses with 'Programming' in the name
-- Write a query to find courses that contain the word 'Programming'
-- Expected: Programming-related courses

-- Your code here:
-- SELECT ...

-- Task 9.3: Find students with first names containing 'a' (case insensitive)
-- Write a query to find students whose first name contains the letter 'a'
-- Expected: Students with 'a' in their first name

-- Your code here:
-- SELECT ...

-- =====================================================
-- EXERCISE 10: COMPREHENSIVE CHALLENGE
-- =====================================================

PRINT '=== EXERCISE 10: COMPREHENSIVE CHALLENGE ===';

-- Task 10.1: Create a comprehensive student report
-- Write a query that shows:
-- - Student full name (FirstName + LastName)
-- - GPA
-- - Number of courses enrolled
-- - Average grade in enrolled courses
-- - Department of enrolled courses
-- Only for students with GPA > 3.5
-- Sorted by GPA descending, then by number of courses descending
-- Expected: Comprehensive student performance report

-- Your code here:
-- SELECT ...

-- =====================================================
-- SOLUTION HINTS (Uncomment to see solutions)
-- =====================================================

/*
-- Exercise 1.1 Solution:
SELECT FirstName, LastName, Email FROM Students;

-- Exercise 1.2 Solution:
SELECT CourseName, Credits FROM Courses WHERE IsActive = 1;

-- Exercise 1.3 Solution:
SELECT 
    FirstName AS 'Student First Name',
    LastName AS 'Student Last Name',
    GPA AS 'Grade Point Average'
FROM Students;

-- Exercise 2.1 Solution:
SELECT DISTINCT Department FROM Courses;

-- Exercise 2.2 Solution:
SELECT DISTINCT Credits FROM Courses;

-- Exercise 2.3 Solution:
SELECT DISTINCT Department, Credits FROM Courses;

-- Exercise 3.1 Solution:
SELECT FirstName, LastName, GPA FROM Students WHERE GPA > 3.8;

-- Exercise 3.2 Solution:
SELECT CourseName, Credits FROM Courses WHERE Credits = 4;

-- Exercise 3.3 Solution:
SELECT FirstName, LastName, GPA FROM Students WHERE GPA BETWEEN 3.5 AND 3.8;

-- Exercise 3.4 Solution:
SELECT FirstName, LastName FROM Students WHERE FirstName LIKE 'J%';

-- Exercise 3.5 Solution:
SELECT CourseName, Credits FROM Courses WHERE Department = 'Computer Science';

-- Exercise 4.1 Solution:
SELECT FirstName, LastName, GPA FROM Students ORDER BY GPA DESC;

-- Exercise 4.2 Solution:
SELECT CourseName, Credits FROM Courses ORDER BY Credits ASC, CourseName ASC;

-- Exercise 4.3 Solution:
SELECT FirstName, LastName FROM Students ORDER BY LastName ASC, FirstName ASC;

-- Exercise 5.1 Solution:
SELECT CourseName, Credits FROM Courses 
WHERE Department = 'Computer Science' AND Credits = 4;

-- Exercise 5.2 Solution:
SELECT FirstName, LastName, GPA FROM Students 
WHERE GPA = 3.75 OR GPA = 3.90;

-- Exercise 5.3 Solution:
SELECT DISTINCT s.FirstName, s.LastName 
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE c.Department != 'Computer Science';

-- Exercise 5.4 Solution:
SELECT CourseName, Credits FROM Courses 
WHERE Credits = 3 AND IsActive = 1;

-- Exercise 6.1 Solution:
SELECT TOP 3 FirstName, LastName, GPA 
FROM Students 
ORDER BY GPA DESC;

-- Exercise 6.2 Solution:
SELECT CourseName, Credits 
FROM Courses 
WHERE Department = 'Information Technology' 
ORDER BY CourseName ASC;

-- Exercise 6.3 Solution:
SELECT DISTINCT s.FirstName, s.LastName, s.GPA
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE s.GPA > 3.5 AND c.Department = 'Computer Science';

-- Exercise 6.4 Solution:
SELECT DISTINCT FirstName 
FROM Students 
WHERE FirstName LIKE 'J%' OR FirstName LIKE 'M%';

-- Exercise 7.1 Solution:
SELECT s.FirstName, s.LastName, COUNT(e.CourseID) AS 'Number of Courses'
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
GROUP BY s.StudentID, s.FirstName, s.LastName
HAVING COUNT(e.CourseID) > 1;

-- Exercise 7.2 Solution:
SELECT c.Department, AVG(s.GPA) AS 'Average GPA'
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
GROUP BY c.Department;

-- Exercise 7.3 Solution:
SELECT c.CourseName, c.Credits
FROM Courses c
LEFT JOIN Enrollments e ON c.CourseID = e.CourseID
WHERE e.CourseID IS NULL;

-- Exercise 7.4 Solution:
-- Students with highest GPA
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = (SELECT MAX(GPA) FROM Students);

-- Students with lowest GPA
SELECT FirstName, LastName, GPA 
FROM Students 
WHERE GPA = (SELECT MIN(GPA) FROM Students);

-- Exercise 8.1 Solution:
SELECT FirstName, LastName, DateOfBirth 
FROM Students 
WHERE YEAR(DateOfBirth) = 2000;

-- Exercise 8.2 Solution:
SELECT CourseName, Credits 
FROM Courses 
WHERE Credits BETWEEN 3 AND 4;

-- Exercise 8.3 Solution:
SELECT FirstName, LastName, Email 
FROM Students 
WHERE Email IS NOT NULL;

-- Exercise 9.1 Solution:
SELECT FirstName, LastName 
FROM Students 
WHERE LastName LIKE '%son';

-- Exercise 9.2 Solution:
SELECT CourseName, Credits 
FROM Courses 
WHERE CourseName LIKE '%Programming%';

-- Exercise 9.3 Solution:
SELECT FirstName, LastName 
FROM Students 
WHERE FirstName LIKE '%a%';

-- Exercise 10.1 Solution:
SELECT 
    s.FirstName + ' ' + s.LastName AS 'Full Name',
    s.GPA,
    COUNT(e.CourseID) AS 'Number of Courses',
    AVG(e.Grade) AS 'Average Grade',
    c.Department
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE s.GPA > 3.5
GROUP BY s.StudentID, s.FirstName, s.LastName, s.GPA, c.Department
ORDER BY s.GPA DESC, COUNT(e.CourseID) DESC;
*/

PRINT '=== SQL PRACTICE EXERCISES COMPLETE ===';
PRINT 'Review the solutions in the commented section above to check your work!'; 