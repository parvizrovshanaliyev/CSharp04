using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UndoTextEditor.Models;

namespace UndoTextEditor.Repositories
{
    /// <summary>
    /// File-based implementation of the text repository
    /// </summary>
    public class FileTextRepository : ITextRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the FileTextRepository class
        /// </summary>
        /// <param name="filePath">The path to the storage file</param>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null</exception>
        public FileTextRepository(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        /// <summary>
        /// Saves the text lines to a file
        /// </summary>
        /// <param name="lines">The collection of text lines to save</param>
        public void Save(IEnumerable<TextLine> lines)
        {
            try
            {
                var content = string.Join(Environment.NewLine, lines.Select(l => l.Content));
                File.WriteAllText(_filePath, content);
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to save text to file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Loads text lines from a file
        /// </summary>
        /// <returns>A collection of text lines</returns>
        public IEnumerable<TextLine> Load()
        {
            try
            {
                if (!Exists())
                    return Enumerable.Empty<TextLine>();

                var lines = File.ReadAllLines(_filePath);
                return lines.Select(line => new TextLine(line));
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to load text from file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Checks if the storage file exists
        /// </summary>
        /// <returns>True if the file exists, false otherwise</returns>
        public bool Exists()
        {
            return File.Exists(_filePath);
        }
    }
}