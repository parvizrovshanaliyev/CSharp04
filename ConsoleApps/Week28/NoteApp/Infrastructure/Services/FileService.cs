using NoteApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Infrastructure.Services
{
    /// <summary>
    /// Implements the IFileService interface to provide concrete file system operations.
    /// This class handles the low-level file operations using the System.IO namespace.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Appends the specified content to a file.
        /// Creates the file if it doesn't exist.
        /// </summary>
        /// <param name="path">The path to the target file.</param>
        /// <param name="content">The content to append.</param>
        public void Append(string path, string content)
        {
            /*
             * AppendAllText will:
             * - Create the file if it doesn't exist
             * - Open the file
             * - Add the content at the end
             * - Close the file (handled by the method)
             */
            File.AppendAllText(path, content);
        }

        /// <summary>
        /// Reads all content from the specified file.
        /// </summary>
        /// <param name="path">The path to the file to read.</param>
        /// <returns>The content of the file, or empty string if the file doesn't exist.</returns>
        public string Read(string path)
        {
            /*
             * Check file existence before reading
             * Return empty string if file doesn't exist to prevent exceptions
             */
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        /// <summary>
        /// Deletes the specified file if it exists.
        /// </summary>
        /// <param name="path">The path to the file to delete.</param>
        public void Delete(string path)
        {
            /*
             * Check file existence before attempting deletion
             * This prevents unnecessary exceptions
             */
            if (File.Exists(path)) File.Delete(path);
        }

        /// <summary>
        /// Checks if a file exists at the specified path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True if the file exists; otherwise, false.</returns>
        public bool Exists(string path)
        {
            /*
             * Simple wrapper around File.Exists
             * Provides consistency with the interface
             */
            return File.Exists(path);
        }
    }
}
