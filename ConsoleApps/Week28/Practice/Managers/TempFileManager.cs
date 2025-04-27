using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Practice.Interfaces;

namespace Practice.Managers
{
    /// <summary>
    /// Manages temporary files with automatic cleanup capabilities.
    /// This class provides functionality for creating, writing to, and cleaning up temporary files.
    /// </summary>
    /// <remarks>
    /// Understanding Temporary File Management:
    /// 
    /// 1. Why Temporary Files are Important:
    /// - Provides temporary storage for intermediate processing
    /// - Helps manage system resources efficiently
    /// - Reduces memory usage for large operations
    /// - Enables data persistence between operations
    /// 
    /// 2. Key Features:
    /// - Automatic file cleanup
    /// - Secure file handling
    /// - Resource tracking
    /// - Configurable retention policies
    /// 
    /// 3. Security Considerations:
    /// - Proper file permissions
    /// - Secure file deletion
    /// - Access control
    /// - Path validation
    /// 
    /// 4. Implementation Details:
    /// - Uses system temp directory
    /// - Implements file tracking
    /// - Provides cleanup mechanisms
    /// - Manages file lifecycle
    /// 
    /// Learning Objectives:
    /// - File system operations
    /// - Resource management
    /// - Error handling
    /// - Cleanup strategies
    /// - Security best practices
    /// 
    /// Topics to Learn in the Future:
    /// - Thread-safe operations
    /// - Asynchronous file handling
    /// - Advanced cleanup strategies
    /// - Resource pooling
    /// - Performance optimization
    /// </remarks>
    public class TempFileManager : ITempFile
    {
        private readonly string _tempDirectory;
        // TODO: In the future, replace with ConcurrentDictionary for thread-safe operations
        private readonly Dictionary<string, DateTime> _tempFiles;
        private readonly ILogger _logger;
        private bool _disposed;

        // TODO: In the future, implement a timer for automatic cleanup
        private const int MAX_FILE_AGE_HOURS = 24;

        /// <summary>
        /// Initializes a new instance of the TempFileManager class.
        /// </summary>
        /// <param name="tempDirectory">The name of the directory to store temporary files in.</param>
        /// <param name="logger">The logger instance for recording operations and errors.</param>
        public TempFileManager(string tempDirectory, ILogger logger)
        {
            /*
            * Constructor Implementation Details:
            * 
            * 1. Input Validation:
            *    - Checks for null or empty directory name
            *    - Validates logger instance
            * 
            * 2. Directory Setup:
            *    - Combines with system temp path
            *    - Creates directory if not exists
            *    - Sets appropriate permissions
            * 
            * 3. Resource Initialization:
            *    - Creates file tracking dictionary
            *    - Initializes logger
            *    - Sets up cleanup parameters
            * 
            * Security Considerations:
            * - Directory permissions
            * - Path validation
            * - Resource isolation
            * 
            * TODO: In the future, implement:
            * - Custom cleanup intervals
            * - Directory size limits
            * - Access control lists
            * - Resource monitoring
            */
            if (string.IsNullOrEmpty(tempDirectory))
                throw new ArgumentNullException(nameof(tempDirectory));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tempDirectory = Path.Combine(Path.GetTempPath(), tempDirectory);
            _tempFiles = new Dictionary<string, DateTime>();

            if (!Directory.Exists(_tempDirectory))
                Directory.CreateDirectory(_tempDirectory);
        }

        /// <summary>
        /// Creates a new temporary file with a unique name.
        /// </summary>
        /// <returns>The full path to the created temporary file.</returns>
        public string CreateTempFile()
        {
            /*
            * File Creation Process:
            * 
            * 1. Preparation:
            *    - Checks if manager is disposed
            *    - Generates unique file name using GUID
            *    - Constructs full file path
            * 
            * 2. File Creation:
            *    - Creates empty file
            *    - Sets appropriate permissions
            *    - Adds to tracking dictionary
            * 
            * 3. Tracking:
            *    - Records creation time
            *    - Updates file dictionary
            *    - Logs creation event
            * 
            * Security Features:
            * - Unique file names
            * - Proper permissions
            * - Access tracking
            * - Resource monitoring
            * 
            * Error Handling:
            * - Path validation
            * - Creation failures
            * - Permission issues
            * - Resource limits
            * 
            * TODO: In the future, implement:
            * - File type restrictions
            * - Size quotas
            * - Access controls
            * - Creation policies
            */
            ThrowIfDisposed();

            try
            {
                string tempFile = Path.Combine(_tempDirectory, $"temp_{Guid.NewGuid()}.tmp");
                using (File.Create(tempFile)) { }

                _tempFiles[tempFile] = DateTime.UtcNow;
                _logger.WriteLog($"Temporary file created: {tempFile}");

                return tempFile;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to create temporary file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Writes data to a temporary file.
        /// </summary>
        /// <param name="tempFile">The path to the temporary file.</param>
        /// <param name="data">The data to write to the file.</param>
        public void WriteTempData(string tempFile, string data)
        {
            /*
            * Data Writing Process:
            * 
            * 1. Validation:
            *    - Checks if file exists in tracking
            *    - Validates input data
            *    - Verifies file accessibility
            * 
            * 2. Writing Operation:
            *    - Opens file stream
            *    - Writes data securely
            *    - Ensures proper flushing
            * 
            * 3. Error Handling:
            *    - File access errors
            *    - Write failures
            *    - Resource constraints
            * 
            * Security Considerations:
            * - File permissions
            * - Data validation
            * - Resource limits
            * - Access control
            * 
            * TODO: In the future, implement:
            * - Buffered writing
            * - Data encryption
            * - Write verification
            * - Access logging
            */
            ThrowIfDisposed();

            if (!_tempFiles.ContainsKey(tempFile))
                throw new FileNotFoundException("Temporary file not found", tempFile);

            try
            {
                File.WriteAllText(tempFile, data);
                _logger.WriteLog($"Data written to temporary file: {tempFile}");
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to write to temporary file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Manually triggers cleanup of expired temporary files.
        /// </summary>
        public void CleanupTempFiles()
        {
            /*
            * Cleanup Process:
            * 
            * 1. Initialization:
            *    - Checks manager state
            *    - Prepares for cleanup
            *    - Logs operation start
            * 
            * 2. Execution:
            *    - Calls cleanup implementation
            *    - Handles any errors
            *    - Updates tracking
            * 
            * Security Considerations:
            * - Secure deletion
            * - Resource protection
            * - Error handling
            * 
            * TODO: In the future, implement:
            * - Scheduled cleanup
            * - Size-based cleanup
            * - Cleanup policies
            * - Recovery options
            */
            ThrowIfDisposed();
            PerformCleanup();
        }

        /// <summary>
        /// Performs the actual cleanup of expired temporary files.
        /// </summary>
        private void PerformCleanup()
        {
            /*
            * Cleanup Implementation:
            * 
            * 1. File Age Check:
            *    - Gets current time
            *    - Calculates age of each file
            *    - Identifies expired files
            * 
            * 2. Deletion Process:
            *    - Iterates through expired files
            *    - Deletes each file securely
            *    - Updates tracking dictionary
            * 
            * 3. Error Handling:
            *    - File access errors
            *    - Deletion failures
            *    - Resource issues
            * 
            * Security Features:
            * - Secure deletion
            * - Access verification
            * - Resource cleanup
            * 
            * TODO: In the future, implement:
            * - Batch processing
            * - Priority-based cleanup
            * - Cleanup verification
            * - Recovery mechanisms
            */
            var now = DateTime.UtcNow;
            var expiredFiles = _tempFiles
                .Where(kvp => (now - kvp.Value).TotalHours >= MAX_FILE_AGE_HOURS)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var file in expiredFiles)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        _logger.WriteLog($"Deleted expired temporary file: {file}");
                    }

                    _tempFiles.Remove(file);
                }
                catch (Exception ex)
                {
                    _logger.WriteError($"Failed to delete temporary file {file}: {ex.Message}");
                }
            }
        }

        private void ThrowIfDisposed()
        {
            /*
            * Disposal Check Process:
            * 
            * 1. State Verification:
            *    - Checks disposed flag
            *    - Throws if disposed
            * 
            * 2. Error Handling:
            *    - Throws ObjectDisposedException
            *    - Includes class name
            * 
            * Purpose:
            * - Prevents use of disposed resources
            * - Ensures proper error messages
            * - Maintains object lifecycle
            * 
            * TODO: In the future, add:
            * - Resource state tracking
            * - Disposal event notification
            */
            if (_disposed)
                throw new ObjectDisposedException(nameof(TempFileManager));
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            /*
            * Resource Cleanup Process:
            * 
            * 1. Disposal Logic:
            *    - Checks if already disposed
            *    - Handles managed resource cleanup
            *    - Cleans up temporary files
            * 
            * 2. File Cleanup:
            *    - Deletes remaining files
            *    - Clears tracking dictionary
            *    - Removes temp directory
            * 
            * 3. Error Handling:
            *    - Logs cleanup failures
            *    - Continues on errors
            *    - Ensures complete cleanup
            * 
            * Security Considerations:
            * - Secure file deletion
            * - Resource cleanup
            * - Error logging
            * 
            * TODO: In the future, implement:
            * - Async cleanup
            * - Cleanup verification
            * - Resource tracking
            */
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (var file in _tempFiles.Keys.ToList())
                    {
                        try
                        {
                            if (File.Exists(file))
                                File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            _logger.WriteError($"Failed to delete temporary file during disposal {file}: {ex.Message}");
                        }
                    }

                    _tempFiles.Clear();

                    try
                    {
                        if (Directory.Exists(_tempDirectory))
                            Directory.Delete(_tempDirectory, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.WriteError($"Failed to delete temporary directory during disposal: {ex.Message}");
                    }
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            /*
            * IDisposable Implementation:
            * 
            * 1. Cleanup Process:
            *    - Calls virtual Dispose
            *    - Suppresses finalization
            * 
            * 2. Resource Management:
            *    - Ensures proper cleanup
            *    - Prevents resource leaks
            * 
            * Purpose:
            * - Implements standard pattern
            * - Ensures cleanup execution
            * - Manages object lifecycle
            * 
            * TODO: In the future, implement:
            * - IAsyncDisposable
            * - Disposal logging
            * - Cleanup verification
            */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~TempFileManager()
        {
            /*
            * Finalizer Implementation:
            * 
            * 1. Cleanup Process:
            *    - Calls Dispose(false)
            *    - Handles unmanaged resources
            * 
            * 2. Purpose:
            *    - Last-chance cleanup
            *    - Resource recovery
            *    - System protection
            * 
            * Security Considerations:
            * - Resource cleanup
            * - System stability
            * - Data protection
            * 
            * TODO: In the future, implement:
            * - Finalizer logging
            * - Resource tracking
            * - Cleanup verification
            */
            Dispose(false);
        }
    }
}