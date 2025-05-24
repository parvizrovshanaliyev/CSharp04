using System.Collections.Generic;
using UndoTextEditor.Models;

namespace UndoTextEditor.Repositories
{
    /// <summary>
    /// Defines the contract for text storage operations
    /// </summary>
    public interface ITextRepository
    {
        /// <summary>
        /// Saves the text lines to storage
        /// </summary>
        /// <param name="lines">The collection of text lines to save</param>
        void Save(IEnumerable<TextLine> lines);

        /// <summary>
        /// Loads text lines from storage
        /// </summary>
        /// <returns>A collection of text lines</returns>
        IEnumerable<TextLine> Load();

        /// <summary>
        /// Checks if storage exists
        /// </summary>
        /// <returns>True if storage exists, false otherwise</returns>
        bool Exists();
    }
}