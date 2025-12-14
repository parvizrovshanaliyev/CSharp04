# 📚 Library Management System

A console-based Library Management System built with **C# .NET 8** and **ADO.NET** for Week49 practice. This project demonstrates clean architecture principles, repository pattern, and service layer implementation.

---

## 🎯 Project Purpose

This project is designed to teach students:

1. **ADO.NET Fundamentals** - Database connections, commands, and data readers
2. **Layered Architecture** - Separation of concerns with Domain, Application, Infrastructure layers
3. **Repository Pattern** - Abstracting data access logic
4. **Service Layer** - Business logic and validation
5. **Interface-based Design** - Programming to abstractions, not implementations
6. **CRUD Operations** - Create, Read, Update, Delete operations with SQL Server

---

## 📁 Folder Structure

```
LibraryManagementSystem/
│
├── 📄 Program.cs                    # Entry point - Console UI & Menu Navigation
├── 📄 LibraryManagementSystem.csproj
├── 📄 README.md
│
├── 📂 Domain/                       # Core business entities
│   └── 📂 Entities/
│       ├── Book.cs                  # Book entity with properties
│       ├── Member.cs                # Library member entity
│       └── BookBorrowRecord.cs      # Borrow transaction entity
│
├── 📂 Application/                  # Business logic layer
│   ├── 📂 Interfaces/
│   │   ├── IBookRepository.cs       # Repository contract for Books
│   │   ├── IMemberRepository.cs     # Repository contract for Members
│   │   ├── IBookBorrowRepository.cs # Repository contract for Borrows
│   │   ├── IBookService.cs          # Service contract for Books
│   │   ├── IMemberService.cs        # Service contract for Members
│   │   └── IBookBorrowService.cs    # Service contract for Borrows
│   │
│   └── 📂 Services/
│       ├── BookService.cs           # Book business logic & validation
│       ├── MemberService.cs         # Member business logic & validation
│       └── BookBorrowService.cs     # Borrow business logic & validation
│
├── 📂 Infrastructure/               # Data access layer
│   ├── 📂 Data/
│   │   ├── DatabaseConfig.cs        # Connection string configuration
│   │   └── DatabaseSetup.sql        # SQL script to create database & tables
│   │
│   └── 📂 Repositories/
│       ├── BookRepository.cs        # ADO.NET implementation for Books
│       ├── MemberRepository.cs      # ADO.NET implementation for Members
│       └── BookBorrowRepository.cs  # ADO.NET implementation for Borrows
│
└── 📂 Presentation/                 # UI helper utilities
    └── ConsoleHelper.cs             # Input/Output helper methods
```

---

## 🏗️ Architecture Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                        PRESENTATION LAYER                        │
│  ┌─────────────────┐    ┌─────────────────────────────────┐     │
│  │   Program.cs    │    │      ConsoleHelper.cs           │     │
│  │  (Menu & UI)    │    │  (Input validation & Output)    │     │
│  └────────┬────────┘    └─────────────────────────────────┘     │
└───────────┼─────────────────────────────────────────────────────┘
            │ calls
            ▼
┌─────────────────────────────────────────────────────────────────┐
│                        APPLICATION LAYER                         │
│  ┌─────────────────────────────────────────────────────────┐    │
│  │                      Services                            │    │
│  │  BookService    MemberService    BookBorrowService       │    │
│  │  (Validation & Business Logic)                           │    │
│  └────────┬────────────────────────────────────────────────┘    │
│           │ implements                                           │
│  ┌────────▼────────────────────────────────────────────────┐    │
│  │                    Interfaces                            │    │
│  │  IBookService   IMemberService   IBookBorrowService      │    │
│  │  IBookRepository IMemberRepository IBookBorrowRepository │    │
│  └─────────────────────────────────────────────────────────┘    │
└───────────┼─────────────────────────────────────────────────────┘
            │ uses
            ▼
┌─────────────────────────────────────────────────────────────────┐
│                      INFRASTRUCTURE LAYER                        │
│  ┌─────────────────────────────────────────────────────────┐    │
│  │                    Repositories                          │    │
│  │  BookRepository  MemberRepository  BookBorrowRepository  │    │
│  │  (ADO.NET: SqlConnection, SqlCommand, SqlDataReader)     │    │
│  └────────┬────────────────────────────────────────────────┘    │
└───────────┼─────────────────────────────────────────────────────┘
            │ connects to
            ▼
┌─────────────────────────────────────────────────────────────────┐
│                         DATABASE                                 │
│           SQL Server (LibraryDB)                                │
│     Tables: Books, Members, BookBorrowRecords                   │
└─────────────────────────────────────────────────────────────────┘
```

---

## 🚀 Step-by-Step Guide to Build This Project

### Step 1: Create Project Structure

```bash
# Create new console project
dotnet new console -n LibraryManagementSystem

# Navigate to project folder
cd LibraryManagementSystem

# Add SQL Client package
dotnet add package System.Data.SqlClient
```

Create the folder structure:
```
mkdir Domain\Entities
mkdir Application\Interfaces
mkdir Application\Services
mkdir Infrastructure\Data
mkdir Infrastructure\Repositories
mkdir Presentation
```

---

### Step 2: Create Domain Entities

**Domain/Entities/Book.cs**
```csharp
namespace LibraryManagementSystem.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public override string ToString() =>
        $"[{Id}] {Title} by {Author} ({PublishedYear}) - {AvailableCopies}/{TotalCopies} available";
}
```

**Domain/Entities/Member.cs**
```csharp
namespace LibraryManagementSystem.Domain.Entities;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateTime MembershipDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString() =>
        $"[{Id}] {FullName} | {Email} | Active: {IsActive}";
}
```

**Domain/Entities/BookBorrowRecord.cs**
```csharp
namespace LibraryManagementSystem.Domain.Entities;

public class BookBorrowRecord
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;
    public int DaysOverdue => IsOverdue ? (DateTime.Now - DueDate).Days : 0;

    public override string ToString() =>
        $"[{Id}] BookId:{BookId} MemberId:{MemberId} | Due:{DueDate:d} | Returned:{IsReturned}";
}
```

---

### Step 3: Create Repository Interfaces

**Application/Interfaces/IBookRepository.cs**
```csharp
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

public interface IBookRepository
{
    List<Book> GetAll();
    Book? GetById(int id);
    int Add(Book book);
    bool Update(Book book);
    bool Delete(int id);
}
```

> Create similar interfaces for `IMemberRepository` and `IBookBorrowRepository`

---

### Step 4: Create Service Interfaces

**Application/Interfaces/IBookService.cs**
```csharp
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

public interface IBookService
{
    List<Book> GetAllBooks();
    Book? GetBookById(int id);
    int AddBook(Book book);
    bool UpdateBook(Book book);
    bool DeleteBook(int id);
}
```

> Create similar interfaces for `IMemberService` and `IBookBorrowService`

---

### Step 5: Configure Database Connection

**Infrastructure/Data/DatabaseConfig.cs**
```csharp
namespace LibraryManagementSystem.Infrastructure.Data;

public static class DatabaseConfig
{
    public static string ConnectionString =>
        "Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
}
```

---

### Step 6: Implement Repositories with ADO.NET

**Infrastructure/Repositories/BookRepository.cs**
```csharp
using System.Data.SqlClient;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _connectionString;

    public BookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Book> GetAll()
    {
        var books = new List<Book>();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT * FROM Books", connection);
        
        connection.Open();
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            books.Add(MapToEntity(reader));
        }

        return books;
    }

    public Book? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using var reader = command.ExecuteReader();
        
        return reader.Read() ? MapToEntity(reader) : null;
    }

    public int Add(Book book)
    {
        const string sql = @"
            INSERT INTO Books (Title, Author, ISBN, PublishedYear, Genre, TotalCopies, AvailableCopies)
            VALUES (@Title, @Author, @ISBN, @PublishedYear, @Genre, @TotalCopies, @AvailableCopies);
            SELECT SCOPE_IDENTITY();";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@ISBN", book.ISBN);
        command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@Genre", book.Genre);
        command.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
        command.Parameters.AddWithValue("@AvailableCopies", book.TotalCopies);

        connection.Open();
        return Convert.ToInt32(command.ExecuteScalar());
    }

    public bool Update(Book book)
    {
        const string sql = @"
            UPDATE Books SET 
                Title = @Title, Author = @Author, ISBN = @ISBN,
                PublishedYear = @PublishedYear, Genre = @Genre,
                TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies,
                UpdatedAt = GETDATE()
            WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@Id", book.Id);
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@ISBN", book.ISBN);
        command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@Genre", book.Genre);
        command.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
        command.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("DELETE FROM Books WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        return command.ExecuteNonQuery() > 0;
    }

    private static Book MapToEntity(SqlDataReader reader) => new()
    {
        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        Title = reader.GetString(reader.GetOrdinal("Title")),
        Author = reader.GetString(reader.GetOrdinal("Author")),
        ISBN = reader.GetString(reader.GetOrdinal("ISBN")),
        PublishedYear = reader.GetInt32(reader.GetOrdinal("PublishedYear")),
        Genre = reader.GetString(reader.GetOrdinal("Genre")),
        TotalCopies = reader.GetInt32(reader.GetOrdinal("TotalCopies")),
        AvailableCopies = reader.GetInt32(reader.GetOrdinal("AvailableCopies")),
        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) 
            ? null 
            : reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
    };
}
```

---

### Step 7: Implement Services with Validation

**Application/Services/BookService.cs**
```csharp
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public List<Book> GetAllBooks() => _repository.GetAll();
    
    public Book? GetBookById(int id) => _repository.GetById(id);

    public int AddBook(Book book)
    {
        ValidateBook(book);
        return _repository.Add(book);
    }

    public bool UpdateBook(Book book)
    {
        ValidateBook(book);
        return _repository.Update(book);
    }

    public bool DeleteBook(int id) => _repository.Delete(id);

    private void ValidateBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Title is required.");
        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Author is required.");
        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("ISBN is required.");
        if (book.PublishedYear < 1800 || book.PublishedYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid published year.");
        if (book.TotalCopies < 1)
            throw new ArgumentException("Total copies must be at least 1.");
    }
}
```

---

### Step 8: Create Console Helper

**Presentation/ConsoleHelper.cs**
```csharp
namespace LibraryManagementSystem.Presentation;

public static class ConsoleHelper
{
    public static int ReadInt(string prompt, int? defaultValue = null)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) && defaultValue.HasValue)
                return defaultValue.Value;

            if (int.TryParse(input, out int result))
                return result;

            PrintError("Please enter a valid number.");
        }
    }

    public static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            PrintError("This field is required.");
        }
    }

    public static void PrintSuccess(string msg) => Console.WriteLine($"✅ [SUCCESS] {msg}");
    public static void PrintError(string msg) => Console.WriteLine($"❌ [ERROR] {msg}");
    public static void PrintInfo(string msg) => Console.WriteLine($"ℹ️ [INFO] {msg}");
}
```

---

### Step 9: Create Database

Run the SQL script in **Infrastructure/Data/DatabaseSetup.sql** in SQL Server Management Studio (SSMS) to create:
- `LibraryDB` database
- `Books` table
- `Members` table
- `BookBorrowRecords` table
- Sample data

---

### Step 10: Wire Everything in Program.cs

```csharp
using LibraryManagementSystem.Application.Services;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories;

var connectionString = DatabaseConfig.ConnectionString;
var bookService = new BookService(new BookRepository(connectionString));
var memberService = new MemberService(new MemberRepository(connectionString));
var borrowService = new BookBorrowService(new BookBorrowRepository(connectionString));

// Create menu and call services...
```

---

## 🏃 How to Run

1. **Prerequisites:**
   - .NET 8 SDK
   - SQL Server (LocalDB or Express)

2. **Setup Database:**
   ```bash
   # Run DatabaseSetup.sql in SSMS or Azure Data Studio
   ```

3. **Run the Application:**
   ```bash
   dotnet run
   ```

---

## 📝 Student Tasks (Practice)

After completing the basic CRUD operations, try implementing these features:

### Task 1: Search Methods
Add search functionality to services:
```csharp
// IBookService.cs
List<Book> SearchByTitle(string title);
List<Book> SearchByAuthor(string author);
List<Book> GetAvailableBooks();

// IMemberService.cs
List<Member> SearchByName(string name);
Member? GetByEmail(string email);
```

### Task 2: Borrow Operations
Implement these business logic methods:
```csharp
// IBookBorrowService.cs
bool BorrowBook(int bookId, int memberId);  // Decrease AvailableCopies
bool ReturnBook(int borrowId);               // Increase AvailableCopies
bool ExtendDueDate(int borrowId, int days);
List<BookBorrowRecord> GetOverdueBooks();
List<BookBorrowRecord> GetMemberBorrowHistory(int memberId);
```

### Task 3: Reports
Create report methods:
```csharp
// Statistics
int GetTotalBooks();
int GetTotalMembers();
int GetActiveBorrows();
List<Book> GetMostBorrowedBooks(int top = 10);
```

### Task 4: Input Validation
Enhance validation:
- ISBN format validation (10 or 13 digits)
- Email format validation
- Phone number format validation
- Duplicate ISBN check before adding book
- Duplicate email check before adding member

---

## 🔑 Key Concepts Learned (Detailed Explanations)

### 1. ADO.NET (ActiveX Data Objects for .NET)

ADO.NET is Microsoft's data access technology that allows .NET applications to communicate with databases. It provides a bridge between your C# code and SQL Server.

**Core Components:**

| Component | Purpose | Example |
|-----------|---------|---------|
| `SqlConnection` | Opens a connection to the database | `new SqlConnection(connectionString)` |
| `SqlCommand` | Executes SQL queries or stored procedures | `new SqlCommand("SELECT * FROM Books", connection)` |
| `SqlDataReader` | Reads data row by row (forward-only, read-only) | `command.ExecuteReader()` |
| `SqlParameter` | Prevents SQL injection by parameterizing queries | `command.Parameters.AddWithValue("@Id", id)` |

**Connection Lifecycle:**
```csharp
// 1. Create connection
using var connection = new SqlConnection(connectionString);

// 2. Create command
using var command = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", connection);

// 3. Add parameters (NEVER concatenate strings - SQL Injection risk!)
command.Parameters.AddWithValue("@Id", bookId);

// 4. Open connection
connection.Open();

// 5. Execute and read
using var reader = command.ExecuteReader();
while (reader.Read())
{
    // Process each row
}
// 6. Connection automatically closed by 'using' statement
```

**Execute Methods:**
| Method | Returns | Use Case |
|--------|---------|----------|
| `ExecuteReader()` | SqlDataReader | SELECT queries (multiple rows) |
| `ExecuteScalar()` | Single value (object) | COUNT, MAX, INSERT with IDENTITY |
| `ExecuteNonQuery()` | Affected row count (int) | INSERT, UPDATE, DELETE |

---

### 2. Repository Pattern

The Repository Pattern creates an abstraction layer between your business logic and data access code. Think of it as a "collection" of domain objects that hides the database complexity.

**Why Use Repository Pattern?**

| Without Repository | With Repository |
|-------------------|-----------------|
| SQL code scattered everywhere | SQL code in one place |
| Hard to test (database dependency) | Easy to mock for unit tests |
| Changing database requires many changes | Change only repository implementation |
| Business logic mixed with data access | Clean separation of concerns |

**Repository Structure:**
```
IBookRepository (Interface - Contract)
        ↓
BookRepository (Implementation - ADO.NET)
```

**Example:**
```csharp
// Interface - defines WHAT operations are available
public interface IBookRepository
{
    List<Book> GetAll();          // Read all
    Book? GetById(int id);        // Read one
    int Add(Book book);           // Create
    bool Update(Book book);       // Update
    bool Delete(int id);          // Delete
}

// Implementation - defines HOW operations work
public class BookRepository : IBookRepository
{
    public List<Book> GetAll()
    {
        // ADO.NET code here
    }
}
```

**Benefits:**
- ✅ **Testability**: Mock the interface for unit tests
- ✅ **Maintainability**: Database changes don't affect business logic
- ✅ **Flexibility**: Easy to switch databases (SQL Server → PostgreSQL)
- ✅ **Single Responsibility**: Repository only handles data access

---

### 3. Service Layer

The Service Layer contains your application's business logic and validation rules. It sits between the UI (Program.cs) and the Repository.

**Responsibilities:**
| Service Does | Service Does NOT |
|--------------|------------------|
| Validate input data | Access database directly |
| Apply business rules | Handle UI concerns (Console.WriteLine) |
| Orchestrate multiple repositories | Know about SQL or ADO.NET |
| Throw meaningful exceptions | Format output for display |

**Example - Validation in Service:**
```csharp
public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public int AddBook(Book book)
    {
        // Business validation - Service responsibility
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Title is required.");
        
        if (book.PublishedYear > DateTime.Now.Year)
            throw new ArgumentException("Published year cannot be in the future.");
        
        if (book.TotalCopies < 1)
            throw new ArgumentException("Must have at least 1 copy.");

        // Delegate to repository - data access
        return _repository.Add(book);
    }
}
```

**Service vs Repository:**
```
┌─────────────────────────────────────────────────────────────┐
│ SERVICE (BookService)                                       │
│ - Validates: Title not empty? Year valid? Copies > 0?       │
│ - Business Rules: Can member borrow more books?             │
│ - Orchestration: Update book AND create borrow record       │
└─────────────────────────┬───────────────────────────────────┘
                          │ calls
                          ▼
┌─────────────────────────────────────────────────────────────┐
│ REPOSITORY (BookRepository)                                 │
│ - CRUD only: GetAll, GetById, Add, Update, Delete           │
│ - No business logic, no validation                          │
│ - Pure data access with ADO.NET                             │
└─────────────────────────────────────────────────────────────┘
```

---

### 4. Interfaces (Contracts)

An interface defines a contract - a set of methods that implementing classes MUST provide. It enables loose coupling and dependency injection.

**Why Interfaces?**

```csharp
// WITHOUT Interface - Tight Coupling ❌
public class BookService
{
    private readonly BookRepository _repository = new BookRepository();
    // Problem: BookService is tightly coupled to BookRepository
    // Cannot test without real database
    // Cannot switch to different repository
}

// WITH Interface - Loose Coupling ✅
public class BookService
{
    private readonly IBookRepository _repository;
    
    public BookService(IBookRepository repository)
    {
        _repository = repository;  // Any implementation works!
    }
}
```

**Interface Benefits:**
| Benefit | Explanation |
|---------|-------------|
| **Testability** | Pass a mock/fake repository for unit tests |
| **Flexibility** | Swap implementations without changing code |
| **Abstraction** | Hide implementation details |
| **Contract** | Clear definition of what operations exist |

**Real-World Analogy:**
```
Interface = USB Port (standard contract)
Implementation = USB Drive, USB Mouse, USB Keyboard (different implementations)

Your computer doesn't care WHAT is plugged in,
as long as it follows the USB interface contract.
```

---

### 5. Dependency Injection (DI)

Dependency Injection is a design pattern where dependencies are "injected" from outside rather than created inside a class.

**Types of Injection:**

```csharp
// 1. CONSTRUCTOR INJECTION (Recommended) ✅
public class BookService
{
    private readonly IBookRepository _repository;
    
    public BookService(IBookRepository repository)  // Injected via constructor
    {
        _repository = repository;
    }
}

// 2. PROPERTY INJECTION
public class BookService
{
    public IBookRepository Repository { get; set; }  // Injected via property
}

// 3. METHOD INJECTION
public class BookService
{
    public void DoSomething(IBookRepository repository)  // Injected per method
    {
    }
}
```

**DI in Our Project:**
```csharp
// Program.cs - Composition Root (where we wire everything)
var connectionString = DatabaseConfig.ConnectionString;

// Create repositories (concrete implementations)
IBookRepository bookRepository = new BookRepository(connectionString);

// Inject repository into service
IBookService bookService = new BookService(bookRepository);

// Now bookService uses bookRepository internally
var books = bookService.GetAllBooks();
```

**Benefits of DI:**
- ✅ **Testability**: Inject mock repositories for testing
- ✅ **Flexibility**: Change implementations without modifying code
- ✅ **Single Responsibility**: Classes don't create their own dependencies
- ✅ **Explicit Dependencies**: Clear what a class needs to function

---

### 6. Layered Architecture

Layered Architecture organizes code into horizontal layers, each with a specific responsibility. Higher layers depend on lower layers, but NOT vice versa.

**Our Project Layers:**

```
┌─────────────────────────────────────────────────────────────┐
│ LAYER 1: PRESENTATION (UI)                                  │
│ ─────────────────────────                                   │
│ Files: Program.cs, ConsoleHelper.cs                         │
│ Purpose: User interaction, display, input                   │
│ Knows About: Application Layer (Services)                   │
│ Does NOT Know: Infrastructure (Repositories, Database)      │
└─────────────────────────────────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│ LAYER 2: APPLICATION (Business Logic)                       │
│ ────────────────────────────────────                        │
│ Files: Services/, Interfaces/                               │
│ Purpose: Business rules, validation, orchestration          │
│ Knows About: Domain Layer (Entities)                        │
│ Does NOT Know: Infrastructure (how data is stored)          │
└─────────────────────────────────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│ LAYER 3: DOMAIN (Core Business Entities)                    │
│ ────────────────────────────────────────                    │
│ Files: Entities/                                            │
│ Purpose: Define business objects (Book, Member, etc.)       │
│ Knows About: Nothing (pure, no dependencies)                │
│ Does NOT Know: How it's stored or displayed                 │
└─────────────────────────────────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│ LAYER 4: INFRASTRUCTURE (Data Access)                       │
│ ──────────────────────────────────────                      │
│ Files: Repositories/, Data/                                 │
│ Purpose: Database communication, ADO.NET, SQL               │
│ Knows About: Domain (entities), Database                    │
│ Implements: Repository interfaces from Application          │
└─────────────────────────────────────────────────────────────┘
```

**Dependency Rule:**
```
✅ Allowed: Presentation → Application → Domain
✅ Allowed: Infrastructure → Domain (implements interfaces)
❌ Not Allowed: Domain → Infrastructure
❌ Not Allowed: Application → Presentation
```

**Benefits:**
| Benefit | Explanation |
|---------|-------------|
| **Separation of Concerns** | Each layer has one job |
| **Maintainability** | Change one layer without affecting others |
| **Testability** | Test each layer independently |
| **Reusability** | Use same business logic with different UI |
| **Scalability** | Easy to add new features |

---

### 7. CRUD Operations

CRUD represents the four basic operations for persistent storage:

| Operation | SQL | ADO.NET Method | HTTP Verb |
|-----------|-----|----------------|-----------|
| **C**reate | INSERT | ExecuteScalar() | POST |
| **R**ead | SELECT | ExecuteReader() | GET |
| **U**pdate | UPDATE | ExecuteNonQuery() | PUT/PATCH |
| **D**elete | DELETE | ExecuteNonQuery() | DELETE |

**CRUD in Repository:**
```csharp
public class BookRepository : IBookRepository
{
    // CREATE
    public int Add(Book book)
    {
        const string sql = "INSERT INTO Books (...) VALUES (...); SELECT SCOPE_IDENTITY();";
        return Convert.ToInt32(command.ExecuteScalar());
    }

    // READ (All)
    public List<Book> GetAll()
    {
        const string sql = "SELECT * FROM Books";
        // Use ExecuteReader()
    }

    // READ (Single)
    public Book? GetById(int id)
    {
        const string sql = "SELECT * FROM Books WHERE Id = @Id";
        // Use ExecuteReader()
    }

    // UPDATE
    public bool Update(Book book)
    {
        const string sql = "UPDATE Books SET ... WHERE Id = @Id";
        return command.ExecuteNonQuery() > 0;
    }

    // DELETE
    public bool Delete(int id)
    {
        const string sql = "DELETE FROM Books WHERE Id = @Id";
        return command.ExecuteNonQuery() > 0;
    }
}
```

---

### 8. SQL Injection Prevention

SQL Injection is a security vulnerability where malicious SQL is inserted into queries. **ALWAYS use parameterized queries!**

**❌ DANGEROUS - SQL Injection Vulnerable:**
```csharp
// NEVER DO THIS!
string sql = "SELECT * FROM Books WHERE Title = '" + userInput + "'";

// If userInput = "'; DROP TABLE Books; --"
// Result: SELECT * FROM Books WHERE Title = ''; DROP TABLE Books; --'
// Your table is deleted!
```

**✅ SAFE - Parameterized Query:**
```csharp
// ALWAYS DO THIS!
string sql = "SELECT * FROM Books WHERE Title = @Title";
command.Parameters.AddWithValue("@Title", userInput);

// Parameters are escaped automatically
// Malicious input is treated as literal string
```

---

### 9. Using Statement & IDisposable

The `using` statement ensures resources are properly disposed (closed/released) even if an exception occurs.

**Why It Matters:**
```csharp
// WITHOUT using - Resource leak risk ❌
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();
// If exception here, connection stays open!
// Eventually: "Max pool size reached" error

// WITH using - Automatic cleanup ✅
using var connection = new SqlConnection(connectionString);
connection.Open();
// Connection automatically closed when scope ends
// Even if exception occurs!
```

**Equivalent Code:**
```csharp
// using statement
using var connection = new SqlConnection(connectionString);

// Is equivalent to:
SqlConnection connection = new SqlConnection(connectionString);
try
{
    // your code
}
finally
{
    connection?.Dispose();  // Always runs, closes connection
}
```

---

## 📚 Resources

- [ADO.NET Documentation](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Clean Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)

---

## 📄 License

This project is for educational purposes - Week49 ADO.NET Practice.

---

**Happy Coding! 🚀**
