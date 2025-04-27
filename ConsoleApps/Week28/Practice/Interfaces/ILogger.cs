using System;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for logging operations in the application.
    /// This interface provides methods for writing logs and errors, and retrieving log file information.
    /// Implements IDisposable to ensure proper resource cleanup.
    /// </summary>
    /// <remarks>
    /// The ILogger interface is designed to:
    /// - Provide a standardized way to log information and errors
    /// - Support resource cleanup through IDisposable
    /// - Allow log file size monitoring
    /// - Be thread-safe in implementations
    /// 
    /// This interface is crucial for:
    /// - Debugging and troubleshooting
    /// - Audit trails
    /// - System monitoring
    /// - Error tracking
    /// 
    /// Implementations should ensure:
    /// - Thread safety for concurrent logging
    /// - Proper file handling and resource management
    /// - Efficient logging operations
    /// - Appropriate error handling
    /// </remarks>
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// Writes an informational message to the log.
        /// </summary>
        /// <param name="message">The message to be logged. Should not be null or empty.</param>
        /// <exception cref="ArgumentNullException">Thrown when message is null or empty.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the logger has been disposed.</exception>
        /// <remarks>
        /// This method should:
        /// - Format the message with timestamp
        /// - Handle concurrent write operations
        /// - Ensure proper file handling
        /// - Implement appropriate buffering if needed
        /// </remarks>
        void WriteLog(string message);

        /// <summary>
        /// Writes an error message to the log.
        /// </summary>
        /// <param name="error">The error message to be logged. Should not be null or empty.</param>
        /// <exception cref="ArgumentNullException">Thrown when error is null or empty.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the logger has been disposed.</exception>
        /// <remarks>
        /// This method should:
        /// - Format the error message with timestamp
        /// - Potentially include stack traces or additional error details
        /// - Handle concurrent write operations
        /// - Ensure proper file handling
        /// - Implement appropriate buffering if needed
        /// </remarks>
        void WriteError(string error);

        /// <summary>
        /// Gets the current size of the log file in bytes.
        /// </summary>
        /// <returns>The size of the log file in bytes.</returns>
        /// <exception cref="ObjectDisposedException">Thrown when the logger has been disposed.</exception>
        /// <remarks>
        /// This method should:
        /// - Handle file access properly
        /// - Be thread-safe
        /// - Return accurate file size even with concurrent writes
        /// - Handle potential file system errors
        /// 
        /// The size information can be used for:
        /// - Log rotation decisions
        /// - Disk space management
        /// - Monitoring and alerting
        /// </remarks>
        long GetLogSize();
    }
}