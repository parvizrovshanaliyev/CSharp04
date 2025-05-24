# 📚 Student Grade Management System

## 🎯 Project Overview

The Student Grade Management System is a C# console application that demonstrates object-oriented programming principles, SOLID design patterns, and best practices in software development. The system allows users to manage student grades through a simple console interface.

### 🎯 Project Goals
- Demonstrate SOLID principles in practice
- Implement clean architecture
- Show proper error handling and validation
- Provide a maintainable and extensible codebase

## 🏗️ Architecture

The project follows a layered architecture with clear separation of concerns:

```
Project Structure
├── Models/
│   └── Student.cs           # Data model
├── Interfaces/
│   └── IStudentRepository.cs # Repository contract
├── Repositories/
│   └── StudentRepository.cs  # Data access implementation
├── Services/
│   └── StudentService.cs     # Business logic
└── Program.cs               # User interface
```

### 🔄 Data Flow

```
User Interface (Program.cs)
        ↓
Business Logic (StudentService.cs)
        ↓
Data Access (StudentRepository.cs)
        ↓
Data Storage (ArrayList)
```

### 📦 Dependencies
- .NET 6.0
- System.Collections (for ArrayList)
- System.Linq (for LINQ operations)

## 💡 Key Features

1. **Student Management**
   - Add new students with grades
   - Remove students by name
   - View all students
   - Calculate average grades

2. **Data Validation**
   - Name validation (non-empty)
   - Grade validation (0-100 range)
   - Duplicate name checking

3. **Sorting**
   - Students sorted by grade in descending order
   - Implemented using IComparable interface

## 🛠️ Technical Implementation

### 1. Student Model
```csharp
public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public double Grade { get; set; }

    public Student(string name, double grade)
    {
        Name = name;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        return other.Grade.CompareTo(Grade); // Descending order
    }
}
```

#### Key Points:
- Implements `IComparable<Student>` for sorting
- Properties with proper encapsulation
- Constructor for initialization
- Custom comparison logic for descending order

### 2. Repository Pattern
```csharp
public interface IStudentRepository
{
    void AddStudent(Student student);
    void RemoveStudent(string name);
    ArrayList GetAllStudents();
    double CalculateAverageGrade();
    bool StudentExists(string name);
}
```

#### Implementation Details:
```csharp
public class StudentRepository : IStudentRepository
{
    private readonly ArrayList _students;

    public StudentRepository()
    {
        _students = new ArrayList();
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void RemoveStudent(string name)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i] is Student student && 
                student.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                _students.RemoveAt(i);
                break;
            }
        }
    }
}
```

### 3. Service Layer
```csharp
public class StudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public bool AddStudent(string name, double grade)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        if (grade < 0 || grade > 100)
            return false;

        if (_studentRepository.StudentExists(name))
            return false;

        var student = new Student(name, grade);
        _studentRepository.AddStudent(student);
        return true;
    }
}
```

## 🎨 SOLID Principles Implementation

### 1. Single Responsibility Principle (SRP)
Each class has a single responsibility:
- `Student`: Data model and comparison logic
- `StudentRepository`: Data persistence
- `StudentService`: Business logic and validation
- `Program`: User interface and interaction

### 2. Open/Closed Principle (OCP)
The system is designed for extension:
```csharp
// Example of extending the system
public interface IGradeCalculator
{
    double CalculateGrade(Student student);
}

public class StandardGradeCalculator : IGradeCalculator
{
    public double CalculateGrade(Student student) { /* ... */ }
}

public class WeightedGradeCalculator : IGradeCalculator
{
    public double CalculateGrade(Student student) { /* ... */ }
}
```

### 3. Liskov Substitution Principle (LSP)
The `Student` class properly implements `IComparable<Student>`:
```csharp
public class Student : IComparable<Student>
{
    public int CompareTo(Student other)
    {
        return other.Grade.CompareTo(Grade);
    }
}
```

### 4. Interface Segregation Principle (ISP)
Interfaces are focused and specific:
```csharp
public interface IStudentReader
{
    Student GetStudent(string name);
    ArrayList GetAllStudents();
}

public interface IStudentWriter
{
    void AddStudent(Student student);
    void RemoveStudent(string name);
}
```

### 5. Dependency Inversion Principle (DIP)
High-level modules depend on abstractions:
```csharp
public class StudentService
{
    private readonly IStudentRepository _repository;
    
    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }
}
```

## 🔍 Code Quality Features

### 1. Error Handling
```csharp
public bool AddStudent(string name, double grade)
{
    try
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        if (grade < 0 || grade > 100)
            return false;

        // ... rest of the implementation
    }
    catch (Exception ex)
    {
        // Log the error
        return false;
    }
}
```

### 2. Code Documentation
```csharp
/// <summary>
/// Adds a new student to the system with validation.
/// </summary>
/// <param name="name">The name of the student.</param>
/// <param name="grade">The grade of the student (0-100).</param>
/// <returns>True if the student was added successfully, false otherwise.</returns>
/// <remarks>
/// This method performs the following validations:
/// - Name must not be empty
/// - Grade must be between 0 and 100
/// - Student name must not already exist
/// </remarks>
public bool AddStudent(string name, double grade)
```

## 🚀 Usage Guide

### Running the Application

1. Build the project:
```bash
dotnet build
```

2. Run the application:
```bash
dotnet run
```

### Menu Options

1. **Add Student**
   ```
   Enter name: John Doe
   Enter grade: 85.5
   ✅ Student added!
   ```

2. **Show All Students**
   ```
   📋 Students (sorted by grade):
   Name: Alice   | Grade: 92.0
   Name: John    | Grade: 85.5
   ```

3. **Show Average Grade**
   ```
   📊 Average Grade: 88.75
   ```

4. **Remove Student**
   ```
   Enter name to remove: John
   ✅ Student 'John' removed from list.
   ```

## 🔧 Future Improvements

### 1. Data Persistence
```csharp
public interface IStudentStorage
{
    void SaveStudents(IEnumerable<Student> students);
    IEnumerable<Student> LoadStudents();
}

public class FileStudentStorage : IStudentStorage
{
    private readonly string _filePath;
    
    public void SaveStudents(IEnumerable<Student> students)
    {
        // Implementation
    }
}
```

### 2. Enhanced Features
- Grade statistics (min, max, median)
- Student categories (A, B, C, etc.)
- Search functionality
- Grade history tracking

### 3. UI Improvements
- Color coding for different grade ranges
- Better formatting and alignment
- Export to CSV/Excel
- Interactive menu system

## 📝 Best Practices Demonstrated

### 1. Code Organization
```
Project/
├── Models/          # Data models
├── Interfaces/      # Contracts
├── Repositories/    # Data access
├── Services/        # Business logic
└── Program.cs       # Entry point
```

### 2. Error Handling
- Input validation
- Exception handling
- User feedback
- Graceful degradation

### 3. Documentation
- XML comments
- README documentation
- Code examples
- Usage instructions

### 4. Testing Considerations
```csharp
[TestClass]
public class StudentServiceTests
{
    private IStudentRepository _mockRepository;
    private StudentService _service;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new MockStudentRepository();
        _service = new StudentService(_mockRepository);
    }

    [TestMethod]
    public void AddStudent_ValidData_ReturnsTrue()
    {
        // Arrange
        string name = "Test Student";
        double grade = 85.0;

        // Act
        bool result = _service.AddStudent(name, grade);

        // Assert
        Assert.IsTrue(result);
    }
}
```

## 🎓 Learning Points

### 1. OOP Concepts
- **Encapsulation**: Private fields, public properties
- **Inheritance**: Interface implementation
- **Polymorphism**: Interface-based programming
- **Abstraction**: Abstract interfaces

### 2. Design Patterns
- **Repository Pattern**: Data access abstraction
- **Service Layer Pattern**: Business logic separation
- **Dependency Injection**: Loose coupling

### 3. C# Features
- **Interfaces**: Contract definition
- **Generics**: Type-safe collections
- **Collections**: ArrayList usage
- **Exception Handling**: Try-catch blocks

## 📚 References

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Repository Pattern](https://martinfowler.com/eaaCatalog/repository.html)
- [Clean Code Principles](https://www.martinfowler.com/bliki/CleanCode.html)
- [C# Best Practices](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)

## 👥 Contributing

Feel free to contribute to this project by:
1. Forking the repository
2. Creating a feature branch
3. Submitting a pull request

### Contribution Guidelines
- Follow the existing code style
- Add XML documentation
- Include unit tests
- Update the README if necessary

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

### License Terms
- Free to use for commercial and non-commercial purposes
- Must include original copyright notice
- No warranty provided 