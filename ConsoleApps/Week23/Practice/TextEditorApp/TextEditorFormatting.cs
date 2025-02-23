using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TextEditorApp;

/// <summary>
/// Provides text formatting options.
/// </summary>
public partial class TextEditor
{
    public void ToUpperCase()
    {
        content = new StringBuilder(content.ToString().ToUpper());
    }

    public void ToLowerCase()
    {
        content = new StringBuilder(content.ToString().ToLower());
    }
}
