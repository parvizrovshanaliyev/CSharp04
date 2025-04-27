# DirectoryMonitor Class Documentation

## Overview

The `DirectoryMonitor` class is a robust tool designed for real-time monitoring of file system changes within a specified directory. It implements the `IDirectoryMonitor` interface and leverages the `FileSystemWatcher` class from the .NET Framework to efficiently manage and respond to file system events.

## Properties

### Basic Properties
- `IsMonitoring`: A boolean property that indicates whether the monitoring process is currently active
- `MonitoredPath`: A string property that stores the absolute path of the directory being monitored

### Events
- `FileCreated`: Event triggered when a new file is created in the monitored directory
- `FileDeleted`: Event triggered when an existing file is deleted from the monitored directory
- `FileChanged`: Event triggered when the contents or attributes of a file are modified
- `FileRenamed`: Event triggered when a file is renamed within the monitored directory
- `MonitorError`: Event triggered when an error occurs during the monitoring process

## Constructor

```csharp
public DirectoryMonitor(string directoryPath, ILogger logger)
```

### Parameters
- `directoryPath`: Absolute or relative path of the directory to monitor. Must be a valid directory path
- `logger`: An implementation of the ILogger interface for recording operational events and errors

### Features
- Performs comprehensive validation of the directory path and logger instance
- Initializes and configures the underlying FileSystemWatcher instance
- Sets up event handlers for file system notifications
- Establishes logging mechanisms for operation tracking

## Methods

### StartMonitoring
```csharp
public void StartMonitoring()
```
- Initiates the file system monitoring process
- Enables the FileSystemWatcher to begin receiving change notifications
- Throws `InvalidOperationException` if monitoring is already active
- Throws `ObjectDisposedException` if the DirectoryMonitor instance has been disposed

### StopMonitoring
```csharp
public void StopMonitoring()
```
- Safely terminates the file system monitoring process
- Disables the FileSystemWatcher and stops receiving notifications
- Throws `ObjectDisposedException` if the DirectoryMonitor instance has been disposed
- Ensures proper cleanup of monitoring resources

### Configure
```csharp
public void Configure(bool includeSubdirectories = true, string filter = "*.*")
```
- Configures the monitoring behavior and filtering options
- `includeSubdirectories`: When true, monitors all subdirectories recursively
- `filter`: Specifies which files to monitor (e.g., "*.txt" for text files only)
- Can be called before or after starting monitoring

## Event Handlers

### OnFileCreated
- Processes file creation events from the FileSystemWatcher
- Validates the event data and file existence
- Logs the creation event with file details
- Raises the `FileCreated` event for subscribers

### OnFileDeleted
- Handles file deletion notifications
- Verifies the deletion operation
- Logs the deletion event with path information
- Triggers the `FileDeleted` event for subscribers

### OnFileChanged
- Manages file modification events
- Validates the change type and file accessibility
- Records the modification in the log
- Raises the `FileChanged` event for subscribers

### OnFileRenamed
- Processes file rename operations
- Tracks both old and new file names
- Logs the rename operation details
- Triggers the `FileRenamed` event for subscribers

### OnError
- Handles any errors that occur during monitoring
- Logs detailed error information
- Raises the `MonitorError` event for error handling
- Provides error recovery where possible

## Resource Management

### Dispose Pattern
- Implements the standard IDisposable pattern for resource cleanup
- Properly disposes of the FileSystemWatcher instance
- Cleans up event handlers to prevent memory leaks
- Implements both synchronous and asynchronous disposal methods

## Usage Example

```csharp
using (var monitor = new DirectoryMonitor("watchFolder", logger))
{
    // Subscribe to file creation events
    monitor.FileCreated += (s, e) => Console.WriteLine($"File created: {e.FullPath}");
    
    // Configure monitoring options
    monitor.Configure(includeSubdirectories: true, filter: "*.txt");
    
    // Start the monitoring process
    monitor.StartMonitoring();
    
    // Application-specific operations...
    
    // Stop monitoring when done
    monitor.StopMonitoring();
}
```

## Security Considerations

- Validates and sanitizes all file paths to prevent path traversal attacks
- Checks directory access permissions before initiating monitoring
- Implements secure resource cleanup procedures
- Handles sensitive file information appropriately
- Validates event data before processing

## Best Practices

1. Always wrap DirectoryMonitor instances in a `using` block for proper resource management
2. Implement appropriate error handlers for all subscribed events
3. Call `StopMonitoring` explicitly before disposal when possible
4. Consider performance implications when monitoring large directory trees
5. Use specific file filters to reduce unnecessary event processing
6. Implement proper exception handling for all event handlers
7. Consider using async/await pattern for long-running operations

## Future Enhancements

- Implementation of asynchronous event processing for improved performance
- Enhanced filtering capabilities with regex support
- Performance optimizations for large directory structures
- Detailed monitoring statistics and reporting
- Event prioritization and throttling mechanisms
- Support for compressed and encrypted file monitoring
- Network resilience improvements for remote directories

## Notes

- FileSystemWatcher has inherent limitations regarding buffer sizes and event timing
- Performance may be significantly impacted when monitoring network directories
- Consider implementing event buffering for high-frequency change scenarios
- Monitor memory usage when watching large directory structures
- Be aware of platform-specific behaviors and limitations
- Consider using a queue-based approach for handling rapid successive events
- Test thoroughly in various network and load conditions 