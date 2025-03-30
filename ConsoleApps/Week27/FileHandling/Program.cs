using System;
using System.IO;
using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the path to the file
            string filePath = @"C:\New folder\MyFile.txt";

            // Define the content to write and append
            string initialText = "This file was just created.";
            string appendedText = "C# is an Object-Oriented Programming Language.";

            try
            {
                Console.WriteLine("=== File Operation Started ===");

                /*
                 * Step 1: CREATE the file and write initial text
                 * FileMode.Create: Creates a new file, or overwrites if it already exists
                 * FileAccess.Write: We only want to write at this point
                 * FileShare.ReadWrite: Allows other processes to read/write at the same time
                 */
                using (FileStream createStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(createStream, Encoding.UTF8))
                {
                    writer.WriteLine(initialText); // Write the initial line of text
                    Console.WriteLine("File created with initial content.");
                }

                /*
                 * Step 2: APPEND more text to the existing file
                 * FileMode.Append: Opens the file and moves the pointer to the end
                 * FileAccess.Write: We will only write
                 * FileShare.ReadWrite: Allows other processes to read/write simultaneously
                 */
                using (FileStream appendStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(appendStream, Encoding.UTF8))
                {
                    writer.WriteLine(appendedText); // Append the second line of text
                    Console.WriteLine("Text appended to the file.");
                }

                /*
                 * Step 3: READ and display the file content
                 * FileMode.Open: Open the existing file
                 * FileAccess.Read: We are only reading
                 * FileShare.ReadWrite: Allows other processes to access while we read
                 */
                using (FileStream readStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(readStream, Encoding.UTF8))
                {
                    string fileContent = reader.ReadToEnd(); // Read the entire content
                    Console.WriteLine("\n=== File Content ===");
                    Console.WriteLine(fileContent); // Output the content to console
                }
            }
            catch (Exception ex)
            {
                /*
                 * Catch any exception that might occur during the process.
                 * For example: File not found, access denied, path invalid, etc.
                 */
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }

            // Prompt to exit
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
