using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TextEditorApp;

/// <summary>
/// Provides basic text operations.
/// This is part of a modular text editor implementation using <c>partial</c> classes.
/// </summary>
public partial class TextEditor
{
    /// <summary>
    /// Stores the text content in a mutable string format for efficiency.
    /// </summary>
    private StringBuilder content = new StringBuilder();

    /// <summary>
    /// Writes text into the editor, appending it to existing content.
    /// </summary>
    /// <param name="text">The text to be added.</param>
    public void Write(string text)
    {
        content.AppendLine(text);
    }

    /// <summary>
    /// Clears all text content from the editor.
    /// </summary>
    public void Clear()
    {
        content.Clear();
    }

    /// <summary>
    /// Displays the current text content stored in the editor.
    /// </summary>
    public void Display()
    {
        Console.WriteLine("Text Content:");
        Console.WriteLine(content.ToString());
    }
}
