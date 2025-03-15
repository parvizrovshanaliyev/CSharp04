namespace Practice.Helpers;

/// <summary>
/// Provides utility methods for date and time operations.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// Returns today's date in "yyyy-MM-dd" format.
    /// Example:
    /// <code>
    /// DateTimeHelper.GetCurrentDate();
    /// // Output: 2025-03-08
    /// </code>
    /// </summary>
    public static string GetCurrentDate() => DateTime.Now.ToString("yyyy-MM-dd");

    /// <summary>
    /// Calculates the number of days between two dates.
    /// Example:
    /// <code>
    /// DateTimeHelper.DaysBetween(DateTime.Now, new DateTime(2025, 12, 31))
    /// // Output: X days
    /// </code>
    /// </summary>
    public static int DaysBetween(DateTime start, DateTime end) => (end - start).Days;
}