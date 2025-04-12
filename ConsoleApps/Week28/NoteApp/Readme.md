# 📁 File Handling in C# – Console App (SOLID, Clean Architecture)

Welcome to this detailed walkthrough for building a real-world **C# Console Application** focused on **File Handling** using the `System.IO.File` class. This guide is beginner-friendly and incorporates **Object-Oriented Programming (OOP)** along with **SOLID** principles and a **Clean Architecture** style.

---

## 📘 Introduction
This tutorial walks you through building a simple Note Manager using:
- Layered architecture (Presentation, Application, Domain, Infrastructure)
- File operations (Read, Write, Append, Delete)
- SOLID design principles
- Testable and extendable service and infrastructure layers

---

## 🛠️ Prerequisites

### Tools:
- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- Visual Studio or VS Code

### Concepts:
- Classes, interfaces, and dependency injection basics
- Basic understanding of console apps

---

## 🗂️ Folder Structure

```
NoteApp/
├── Program.cs
├── Domain/
│   ├── Entities/
│   │   └── Note.cs
│   └── Interfaces/
│       └── IFileService.cs
├── Application/
│   ├── Interfaces/
│   │   └── INoteService.cs
│   └── Services/
│       └── NoteService.cs
├── Infrastructure/
│   └── FileService.cs
```

---

## 🧱 Domain Layer

### `Note` Entity
```csharp
namespace NoteApp.Domain.Entities;

public class Note
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
```

### `IFileService` Interface
```csharp
namespace NoteApp.Domain.Interfaces;

public interface IFileService
{
    void Append(string path, string content);
    string Read(string path);
    void Delete(string path);
    bool Exists(string path);
}
```

---

## ⚙️ Infrastructure Layer

### `FileService`
```csharp
using System.IO;
using NoteApp.Domain.Interfaces;

namespace NoteApp.Infrastructure;

public class FileService : IFileService
{
    public void Append(string path, string content)
    {
        File.AppendAllText(path, content);
    }

    public string Read(string path)
    {
        return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
    }

    public void Delete(string path)
    {
        if (File.Exists(path)) File.Delete(path);
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}
```

---

## 🧠 Application Layer

### `INoteService` Interface
```csharp
namespace NoteApp.Application.Interfaces;

public interface INoteService
{
    void Create(string title, string content);
    string GetAll();
    void Clear();
    bool Any();
}
```

### `NoteService` Implementation
```csharp
using NoteApp.Domain.Entities;
using NoteApp.Domain.Interfaces;
using NoteApp.Application.Interfaces;

namespace NoteApp.Application.Services;

public class NoteService : INoteService
{
    private readonly IFileService _fileService;
    private readonly string _filePath = "notes.txt";

    public NoteService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Create(string title, string content)
    {
        var note = new Note { Title = title, Content = content };
        var data = $"[{note.CreatedAt}] {note.Title}\n{note.Content}\n---\n";
        _fileService.Append(_filePath, data);
    }

    public string GetAll()
    {
        return _fileService.Exists(_filePath) ? _fileService.Read(_filePath) : "No notes available.";
    }

    public void Clear()
    {
        _fileService.Delete(_filePath);
    }

    public bool Any()
    {
        return _fileService.Exists(_filePath);
    }
}
```

---

## 🎮 Presentation Layer (Program.cs)
```csharp
using NoteApp.Domain.Interfaces;
using NoteApp.Infrastructure;
using NoteApp.Application.Interfaces;
using NoteApp.Application.Services;

IFileService fileService = new FileService();
INoteService noteService = new NoteService(fileService);
bool running = true;

while (running)
{
    Console.WriteLine("\n📘 Note Manager");
    Console.WriteLine("1. Add Note");
    Console.WriteLine("2. View Notes");
    Console.WriteLine("3. Delete All Notes");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Content: ");
            string content = Console.ReadLine();
            noteService.Create(title, content);
            Console.WriteLine("Note saved!");
            break;

        case "2":
            Console.WriteLine("\nYour Notes:");
            Console.WriteLine(noteService.GetAll());
            break;

        case "3":
            noteService.Clear();
            Console.WriteLine("All notes deleted.");
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}
```

---

## ⚠️ Error Handling
Wrap high-risk operations in `try-catch` blocks:
```csharp
try
{
    noteService.Create("Test", "This is a test.");
}
catch (IOException ex)
{
    Console.WriteLine("I/O Error: " + ex.Message);
}
```

---

## 🧱 SOLID Principles in Practice
- **S – Single Responsibility:** Each class handles one responsibility only.
- **O – Open/Closed:** Easy to extend (`IFileService`, `INoteService`) without modifying existing logic.
- **L – Liskov Substitution:** Interfaces ensure substitutable implementations.
- **I – Interface Segregation:** Services and infrastructure expose only what they need.
- **D – Dependency Inversion:** High-level modules (`NoteService`) depend on abstractions, not concrete file classes.

---

## 📚 Suggested Enhancements
- Add search/filter by title or date
- Export notes to a different format (e.g., JSON, XML)
- Add unique ID and implement note deletion by ID
- Write unit tests using Moq/xUnit for services
- Replace file storage with database (EF Core)

---

## ✅ Final Thoughts
You've successfully created a modular, testable, and SOLID-aligned console application in C#. This structure serves as a strong foundation for more advanced features and real-world applications.

Happy coding! 🚀💡

