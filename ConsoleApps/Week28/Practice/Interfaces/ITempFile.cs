using System;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for temporary file operations.
    /// This interface provides methods for creating, writing to, and managing temporary files.
    /// </summary>
    /// <remarks>
    /// The ITempFile interface is designed to:
    /// - Provide temporary file management
    /// - Handle file cleanup
    /// - Manage resource lifecycle
    /// - Ensure secure operations
    /// 
    /// Key design considerations:
    /// - File lifecycle management
    /// - Resource cleanup
    /// - Security handling
    /// - Error management
    /// 
    /// Implementation requirements:
    /// - Handle file operations safely
    /// - Implement proper cleanup
    /// - Manage file tracking
    /// - Handle errors appropriately
    /// </remarks>
    public interface ITempFile : IDisposable
    {
        /// <summary>
        /// Creates a new temporary file with a unique name.
        /// </summary>
        /// <returns>The full path to the created temporary file.</returns>
        /// <exception cref="IOException">Thrown when file creation fails.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when access is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Generate unique filename
        /// - Create empty file
        /// - Track created file
        /// - Handle errors
        /// </remarks>
        string CreateTempFile();

        /// <summary>
        /// Writes data to a temporary file.
        /// </summary>
        /// <param name="tempFile">The path to the temporary file.</param>
        /// <param name="data">The data to write to the file.</param>
        /// <exception cref="ArgumentNullException">Thrown when tempFile is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the temporary file is not found.</exception>
        /// <exception cref="IOException">Thrown when writing fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate file exists
        /// - Write data safely
        /// - Handle errors
        /// - Track modifications
        /// </remarks>
        void WriteTempData(string tempFile, string data);

        /// <summary>
        /// Manually triggers cleanup of expired temporary files.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the manager has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Check file age
        /// - Remove expired files
        /// - Update tracking
        /// - Handle errors
        /// </remarks>
        void CleanupTempFiles();
    }
}