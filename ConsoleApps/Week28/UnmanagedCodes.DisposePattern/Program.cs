using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedCodes.DisposePattern;


public class MyResource : IDisposable
{
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~MyResource()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

/// <summary>
/// Demonstrates proper implementation of the Dispose Pattern for file handling operations.
/// This class manages both managed and unmanaged resources, implementing IDisposable
/// to ensure proper cleanup of system resources.
/// </summary>
/// <remarks>
/// The class follows the complete Dispose Pattern including:
/// - Implementation of IDisposable
/// - Protected virtual Dispose method for inheritance scenarios
/// - Finalizer for backup cleanup
/// - Safe handling of multiple resource types
/// - Thread-safe disposal checks
/// </remarks>
public class FileHandler : IDisposable
{
    /*
     * Private fields to track the state and resources:
     * - _disposed: Tracks whether the object has been disposed
     * - _handle: SafeFileHandle for the underlying file handle (unmanaged resource)
     * - _fileStream: Managed wrapper around the file handle
     * - _writer: High-level stream writer for text operations
     * - _filePath: Stores the path for error reporting and tracking
     */
    private bool _disposed = false;
    /// <summary>
    /// SafeFileHandle represents a wrapper around a native file handle.
    /// It provides safe handling of unmanaged file resources by implementing
    /// proper cleanup through the SafeHandle base class.
    /// </summary>
    /// <remarks>
    /// - This is an unmanaged resource that must be explicitly disposed
    /// - Inherits from SafeHandle to ensure proper resource cleanup
    /// - Used as a safe wrapper around the raw file handle
    /// - Prevents handle recycling and use-after-free bugs
    /// - Automatically releases the handle when disposed
    /// </remarks>
    private SafeFileHandle _handle;
    private FileStream _fileStream;
    private StreamWriter _writer;
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the FileHandler class.
    /// Opens or creates a file at the specified path with read/write access.
    /// </summary>
    /// <param name="filePath">The full path to the file to handle.</param>
    /// <exception cref="IOException">Thrown when file access fails.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when file permissions are insufficient.</exception>
    /// <exception cref="ArgumentException">Thrown when filePath is invalid.</exception>
    public FileHandler(string filePath)
    {
        /*
         * Constructor implementation steps:
         * 1. Store the file path for reference
         * 2. Open a safe file handle using File.OpenHandle
         * 3. Create a FileStream from the handle
         * 4. Create a StreamWriter for text operations
         * 5. Handle any exceptions and ensure cleanup on failure
         */
        _filePath = filePath;
        try
        {
            _handle = File.OpenHandle(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _fileStream = new FileStream(_handle, FileAccess.ReadWrite);
            _writer = new StreamWriter(_fileStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing FileHandler: {ex.Message}");
            // Ensure cleanup of any resources that were successfully created
            Dispose(true);
            throw;
        }
    }

    /// <summary>
    /// Writes the specified content to the file, followed by a line terminator.
    /// </summary>
    /// <param name="content">The string to write to the file.</param>
    /// <exception cref="ObjectDisposedException">Thrown if the FileHandler has been disposed.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
    public void WriteToFile(string content)
    {
        /*
         * Write operation steps:
         * 1. Check if object has been disposed
         * 2. Write the content using StreamWriter
         * 3. Flush to ensure content is written to disk
         * 4. Handle any exceptions during writing
         */
        CheckDisposed();
        try
        {
            _writer.WriteLine(content);
            _writer.Flush();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Reads all content from the file and returns it as a string.
    /// The file pointer is reset to the beginning before reading.
    /// </summary>
    /// <returns>A string containing all text from the file.</returns>
    /// <exception cref="ObjectDisposedException">Thrown if the FileHandler has been disposed.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
    public string ReadFromFile()
    {
        /*
         * Read operation steps:
         * 1. Check if object has been disposed
         * 2. Reset file position to start
         * 3. Create temporary StreamReader
         * 4. Read entire file content
         * 5. Handle any exceptions during reading
         */
        CheckDisposed();
        try
        {
            _fileStream.Position = 0;
            using var reader = new StreamReader(_fileStream, leaveOpen: true);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from file: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Implements the IDisposable interface. Performs application-defined tasks associated
    /// with freeing, releasing, or resetting managed and unmanaged resources.
    /// </summary>
    /// <remarks>
    /// This method follows the standard Dispose pattern:
    /// 1. Calls the protected virtual Dispose method with disposing=true
    /// 2. Suppresses finalization to prevent redundant cleanup
    /// </remarks>
    public void Dispose()
    {
        /*
         * Standard dispose implementation:
         * - Call the virtual dispose method with disposing=true
         * - Tell GC to suppress finalization since we've cleaned up
         */
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Protected implementation of Dispose pattern.
    /// </summary>
    /// <param name="disposing">
    /// True: Clean up both managed and unmanaged resources.
    /// False: Clean up only unmanaged resources.
    /// </param>
    /// <remarks>
    /// When disposing=true, this method is being called by user code or the Dispose method.
    /// When disposing=false, this method is being called by the finalizer and should only cleanup unmanaged resources.
    /// </remarks>
    protected virtual void Dispose(bool disposing)
    {
        /*
         * Resource cleanup implementation:
         * 1. Check if already disposed to prevent multiple disposals
         * 2. If disposing=true (called from Dispose method):
         *    - Dispose managed resources (StreamWriter, FileStream, SafeFileHandle)
         *    - Set references to null to prevent accidental use
         * 3. Clean up any unmanaged resources regardless of disposing value
         * 4. Mark as disposed
         */
        if (_disposed)
            return;

        if (disposing)
        {
            // Clean up managed resources (dispose in reverse order of creation)
            if (_writer != null)
            {
                _writer.Dispose();
                _writer = null;
            }

            if (_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }

            if (_handle != null)
            {
                _handle.Dispose();
                _handle = null;
            }
        }

        // Clean up unmanaged resources here if any

        _disposed = true;
    }

    /// <summary>
    /// Finalizer (destructor) for the FileHandler class.
    /// Provides backup cleanup of resources if user forgets to call Dispose.
    /// </summary>
    /// <remarks>
    /// The finalizer is a backup mechanism and should ideally never be needed
    /// if the object is properly disposed by calling Dispose().
    /// </remarks>
    ~FileHandler()
    {
        /*
         * Finalizer implementation:
         * - Call Dispose with disposing=false to cleanup only unmanaged resources
         * - This runs on the finalizer thread and should do minimal work
         */
        Dispose(false);
    }

    /// <summary>
    /// Checks if the object has been disposed and throws an exception if it has.
    /// </summary>
    /// <exception cref="ObjectDisposedException">
    /// Thrown when the object has already been disposed.
    /// </exception>
    private void CheckDisposed()
    {
        /*
         * Disposal check implementation:
         * - Throws ObjectDisposedException if object has been disposed
         * - Helps prevent use of disposed objects which could cause errors
         */
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(FileHandler));
        }
    }
}

/// <summary>
/// Main program class demonstrating various ways to use the FileHandler class
/// and proper resource management techniques.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main entry point of the application. Demonstrates different patterns
    /// for using and disposing of FileHandler instances.
    /// </summary>
    /// <param name="args">Command line arguments (not used).</param>
    static void Main(string[] args)
    {
        Console.WriteLine("Demonstrating Dispose Pattern with File Handling\n");

        string filePath = "test.txt";

        try
        {
            /*
             * Example 1: Using statement (recommended approach)
             * - Automatically calls Dispose when block exits
             * - Ensures proper cleanup even if exception occurs
             * - Most concise and safe way to use disposable objects
             */
            Console.WriteLine("Example 1: Using 'using' statement");
            using (var fileHandler = new FileHandler(filePath))
            {
                fileHandler.WriteToFile("Hello, World!");
                Console.WriteLine("Content written to file.");

                string content = fileHandler.ReadFromFile();
                Console.WriteLine($"Read from file: {content}");
            }
            Console.WriteLine("FileHandler disposed automatically.\n");

            /*
             * Example 2: Manual disposal with try-finally
             * - Shows explicit disposal pattern
             * - Demonstrates proper error handling
             * - Ensures cleanup in finally block
             */
            Console.WriteLine("Example 2: Manual disposal");
            var manualFileHandler = new FileHandler(filePath);
            try
            {
                manualFileHandler.WriteToFile("Testing manual disposal");
                Console.WriteLine("Content written to file.");

                string content = manualFileHandler.ReadFromFile();
                Console.WriteLine($"Read from file: {content}");
            }
            finally
            {
                if (manualFileHandler != null)
                {
                    manualFileHandler.Dispose();
                    Console.WriteLine("FileHandler disposed manually.");
                }
            }

            /*
             * Example 3: Demonstrating disposed object behavior
             * - Shows what happens when using disposed object
             * - Demonstrates proper exception handling
             * - Shows importance of checking disposed state
             */
            Console.WriteLine("\nExample 3: Demonstrating ObjectDisposedException");
            var disposedHandler = new FileHandler(filePath);
            disposedHandler.Dispose();
            try
            {
                disposedHandler.WriteToFile("This will fail");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Caught ObjectDisposedException as expected.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            /*
             * Cleanup: Remove test file
             * - Ensures test file is removed
             * - Demonstrates proper cleanup in finally block
             * - Shows checking for file existence before deletion
             */
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"\nTest file {filePath} deleted.");
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}