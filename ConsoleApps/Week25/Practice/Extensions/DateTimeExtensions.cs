namespace Practice.Extensions;

/// <summary>
/// Provides extension methods for DateTime operations.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Calculates the age based on a given birthdate.
    /// Example:
    /// <code>
    /// DateTime birthdate = new DateTime(2000, 5, 10);
    /// int age = birthdate.GetAge(); // Returns the age based on the current date
    /// </code>
    /// </summary>
    public static int GetAge(this DateTime birthdate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthdate.Year;
        if (birthdate.Date > today.AddYears(-age)) age--;
        return age;
    }
}