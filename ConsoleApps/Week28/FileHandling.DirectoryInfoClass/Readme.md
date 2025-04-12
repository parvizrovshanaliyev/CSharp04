# 📁 File Handling in C# – `DirectoryInfo` Class

Welcome to this beginner-friendly guide focused on the `DirectoryInfo` class in C#. If you're new to working with file systems, directories, and automation in C#, this guide will help you understand and apply `DirectoryInfo` in practical, real-world scenarios.

---

## 🎓 Target Audience
- Students and beginner developers new to working with directories in C#
- Learners who want to understand the `System.IO.DirectoryInfo` class in depth
- Developers looking to handle folder creation, metadata, file listing, and deletion operations programmatically

---

## 📘 Introduction
**Directory handling** allows C# applications to create, navigate, read from, and manipulate folder structures.

C# provides powerful tools in the `System.IO` namespace for handling files and directories.
- `DirectoryInfo` is used for **object-oriented, instance-based** directory operations.
- `Directory` is used for **static, one-time** operations.

---

## 📂 What is `DirectoryInfo`?
The `DirectoryInfo` class provides a way to interact with directories using object-oriented principles.

### 🔍 Why Use `DirectoryInfo`?
- You want to repeatedly work with a directory
- You need to access metadata (e.g., `CreationTime`, `LastAccessTime`)
- You want cleaner code using reusable instances

### 🔁 `DirectoryInfo` vs `Directory`
| Feature                     | `Directory` (Static)         | `DirectoryInfo` (Instance)          |
|----------------------------|------------------------------|-------------------------------------|
| Usage Style                | Utility-like, quick usage    | Object-oriented, reusable           |
| Metadata Access            | Limited                      | Rich metadata support               |
| Performance (multiple ops) | Resolves path every call     | Caches metadata and path info       |
| Best For                   | One-off directory operations | Managing folders across multiple ops|

---

## 🛠️ Core Functionality with Code Examples

### ✅ Creating a Directory
```csharp
// Create a new directory if it doesn't exist
DirectoryInfo dir = new DirectoryInfo("MyData");
if (!dir.Exists)
{
    dir.Create();
    Console.WriteLine("Directory created successfully.");
}
```

### ✅ Checking Directory Existence
```csharp
// Check if directory exists before performing operations
if (dir.Exists)
{
    Console.WriteLine("Directory exists: " + dir.FullName);
}
```

### ✅ Getting Directory Metadata
```csharp
Console.WriteLine($"Created on: {dir.CreationTime}");
Console.WriteLine($"Last modified: {dir.LastWriteTime}");
```

### ✅ Listing Files in a Directory
```csharp
// Get all files in the directory
FileInfo[] files = dir.GetFiles();
foreach (var file in files)
{
    Console.WriteLine(file.Name);
}
```

### ✅ Listing Subdirectories
```csharp
// Get all subdirectories in the current directory
DirectoryInfo[] subDirs = dir.GetDirectories();
foreach (var sub in subDirs)
{
    Console.WriteLine("Subdirectory: " + sub.Name);
}
```

### ✅ Filtering Files (e.g., only .txt files)
```csharp
// Get only .txt files
FileInfo[] textFiles = dir.GetFiles("*.txt");
foreach (var txt in textFiles)
{
    Console.WriteLine(txt.Name);
}
```

### ✅ Deleting a Directory
```csharp
// Caution: Only deletes empty directories
if (dir.Exists)
{
    dir.Delete();
    Console.WriteLine("Directory deleted.");
}
```

### ✅ Recursively Deleting a Directory
```csharp
// Recursively delete a non-empty directory
DirectoryInfo logs = new DirectoryInfo("Logs");
if (logs.Exists)
{
    logs.Delete(true); // 'true' means recursive delete
    Console.WriteLine("Logs directory and contents deleted.");
}
```

---

## 🧼 Best Practices
- ✅ Always check `Exists` before deleting or modifying directories
- ✅ Use `Path.Combine()` instead of manually joining paths with slashes
- ✅ Handle exceptions such as `DirectoryNotFoundException` and `UnauthorizedAccessException`
- ✅ Use recursive deletion carefully — it permanently removes contents
- ✅ Prefer `DirectoryInfo` for reusable logic or when accessing metadata

---

## ⚠️ Common Pitfalls
- ❌ Trying to get metadata from a non-existent directory
- ❌ Deleting directories that still contain files or subfolders without recursive flag
- ❌ Using hardcoded paths (use `Path.Combine` for portability)
- ❌ Assuming all subdirectories are accessible (permission issues)

---

## 🛠️ Real-World Exercise – CLI Folder Inspector
Build a small console app that:
- Accepts a directory path from the user
- Lists all `.txt` files and their sizes
- Displays creation and last modified time for each
- Exports this info to a CSV file (`DirectoryReport.csv`)

> 💡 Bonus: Add options to filter by date or extension

---

## 📚 Additional Resources
- 📖 [Microsoft Docs – DirectoryInfo](https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo)
- 📺 [YouTube: C# DirectoryInfo Tutorials](https://www.youtube.com/results?search_query=DirectoryInfo+C%23)
- 📘 Recommended: *C# 12 and .NET 8 Modern Cross-Platform Development* by Mark J. Price

---

## ✅ Conclusion
The `DirectoryInfo` class provides an easy and powerful way to interact with folders in your filesystem. It’s perfect for file explorers, backup tools, log processors, and any app that works with structured folders.

Now that you understand how to create, inspect, filter, and delete directories — try building something real with it!

> 🚀 **Next Step:** Combine `DirectoryInfo` with `FileInfo` to create a complete file system manager.

Happy coding! 💻

