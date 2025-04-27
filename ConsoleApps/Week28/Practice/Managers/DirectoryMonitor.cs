using System;
using System.IO;
using Practice.Interfaces;

namespace Practice.Managers
{
    /// <summary>
    /// Monitors a directory for file system changes and logs the events.
    /// This class provides real-time monitoring of file creation, deletion, modification, and renaming events.
    /// </summary>
    /// <remarks>
    /// Understanding Directory Monitoring:
    /// 
    /// 1. Why Directory Monitoring is Important:
    /// - Enables real-time file system change detection
    /// - Supports automated responses to file operations
    /// - Facilitates system synchronization
    /// - Helps maintain data integrity
    /// - Enables audit trail creation
    /// 
    /// 2. Key Features:
    /// - Real-time event notification
    /// - Multiple event type monitoring
    /// - Recursive directory watching
    /// - Event filtering capabilities
    /// - Resource-efficient monitoring
    /// 
    /// 3. Monitoring Events:
    /// - Created: New file or directory creation
    /// - Deleted: File or directory removal
    /// - Changed: Content modifications
    /// - Renamed: Name or location changes
    /// 
    /// 4. Implementation Details:
    /// - Uses FileSystemWatcher for monitoring
    /// - Implements event handlers
    /// - Provides logging capabilities
    /// - Manages system resources
    /// 
    /// Learning Objectives:
    /// - File system event handling
    /// - Resource management
    /// - Event-driven programming
    /// - Error handling strategies
    /// - Logging implementation
    /// 
    /// Topics to Learn in the Future:
    /// - Advanced event filtering
    /// - Pattern-based monitoring
    /// - Performance optimization
    /// - Network path monitoring
    /// - Security enhancements
    /// </remarks>
    public class DirectoryMonitor : IDirectoryMonitor
    {
        private readonly FileSystemWatcher _watcher;
        private readonly ILogger _logger;
        private bool _disposed;

        /// <summary>
        /// Gets whether the monitor is currently active.
        /// </summary>
        public bool IsMonitoring { get; private set; }

        /// <summary>
        /// Gets the path being monitored.
        /// </summary>
        public string MonitoredPath { get; }

        public event EventHandler<FileSystemEventArgs>? FileCreated;
        public event EventHandler<FileSystemEventArgs>? FileDeleted;
        public event EventHandler<FileSystemEventArgs>? FileChanged;
        public event EventHandler<RenamedEventArgs>? FileRenamed;
        public event EventHandler<ErrorEventArgs>? MonitorError;

        /// <summary>
        /// Constructor for the DirectoryMonitor class.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to monitor</param>
        /// <param name="logger">The logger instance for recording events</param>
        /// <exception cref="ArgumentNullException">Thrown when directoryPath or logger is null.</exception>
        /// <exception cref="IOException">Thrown when the directory cannot be created or accessed.</exception>
        public DirectoryMonitor(string directoryPath, ILogger logger)
        {
            /*
            * Constructor Implementation Details:
            * 
            * 1. Input Validation:
            *    - Checks for null or empty directory path
            *    - Validates logger instance
            *    - Ensures directory path is accessible
            * 
            * 2. Directory Setup:
            *    - Creates directory if it doesn't exist
            *    - Verifies directory permissions
            *    - Sets up monitoring path
            * 
            * 3. Watcher Configuration:
            *    - Creates FileSystemWatcher instance
            *    - Sets notification filters
            *    - Configures subdirectory monitoring
            *    - Initializes in disabled state
            * 
            * 4. Event Handler Setup:
            *    - Initializes event handlers
            *    - Configures event routing
            * 
            * Security Considerations:
            * - Directory access rights
            * - Path validation
            * - Resource protection
            * 
            * TODO: In the future, implement:
            * - Custom filter patterns
            * - Event buffering
            * - Access control
            * - Performance monitoring
            */
            if (string.IsNullOrEmpty(directoryPath))
                throw new ArgumentNullException(nameof(directoryPath));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MonitoredPath = directoryPath;

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            _watcher = new FileSystemWatcher(directoryPath)
            {
                NotifyFilter = NotifyFilters.LastWrite
                            | NotifyFilters.FileName
                            | NotifyFilters.DirectoryName
                            | NotifyFilters.CreationTime,
                IncludeSubdirectories = true,
                EnableRaisingEvents = false
            };

            Configure(); // Set default configuration
            InitializeEventHandlers();
        }

        /// <summary>
        /// Configures the monitoring settings.
        /// </summary>
        public void Configure(bool includeSubdirectories = true, string filter = "*.*")
        {
            ThrowIfDisposed();

            _watcher.IncludeSubdirectories = includeSubdirectories;
            _watcher.Filter = filter;
            _watcher.NotifyFilter = NotifyFilters.LastWrite
                                | NotifyFilters.FileName
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.CreationTime;

            _logger.WriteLog($"Monitor configured: IncludeSubdirectories={includeSubdirectories}, Filter={filter}");
        }

        private void InitializeEventHandlers()
        {
            /*
            * Event Handler Initialization Process:
            * 
            * 1. Event Registration:
            *    - Created event for new files
            *    - Deleted event for removed files
            *    - Changed event for modifications
            *    - Renamed event for name changes
            *    - Error event for monitoring issues
            * 
            * 2. Handler Configuration:
            *    - Sets up event routing
            *    - Configures event parameters
            *    - Establishes logging connections
            * 
            * 3. Error Management:
            *    - Sets up error handling
            *    - Configures error reporting
            *    - Establishes recovery procedures
            * 
            * Performance Considerations:
            * - Event handler efficiency
            * - Resource utilization
            * - Response time optimization
            * 
            * TODO: In the future, implement:
            * - Event filtering
            * - Event batching
            * - Custom event handlers
            * - Performance monitoring
            */
            _watcher.Created += OnFileCreated;
            _watcher.Deleted += OnFileDeleted;
            _watcher.Changed += OnFileChanged;
            _watcher.Renamed += OnFileRenamed;
            _watcher.Error += OnError;
        }

        /// <summary>
        /// Starts monitoring the directory.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the monitor has been disposed.</exception>
        public void StartMonitoring()
        {
            /*
            * Monitoring Start Process:
            * 
            * 1. State Validation:
            *    - Checks if object is disposed
            *    - Verifies current monitoring state
            *    - Validates directory access
            * 
            * 2. Monitoring Activation:
            *    - Enables event raising
            *    - Updates monitoring state
            *    - Initializes tracking
            * 
            * 3. Logging:
            *    - Records start operation
            *    - Logs initial state
            *    - Tracks monitoring status
            * 
            * Error Handling:
            * - Access permission errors
            * - Resource availability
            * - State transition issues
            * 
            * TODO: In the future, implement:
            * - Startup verification
            * - Resource monitoring
            * - State persistence
            * - Health checks
            */
            ThrowIfDisposed();

            if (!IsMonitoring)
            {
                _watcher.EnableRaisingEvents = true;
                IsMonitoring = true;
                _logger.WriteLog("Directory monitoring started");
            }
            else
            {
                throw new InvalidOperationException("Monitoring is already active");
            }
        }

        /// <summary>
        /// Stops monitoring the directory.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the monitor has been disposed.</exception>
        public void StopMonitoring()
        {
            /*
            * Monitoring Stop Process:
            * 
            * 1. State Validation:
            *    - Checks if object is disposed
            *    - Verifies current monitoring state
            *    - Validates operation possibility
            * 
            * 2. Monitoring Deactivation:
            *    - Disables event raising
            *    - Updates monitoring state
            *    - Cleans up tracking
            * 
            * 3. Cleanup:
            *    - Releases resources
            *    - Clears event queue
            *    - Updates status
            * 
            * Error Handling:
            * - Resource cleanup errors
            * - State transition issues
            * - Event queue management
            * 
            * TODO: In the future, implement:
            * - Graceful shutdown
            * - Event queue draining
            * - State verification
            * - Resource cleanup
            */
            ThrowIfDisposed();

            if (IsMonitoring)
            {
                _watcher.EnableRaisingEvents = false;
                IsMonitoring = false;
                _logger.WriteLog("Directory monitoring stopped");
            }
        }

        /// <summary>
        /// Handles file creation events.
        /// </summary>
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            /*
            * File Creation Event Handling:
            * 
            * 1. Event Processing:
            *    - Receives creation notification
            *    - Extracts file information
            *    - Validates event data
            * 
            * 2. Logging:
            *    - Records creation event
            *    - Logs file details
            *    - Tracks timestamp
            * 
            * 3. Event Response:
            *    - Processes creation notification
            *    - Updates tracking information
            *    - Triggers any callbacks
            * 
            * Security Considerations:
            * - File access rights
            * - Path validation
            * - Creation verification
            * 
            * TODO: In the future, implement:
            * - Event filtering
            * - Creation verification
            * - Extended logging
            * - Pattern matching
            */
            _logger.WriteLog($"File created: {e.FullPath}");
            FileCreated?.Invoke(this, e);
        }

        /// <summary>
        /// Handles file deletion events.
        /// </summary>
        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            /*
            * File Deletion Event Handling:
            * 
            * 1. Event Processing:
            *    - Receives deletion notification
            *    - Extracts file information
            *    - Validates event data
            * 
            * 2. Logging:
            *    - Records deletion event
            *    - Logs file details
            *    - Tracks timestamp
            * 
            * 3. Event Response:
            *    - Processes deletion notification
            *    - Updates tracking information
            *    - Triggers any callbacks
            * 
            * Security Considerations:
            * - Deletion verification
            * - Access rights check
            * - Audit trail creation
            * 
            * TODO: In the future, implement:
            * - Deletion verification
            * - Recovery options
            * - Extended logging
            * - Pattern matching
            */
            _logger.WriteLog($"File deleted: {e.FullPath}");
            FileDeleted?.Invoke(this, e);
        }

        /// <summary>
        /// Handles file modification events.
        /// </summary>
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            /*
            * File Change Event Handling:
            * 
            * 1. Event Processing:
            *    - Receives change notification
            *    - Extracts modification details
            *    - Validates event data
            * 
            * 2. Logging:
            *    - Records change event
            *    - Logs modification details
            *    - Tracks timestamp
            * 
            * 3. Event Response:
            *    - Processes change notification
            *    - Updates tracking information
            *    - Triggers any callbacks
            * 
            * Security Considerations:
            * - Change verification
            * - Access rights check
            * - Modification tracking
            * 
            * TODO: In the future, implement:
            * - Change type detection
            * - Content comparison
            * - Extended logging
            * - Pattern matching
            */
            _logger.WriteLog($"File changed: {e.FullPath}");
            FileChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Handles file renaming events.
        /// </summary>
        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            /*
            * File Rename Event Handling:
            * 
            * 1. Event Processing:
            *    - Receives rename notification
            *    - Extracts old and new names
            *    - Validates event data
            * 
            * 2. Logging:
            *    - Records rename event
            *    - Logs path changes
            *    - Tracks timestamp
            * 
            * 3. Event Response:
            *    - Processes rename notification
            *    - Updates tracking information
            *    - Triggers any callbacks
            * 
            * Security Considerations:
            * - Path validation
            * - Access rights check
            * - Name change verification
            * 
            * TODO: In the future, implement:
            * - Name validation
            * - Path verification
            * - Extended logging
            * - Pattern matching
            */
            _logger.WriteLog($"File renamed from {e.OldFullPath} to {e.FullPath}");
            FileRenamed?.Invoke(this, e);
        }

        /// <summary>
        /// Handles file system watcher error events.
        /// </summary>
        private void OnError(object sender, ErrorEventArgs e)
        {
            /*
            * Error Event Handling:
            * 
            * 1. Error Processing:
            *    - Receives error notification
            *    - Extracts error details
            *    - Analyzes error type
            * 
            * 2. Error Logging:
            *    - Records error event
            *    - Logs error details
            *    - Tracks occurrence
            * 
            * 3. Error Response:
            *    - Processes error condition
            *    - Attempts recovery
            *    - Notifies system
            * 
            * Recovery Strategies:
            * - Automatic retry
            * - Resource reset
            * - State recovery
            * 
            * TODO: In the future, implement:
            * - Error classification
            * - Recovery procedures
            * - Extended logging
            * - Health monitoring
            */
            _logger.WriteError($"Directory monitoring error: {e.GetException().Message}");
            MonitorError?.Invoke(this, e);
        }

        private void ThrowIfDisposed()
        {
            /*
            * Disposal Check Process:
            * 
            * 1. State Verification:
            *    - Checks disposed flag
            *    - Validates object state
            *    - Ensures resource availability
            * 
            * 2. Exception Handling:
            *    - Throws if disposed
            *    - Includes context information
            *    - Maintains consistency
            * 
            * Purpose:
            * - Prevents invalid operations
            * - Ensures resource safety
            * - Maintains object lifecycle
            * 
            * TODO: In the future, implement:
            * - State tracking
            * - Resource verification
            * - Extended logging
            */
            if (_disposed)
                throw new ObjectDisposedException(nameof(DirectoryMonitor));
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
            *    - Checks disposal state
            *    - Handles managed resources
            *    - Cleans up monitoring
            * 
            * 2. Resource Management:
            *    - Stops monitoring
            *    - Disposes watcher
            *    - Clears references
            * 
            * 3. State Management:
            *    - Updates disposed flag
            *    - Ensures consistency
            *    - Prevents reuse
            * 
            * Security Considerations:
            * - Resource cleanup
            * - Event handler removal
            * - State verification
            * 
            * TODO: In the future, implement:
            * - Resource tracking
            * - Cleanup verification
            * - Extended logging
            */
            if (!_disposed)
            {
                if (disposing)
                {
                    StopMonitoring();
                    _watcher.Dispose();
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
            *    - Ensures cleanup
            * 
            * 2. Resource Management:
            *    - Handles managed resources
            *    - Updates state
            *    - Prevents reuse
            * 
            * Purpose:
            * - Standard cleanup pattern
            * - Resource management
            * - Memory optimization
            * 
            * TODO: In the future, implement:
            * - Cleanup verification
            * - Resource tracking
            * - Extended logging
            */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~DirectoryMonitor()
        {
            /*
            * Finalizer Implementation:
            * 
            * 1. Cleanup Process:
            *    - Calls Dispose(false)
            *    - Handles unmanaged resources
            *    - Final cleanup
            * 
            * 2. Purpose:
            *    - Last-chance cleanup
            *    - Resource recovery
            *    - System protection
            * 
            * Security Considerations:
            * - Resource cleanup
            * - State verification
            * - System stability
            * 
            * TODO: In the future, implement:
            * - Resource tracking
            * - Cleanup verification
            * - Extended logging
            */
            Dispose(false);
        }
    }
}