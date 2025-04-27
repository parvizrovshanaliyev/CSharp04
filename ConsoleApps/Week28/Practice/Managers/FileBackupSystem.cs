using System;
using System.Collections.Generic;
using System.IO;
using Practice.Interfaces;

namespace Practice.Managers
{
    /// <summary>
    /// Manages file backup operations with automatic logging and error handling.
    /// This class provides functionality for creating backups, restoring from backups,
    /// and managing backup files with proper resource management.
    /// </summary>
    /// <remarks>
    /// Learning Objectives:
    /// - File backup operations
    /// - Error handling and logging
    /// - Resource management
    /// - File system operations
    /// - Interface implementation
    /// 
    /// Topics to Learn in the Future:
    /// - Asynchronous file operations
    /// - Progress reporting
    /// - Compression techniques
    /// - Backup rotation strategies
    /// - File integrity verification
    /// </remarks>
    public class FileBackupSystem : IFileBackup, IDisposable
    {
        private readonly string _backupDirectory;
        private bool _disposed;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor for the FileBackupSystem class.
        /// </summary>
        /// <param name="backupDirectory">The directory where backups will be stored</param>
        /// <param name="logger">The logger instance for recording operations and errors</param>
        public FileBackupSystem(string backupDirectory, ILogger logger)
        {
            /*
            * Constructor implementation:
            * 1. Validates both parameters for null
            * 2. Stores the backup directory path
            * 3. Stores the logger instance
            * 4. Creates the backup directory if it doesn't exist
            * 
            * Note: Directory.CreateDirectory is idempotent - safe to call even if directory exists
            */
            _backupDirectory = backupDirectory ?? throw new ArgumentNullException(nameof(backupDirectory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (!Directory.Exists(_backupDirectory))
                Directory.CreateDirectory(_backupDirectory);
        }

        /// <summary>
        /// Creates a backup of the specified file with a timestamp.
        /// </summary>
        /// <param name="sourceFile">The path of the file to backup.</param>
        /// <returns>True if the backup was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sourceFile is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
        /// <exception cref="IOException">Thrown when the backup operation fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        public bool CreateBackup(string sourceFile)
        {
            /*
            * Backup creation process:
            * 1. Validates object state and parameters
            * 2. Checks if source file exists
            * 3. Generates unique backup filename with timestamp
            * 4. Copies file to backup location
            * 5. Logs the operation
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Wraps operations in try-catch for proper error handling
            * - Generates timestamp in format: yyyyMMdd_HHmmss
            * - Combines backup directory path with timestamped filename
            * - Uses CopyFile method for actual file copying
            * - Logs success or failure using the logger
            * 
            * Example filename generation:
            * Input: "data.txt"
            * Timestamp: "20240314_153045"
            * Output: "data_20240314_153045.txt"
            * 
            * TODO: In the future, make this method async (CreateBackupAsync)
            */
            ThrowIfDisposed();

            try
            {
                if (!File.Exists(sourceFile))
                    throw new FileNotFoundException("Source file not found", sourceFile);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = Path.GetFileName(sourceFile);
                string backupFile = Path.Combine(_backupDirectory,
                    $"{Path.GetFileNameWithoutExtension(fileName)}_{timestamp}{Path.GetExtension(fileName)}");

                CopyFile(sourceFile, backupFile);
                _logger.WriteLog($"Backup created: {backupFile}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Backup creation failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Restores a file from a backup.
        /// </summary>
        /// <param name="backupFile">The path of the backup file to restore from.</param>
        /// <returns>True if the restore was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when backupFile is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the backup file does not exist.</exception>
        /// <exception cref="IOException">Thrown when the restore operation fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        public bool RestoreFromBackup(string backupFile)
        {
            /*
            * Restore process:
            * 1. Validates object state and parameters
            * 2. Checks if backup file exists
            * 3. Extracts original filename from backup name
            * 4. Creates restored file with "_restored" suffix
            * 5. Copies backup to restored location
            * 6. Logs the operation
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Wraps operations in try-catch for proper error handling
            * - Extracts original filename by splitting on '_' and taking first part
            * - Appends "_restored" suffix to the original filename
            * - Uses CopyFile method for actual file copying
            * - Logs success or failure using the logger
            * 
            * Example filename processing:
            * Input: "data_20240314_153045.txt"
            * Original name: "data"
            * Output: "data_restored.txt"
            * 
            * TODO: In the future, make this method async (RestoreFromBackupAsync)
            */
            ThrowIfDisposed();

            try
            {
                if (!File.Exists(backupFile))
                    throw new FileNotFoundException("Backup file not found", backupFile);

                string originalFileName = Path.GetFileNameWithoutExtension(backupFile).Split('_')[0];
                string restoredFile = Path.Combine(
                    Path.GetDirectoryName(backupFile) ?? string.Empty,
                    $"{originalFileName}_restored{Path.GetExtension(backupFile)}");

                CopyFile(backupFile, restoredFile);
                _logger.WriteLog($"Restored from backup: {restoredFile}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Restore failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Lists all backup files in the backup directory.
        /// </summary>
        /// <returns>A list of paths to backup files.</returns>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        public List<string> ListBackups()
        {
            /*
            * Backup listing process:
            * 1. Validates object state
            * 2. Gets all files from backup directory
            * 3. Returns list of full file paths
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Uses Directory.GetFiles to get all files in backup directory
            * - Creates new List<string> from array for better encapsulation
            * - Returns empty list if directory is empty
            * - Returns full paths to files, not just filenames
            * 
            * Note: This method is synchronous and might be slow for directories
            * with many files or on network paths
            */
            ThrowIfDisposed();
            return new List<string>(Directory.GetFiles(_backupDirectory));
        }

        /// <summary>
        /// Copies a file from source path to destination path.
        /// </summary>
        /// <param name="sourcePath">The path of the source file to copy.</param>
        /// <param name="destinationPath">The path where the file should be copied to.</param>
        /// <returns>True if the copy was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sourcePath or destinationPath is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        public bool CopyFile(string sourcePath, string destinationPath)
        {
            /*
            * File copy process:
            * 1. Opens source file for reading
            * 2. Creates destination file
            * 3. Copies data using streams
            * 4. Handles any I/O errors
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Creates FileStream for source with Read access
            * - Creates FileStream for destination with Create mode
            * - Uses 'using' statements for proper resource disposal
            * - Uses Stream.CopyTo for efficient buffered copying
            * - Logs any errors that occur during copying
            * - Returns true on successful copy
            * 
            * Error handling:
            * - Catches and logs any exceptions
            * - Rethrows exceptions for caller handling
            * - Ensures streams are properly closed even on error
            * 
            * TODO: In the future, make this method async (CopyFileAsync)
            */
            ThrowIfDisposed();

            try
            {
                using var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
                using var destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);
                sourceStream.CopyTo(destinationStream);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File copy failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a file at the specified path.
        /// </summary>
        /// <param name="filePath">The path of the file to delete.</param>
        /// <returns>True if the deletion was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        public bool DeleteFile(string filePath)
        {
            /*
            * File deletion process:
            * 1. Validates object state
            * 2. Attempts to delete the file
            * 3. Logs any errors
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Uses File.Delete for direct file deletion
            * - Wraps deletion in try-catch for error handling
            * - Logs success implicitly (no exception)
            * - Logs any errors that occur during deletion
            * - Returns true on successful deletion
            * 
            * Error handling:
            * - Catches and logs IOException, UnauthorizedAccessException
            * - Rethrows exceptions for caller handling
            * 
            * TODO: In the future, make this method async (DeleteFileAsync)
            */
            ThrowIfDisposed();

            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"File deletion failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Checks if a file exists at the specified path.
        /// </summary>
        /// <param name="filePath">The path of the file to check.</param>
        /// <returns>True if the file exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        public bool Exists(string filePath)
        {
            /*
            * File existence check:
            * 1. Validates object state
            * 2. Checks if file exists
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Uses File.Exists for direct existence check
            * - Returns boolean without exception handling
            * - No logging needed for this simple operation
            * 
            * Note: This method is lightweight and fast for local files,
            * but might be slower for network paths
            * 
            * TODO: In the future, make this method async (ExistsAsync)
            */
            ThrowIfDisposed();
            return File.Exists(filePath);
        }

        /// <summary>
        /// Gets the size of a file in bytes.
        /// </summary>
        /// <param name="filePath">The path of the file to get the size of.</param>
        /// <returns>The size of the file in bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        public long GetFileSize(string filePath)
        {
            /*
            * File size retrieval:
            * 1. Validates object state
            * 2. Gets file information
            * 3. Returns file length
            * 
            * Implementation details:
            * - Uses ThrowIfDisposed to ensure the manager is still valid
            * - Creates FileInfo object for file metadata access
            * - Returns Length property directly
            * - No need for try-catch as FileInfo constructor doesn't throw
            * - Actual exceptions will occur when accessing Length
            * 
            * Note: This method is efficient as it doesn't open the file,
            * just reads the metadata
            * 
            * TODO: In the future, make this method async (GetFileSizeAsync)
            */
            ThrowIfDisposed();
            return new FileInfo(filePath).Length;
        }

        private void ThrowIfDisposed()
        {
            /*
            * Disposal check:
            * 1. Checks if object has been disposed
            * 2. Throws if disposed
            * 
            * Implementation details:
            * - Checks _disposed field directly
            * - Throws ObjectDisposedException if true
            * - Includes class name in exception message
            * - Used by all public methods to ensure valid state
            * 
            * This prevents operations on disposed objects and provides
            * clear error messages when misused
            */
            if (_disposed)
                throw new ObjectDisposedException(nameof(FileBackupSystem));
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            /*
            * Resource cleanup:
            * 1. Checks if already disposed
            * 2. Marks as disposed
            * 
            * Implementation details:
            * - Uses _disposed field to prevent multiple disposal
            * - Checks disposing parameter for managed cleanup
            * - Currently no managed resources to clean up
            * - Sets _disposed flag to true after cleanup
            * 
            * Note: This class doesn't own any unmanaged resources directly,
            * but follows proper IDisposable pattern for future expansion
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
            * IDisposable implementation:
            * 1. Calls virtual Dispose
            * 2. Suppresses finalization
            * 
            * Implementation details:
            * - Calls Dispose(true) for full cleanup
            * - Uses GC.SuppressFinalize to prevent unnecessary finalization
            * - This is the method called by using statements
            * 
            * This implements the standard IDisposable pattern correctly
            */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~FileBackupSystem()
        {
            /*
            * Finalizer:
            * 1. Calls Dispose(false)
            * 2. Only cleans up unmanaged resources
            * 
            * Implementation details:
            * - Called by garbage collector if Dispose() wasn't called
            * - Passes false to indicate unmanaged cleanup only
            * - Serves as a safety net for resource cleanup
            * 
            * Note: This should rarely be called if the class is used correctly
            * with using statements or explicit Dispose calls
            */
            Dispose(false);
        }
    }
}