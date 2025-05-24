using System;
using System.Collections.Generic;
using System.Linq;
using UndoTextEditor.Models;
using UndoTextEditor.Repositories;

namespace UndoTextEditor.Services
{
    /// <summary>
    /// Implementation of the text editor service
    /// </summary>
    public class TextEditorService : ITextEditorService
    {
        private readonly Stack<TextLine> _textLines;
        private readonly ITextRepository _repository;

        /// <summary>
        /// Initializes a new instance of the TextEditorService class
        /// </summary>
        /// <param name="repository">The text repository to use</param>
        /// <exception cref="ArgumentNullException">Thrown when repository is null</exception>
        public TextEditorService(ITextRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _textLines = new Stack<TextLine>();
        }

        /// <summary>
        /// Adds a new line of text
        /// </summary>
        /// <param name="content">The text content to add</param>
        /// <returns>True if the line was added successfully</returns>
        public bool AddLine(string content)
        {
            try
            {
                var line = new TextLine(content);
                _textLines.Push(line);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Undoes the last added line
        /// </summary>
        /// <returns>The removed line, or null if no lines exist</returns>
        public TextLine Undo()
        {
            return _textLines.Count > 0 ? _textLines.Pop() : null;
        }

        /// <summary>
        /// Gets all current text lines
        /// </summary>
        /// <returns>A collection of text lines</returns>
        public IEnumerable<TextLine> GetAllLines()
        {
            return _textLines.Reverse();
        }

        /// <summary>
        /// Clears all text lines
        /// </summary>
        public void Clear()
        {
            _textLines.Clear();
        }

        /// <summary>
        /// Saves the current text to storage
        /// </summary>
        public void Save()
        {
            _repository.Save(GetAllLines());
        }

        /// <summary>
        /// Loads text from storage
        /// </summary>
        public void Load()
        {
            Clear();
            var lines = _repository.Load();
            foreach (var line in lines.Reverse())
            {
                _textLines.Push(line);
            }
        }
    }
}