using System.Globalization;

namespace Practice;

/// <summary>
/// Provides helper methods for string operations.
/// </summary>
public static class StringHelper
{
    /// <summary>
    /// Checks if the given string is a palindrome.
    /// Example:
    /// <code>
    /// StringHelper.IsPalindrome("racecar") // Returns true
    /// </code>
    /// </summary>
    public static bool IsPalindrome(string input)
    {
        string reversed = new string(input.ToLower().ToCharArray().Reverse().ToArray());
        return input.ToLower() == reversed;
    }

    /// <summary>
    /// Converts the given string to title case.
    /// Example:
    /// <code>
    /// StringHelper.ToTitleCase("hello world") // Returns "Hello World"
    /// </code>
    /// </summary>
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(input.ToLower());
    }
}