using System.Text;

namespace FileHandling.DirectoryInfoClass
{
    /// <summary>
    /// A console application that inspects directories and generates reports about text files.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Prompts user for a directory path, analyzes .txt files, and generates a CSV report.
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        static void Main(string[] args)
        {
            /*
             * Display welcome message and get directory path from user.
             * The path will be used to inspect .txt files in that directory.
             */
            Console.WriteLine("Welcome to CLI Folder Inspector!");
            Console.Write("Please enter a directory path to inspect: ");
            string? path = Console.ReadLine();

            // Validate that the path is not empty or whitespace
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Path cannot be empty!");
                return;
            }

            try
            {
                /*
                 * Create DirectoryInfo object and verify directory exists.
                 * DirectoryInfo provides functionality to inspect and manipulate directory information.
                 */
                DirectoryInfo directory = new DirectoryInfo(path);

                if (!directory.Exists)
                {
                    Console.WriteLine("Directory does not exist!");
                    return;
                }

                /*
                 * Get all .txt files in the specified directory.
                 * FileInfo[] contains metadata about each file including name, size, and timestamps.
                 */
                FileInfo[] txtFiles = directory.GetFiles("*.txt");

                /*
                 * Initialize StringBuilder to construct CSV content.
                 * First line contains the column headers for the report.
                 */
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine("FileName,SizeInBytes,CreationTime,LastModifiedTime");

                Console.WriteLine("\nFound .txt files:");
                Console.WriteLine("----------------------------------------");

                /*
                 * Iterate through each text file:
                 * - Display file information to console
                 * - Add file information to CSV content
                 */
                foreach (var file in txtFiles)
                {
                    // Display detailed file information to console
                    Console.WriteLine($"File: {file.Name}");
                    Console.WriteLine($"Size: {file.Length} bytes");
                    Console.WriteLine($"Created: {file.CreationTime}");
                    Console.WriteLine($"Last Modified: {file.LastWriteTime}");
                    Console.WriteLine("----------------------------------------");

                    // Append file information as a new row in CSV content
                    csvContent.AppendLine($"{file.Name},{file.Length},{file.CreationTime},{file.LastWriteTime}");
                }

                /*
                 * Generate and save the CSV report in the inspected directory.
                 * Path.Combine ensures proper path formatting for the target OS.
                 */
                string reportPath = Path.Combine(directory.FullName, "DirectoryReport.csv");
                File.WriteAllText(reportPath, csvContent.ToString());

                Console.WriteLine($"\nReport saved to: {reportPath}");
            }
            catch (UnauthorizedAccessException)
            {
                // Handle access denied errors separately for better user feedback
                Console.WriteLine("Error: Access denied. Make sure you have the necessary permissions.");
            }
            catch (Exception ex)
            {
                // Catch all other unexpected errors and display the message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
