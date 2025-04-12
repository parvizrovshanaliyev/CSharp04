# 📁 Complete Guide to File Handling in C#

This is a detailed and practical guide for learning **file input/output (I/O)** in C#. If you're new to working with files, this document will introduce you to the essential file handling components in the .NET ecosystem. You'll learn everything from reading and writing basic text files to working with binary data, directories, and even exporting data to Excel.

---

## 🎓 Target Audience
This guide is designed for:
- Students and beginner developers new to file I/O in C#
- .NET learners looking to explore the `System.IO` namespace
- Developers who want a structured and real-world understanding of file handling classes

No prior file handling experience is needed — this is beginner-friendly and starts from the basics.

---

## 📘 What is File Handling?
**File handling** refers to reading from, writing to, creating, deleting, and managing files using code. In C#, file handling is done using the `System.IO` namespace. It’s crucial for:
- Reading/writing logs and reports
- Saving user-generated content
- Importing/exporting data
- Configuration storage

---

## 🧭 Overview of `System.IO` Namespace
The `System.IO` namespace offers a comprehensive set of classes to work with files, directories, and data streams:

### File Operation Classes
- `File` – Static helper class for one-off file operations
- `FileInfo` – Object-oriented approach with metadata access
- `FileStream` – Low-level byte stream access

### Text/Binary Reader-Writer Classes
- `StreamReader` / `StreamWriter` – For reading/writing text data
- `TextReader` / `TextWriter` – Abstract base classes for text streams
- `BinaryReader` / `BinaryWriter` – For structured binary data
- `StringReader` / `StringWriter` – In-memory stream equivalents for strings

### Directory Operation Classes
- `Directory` – Static methods for managing directories
- `DirectoryInfo` – Object-oriented directory operations

---

## 🧱 Core Topics with Code Examples
Each of the following sections introduces a key class or concept used in file handling:

### ✅ File Handling in C# (Concept Overview)
Includes:
- Absolute vs relative paths
- Text vs binary files
- File encodings (`UTF8`, `Unicode`, etc.)
- File modes (`Create`, `Append`, `Open`, etc.)

```csharp
// Safely combine directory and filename using Path.Combine
string path = Path.Combine(Environment.CurrentDirectory, "notes.txt");
```

### ✅ FileStream Class
For byte-level control over file contents.
```csharp
// Create a new file and write raw bytes to it
using var fs = new FileStream("data.bin", FileMode.Create);
byte[] buffer = { 0x10, 0x20, 0x30 }; // sample bytes to write
fs.Write(buffer, 0, buffer.Length); // write the bytes to file
```

### ✅ StreamReader and StreamWriter
For simple text file operations.
```csharp
// Write to a text file
using var writer = new StreamWriter("hello.txt");
writer.WriteLine("Hello, world!");

// Read the file content
using var reader = new StreamReader("hello.txt");
string content = reader.ReadToEnd();
Console.WriteLine(content);
```

### ✅ File Class
Static class for quick file manipulations.
```csharp
// Write text to file in one line
File.WriteAllText("log.txt", "Started on: " + DateTime.Now);

// Read all contents from the file
string log = File.ReadAllText("log.txt");
```

### ✅ TextReader and TextWriter
Base classes for working with text streams.
```csharp
// Write using abstract base class TextWriter
TextWriter tw = new StreamWriter("output.txt");
tw.WriteLine("TextWriter in action");
tw.Close();
```

### ✅ BinaryReader and BinaryWriter
Best for storing primitive types or binary-formatted data.
```csharp
// Create and write binary data to a file
using var bw = new BinaryWriter(File.Open("info.dat", FileMode.Create));
bw.Write(1234);      // Write an integer
bw.Write(true);      // Write a boolean
bw.Write(3.14);      // Write a double
```

### ✅ StringWriter and StringReader
For in-memory string-based data manipulation.
```csharp
// Use StringWriter to write to memory instead of disk
StringWriter sw = new StringWriter();
sw.WriteLine("Memory-based string output");
string result = sw.ToString(); // retrieve the written content
```

### ✅ FileInfo Class
OOP-based file handler for metadata and reusable logic.
```csharp
// Create and get file metadata using FileInfo
var file = new FileInfo("sample.txt");
if (!file.Exists) file.Create().Close(); // create file if not exists
Console.WriteLine(file.Length);          // print file size
Console.WriteLine(file.CreationTime);    // print creation timestamp
```

### ✅ DirectoryInfo Class
For creating, deleting, and listing directories.
```csharp
// Work with folders using DirectoryInfo
var dir = new DirectoryInfo("Reports");
if (!dir.Exists) dir.Create(); // create the directory if it doesn't exist

// List all files in the directory
foreach (var file in dir.GetFiles())
{
    Console.WriteLine(file.Name);
}
```

### ✅ Export and Import Excel Data (Advanced)
Using the EPPlus library (install via NuGet).
```csharp
// Create and write to Excel using EPPlus
using var package = new ExcelPackage(new FileInfo("report.xlsx"));
var sheet = package.Workbook.Worksheets.Add("Sheet1");
sheet.Cells[1, 1].Value = "Header";
sheet.Cells[2, 1].Value = "Row 1";
package.Save();
```

---

## 🧼 Best Practices
- Use `using` statements to auto-dispose streams and avoid file locks.
- Always check file or directory existence with `File.Exists` / `Directory.Exists`.
- Use `Path.Combine()` instead of string concatenation for paths.
- Handle specific exceptions (`IOException`, `UnauthorizedAccessException`) for robustness.
- Avoid hardcoded file paths — consider using `Environment.GetFolderPath()`.

---

## ⚠️ Common Pitfalls
- Forgetting to dispose or close file streams (can lock the file)
- Overwriting files with `FileMode.Create` without checking existence
- Using incorrect encoding (e.g., writing UTF-8 and reading as ASCII)
- Assuming file paths are always valid on all operating systems
- Not catching file-related exceptions (e.g., file in use, access denied)

---

## 🛠️ Real-World Mini Project Idea
### CLI-Based File Utility
Build a console tool that:
- Lists files in a directory
- Filters by extension or modified date
- Reads and displays file size, type, and creation date
- Supports file copy, move, rename, and delete
- Exports a report to Excel or CSV

---

## 📚 Recommended Learning Resources
- 📖 [Microsoft Docs – System.IO Overview](https://learn.microsoft.com/en-us/dotnet/api/system.io)
- 🎓 [C# File Handling Course – YouTube](https://www.youtube.com/results?search_query=file+handling+in+c%23)
- 📘 *Pro C# 9 with .NET 5* by Andrew Troelsen (APress)
- 🔧 [EPPlus Documentation – Excel Library](https://github.com/EPPlusSoftware/EPPlus)

---

## ✅ Final Thoughts
Mastering file handling in C# enables you to build robust applications that deal with local data storage, logs, backups, and document manipulation. With the tools and practices in this guide, you now have the confidence to implement file features in real-world software.

> 💡 **Challenge:** Extend your mini project to include support for reading JSON/XML configuration files and writing logs to a local `.log` file.

Happy coding! 🚀

