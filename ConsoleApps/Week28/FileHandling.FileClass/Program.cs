using System.Text;

namespace FileHandling.FileClass
{
    /// <summary>
    /// Demonstrates common file handling operations using the System.IO.File class.
    /// This class provides examples of creating, writing, reading, and manipulating files.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Demonstrates various file operations including creation, writing, reading, and error handling.
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        static void Main(string[] args)
        {
            /*
             * Define constant file paths for our examples
             * Using constants makes it easier to maintain and update paths
             */
            const string mainFile = "example.txt";
            const string backupFile = "backup.txt";
            const string archiveFile = "archive/archived.txt";

            try
            {
                /*
                 * Example 1: Creating and Writing to a File
                 * Demonstrates basic file creation and writing operations
                 * WriteAllText creates a new file (or overwrites existing) and writes content
                 */
                Console.WriteLine("1. Creating and writing to a file...");
                File.WriteAllText(mainFile, "Hello, World!\nThis is a test file.");
                Console.WriteLine($"Created and wrote to {mainFile}");

                /*
                 * Example 2: Reading File Content
                 * Shows how to read the entire content of a file into a string
                 * ReadAllText is useful for small files that can fit in memory
                 */
                Console.WriteLine("\n2. Reading file content...");
                string content = File.ReadAllText(mainFile);
                Console.WriteLine("File content:");
                Console.WriteLine(content);

                /*
                 * Example 3: Appending Content
                 * Demonstrates how to add new content to an existing file
                 * AppendAllText preserves existing content and adds new text at the end
                 */
                Console.WriteLine("\n3. Appending to file...");
                File.AppendAllText(mainFile, "\nThis line was appended!");
                Console.WriteLine("Content appended successfully.");

                /*
                 * Example 4: Reading File Line by Line
                 * Shows how to read a file line by line using ReadAllLines
                 * Useful when you need to process file content line by line
                 */
                Console.WriteLine("\n4. Reading file line by line...");
                string[] lines = File.ReadAllLines(mainFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"Line {i + 1}: {lines[i]}");
                }

                /*
                 * Example 5: File Copy Operation
                 * Demonstrates how to create a backup copy of a file
                 * The overwrite parameter allows replacing existing files
                 */
                Console.WriteLine("\n5. Creating a backup copy...");
                File.Copy(mainFile, backupFile, overwrite: true);
                Console.WriteLine($"Backup created: {backupFile}");

                /*
                 * Example 6: Creating Directory and Moving File
                 * Shows how to create a directory and move a file into it
                 * Directory.CreateDirectory ensures the target directory exists
                 */
                Console.WriteLine("\n6. Moving file to archive...");
                Directory.CreateDirectory("archive");
                if (File.Exists(archiveFile))
                {
                    File.Delete(archiveFile);
                }
                File.Move(backupFile, archiveFile);
                Console.WriteLine("File moved to archive successfully.");

                /*
                 * Example 7: File Information
                 * Demonstrates how to get file information using File static methods
                 * Shows creation time, last access time, and last write time
                 */
                Console.WriteLine("\n7. Displaying file information...");
                Console.WriteLine($"Creation Time: {File.GetCreationTime(mainFile)}");
                Console.WriteLine($"Last Access: {File.GetLastAccessTime(mainFile)}");
                Console.WriteLine($"Last Write: {File.GetLastWriteTime(mainFile)}");

                /*
                 * Example 8: Clean up demonstration files
                 * Shows how to check for file existence and delete files
                 * Always verify file existence before attempting to delete
                 */
                Console.WriteLine("\n8. Cleaning up...");
                if (File.Exists(mainFile)) File.Delete(mainFile);
                if (File.Exists(archiveFile)) File.Delete(archiveFile);
                if (Directory.Exists("archive")) Directory.Delete("archive");
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
