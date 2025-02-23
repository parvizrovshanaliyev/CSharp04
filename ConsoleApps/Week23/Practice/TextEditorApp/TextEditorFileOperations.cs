using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TextEditorApp;

/// <summary>
/// Simulates file operations for the text editor.
/// </summary>
public partial class TextEditor
{
    private StringBuilder simulatedFile = new StringBuilder();

    public void SaveToFile()
    {
        simulatedFile.Clear();
        simulatedFile.Append(content.ToString());
        Console.WriteLine("(Simulated) Text saved to file.");
    }

    public void LoadFromFile()
    {
        if (simulatedFile.Length > 0)
        {
            content.Clear();
            content.Append(simulatedFile.ToString());
            Console.WriteLine("(Simulated) Text loaded from file.");
        }
        else
        {
            Console.WriteLine("(Simulated) No file found to load.");
        }
    }
}
