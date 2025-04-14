# Week 28 - File Handling and Resource Management Tasks

## Overview
This set of tasks is designed to help you practice and understand file handling, resource management, and the implementation of the IDisposable pattern in C#. You'll work with various file operations, handle resources properly, and implement best practices for resource cleanup.

## Task 1: Log File Manager
Create a `LogFileManager` class that implements proper resource management for writing logs to a file.

### Requirements:
1. Implement the `IDisposable` interface
2. Use `StreamWriter` for writing logs
3. Include methods:
   - `WriteLog(string message)`: Writes a timestamped log entry
   - `WriteError(string error)`: Writes a timestamped error entry
   - `GetLogSize()`: Returns the current size of the log file
4. Implement proper resource cleanup in the Dispose pattern
5. Include both managed and unmanaged resource handling

### Example Usage:
```csharp
using (var logManager = new LogFileManager("application.log"))
{
    logManager.WriteLog("Application started");
    logManager.WriteError("Connection failed");
    Console.WriteLine($"Log size: {logManager.GetLogSize()} bytes");
}
```

## Task 2: File Backup System
Create a `FileBackupSystem` that manages file backups with proper resource handling.

### Requirements:
1. Create methods for:
   - `CreateBackup(string sourceFile)`: Creates a backup with timestamp
   - `RestoreFromBackup(string backupFile)`: Restores from a backup
   - `ListBackups()`: Lists all available backups
2. Use `FileStream` for file operations
3. Implement proper exception handling
4. Use the `using` statement appropriately
5. Include progress reporting for long operations

### Example Usage:
```csharp
var backupSystem = new FileBackupSystem("backups");
backupSystem.CreateBackup("important.txt");
var backups = backupSystem.ListBackups();
backupSystem.RestoreFromBackup(backups[0]);
```

## Task 3: Directory Monitor
Create a `DirectoryMonitor` class that watches for file changes and manages resources properly.

### Requirements:
1. Use `FileSystemWatcher` to monitor directory changes
2. Implement `IDisposable` for proper cleanup
3. Track:
   - File creation
   - File deletion
   - File modification
4. Log all changes to a file
5. Include methods to start and stop monitoring
6. Implement proper event handling

### Example Usage:
```csharp
using (var monitor = new DirectoryMonitor("watchFolder"))
{
    monitor.StartMonitoring();
    Console.WriteLine("Monitoring started. Press any key to stop...");
    Console.ReadKey();
    monitor.StopMonitoring();
}
```

## Task 4: File Encryption Manager
Create a `FileEncryptionManager` that handles encryption/decryption of files with proper resource management.

### Requirements:
1. Implement methods for:
   - `EncryptFile(string sourceFile, string destinationFile, string password)`
   - `DecryptFile(string sourceFile, string destinationFile, string password)`
2. Use appropriate encryption algorithms
3. Implement `IDisposable` for proper cleanup of cryptographic resources
4. Handle large files efficiently using streams
5. Include progress reporting

### Example Usage:
```csharp
using (var encryptionManager = new FileEncryptionManager())
{
    encryptionManager.EncryptFile("sensitive.txt", "sensitive.encrypted", "password123");
    encryptionManager.DecryptFile("sensitive.encrypted", "sensitive_decrypted.txt", "password123");
}
```

## Task 5: Temporary File Manager
Create a `TempFileManager` class that manages temporary files with automatic cleanup.

### Requirements:
1. Implement methods for:
   - `CreateTempFile()`: Creates a temporary file and returns its path
   - `WriteTempData(string data)`: Writes data to a temporary file
   - `CleanupTempFiles()`: Removes all temporary files
2. Implement `IDisposable` for automatic cleanup
3. Track all created temporary files
4. Include proper error handling
5. Implement file age monitoring

### Example Usage:
```csharp
using (var tempManager = new TempFileManager())
{
    string tempFile = tempManager.CreateTempFile();
    tempManager.WriteTempData("temporary content");
    // Files are automatically cleaned up when disposed
}
```

## Bonus Challenge: Resource Pool Manager
Create a `ResourcePoolManager` that manages a pool of reusable resources (like file handles or database connections).

### Requirements:
1. Implement a generic resource pool
2. Include methods for:
   - `AcquireResource()`: Gets a resource from the pool
   - `ReleaseResource(T resource)`: Returns a resource to the pool
3. Implement proper resource cleanup
4. Handle pool exhaustion scenarios
5. Include timeout mechanisms
6. Implement thread-safe resource management

### Example Usage:
```csharp
using (var poolManager = new ResourcePoolManager<FileStream>(maxPoolSize: 5))
{
    var resource = poolManager.AcquireResource();
    try
    {
        // Use the resource
    }
    finally
    {
        poolManager.ReleaseResource(resource);
    }
}
```

## Evaluation Criteria
- Proper implementation of the IDisposable pattern
- Correct resource management and cleanup
- Appropriate use of using statements
- Proper exception handling
- Code organization and clarity
- Performance considerations
- Thread safety where appropriate

## Submission Guidelines
1. Create a separate class file for each task
2. Include XML documentation for public members
3. Add appropriate exception handling
4. Include unit tests for each class
5. Provide example usage in a Program.cs file
6. Submit all files in a single solution

## Additional Notes
- Pay attention to proper resource cleanup
- Consider performance implications of your implementations
- Follow C# coding conventions
- Include appropriate logging and error handling
- Consider edge cases in your implementation 