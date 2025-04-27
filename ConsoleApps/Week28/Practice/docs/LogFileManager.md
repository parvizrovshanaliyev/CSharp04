# LogFileManager Class Documentation

## Overview

The `LogFileManager` class implements the `ILogger` interface to provide basic file logging functionality. It manages writing operations to a log file with proper resource management, error handling, and file system operations.

## Key Features

- File-based logging system
- Operation and error logging
- Log file size monitoring
- Resource management
- Thread-safe operations (planned)
- Buffered writing capabilities
- Automatic file handling
- Timestamp-based logging

## Technical Specifications

### Log Format
- Timestamp Format: `yyyy-MM-dd HH:mm:ss`
- Log Entry Format: `[LEVEL] message`
- Supported Levels: INFO, ERROR
- File Append Mode: Enabled
- Auto-flush: Enabled

## Constructor

```csharp
public LogFileManager(string logFilePath)
```

### Parameters
- `logFilePath`: The path where the log file will be created or appended to

### Initialization Process
- Validates log file path
- Creates or opens log file
- Sets up StreamWriter in append mode
- Initializes internal state
- Prepares thread synchronization (planned)

## Public Methods

### WriteLog
```csharp
public void WriteLog(string message)
```
#### Purpose
Writes an informational message to the log file.

#### Parameters
- `message`: The message to be logged

#### Process
1. Validates message and object state
2. Formats message with timestamp
3. Writes to log file with "INFO" level
4. Flushes to ensure immediate write
5. Handles any writing errors

### WriteError
```csharp
public void WriteError(string error)
```
#### Purpose
Writes an error message to the log file.

#### Parameters
- `error`: The error message to be logged

#### Process
1. Validates error message and object state
2. Formats message with timestamp
3. Writes to log file with "ERROR" level
4. Flushes to ensure immediate write
5. Handles any writing errors

### GetLogSize
```csharp
public long GetLogSize()
```
#### Purpose
Retrieves the current size of the log file in bytes.

#### Returns
- Size of the log file in bytes

#### Process
1. Flushes any buffered content
2. Creates FileInfo object
3. Returns file length
4. Handles any file access errors

## Resource Management

### Dispose Pattern Implementation
```csharp
public void Dispose()
protected virtual void Dispose(bool disposing)
```
- Implements IDisposable interface
- Ensures proper resource cleanup
- Handles StreamWriter disposal
- Implements finalizer for safety
- Manages thread synchronization objects

## Internal Methods

### InitializeWriter
```csharp
private void InitializeWriter()
```
#### Purpose
Initializes the StreamWriter for log file operations.

#### Process
1. Creates StreamWriter in append mode
2. Sets up file stream
3. Configures writing options
4. Handles initialization errors

### WriteEntry
```csharp
private void WriteEntry(string level, string message)
```
#### Purpose
Formats and writes a log entry with the specified level.

#### Parameters
- `level`: Log level (INFO/ERROR)
- `message`: Message to log

#### Process
1. Validates parameters
2. Creates formatted log entry
3. Writes to file
4. Ensures immediate flush
5. Handles writing errors

## Error Handling

### Exception Types
- `ArgumentNullException`: For null input parameters
- `IOException`: For file operation failures
- `ObjectDisposedException`: When accessing disposed instance
- `UnauthorizedAccessException`: For permission issues

### Error Management
- Comprehensive exception handling
- Error state logging
- Resource protection
- Safe error recovery
- User-friendly error messages

## Best Practices

1. Always use within a `using` block
2. Handle exceptions appropriately
3. Monitor log file size
4. Implement log rotation
5. Use appropriate log levels
6. Regular log maintenance
7. Secure log file access
8. Backup log files regularly

## Usage Example

```csharp
using (var logger = new LogFileManager("application.log"))
{
    try
    {
        // Log information
        logger.WriteLog("Application started");

        // Perform some operations
        try
        {
            // Some operation that might fail
            throw new Exception("Operation failed");
        }
        catch (Exception ex)
        {
            // Log error
            logger.WriteError($"Operation error: {ex.Message}");
        }

        // Check log size
        long size = logger.GetLogSize();
        logger.WriteLog($"Current log size: {size} bytes");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Logging failed: {ex.Message}");
    }
}
```

## Performance Considerations

- Buffered writing operations
- Immediate flush on demand
- Efficient resource usage
- File size monitoring
- Stream management
- Memory optimization

## Security Features

1. File Access Control
   - Permission verification
   - Path validation
   - Secure file operations

2. Resource Protection
   - Safe resource cleanup
   - Protected file handles
   - Secure disposal

3. Data Integrity
   - Immediate flush capability
   - Write verification
   - Error tracking

## Future Enhancements

- Asynchronous logging support
- Log file rotation
- Compression support
- Log level filtering
- Pattern-based formatting
- Remote logging capability
- Log analysis tools
- Performance metrics
- Enhanced thread safety

## Limitations and Notes

- Synchronous operations only
- Single file logging
- Local file system focus
- Regular maintenance needed
- Size management required
- Permission requirements
- Backup strategy needed

## Dependencies

- System.IO namespace
- ILogger interface
- IDisposable interface

## Thread Safety

### Current Implementation
- Basic thread safety planned
- Lock-based synchronization
- Resource protection
- Concurrent access handling

### Future Implementation
- Enhanced thread safety
- Async/await support
- Concurrent writing
- Queue-based logging

## Log File Management

### File Operations
- Append-mode writing
- Automatic file creation
- Size monitoring
- Resource cleanup

### Log Format
```
2024-03-14 15:30:45 [INFO] Application started
2024-03-14 15:30:46 [ERROR] Operation failed: Invalid input
```

### Maintenance
- Regular size checking
- Backup procedures
- Cleanup routines
- Error monitoring 