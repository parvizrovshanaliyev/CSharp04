using System;
using System.Collections.Generic;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for file backup operations.
    /// This interface provides methods for creating backups, restoring from backups,
    /// and managing backup files.
    /// </summary>
    /// <remarks>
    /// The IFileBackup interface is designed to:
    /// - Provide file backup functionality
    /// - Support backup restoration
    /// - Manage backup listings
    /// - Handle resource cleanup
    /// 
    /// Key design considerations:
    /// - Backup file management
    /// - Resource cleanup
    /// - Error handling
    /// - Operation logging
    /// 
    /// Implementation requirements:
    /// - Handle file system operations safely
    /// - Manage backup directory
    /// - Implement proper error handling
    /// - Support backup file tracking
    /// </remarks>
    public interface IFileBackup : IDisposable
    {
        /// <summary>
        /// Creates a backup of the specified file with a timestamp.
        /// </summary>
        /// <param name="sourceFile">The path of the file to backup.</param>
        /// <returns>True if the backup was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when sourceFile is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
        /// <exception cref="IOException">Thrown when the backup operation fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate source file
        /// - Create timestamped backup
        /// - Handle file copying
        /// - Log operations
        /// </remarks>
        bool CreateBackup(string sourceFile);

        /// <summary>
        /// Restores a file from a backup.
        /// </summary>
        /// <param name="backupFile">The path of the backup file to restore from.</param>
        /// <returns>True if the restore was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when backupFile is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the backup file does not exist.</exception>
        /// <exception cref="IOException">Thrown when the restore operation fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate backup file
        /// - Create restored file
        /// - Handle file copying
        /// - Log operations
        /// </remarks>
        bool RestoreFromBackup(string backupFile);

        /// <summary>
        /// Lists all backup files in the backup directory.
        /// </summary>
        /// <returns>A list of paths to backup files.</returns>
        /// <exception cref="ObjectDisposedException">Thrown when the backup system has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - List all backup files
        /// - Handle directory access
        /// - Filter backup files
        /// - Return full paths
        /// </remarks>
        List<string> ListBackups();

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
        /// <remarks>
        /// Implementation should:
        /// - Validate paths
        /// - Handle file copying
        /// - Manage resources
        /// - Log operations
        /// </remarks>
        bool CopyFile(string sourcePath, string destinationPath);

        /// <summary>
        /// Deletes a file at the specified path.
        /// </summary>
        /// <param name="filePath">The path of the file to delete.</param>
        /// <returns>True if the deletion was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate file path
        /// - Handle file deletion
        /// - Log operations
        /// - Handle errors
        /// </remarks>
        bool DeleteFile(string filePath);

        /// <summary>
        /// Checks if a file exists at the specified path.
        /// </summary>
        /// <param name="filePath">The path of the file to check.</param>
        /// <returns>True if the file exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate file path
        /// - Check existence
        /// - Handle errors
        /// - Log operations
        /// </remarks>
        bool Exists(string filePath);
    }
}