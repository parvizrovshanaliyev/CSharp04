# ADO.NET Basics - Practice Tasks

## Task 1: Basic Database Connection
Create a console application that connects to a SQL Server database and demonstrates basic ADO.NET operations.

### Requirements:
1. Create a new database named `PracticeDb`
2. Create a `Students` table with the following schema:
```sql
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Grade DECIMAL(3,2) NOT NULL
);
```

3. Implement the following operations:
   - Insert sample student data
   - Retrieve all students
   - Find students by name
   - Update student grades
   - Delete a student

### Code Structure:
```csharp
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public decimal Grade { get; set; }
}

public class DatabaseManager
{
    private readonly string _connectionString;

    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // TODO: Implement CRUD operations
}
```

## Task 2: Student Management System
Build a simple console-based Student Management System using ADO.NET.

### Features to Implement:
1. **Add New Student**
   - Collect student details from user
   - Validate input data
   - Insert into database

2. **View All Students**
   - Display in formatted table
   - Include average grade

3. **Search Students**
   - By name (partial match)
   - By grade range

4. **Update Student**
   - Modify grades
   - Update personal information

5. **Delete Student**
   - By ID
   - Confirm before deletion

### Menu System:
```csharp
while (true)
{
    Console.WriteLine("\nStudent Management System");
    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Students");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Exit");
    
    // TODO: Implement menu logic
}
```

## Task 3: Advanced Features

### Requirements:
1. **Batch Operations**
   - Add multiple students at once
   - Update multiple grades

2. **Data Export**
   - Export student data to CSV
   - Generate grade report

3. **Statistics**
   - Calculate class average
   - Find top performers
   - Generate grade distribution

4. **Error Handling**
   - Implement proper exception handling
   - Log database errors
   - User-friendly error messages

## Evaluation Criteria

### 1. Code Quality (40%)
- Proper use of ADO.NET
- Clean code structure
- Error handling
- Resource management

### 2. Functionality (30%)
- All CRUD operations working
- Correct data manipulation
- Proper validation

### 3. User Interface (20%)
- Clear menu system
- Input validation
- User feedback

### 4. Documentation (10%)
- Code comments
- README file
- Usage instructions

## Submission Requirements

1. Create a new GitHub repository
2. Include:
   - Complete source code
   - Database scripts
   - README.md with setup instructions
   - Screenshots of the application

3. Code organization:
```
Practice/
├── Models/
│   └── Student.cs
├── Services/
│   └── DatabaseManager.cs
├── Helpers/
│   └── ConsoleHelper.cs
├── Program.cs
└── README.md
```

## Getting Started

1. First, install required NuGet package:
```xml
<ItemGroup>
    <PackageReference Include="System.Data.SqlClient" Version="4.9.0" />
</ItemGroup>
```

2. Run database setup script:
```sql
USE master;
GO

CREATE DATABASE PracticeDb;
GO

USE PracticeDb;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Grade DECIMAL(3,2) NOT NULL
);
```

3. Start implementing the required features

## Deadline
- Complete all tasks within one week
- Submit GitHub repository link

Good luck with your implementation!