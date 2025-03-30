using System.Globalization;

namespace IntelligentUserProfileApp;

public static class StringExtensions
{
    public static int WordCount(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? 0 : input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string ToTitleCase(this string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}