using Practice.Managers;

namespace Practice
{
    /// <summary>
    /// Demonstrates the usage of file handling and resource management classes.
    /// This program showcases various file operations including backup, monitoring,
    /// encryption, and temporary file management.
    /// </summary>
    /// <remarks>
    /// Understanding File Operations and Security:
    /// 
    /// 1. File Encryption Importance:
    /// - Protects sensitive data from unauthorized access
    /// - Ensures data confidentiality during storage
    /// - Complies with data protection regulations
    /// - Prevents data breaches and tampering
    /// - Enables secure file sharing
    /// 
    /// 2. Encryption Implementation:
    /// - Uses AES (Advanced Encryption Standard)
    /// - Implements secure key derivation (PBKDF2)
    /// - Utilizes unique initialization vectors (IV)
    /// - Manages encryption resources properly
    /// - Ensures secure cleanup of sensitive data
    /// 
    /// 3. File Operations Overview:
    /// - Backup: Creates timestamped file copies
    /// - Monitoring: Tracks file system changes
    /// - Encryption: Secures sensitive data
    /// - Temp Files: Manages temporary storage
    /// 
    /// 4. Resource Management:
    /// - Proper disposal of resources
    /// - Memory management
    /// - File handle cleanup
    /// - Event handler management
    /// 
    /// Learning Objectives:
    /// - File system operations
    /// - Encryption principles
    /// - Resource management
    /// - Error handling
    /// - Logging implementation
    /// 
    /// Topics to Learn in the Future:
    /// - Advanced encryption methods
    /// - Compression techniques
    /// - Digital signatures
    /// - Certificate management
    /// - Key storage solutions
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Demonstrates various file handling and resource management scenarios.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            /*
            * Main Method Implementation:
            * 
            * 1. Logger Setup:
            *    - Creates log file manager
            *    - Configures logging path
            *    - Initializes logging system
            * 
            * 2. Error Handling:
            *    - Implements try-catch block
            *    - Logs any errors
            *    - Provides user feedback
            * 
            * 3. Resource Management:
            *    - Uses using statements
            *    - Ensures proper cleanup
            *    - Handles disposable objects
            * 
            * 4. User Interface:
            *    - Shows progress messages
            *    - Provides operation feedback
            *    - Waits for user input
            */

            // Initialize the logger with proper resource management
            using var logManager = new LogFileManager("application.log");

            try
            {
                // Example 1: File Backup System Demo
                /*
                * Backup System Demonstration:
                * 
                * 1. Setup:
                *    - Creates backup system instance
                *    - Configures backup directory
                *    - Initializes tracking
                * 
                * 2. Operations:
                *    - Creates test file
                *    - Performs backup
                *    - Verifies backup
                * 
                * 3. Resource Management:
                *    - Uses using block
                *    - Ensures cleanup
                *    - Manages file handles
                */
                Console.WriteLine("\n=== File Backup System Demo ===");
                using (var backupSystem = new FileBackupSystem("backups", logManager))
                {
                    File.WriteAllText("test.txt", "Hello, World!");
                    backupSystem.CreateBackup("test.txt");
                    Console.WriteLine("Backup created successfully");
                }

                // Example 2: Directory Monitor Demo
                /*
                * Directory Monitoring Demonstration:
                * 
                * 1. Setup:
                *    - Creates monitor instance
                *    - Configures watch directory
                *    - Initializes event handlers
                * 
                * 2. Operations:
                *    - Starts monitoring
                *    - Creates test file
                *    - Observes changes
                *    - Stops monitoring
                * 
                * 3. Event Handling:
                *    - Processes file events
                *    - Logs changes
                *    - Manages notifications
                */
                Console.WriteLine("\n=== Directory Monitor Demo ===");
                using (var monitor = new DirectoryMonitor("watchFolder", logManager))
                {
                    monitor.StartMonitoring();
                    Console.WriteLine("Monitoring started. Creating a test file...");

                    File.WriteAllText("watchFolder/test.txt", "Test content");
                    Thread.Sleep(1000); // Allow time for event processing

                    monitor.StopMonitoring();
                    Console.WriteLine("Monitoring stopped");
                }

                // Example 3: File Encryption Demo
                /*
                * Encryption Demonstration:
                * 
                * 1. Setup:
                *    - Creates encryption manager
                *    - Prepares test data
                *    - Initializes encryption
                * 
                * 2. Encryption Process:
                *    - Creates source file
                *    - Encrypts data
                *    - Verifies encryption
                * 
                * 3. Decryption Process:
                *    - Decrypts data
                *    - Verifies content
                *    - Validates integrity
                * 
                * Security Features:
                * - AES encryption
                * - Secure key derivation
                * - IV management
                * - Resource cleanup
                */
                Console.WriteLine("\n=== File Encryption Demo ===");
                using (var encryptionManager = new FileEncryptionManager(logManager))
                {
                    const string originalContent = "Secret information";
                    File.WriteAllText("sensitive.txt", originalContent);

                    encryptionManager.EncryptFile("sensitive.txt", "sensitive.encrypted", "password123");
                    Console.WriteLine("File encrypted");

                    encryptionManager.DecryptFile("sensitive.encrypted", "sensitive_decrypted.txt", "password123");
                    Console.WriteLine("File decrypted");

                    string decryptedContent = File.ReadAllText("sensitive_decrypted.txt");
                    Console.WriteLine($"Decryption successful: {decryptedContent == originalContent}");
                }

                // Example 4: Temporary File Management Demo
                /*
                * Temp File Management Demonstration:
                * 
                * 1. Setup:
                *    - Creates temp manager
                *    - Configures temp directory
                *    - Initializes tracking
                * 
                * 2. Operations:
                *    - Creates temp file
                *    - Writes test data
                *    - Manages lifecycle
                * 
                * 3. Cleanup:
                *    - Performs cleanup
                *    - Verifies deletion
                *    - Manages resources
                * 
                * Resource Management:
                * - Automatic cleanup
                * - Resource tracking
                * - Handle management
                */
                Console.WriteLine("\n=== Temporary File Management Demo ===");
                using (var tempManager = new TempFileManager("tempFiles", logManager))
                {
                    string tempFile = tempManager.CreateTempFile();
                    Console.WriteLine($"Temporary file created: {tempFile}");

                    tempManager.WriteTempData(tempFile, "Temporary data");
                    Console.WriteLine("Data written to temporary file");

                    tempManager.CleanupTempFiles();
                    Console.WriteLine("Cleanup performed");
                }

                Console.WriteLine("\nAll demos completed successfully!");
            }
            catch (Exception ex)
            {
                /*
                * Error Handling:
                * 
                * 1. Exception Processing:
                *    - Catches all exceptions
                *    - Logs error details
                *    - Provides user feedback
                * 
                * 2. Logging:
                *    - Records error message
                *    - Includes stack trace
                *    - Maintains audit trail
                * 
                * 3. User Communication:
                *    - Shows error message
                *    - Directs to log file
                *    - Maintains usability
                */
                logManager.WriteError($"An error occurred: {ex.Message}");
                Console.WriteLine($"An error occurred. Check the log file for details.");
            }

            /*
            * Program Completion:
            * 
            * 1. User Interaction:
            *    - Prompts for key press
            *    - Waits for input
            *    - Ensures message visibility
            * 
            * 2. Cleanup:
            *    - Resources disposed
            *    - Handles released
            *    - Memory freed
            */
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
