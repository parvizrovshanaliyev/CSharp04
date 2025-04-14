using System.Text;

namespace FileHandling.FileInfoClass
{
    /// <summary>
    /// Demonstrates common file handling operations using the System.IO.FileInfo class.
    /// This class showcases object-oriented file operations and metadata handling.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Demonstrates various FileInfo operations including file creation, metadata access,
        /// file manipulation, and proper resource handling.
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        static void Main(string[] args)
        {
            /*
             * Define constant file paths for our examples
             * Using Path.Combine ensures cross-platform compatibility
             */
            string baseDir = Environment.CurrentDirectory;
            string mainFile = Path.Combine(baseDir, "report.txt");
            string backupDir = Path.Combine(baseDir, "backup");
            string archiveDir = Path.Combine(baseDir, "archive");

            try
            {
                /*
                 * Example 1: Creating a FileInfo Instance
                 * Demonstrates instantiation and basic property access
                 * FileInfo provides rich metadata about the file
                 */
                Console.WriteLine("1. Creating FileInfo instance...");
                var fileInfo = new FileInfo(mainFile);
                Console.WriteLine($"File path: {fileInfo.FullName}");
                Console.WriteLine($"Directory: {fileInfo.DirectoryName}");

                /*
                 * Example 2: Creating and Writing to a File
                 * Shows how to create a new file and write content
                 * Uses StreamWriter with proper resource disposal
                 */
                Console.WriteLine("\n2. Creating and writing to file...");
                using (StreamWriter writer = fileInfo.CreateText())
                {
                    writer.WriteLine("Hello from FileInfo!");
                    writer.WriteLine("This is a test file created at: " + DateTime.Now);
                    writer.WriteLine("Demonstrating FileInfo capabilities.");
                }
                Console.WriteLine("File created and content written successfully.");

                /*
                 * Example 3: Reading File Metadata
                 * Demonstrates accessing various file properties
                 * FileInfo caches these properties for better performance
                 */
                Console.WriteLine("\n3. Reading file metadata...");
                fileInfo.Refresh(); // Refresh to ensure latest metadata
                Console.WriteLine($"File Name: {fileInfo.Name}");
                Console.WriteLine($"Extension: {fileInfo.Extension}");
                Console.WriteLine($"Size: {fileInfo.Length} bytes");
                Console.WriteLine($"Created: {fileInfo.CreationTime}");
                Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Read-only?: {fileInfo.IsReadOnly}");

                /*
                 * Example 4: Reading File Content
                 * Shows how to read file content using FileInfo
                 * Uses StreamReader with proper resource disposal
                 */
                Console.WriteLine("\n4. Reading file content...");
                using (StreamReader reader = fileInfo.OpenText())
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"  {line}");
                    }
                }

                /*
                 * Example 5: Creating Backup Directory and Copying File
                 * Demonstrates directory creation and file copying
                 * Shows how to handle existing files
                 */
                Console.WriteLine("\n5. Creating backup...");
                Directory.CreateDirectory(backupDir);
                string backupFile = Path.Combine(backupDir, "report_backup.txt");
                FileInfo backupFileInfo = fileInfo.CopyTo(backupFile, overwrite: true);
                Console.WriteLine($"Backup created: {backupFileInfo.FullName}");

                /*
                 * Example 6: Moving File to Archive
                 * Shows how to move files between directories
                 * Demonstrates proper directory handling
                 */
                Console.WriteLine("\n6. Moving to archive...");
                Directory.CreateDirectory(archiveDir);
                string archiveFile = Path.Combine(archiveDir, "report_archived.txt");
                if (File.Exists(archiveFile))
                {
                    File.Delete(archiveFile);
                }
                backupFileInfo.MoveTo(archiveFile);
                Console.WriteLine("File moved to archive successfully.");

                /*
                 * Example 7: Appending Content
                 * Demonstrates how to append content to existing file
                 * Uses AppendText for efficient append operations
                 */
                Console.WriteLine("\n7. Appending content...");
                using (StreamWriter writer = fileInfo.AppendText())
                {
                    writer.WriteLine("\nThis line was appended at: " + DateTime.Now);
                }
                Console.WriteLine("Content appended successfully.");

                /*
                 * Example 8: Cleanup Operations
                 * Shows proper cleanup of created files and directories
                 * Demonstrates existence checking before deletion
                 */
                Console.WriteLine("\n8. Cleaning up...");
                if (fileInfo.Exists) fileInfo.Delete();
                if (Directory.Exists(archiveDir))
                {
                    Directory.Delete(archiveDir, recursive: true);
                }
                if (Directory.Exists(backupDir))
                {
                    Directory.Delete(backupDir, recursive: true);
                }
                Console.WriteLine("Cleanup completed successfully.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
                Console.WriteLine("Please check if you have the necessary permissions.");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found: {ex.Message}");
                Console.WriteLine("Please verify the directory path is correct.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO Error: {ex.Message}");
                Console.WriteLine("An error occurred while performing file operations.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                Console.WriteLine("Please contact support if the issue persists.");
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
