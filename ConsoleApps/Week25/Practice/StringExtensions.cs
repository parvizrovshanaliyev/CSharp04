namespace Practice;

/// <summary>
/// Provides extension methods for string operations.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Counts the number of words in a string.
    /// Example:
    /// <code>
    /// string sentence = "Hello world!";
    /// int wordCount = sentence.WordCount(); // Returns 2
    /// </code>
    /// </summary>
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}