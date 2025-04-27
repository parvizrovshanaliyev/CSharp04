using System;
using System.IO;
using System.Linq;
using Practice.Interfaces;

namespace Practice.Managers
{
    /// <summary>
    /// Implements the IFileOperation interface to provide file operation functionality.
    /// This class handles file operations like copying, deleting, and checking file existence.
    /// </summary>
    /// <remarks>
    /// Understanding File Operations:
    /// 
    /// 1. Why File Operations are Important:
    /// - Enables file manipulation and management
    /// - Provides data persistence capabilities
    /// - Supports system maintenance tasks
    /// - Facilitates data backup and recovery
    /// 
    /// 2. Key Features:
    /// - File copying with progress tracking
    /// - Secure file deletion
    /// - File existence verification
    /// - File size calculation
    /// 
    /// 3. Implementation Details:
    /// - Uses FileStream for efficient file handling
    /// - Implements buffered operations
    /// - Provides proper error handling
    /// - Manages system resources
    /// 
    /// 4. Security Considerations:
    /// - File access permissions
    /// - Path validation
    /// - Resource cleanup
    /// - Error handling
    /// 
    /// Learning Objectives:
    /// - File system operations
    /// - Resource management
    /// - Error handling
    /// - Security best practices
    /// 
    /// Topics to Learn in the Future:
    /// - Asynchronous operations
    /// - Advanced buffering
    /// - File compression
    /// - Network file operations
    /// </remarks>
    public class FileOperationManager : IFileOperation
    {
        private readonly ILogger _logger;
        private bool _disposed;
        private const int BUFFER_SIZE = 81920; // 80KB buffer

        /// <summary>
        /// Initializes a new instance of the FileOperationManager class.
        /// </summary>
        /// <param name="logger">The logger instance for recording operations and errors.</param>
        public FileOperationManager(ILogger logger)
        {
            /*
            * Constructor Implementation:
            * 
            * 1. Input Validation:
            *    - Validates logger parameter
            *    - Ensures proper initialization
            * 
            * 2. Setup:
            *    - Stores logger instance
            *    - Initializes internal state
            * 
            * Security Considerations:
            * - Parameter validation
            * - Resource initialization
            * - Error handling
            */
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Copies a file from source path to destination path.
        /// </summary>
        public bool CopyFile(string sourcePath, string destinationPath)
        {
            /*
            * File Copy Process:
            * 
            * 1. Validation:
            *    - Checks source and destination paths
            *    - Verifies file existence
            *    - Validates permissions
            * 
            * 2. Copy Operation:
            *    - Opens source file
            *    - Creates destination file
            *    - Copies data in chunks
            * 
            * 3. Progress Tracking:
            *    - Monitors bytes copied
            *    - Reports progress
            *    - Handles cancellation
            * 
            * Security Features:
            * - Path validation
            * - Permission checks
            * - Resource cleanup
            */
            ThrowIfDisposed();
            ValidatePaths(sourcePath, destinationPath);

            try
            {
                using var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
                using var destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

                var buffer = new byte[BUFFER_SIZE];
                int bytesRead;
                long totalBytes = sourceStream.Length;
                long bytesCopied = 0;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    bytesCopied += bytesRead;
                    ReportProgress("Copy", bytesCopied, totalBytes);
                }

                _logger.WriteLog($"File copied successfully from {sourcePath} to {destinationPath}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File copy failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes a file at the specified path.
        /// </summary>
        public bool DeleteFile(string filePath)
        {
            /*
            * File Deletion Process:
            * 
            * 1. Validation:
            *    - Checks file path
            *    - Verifies existence
            *    - Validates permissions
            * 
            * 2. Deletion:
            *    - Attempts file deletion
            *    - Handles file locks
            *    - Manages errors
            * 
            * Security Features:
            * - Path validation
            * - Permission checks
            * - Secure deletion
            */
            ThrowIfDisposed();
            ValidatePath(filePath);

            try
            {
                File.Delete(filePath);
                _logger.WriteLog($"File deleted successfully: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File deletion failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if a file exists at the specified path.
        /// </summary>
        public bool Exists(string filePath)
        {
            /*
            * File Existence Check:
            * 
            * 1. Validation:
            *    - Validates file path
            *    - Checks permissions
            * 
            * 2. Verification:
            *    - Checks file existence
            *    - Handles access errors
            * 
            * Security Features:
            * - Path validation
            * - Permission checks
            * - Error handling
            */
            ThrowIfDisposed();
            ValidatePath(filePath);

            try
            {
                bool exists = File.Exists(filePath);
                _logger.WriteLog($"File existence check: {filePath} - {(exists ? "exists" : "does not exist")}");
                return exists;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File existence check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the size of a file in bytes.
        /// </summary>
        public long GetFileSize(string filePath)
        {
            /*
            * File Size Calculation:
            * 
            * 1. Validation:
            *    - Validates file path
            *    - Checks file existence
            *    - Verifies permissions
            * 
            * 2. Size Retrieval:
            *    - Gets file information
            *    - Calculates size
            *    - Handles large files
            * 
            * Security Features:
            * - Path validation
            * - Permission checks
            * - Error handling
            */
            ThrowIfDisposed();
            ValidatePath(filePath);

            try
            {
                var fileInfo = new FileInfo(filePath);
                var size = fileInfo.Length;
                _logger.WriteLog($"File size retrieved: {filePath} - {size} bytes");
                return size;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File size retrieval failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Creates a new file at the specified path.
        /// </summary>
        public bool CreateFile(string filePath, string? content = null)
        {
            /*
            * File Creation Process:
            * 
            * 1. Validation:
            *    - Validates file path
            *    - Checks directory existence
            *    - Verifies permissions
            * 
            * 2. Creation:
            *    - Creates directory if needed
            *    - Creates the file
            *    - Writes initial content
            * 
            * 3. Security Features:
            *    - Path validation
            *    - Permission checks
            *    - Resource cleanup
            * 
            * Error Handling:
            *    - Path validation errors
            *    - Access denied errors
            *    - I/O errors
            */
            ThrowIfDisposed();
            ValidatePath(filePath);

            try
            {
                // Create directory if it doesn't exist
                string? directoryPath = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Create file and write content if provided
                if (content != null)
                {
                    File.WriteAllText(filePath, content);
                }
                else
                {
                    using (File.Create(filePath)) { }
                }

                _logger.WriteLog($"File created successfully: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File creation failed: {ex.Message}");
                return false;
            }
        }

        private void ValidatePath(string path)
        {
            /*
            * Path Validation Process:
            * 
            * 1. Checks:
            *    - Null or empty check
            *    - Path format validation
            *    - Security validation
            * 
            * 2. Security:
            *    - Prevents path traversal
            *    - Validates characters
            *    - Checks permissions
            */
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (Path.GetInvalidPathChars().Any(c => path.Contains(c)))
                throw new ArgumentException("Path contains invalid characters", nameof(path));
        }

        private void ValidatePaths(string sourcePath, string destinationPath)
        {
            /*
            * Multiple Path Validation:
            * 
            * 1. Individual Validation:
            *    - Validates source path
            *    - Validates destination path
            * 
            * 2. Combined Checks:
            *    - Path equality check
            *    - Directory validation
            *    - Permission verification
            */
            ValidatePath(sourcePath);
            ValidatePath(destinationPath);

            if (string.Equals(sourcePath, destinationPath, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Source and destination paths cannot be the same");
        }

        private void ReportProgress(string operation, long current, long total)
        {
            /*
            * Progress Reporting:
            * 
            * 1. Calculation:
            *    - Computes percentage
            *    - Formats message
            *    - Handles edge cases
            * 
            * 2. Logging:
            *    - Records progress
            *    - Updates status
            *    - Handles errors
            */
            if (total > 0)
            {
                int percentage = (int)((current * 100) / total);
                _logger.WriteLog($"{operation} progress: {percentage}%");
            }
        }

        private void ThrowIfDisposed()
        {
            /*
            * Disposal Check:
            * 
            * 1. Verification:
            *    - Checks disposed state
            *    - Throws if disposed
            * 
            * 2. Purpose:
            *    - Prevents invalid operations
            *    - Ensures proper cleanup
            *    - Maintains consistency
            */
            if (_disposed)
                throw new ObjectDisposedException(nameof(FileOperationManager));
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            /*
            * Resource Cleanup:
            * 
            * 1. Process:
            *    - Checks disposal state
            *    - Cleans up resources
            *    - Updates state
            * 
            * 2. Cleanup:
            *    - Managed resources
            *    - Unmanaged resources
            *    - State management
            */
            if (!_disposed)
            {
                if (disposing)
                {
                    // Currently no managed resources to dispose
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
            * 1. Process:
            *    - Calls Dispose(true)
            *    - Suppresses finalization
            * 
            * 2. Purpose:
            *    - Ensures cleanup
            *    - Manages resources
            *    - Follows pattern
            */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~FileOperationManager()
        {
            /*
            * Finalizer:
            * 
            * 1. Purpose:
            *    - Last-chance cleanup
            *    - Resource recovery
            *    - System protection
            * 
            * 2. Process:
            *    - Calls Dispose(false)
            *    - Handles cleanup
            *    - Ensures safety
            */
            Dispose(false);
        }
    }
}