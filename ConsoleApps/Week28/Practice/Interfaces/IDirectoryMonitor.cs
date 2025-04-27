using System;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines a contract for directory monitoring operations.
    /// This interface provides methods for monitoring directory changes and handling file system events.
    /// </summary>
    /// <remarks>
    /// The IDirectoryMonitor interface is designed to:
    /// - Provide real-time directory monitoring capabilities
    /// - Handle file system events efficiently
    /// - Support proper resource management through IDisposable
    /// - Ensure consistent event handling
    /// 
    /// Key design considerations:
    /// - Event-based monitoring
    /// - Resource cleanup
    /// - Error handling
    /// - State management
    /// 
    /// Implementation requirements:
    /// - Handle file system events appropriately
    /// - Ensure thread safety
    /// - Manage system resources properly
    /// - Implement proper error handling
    /// - Support monitoring configuration
    /// </remarks>
    public interface IDirectoryMonitor : IDisposable
    {
        /// <summary>
        /// Gets whether the monitor is currently active.
        /// </summary>
        bool IsMonitoring { get; }

        /// <summary>
        /// Gets the path being monitored.
        /// </summary>
        string MonitoredPath { get; }

        /// <summary>
        /// Starts monitoring the directory for changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when monitoring is already active.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the monitor has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Initialize monitoring resources
        /// - Set up event handlers
        /// - Begin watching for changes
        /// - Handle startup errors
        /// </remarks>
        void StartMonitoring();

        /// <summary>
        /// Stops monitoring the directory.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the monitor has been disposed.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Stop watching for changes
        /// - Clean up event handlers
        /// - Release monitoring resources
        /// - Handle shutdown errors
        /// </remarks>
        void StopMonitoring();

        /// <summary>
        /// Event raised when a file is created in the monitored directory.
        /// </summary>
        event EventHandler<FileSystemEventArgs> FileCreated;

        /// <summary>
        /// Event raised when a file is deleted from the monitored directory.
        /// </summary>
        event EventHandler<FileSystemEventArgs> FileDeleted;

        /// <summary>
        /// Event raised when a file is modified in the monitored directory.
        /// </summary>
        event EventHandler<FileSystemEventArgs> FileChanged;

        /// <summary>
        /// Event raised when a file is renamed in the monitored directory.
        /// </summary>
        event EventHandler<RenamedEventArgs> FileRenamed;

        /// <summary>
        /// Event raised when an error occurs during monitoring.
        /// </summary>
        event EventHandler<ErrorEventArgs> MonitorError;

        /// <summary>
        /// Configures the monitoring settings.
        /// </summary>
        /// <param name="includeSubdirectories">Whether to monitor subdirectories.</param>
        /// <param name="filter">The file filter pattern (e.g., "*.txt").</param>
        /// <exception cref="ObjectDisposedException">Thrown when the monitor has been disposed.</exception>
        /// <exception cref="ArgumentException">Thrown when filter is invalid.</exception>
        /// <remarks>
        /// Implementation should:
        /// - Validate configuration parameters
        /// - Apply monitoring settings
        /// - Handle reconfiguration while active
        /// - Update internal state
        /// </remarks>
        void Configure(bool includeSubdirectories = true, string filter = "*.*");
    }
}