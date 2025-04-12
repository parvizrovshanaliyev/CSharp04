# 📁 File Handling in C# – Console App (SOLID, Clean Architecture)

Welcome to this detailed walkthrough for building a production-ready **C# Console Application** for **Note Management** using **File Handling** with `System.IO.File`. 
This guide adheres to **SOLID principles** and follows a **Clean Architecture** approach.

---

## 📘 Introduction
This tutorial demonstrates how to:
- Build a Note Manager with layered architecture (Presentation, Application, Domain, Infrastructure)
- Apply SOLID principles to enhance maintainability and scalability
- Separate business logic from infrastructure logic using interfaces and dependency injection

---

## 🛠️ Prerequisites

### Tools
- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- Visual Studio or Visual Studio Code

### Concepts
- C# classes, interfaces, and dependency injection
- Console-based input/output

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
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
```

### `IFileService` Interface
```csharp
namespace NoteApp.Domain.Interfaces;

public interface IFileService
{
    void Write(string path, string content);
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

    public void Write(string path, string content)
    {
        File.WriteAllText(path, content);
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
using NoteApp.Domain.Entities;

namespace NoteApp.Application.Interfaces;

public interface INoteService
{
    void AddNote(Note note);
    IEnumerable<Note> GetNotes();
    void DeleteAll();
    bool HasNotes();
}
```

### `NoteService` Implementation
```csharp
using System.Text.Json;
using NoteApp.Domain.Entities;
using NoteApp.Domain.Interfaces;
using NoteApp.Application.Interfaces;

namespace NoteApp.Application.Services;

public class NoteService : INoteService
{
    private readonly IFileService _fileService;
    private readonly string _filePath = "notes.json";

    public NoteService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void AddNote(Note note)
    {
        var notes = GetNotes().ToList();
        notes.Add(note);
        var json = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
        _fileService.Write(_filePath, json);
    }

    public IEnumerable<Note> GetNotes()
    {
        if (!_fileService.Exists(_filePath))
            return new List<Note>();

        var json = _fileService.Read(_filePath);
        return JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
    }

    public void DeleteAll()
    {
        _fileService.Delete(_filePath);
    }

    public bool HasNotes()
    {
        return _fileService.Exists(_filePath);
    }
}
```

---

## 🎮 Presentation Layer (Program.cs)
```csharp
using NoteApp.Domain.Entities;
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
            noteService.AddNote(new Note { Title = title, Content = content });
            Console.WriteLine("Note saved!");
            break;

        case "2":
            var notes = noteService.GetNotes();
            Console.WriteLine("\nNotes:");
            foreach (var note in notes)
            {
                Console.WriteLine($"[{note.CreatedAt}] {note.Title}: {note.Content}\n---");
            }
            break;

        case "3":
            noteService.DeleteAll();
            Console.WriteLine("All notes deleted.");
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
```

---

## ⚠️ Error Handling
```csharp
try
{
    noteService.AddNote(new Note { Title = "Test", Content = "This is a test note." });
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
```

---

## 🧱 SOLID Principles in Action
- **S** – Each class has a single responsibility.
- **O** – FileService and NoteService can be extended without modification.
- **L** – FileService and NoteService can be substituted via interfaces.
- **I** – Interfaces are small and focused (`INoteService`, `IFileService`).
- **D** – Dependencies are injected via constructors.

---

## 📚 Suggested Enhancements
- Add filtering/search by title
- Add update/delete individual note
- Export to different formats (e.g., CSV)
- Unit tests using xUnit and Moq
- Swap out file storage with EF Core (DB)

---



