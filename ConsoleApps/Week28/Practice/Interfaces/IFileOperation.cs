using System;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for file operations.
    /// This interface provides methods for common file operations like copying, deleting, and checking file existence.
    /// </summary>
    /// <remarks>
    /// The IFileOperation interface is designed to:
    /// - Provide file operations for basic file handling
    /// - Handle large files efficiently
    /// - Support proper resource management through IDisposable
    /// - Ensure consistent error handling
    /// 
    /// Key design considerations:
    /// - Operations return bool for success/failure indication
    /// - File paths are validated consistently
    /// - Resources are properly managed
    /// 
    /// Implementation requirements:
    /// - Handle file system exceptions appropriately
    /// - Ensure thread safety
    /// - Handle large files efficiently
    /// - Implement proper progress reporting if needed
    /// </remarks>
    public interface IFileOperation : IDisposable
    {
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
        /// - Use buffered copying for large files
        /// - Handle existing destination files appropriately
        /// - Preserve file attributes if needed
        /// - Implement progress reporting for large files
        /// - Handle network paths and slow I/O
        /// - Validate file paths and access rights
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
        /// - Handle file locks and sharing violations
        /// - Verify file existence before deletion
        /// - Handle access permissions
        /// - Support retry logic if needed
        /// - Clean up related resources
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
        /// - Handle network paths efficiently
        /// - Cache results if appropriate
        /// - Handle access permissions
        /// - Support UNC paths
        /// - Handle path validation
        /// </remarks>
        bool Exists(string filePath);

        /// <summary>
        /// Gets the size of a file in bytes.
        /// </summary>
        /// <param name="filePath">The path of the file to get the size of.</param>
        /// <returns>The size of the file in bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Handle large files (>2GB)
        /// - Support network paths
        /// - Handle file locks
        /// - Cache results if appropriate
        /// - Handle access permissions
        /// - Support progress reporting for large files
        /// </remarks>
        long GetFileSize(string filePath);

        /// <summary>
        /// Creates a new file at the specified path.
        /// </summary>
        /// <param name="filePath">The path where the file should be created.</param>
        /// <param name="content">The initial content to write to the file. If null, creates an empty file.</param>
        /// <returns>True if the file was created successfully.</returns>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the file operation manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Handle existing files appropriately
        /// - Set proper file permissions
        /// - Create necessary directories
        /// - Handle path validation
        /// - Support different encodings
        /// </remarks>
        bool CreateFile(string filePath, string? content = null);
    }
}