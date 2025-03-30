# 📁 File Handling in C# – Complete Guide for Beginners

## 📌 Overview
File handling in C# is the process of performing operations on files and directories such as creating, reading, writing, appending, deleting, and checking their existence. This guide is written for beginners who want to master file operations in C#. Every concept and keyword used in the code examples is explained clearly to ensure a full understanding.

---

## 📚 What is File Handling?
File handling allows programs to store and retrieve data from physical storage (like a hard disk). This means your program can keep data between runs by saving it to files.

Examples include:
- Saving a user's notes to a `.txt` file
- Logging system events
- Reading data from configuration files

---

## 🔧 Required Namespace: `System.IO`
All file and directory operations in C# are managed under the `System.IO` namespace.

Add this at the top of your C# program:
```csharp
using System.IO;
```
The `using` keyword allows us to use classes inside the `System.IO` namespace **without needing to write `System.IO.` every time**.

---

## 🛠 Important Classes in System.IO
| Class         | Description                                                                 |
|---------------|-----------------------------------------------------------------------------|
| `File`        | Provides static methods to create, read, write, and delete files.          |
| `FileInfo`    | Provides instance methods and properties for detailed file management.     |
| `Directory`   | Provides static methods to manage folders.                                 |
| `DirectoryInfo`| Instance-based directory management (like `FileInfo` for folders).        |
| `StreamWriter`| Used for writing text to files line by line.                              |
| `StreamReader`| Used for reading text from files line by line.                            |
| `FileStream`  | Low-level byte stream for advanced file operations.                       |

---

## ✍️ Writing to a File
### ✅ Method 1: `File.WriteAllText()`
```csharp
string path = "example.txt";
string content = "Hello, this is a sample text.";
File.WriteAllText(path, content);
```
- `File.WriteAllText()` is a static method.
- It creates a file if it doesn't exist.
- If the file **already exists**, its content will be **overwritten**.

### ✅ Method 2: Using `StreamWriter`
```csharp
using (StreamWriter writer = new StreamWriter("example.txt"))
{
    writer.WriteLine("This is line 1.");
    writer.WriteLine("This is line 2.");
}
```
- `StreamWriter` allows writing multiple lines efficiently.
- `using (...) {}` ensures the file is automatically closed when writing is complete.
  - This is important to **prevent file locks or data corruption**.
  - It's called a `using statement block` and is shorthand for `try-finally-dispose`.

---

## 📖 Reading from a File
### ✅ Method 1: `File.ReadAllText()`
```csharp
string content = File.ReadAllText("example.txt");
Console.WriteLine(content);
```
- Reads the **entire content** of the file into a single string.
- Best for small files.

### ✅ Method 2: `StreamReader`
```csharp
using (StreamReader reader = new StreamReader("example.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
```
- Reads the file **line by line**.
- Efficient for large files.
- `reader.ReadLine()` returns one line at a time until the end of the file is reached.

---

## ➕ Appending to a File
### ✅ Method 1: `File.AppendAllText()`
```csharp
File.AppendAllText("example.txt", "\nThis is appended text.");
```
- Adds new content **to the end** of the file without deleting the existing content.

### ✅ Method 2: `StreamWriter` with append mode
```csharp
using (StreamWriter writer = new StreamWriter("example.txt", true))
{
    writer.WriteLine("Appended line.");
}
```
- The second parameter `true` means **append mode**.
- If `false`, it would overwrite the file like in create mode.

---

## ❌ Deleting a File
```csharp
if (File.Exists("example.txt"))
{
    File.Delete("example.txt");
    Console.WriteLine("File deleted successfully.");
}
else
{
    Console.WriteLine("File not found.");
}
```
- Always check if the file exists before deleting to avoid exceptions.

---

## 🔍 Checking if a File Exists
```csharp
if (File.Exists("example.txt"))
{
    Console.WriteLine("File exists.");
}
else
{
    Console.WriteLine("File does not exist.");
}
```
- `File.Exists()` returns a boolean: `true` if the file is found.

---

## 🧰 Using `FileInfo` Class
```csharp
FileInfo fileInfo = new FileInfo("example.txt");
fileInfo.Create().Close(); // Creates and closes the file to finalize creation
fileInfo.AppendText().WriteLine("Hello from FileInfo!");
Console.WriteLine($"File size: {fileInfo.Length} bytes");
```
- `FileInfo` is an object-oriented way to interact with a file.
- Unlike the `File` class, which is static, `FileInfo` allows **instantiating objects**.
- You can reuse the same `FileInfo` object to perform multiple actions on the same file.

---

## 🔐 Using `FileStream` (Advanced)
```csharp
using (FileStream fs = new FileStream("example.dat", FileMode.Create))
{
    byte[] data = System.Text.Encoding.UTF8.GetBytes("Binary Data Example");
    fs.Write(data, 0, data.Length);
}
```
- `FileStream` works with **raw bytes**, not strings.
- Ideal for binary files like images, PDFs, executables.
- `FileMode.Create` means create a new file or overwrite an existing one.

---

## 🗂 Working with Directories
```csharp
// Create a folder if it doesn’t exist
Directory.CreateDirectory("MyFolder");

// List all files in current folder
string[] files = Directory.GetFiles("."); // '.' means current directory
foreach (string file in files)
{
    Console.WriteLine(file);
}
```
- `Directory` is a static class like `File`.
- You can use it to create folders, move them, list files, etc.

---

## 🔄 Exception Handling in File Operations
```csharp
try
{
    File.WriteAllText("test.txt", "Testing");
}
catch (IOException ex)
{
    Console.WriteLine($"IO error: {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Access error: {ex.Message}");
}
```
- `IOException`: Handles file system issues (disk full, locked file, etc.)
- `UnauthorizedAccessException`: Happens when the program lacks permission to read/write
- Always wrap file operations in `try-catch` blocks for safe execution

---

## 🧠 Summary Table
| Task          | Quick Method             | Detailed / Reusable Method         |
|---------------|--------------------------|------------------------------------|
| Write         | `File.WriteAllText()`     | `StreamWriter`                     |
| Read          | `File.ReadAllText()`      | `StreamReader`                     |
| Append        | `File.AppendAllText()`    | `StreamWriter (append: true)`      |
| Delete        | `File.Delete()`           | `FileInfo.Delete()`                |
| Exists Check  | `File.Exists()`           | `FileInfo.Exists` + reuse options  |
| Directory     | `Directory.CreateDirectory()` | `DirectoryInfo` (advanced)    |

---

## 📘 Practice Ideas for Students
1. ✅ Create a simple log file that adds a timestamp every time the program runs.
2. ✅ Write a program that copies the content of one file into another.
3. ✅ List all `.txt` files in a given directory.
4. ✅ Create a to-do list manager that stores tasks in a file.
5. ✅ Read a CSV file and display its content in a tabular format.

---

## 🌊 BONUS: Visualizing Streams
Think of a stream like a conveyor belt in a factory:
- **StreamReader** = A person reading labels off boxes on the belt.
- **StreamWriter** = A person placing labels on boxes.
- **FileStream** = The raw belt carrying everything (both text and binary).
- **BufferedStream** = A faster belt that holds multiple boxes temporarily to move in chunks.

This visualization helps students understand how each stream interacts with files behind the scenes.

---

## 📝 Additional Stream Example: Reading Binary Files
```csharp
using (FileStream fs = new FileStream("image.jpg", FileMode.Open, FileAccess.Read))
{
    byte[] buffer = new byte[fs.Length];
    fs.Read(buffer, 0, buffer.Length);
    Console.WriteLine("Image loaded as byte array with length: " + buffer.Length);
}
```
- Demonstrates how to load non-text data (like an image) into memory.
- Useful for file uploading systems, encryption, and multimedia processing.

---

## 📂 TIP: Combine Streams for Flexibility
You can **nest** streams to combine benefits:
```csharp
using (var fs = new FileStream("data.txt", FileMode.OpenOrCreate))
using (var bs = new BufferedStream(fs))
using (var sw = new StreamWriter(bs))
{
    sw.WriteLine("This is efficient AND easy to read!");
}
```
- Combines raw speed (`FileStream`), performance boost (`BufferedStream`), and simplicity (`StreamWriter`).

---

## 📚 Suggested Learning Progression
1. Understand `File` and `Directory` static methods.
2. Learn about `StreamReader` and `StreamWriter`.
3. Practice with `FileStream` and binary data.
4. Explore `BufferedStream` for optimized performance.
5. Use `try-catch` blocks to make your file-handling robust.
6. Implement real-world mini-projects (logs, to-do lists, image loaders).

---

## 📌 Final Enhancements
- ✅ Use comments in every example to help students understand step-by-step.
- ✅ Add diagrams or flowcharts in a classroom presentation to explain how streams interact.
- ✅ Encourage testing with different file sizes and types.
- ✅ Emphasize cleanup using `using` blocks or manual `.Dispose()` calls.

---

## 🌐 Understanding Streams in Detail
Streams are the backbone of file input/output in C#. A **stream** is a sequence of bytes that can be read from or written to. Think of it like water flowing through a pipe — the stream delivers data in order.

### 🔹 Common Stream Types in C#:
- **`StreamReader`** and **`StreamWriter`**:
  - Text-based stream readers and writers
  - Good for reading/writing lines of plain text

- **`FileStream`**:
  - Works at a lower level with bytes
  - Useful for binary data like images or executable files

- **`BufferedStream`**:
  - Improves efficiency by reducing the number of read/write operations
  - Wraps around another stream to add buffering capability

- **`MemoryStream`**:
  - Used when working with data in memory (e.g., copying a file into RAM temporarily)

### 🔁 Example: Using `BufferedStream` with `FileStream`
```csharp
using (FileStream fileStream = new FileStream("data.bin", FileMode.Create))
using (BufferedStream bufferedStream = new BufferedStream(fileStream))
{
    byte[] data = System.Text.Encoding.UTF8.GetBytes("Buffered stream data.");
    bufferedStream.Write(data, 0, data.Length);
}
```
- This example shows how to wrap a `BufferedStream` around a `FileStream` to improve performance.

Streams are especially powerful when working with large files, real-time data processing, or when building efficient systems that read and write frequently.

---


## 🎯 Final Thoughts
Mastering file handling in C# empowers you to build real-world applications such as loggers, data processors, file converters, configuration readers, and more. Always remember to:

- Close your file streams (`using` block helps automatically)
- Check if files/folders exist before accessing
- Handle exceptions gracefully

> "With great file access comes great responsibility. Always check, handle, and close."

Happy coding! 🚀

