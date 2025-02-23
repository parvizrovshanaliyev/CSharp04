using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice.UserProfileSystem;

using System;
using System.Text.RegularExpressions;


/// <summary>
/// Represents a user profile with basic validation.
/// This class is marked as <c>sealed</c> to prevent inheritance, ensuring security and consistency in user profile management.
/// By sealing the class, we ensure that no subclass can alter its validation logic or behavior.
/// </summary>
public sealed class UserProfile
{
    /// <summary>
    /// Gets the user's name. This property is read-only to maintain data integrity.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the user's age. This property is read-only and validated within the constructor.
    /// </summary>
    public int Age { get; }

    /// <summary>
    /// Gets the user's email. This property is read-only and validated using a regex pattern.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserProfile"/> class.
    /// Ensures that all fields are valid before assigning values.
    /// </summary>
    /// <param name="name">The user's name, which cannot be empty.</param>
    /// <param name="age">The user's age, which must be between 0 and 120.</param>
    /// <param name="email">The user's email, which must be in a valid format.</param>
    /// <exception cref="ArgumentException">Thrown when name is empty, age is invalid, or email format is incorrect.</exception>
    public UserProfile(string name, int age, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (age < 0 || age > 120)
            throw new ArgumentException("Invalid age.");

        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format.");

        Name = name;
        Age = age;
        Email = email;
    }

    /// <summary>
    /// Displays user profile information in a formatted manner.
    /// </summary>
    public void DisplayProfile()
    {
        Console.WriteLine("User Profile:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Email: {Email}");
    }

    /// <summary>
    /// Validates whether the provided email is in a correct format using a regular expression.
    /// </summary>
    /// <param name="email">The email string to validate.</param>
    /// <returns><c>true</c> if the email format is valid; otherwise, <c>false</c>.</returns>
    private static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
    }
}
