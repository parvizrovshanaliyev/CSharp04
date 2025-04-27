using System;
using System.IO;
using Practice.Interfaces;

namespace Practice.Managers
{
    /// <summary>
    /// Basic file logging manager class.
    /// This class implements the ILogger interface and handles writing operations to a log file.
    /// </summary>
    /// <remarks>
    /// Learning Objectives:
    /// - File I/O operations
    /// - IDisposable pattern usage
    /// - Resource Management
    /// - Error Handling
    /// - Interface implementation
    /// 
    /// Topics to Learn in the Future:
    /// - Thread Safety
    /// - Asynchronous Programming (Async/Await)
    /// - Concurrent Access Management
    /// - Buffer Management
    /// - Performance Optimizations
    /// </remarks>
    public class LogFileManager : ILogger
    {
        // TODO: In the future, we will need a special locking mechanism to make this variable thread-safe
        private readonly string _logFilePath;

        // TODO: In the future, we can use a different mechanism instead of StreamWriter for async I/O operations
        private StreamWriter? _writer;

        private bool _disposed;

        // TODO: This lock object will be used for thread-safe implementation in the future
        private readonly object _lockObject = new object();

        /// <summary>
        /// Constructor for the LogFileManager class.
        /// </summary>
        /// <param name="logFilePath">The file path where the log file will be created or appended to</param>
        /// <exception cref="ArgumentNullException">Thrown when logFilePath is null</exception>
        /// <exception cref="IOException">Thrown when there is an error creating or opening the file</exception>
        public LogFileManager(string logFilePath)
        {
            /*
            * Constructor implementation:
            * 1. Validates the logFilePath parameter using null-coalescing operator
            * 2. If logFilePath is null, throws ArgumentNullException
            * 3. Stores the validated path in _logFilePath field
            * 4. Calls InitializeWriter to set up the StreamWriter
            */
            // TODO: We can add more comprehensive path validation in the future
            _logFilePath = logFilePath ?? throw new ArgumentNullException(nameof(logFilePath));
            InitializeWriter();
        }

        // TODO: In the future, we will make this method asynchronous (InitializeWriterAsync)
        private void InitializeWriter()
        {
            /*
            * Writer initialization:
            * 1. Creates a new StreamWriter instance
            * 2. Opens the file in append mode (true parameter)
            * 3. If file doesn't exist, it will be created
            * 4. If file exists, content will be preserved and new logs appended
            */
            // TODO: We can add buffering and encoding options in the future
            _writer = new StreamWriter(_logFilePath, true);
        }

        /// <summary>
        /// Writes a log message to the file.
        /// </summary>
        /// <param name="message">The log message to write</param>
        /// <exception cref="ArgumentNullException">Thrown when message is null</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object has been disposed</exception>
        public void WriteLog(string message)
        {
            /*
            * Log message writing process:
            * 1. Checks if object is disposed using ThrowIfDisposed
            * 2. Calls WriteEntry with "INFO" level and the message
            * 3. Any exceptions from WriteEntry will propagate up
            */
            // TODO: In the future, we will make this method asynchronous (WriteLogAsync)
            ThrowIfDisposed();
            WriteEntry("INFO", message);
        }

        /// <summary>
        /// Writes an error message to the file.
        /// </summary>
        /// <param name="error">The error message to write</param>
        /// <exception cref="ArgumentNullException">Thrown when error is null</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object has been disposed</exception>
        public void WriteError(string error)
        {
            /*
            * Error message writing process:
            * 1. Checks if object is disposed using ThrowIfDisposed
            * 2. Calls WriteEntry with "ERROR" level and the error message
            * 3. Any exceptions from WriteEntry will propagate up
            */
            // TODO: In the future, we will make this method asynchronous (WriteErrorAsync)
            ThrowIfDisposed();
            WriteEntry("ERROR", error);
        }

        /// <summary>
        /// Gets the size of the log file in bytes.
        /// </summary>
        /// <returns>File size in bytes</returns>
        /// <exception cref="ObjectDisposedException">Thrown when the object has been disposed</exception>
        public long GetLogSize()
        {
            /*
            * File size calculation process:
            * 1. Checks if object is disposed
            * 2. Flushes any buffered content to ensure accurate size
            * 3. Creates FileInfo object to get file information
            * 4. Returns the length of the file in bytes
            */
            // TODO: In the future, we will make this method asynchronous (GetLogSizeAsync)
            ThrowIfDisposed();

            // TODO: In the future, we will protect this block with a lock for thread-safety
            _writer?.Flush();
            return new FileInfo(_logFilePath).Length;
        }

        /// <summary>
        /// Formats and writes a log entry to the file.
        /// </summary>
        /// <param name="level">Log level (INFO/ERROR)</param>
        /// <param name="message">Log message</param>
        private void WriteEntry(string level, string message)
        {
            /*
            * Log entry writing process:
            * 1. Validates the message parameter
            * 2. Checks if writer is available
            * 3. Creates formatted log entry with timestamp
            * 4. Writes the entry to the file
            * 5. Flushes to ensure immediate write to disk
            *
            * Format: "yyyy-MM-dd HH:mm:ss [LEVEL] message"
            * Example: "2024-03-14 15:30:45 [INFO] Application started"
            */
            // TODO: In the future, we will make this method asynchronous
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            // TODO: In the future, we will protect this block with a lock for thread-safety
            if (_writer == null)
                throw new ObjectDisposedException(nameof(LogFileManager));

            // TODO: In the future, we can move message formatting to a separate method
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            _writer.WriteLine(logEntry);
            _writer.Flush();
        }

        private void ThrowIfDisposed()
        {
            /*
            * Disposal check:
            * 1. Checks if object has been disposed
            * 2. Throws ObjectDisposedException if true
            * This prevents operations on disposed resources
            */
            if (_disposed)
                throw new ObjectDisposedException(nameof(LogFileManager));
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; 
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            /*
            * Resource cleanup process:
            * 1. Checks if already disposed
            * 2. If disposing is true (called from Dispose method):
            *    - Flushes any remaining content
            *    - Disposes the StreamWriter
            *    - Sets writer to null
            * 3. Marks the object as disposed
            */
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: In the future, we will protect this block with a lock for thread-safe cleanup
                    if (_writer != null)
                    {
                        _writer.Flush();
                        _writer.Dispose();
                        _writer = null;
                    }
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the object.
        /// </summary>
        public void Dispose()
        {
            /*
            * Public disposal method:
            * 1. Calls the virtual Dispose method with true
            * 2. Suppresses finalization since resources are cleaned up
            * This implements the dispose pattern correctly
            */
            // TODO: In the future, we can implement IAsyncDisposable interface
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer - Ensures resources are cleaned up when Dispose is not called.
        /// </summary>
        ~LogFileManager()
        {
            /*
            * Finalizer implementation:
            * 1. Called by garbage collector if Dispose wasn't called
            * 2. Calls Dispose(false) to clean up unmanaged resources only
            * This provides a safety net for resource cleanup
            */
            // TODO: In the future, we can review the finalization strategy
            Dispose(false);
        }
    }
}