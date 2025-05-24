using System.Collections.Generic;
using UndoTextEditor.Models;

namespace UndoTextEditor.Services
{
    /// <summary>
    /// Defines the contract for text editing operations
    /// </summary>
    public interface ITextEditorService
    {
        /// <summary>
        /// Adds a new line of text
        /// </summary>
        /// <param name="content">The text content to add</param>
        /// <returns>True if the line was added successfully</returns>
        bool AddLine(string content);

        /// <summary>
        /// Undoes the last added line
        /// </summary>
        /// <returns>The removed line, or null if no lines exist</returns>
        TextLine Undo();

        /// <summary>
        /// Gets all current text lines
        /// </summary>
        /// <returns>A collection of text lines</returns>
        IEnumerable<TextLine> GetAllLines();

        /// <summary>
        /// Clears all text lines
        /// </summary>
        void Clear();

        /// <summary>
        /// Saves the current text to storage
        /// </summary>
        void Save();

        /// <summary>
        /// Loads text from storage
        /// </summary>
        void Load();
    }
}