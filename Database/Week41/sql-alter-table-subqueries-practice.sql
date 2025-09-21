-- =====================================================
-- Week 41: SQL ALTER TABLE & Subqueries Practice
-- Course: CSharp04 .NET Development
-- Date: 10.08.2025
-- Instructor: Parviz Rovshan Aliyev
-- =====================================================

-- =====================================================
-- STUDENT STUDY GUIDE
-- =====================================================

/*
STUDY ORDER:
1. First read and understand the examples
2. Then write the exercises yourself
3. Check the solutions
4. Try the additional difficulty level exercises
*/

-- =====================================================
-- PART 1: ALTER TABLE STATEMENTS
-- =====================================================

-- 1.1 Creating database and tables
USE master;
GO

-- Create the practice database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Week41Practice')
BEGIN
    CREATE DATABASE Week41Practice;
END
GO

USE Week41Practice;
GO

-- Create sample tables
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    HireDate DATE,
    Salary DECIMAL(10,2),
    Department VARCHAR(50)
);

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100),
    Location VARCHAR(100)
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY,
    ProjectName VARCHAR(100),
    StartDate DATE,
    EndDate DATE,
    Budget DECIMAL(12,2)
);

-- Insert sample data
INSERT INTO Employees VALUES
(1, 'John', 'Doe', 'john.doe@company.com', '2020-01-15', 65000.00, 'IT'),
(2, 'Jane', 'Smith', 'jane.smith@company.com', '2019-03-20', 72000.00, 'HR'),
(3, 'Bob', 'Johnson', 'bob.johnson@company.com', '2021-06-10', 58000.00, 'IT'),
(4, 'Alice', 'Brown', 'alice.brown@company.com', '2020-11-05', 68000.00, 'Finance'),
(5, 'Charlie', 'Wilson', 'charlie.wilson@company.com', '2022-02-28', 55000.00, 'Marketing');

INSERT INTO Departments VALUES
(1, 'Information Technology', 'Building A, Floor 3'),
(2, 'Human Resources', 'Building B, Floor 1'),
(3, 'Finance', 'Building A, Floor 2'),
(4, 'Marketing', 'Building C, Floor 1');

INSERT INTO Projects VALUES
(1, 'Website Redesign', '2024-01-01', '2024-06-30', 50000.00),
(2, 'Mobile App Development', '2024-03-01', '2024-12-31', 120000.00),
(3, 'Database Migration', '2024-02-15', '2024-05-15', 30000.00),
(4, 'Marketing Campaign', '2024-04-01', '2024-07-31', 25000.00);

-- =====================================================
-- 1.2 ADD COLUMN Examples
-- =====================================================

-- Example 1: Adding a single column
ALTER TABLE Employees 
ADD PhoneNumber VARCHAR(15);

-- Example 2: Adding multiple columns
ALTER TABLE Employees 
ADD ManagerID INT,
    IsActive BIT DEFAULT 1;

-- Example 3: Adding a column with a default value
ALTER TABLE Projects 
ADD Status VARCHAR(20) DEFAULT 'Active';

-- Example 4: Adding a column with NOT NULL constraint
ALTER TABLE Employees 
ADD EmployeeCode VARCHAR(10) NOT NULL DEFAULT 'EMP001';

-- =====================================================
-- 1.3 DROP COLUMN Examples
-- =====================================================

-- Example 1: Dropping a single column
ALTER TABLE Employees 
DROP COLUMN PhoneNumber;

-- Example 2: Dropping multiple columns
ALTER TABLE Employees 
DROP COLUMN ManagerID, IsActive;

-- Note: You cannot drop a column that is:
-- - Part of a primary key
-- - Referenced by a foreign key
-- - Used in an index
-- - Used in a check constraint

-- =====================================================
-- 1.4 RENAME COLUMN Examples
-- =====================================================

-- SQL Server doesn't have a direct RENAME COLUMN syntax
-- We need to use sp_rename stored procedure

-- Example 1: Renaming a column
EXEC sp_rename 'Employees.Email', 'EmailAddress', 'COLUMN';

-- Example 2: Renaming a table
EXEC sp_rename 'Projects', 'CompanyProjects';

-- =====================================================
-- 1.5 ALTER/MODIFY DATATYPE Examples
-- =====================================================

-- Example 1: Changing data type (if compatible)
ALTER TABLE Employees 
ALTER COLUMN Salary DECIMAL(12,2);

-- Example 2: Changing VARCHAR length
ALTER TABLE Employees 
ALTER COLUMN FirstName VARCHAR(75);

-- Example 3: Adding NOT NULL constraint
ALTER TABLE Employees 
ALTER COLUMN EmailAddress VARCHAR(100) NOT NULL;

-- =====================================================
-- EXERCISE 1: ALTER TABLE
-- =====================================================

-- Task 1: Add a 'Bonus' column to Employees table with DECIMAL(8,2) data type
ALTER TABLE Employees 
ADD Bonus DECIMAL(8,2);

-- Task 2: Add 'ProjectManager' and 'TeamSize' columns to CompanyProjects table
-- ProjectManager should be VARCHAR(100) and TeamSize should be INT
ALTER TABLE CompanyProjects 
ADD ProjectManager VARCHAR(100),
    TeamSize INT;

-- Task 3: Change the data type of Budget column to MONEY in CompanyProjects table
ALTER TABLE CompanyProjects 
ALTER COLUMN Budget MONEY;

-- Task 4: Add a 'Description' column with default value 'No description available' 
-- to CompanyProjects table with VARCHAR(500) data type
ALTER TABLE CompanyProjects 
ADD Description VARCHAR(500) DEFAULT 'No description available';

-- =====================================================
-- PART 2: SUBQUERIES
-- =====================================================

-- =====================================================
-- 2.1 Subqueries in SELECT Statement
-- =====================================================

-- Example 1: Subquery in SELECT clause
SELECT 
    FirstName,
    LastName,
    Salary,
    (SELECT AVG(Salary) FROM Employees) AS AverageSalary,
    Salary - (SELECT AVG(Salary) FROM Employees) AS SalaryDifference
FROM Employees;

-- Example 2: Subquery with WHERE clause
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- Example 3: Subquery returning multiple values with IN
SELECT FirstName, LastName, Department
FROM Employees
WHERE Department IN (SELECT DepartmentName FROM Departments WHERE Location LIKE '%Building A%');

-- =====================================================
-- 2.2 Subqueries in FROM Clause (Derived Tables)
-- =====================================================

-- Example 1: Using subquery as a table
SELECT 
    Department,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AvgSalary
FROM (SELECT Department, Salary FROM Employees) AS DeptStats
GROUP BY Department;

-- Example 2: Complex derived table
SELECT 
    e.FirstName,
    e.LastName,
    dept_stats.AvgDeptSalary
FROM Employees e
JOIN (
    SELECT 
        Department,
        AVG(Salary) AS AvgDeptSalary
    FROM Employees
    GROUP BY Department
) dept_stats ON e.Department = dept_stats.Department;

-- =====================================================
-- 2.3 Subqueries in INSERT Statement
-- =====================================================

-- Create a new table for high-salary employees
CREATE TABLE HighSalaryEmployees (
    EmployeeID INT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Salary DECIMAL(10,2),
    InsertDate DATETIME DEFAULT GETDATE()
);

-- Example: Insert employees with salary above average
INSERT INTO HighSalaryEmployees (EmployeeID, FirstName, LastName, Salary)
SELECT EmployeeID, FirstName, LastName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- =====================================================
-- 2.4 Subqueries in UPDATE Statement
-- =====================================================

-- Example 1: Update salary based on department average
UPDATE Employees
SET Salary = Salary * 1.1
WHERE Department IN (
    SELECT DepartmentName 
    FROM Departments 
    WHERE Location LIKE '%Building A%'
);

-- Example 2: Update with correlated subquery
UPDATE Employees
SET Salary = (
    SELECT AVG(Salary) * 1.05
    FROM Employees e2
    WHERE e2.Department = Employees.Department
)
WHERE Salary < (
    SELECT AVG(Salary)
    FROM Employees e3
    WHERE e3.Department = Employees.Department
);

-- =====================================================
-- 2.5 Subqueries in DELETE Statement
-- =====================================================

-- Example: Delete employees from departments with no projects
DELETE FROM Employees
WHERE Department IN (
    SELECT d.DepartmentName
    FROM Departments d
    LEFT JOIN CompanyProjects p ON d.DepartmentName = p.ProjectManager
    WHERE p.ProjectID IS NULL
);

-- =====================================================
-- 2.6 EXISTS and NOT EXISTS Subqueries
-- =====================================================

-- Example 1: Employees who have projects
SELECT FirstName, LastName
FROM Employees e
WHERE EXISTS (
    SELECT 1 
    FROM CompanyProjects p 
    WHERE p.ProjectManager = e.FirstName + ' ' + e.LastName
);

-- Example 2: Employees without any projects
SELECT FirstName, LastName
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1 
    FROM CompanyProjects p 
    WHERE p.ProjectManager = e.FirstName + ' ' + e.LastName
);

-- =====================================================
-- 2.7 Correlated Subqueries
-- =====================================================

-- Example 1: Employees with salary higher than department average
SELECT FirstName, LastName, Salary, Department
FROM Employees e1
WHERE Salary > (
    SELECT AVG(Salary)
    FROM Employees e2
    WHERE e2.Department = e1.Department
);

-- Example 2: Department with highest average salary
SELECT DepartmentName
FROM Departments d
WHERE d.DepartmentName = (
    SELECT Department
    FROM Employees
    GROUP BY Department
    HAVING AVG(Salary) = (
        SELECT MAX(AvgSalary)
        FROM (
            SELECT AVG(Salary) AS AvgSalary
            FROM Employees
            GROUP BY Department
        ) AS dept_avg
    )
);

-- =====================================================
-- EXERCISE 2: SUBQUERIES
-- =====================================================

-- Task 1: Find employees who earn more than the company average salary
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- Task 2: Find departments that have employees with salary above 60000
SELECT DISTINCT Department
FROM Employees
WHERE Department IN (
    SELECT Department 
    FROM Employees 
    WHERE Salary > 60000
);

-- Task 3: Update all IT department employees to have 15% salary increase
UPDATE Employees
SET Salary = Salary * 1.15
WHERE Department = 'IT';

-- Task 4: Find employees who work in the same department as 'John Doe'
SELECT FirstName, LastName, Department
FROM Employees
WHERE Department = (
    SELECT Department 
    FROM Employees 
    WHERE FirstName = 'John' AND LastName = 'Doe'
)
AND NOT (FirstName = 'John' AND LastName = 'Doe');

-- Task 5: Create a table with employees who have salary in top 3
CREATE TABLE TopSalaryEmployees (
    EmployeeID INT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO TopSalaryEmployees (EmployeeID, FirstName, LastName, Salary)
SELECT TOP 3 EmployeeID, FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC;

-- =====================================================
-- ADVANCED EXERCISES
-- =====================================================

-- Task 6: Find the second highest salary using subquery
SELECT MAX(Salary) AS SecondHighestSalary
FROM Employees
WHERE Salary < (SELECT MAX(Salary) FROM Employees);

-- Task 7: Find employees who earn more than the average salary of their department
SELECT e1.FirstName, e1.LastName, e1.Salary, e1.Department
FROM Employees e1
WHERE e1.Salary > (
    SELECT AVG(e2.Salary)
    FROM Employees e2
    WHERE e2.Department = e1.Department
);

-- Task 8: Update project budgets to be 10% higher than the average budget
UPDATE CompanyProjects
SET Budget = Budget * 1.10
WHERE Budget < (SELECT AVG(Budget) FROM CompanyProjects);

-- Task 9: Find departments that have more than 2 employees
SELECT Department, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY Department
HAVING COUNT(*) > 2;

-- Task 10: Create a summary table with department statistics including:
-- - Department name
-- - Employee count
-- - Average salary
-- - Maximum salary
-- - Minimum salary
CREATE TABLE DepartmentStatistics (
    DepartmentName VARCHAR(50),
    EmployeeCount INT,
    AverageSalary DECIMAL(10,2),
    MaximumSalary DECIMAL(10,2),
    MinimumSalary DECIMAL(10,2)
);

INSERT INTO DepartmentStatistics (DepartmentName, EmployeeCount, AverageSalary, MaximumSalary, MinimumSalary)
SELECT 
    Department,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AverageSalary,
    MAX(Salary) AS MaximumSalary,
    MIN(Salary) AS MinimumSalary
FROM Employees
GROUP BY Department;

-- =====================================================
-- ADDITIONAL CHALLENGE EXERCISES
-- =====================================================

-- Challenge 1: Find the employee with the highest salary in each department
SELECT e1.FirstName, e1.LastName, e1.Salary, e1.Department
FROM Employees e1
WHERE e1.Salary = (
    SELECT MAX(e2.Salary)
    FROM Employees e2
    WHERE e2.Department = e1.Department
);

-- Challenge 2: Find departments where the average salary is higher than the company average
SELECT Department, AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY Department
HAVING AVG(Salary) > (SELECT AVG(Salary) FROM Employees);

-- Challenge 3: Update employee salaries to match the highest salary in their department
UPDATE Employees
SET Salary = (
    SELECT MAX(e2.Salary)
    FROM Employees e2
    WHERE e2.Department = Employees.Department
);

-- Challenge 4: Find employees who have been with the company longer than the average tenure
SELECT FirstName, LastName, HireDate, 
       DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsWithCompany
FROM Employees
WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > (
    SELECT AVG(DATEDIFF(YEAR, HireDate, GETDATE()))
    FROM Employees
);

-- Challenge 5: Create a comprehensive employee report with department rankings including:
-- - Employee name and salary
-- - Department name
-- - Department rank (within department)
-- - Company rank (overall)
-- - Department average salary
-- - Company average salary
CREATE TABLE EmployeeComprehensiveReport (
    EmployeeName VARCHAR(101),
    Salary DECIMAL(10,2),
    Department VARCHAR(50),
    DepartmentRank INT,
    CompanyRank INT,
    DepartmentAvgSalary DECIMAL(10,2),
    CompanyAvgSalary DECIMAL(10,2)
);

INSERT INTO EmployeeComprehensiveReport
SELECT 
    e.FirstName + ' ' + e.LastName AS EmployeeName,
    e.Salary,
    e.Department,
    RANK() OVER (PARTITION BY e.Department ORDER BY e.Salary DESC) AS DepartmentRank,
    RANK() OVER (ORDER BY e.Salary DESC) AS CompanyRank,
    dept_avg.AvgSalary AS DepartmentAvgSalary,
    (SELECT AVG(Salary) FROM Employees) AS CompanyAvgSalary
FROM Employees e
JOIN (
    SELECT Department, AVG(Salary) AS AvgSalary
    FROM Employees
    GROUP BY Department
) dept_avg ON e.Department = dept_avg.Department;

-- =====================================================
-- LEARNING TIPS
-- =====================================================

/*
ALTER TABLE TIPS:
1. Always backup your data before running ALTER TABLE statements
2. Test on a small dataset first
3. Be careful with NOT NULL constraints on existing data
4. Consider the impact on indexes and foreign keys

SUBQUERY TIPS:
1. Use EXISTS instead of IN for large datasets (better performance)
2. Correlated subqueries can be expensive - use them carefully
3. Always test subqueries separately first
4. Consider using JOINs as alternatives to subqueries when possible

PERFORMANCE TIPS:
1. Use appropriate indexes on columns used in subqueries
2. Avoid nested subqueries when possible
3. Use TOP/LIMIT to limit results in subqueries
4. Consider using CTEs (Common Table Expressions) for complex queries

COMMON MISTAKES TO AVOID:
1. Forgetting to handle NULL values in subqueries
2. Not considering the impact of ALTER TABLE on existing data
3. Using subqueries that return multiple rows when expecting single row
4. Not testing ALTER TABLE statements on sample data first
*/

-- =====================================================
-- CLEANUP (Optional - run at the end)
-- =====================================================

-- Uncomment the following lines to clean up the practice database
-- USE master;
-- DROP DATABASE IF EXISTS Week41Practice;

-- =====================================================
-- SUMMARY
-- =====================================================

/*
This practice session covered:

ALTER TABLE Statements:
- ADD COLUMN: Adding single and multiple columns
- DROP COLUMN: Removing columns from tables
- RENAME COLUMN: Using sp_rename for column renaming
- ALTER COLUMN: Modifying data types and constraints

Subqueries:
- Subqueries in SELECT statements
- Derived tables in FROM clause
- Subqueries in INSERT, UPDATE, DELETE statements
- EXISTS and NOT EXISTS operators
- Correlated subqueries
- Advanced subquery patterns

Key Learning Points:
1. ALTER TABLE is used to modify table structure
2. Subqueries can be used in various parts of SQL statements
3. Correlated subqueries reference the outer query
4. EXISTS is often more efficient than IN for large datasets
5. Always test ALTER TABLE statements on sample data first
*/
