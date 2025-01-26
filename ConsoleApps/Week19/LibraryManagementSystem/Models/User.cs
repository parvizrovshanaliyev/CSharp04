namespace LibraryManagementSystem.Models;

/// <summary>
/// Represents a user in the library system.
/// Stores user credentials and authentication information.
/// </summary>
public class User
{
    /// <summary>
    /// Gets the username of the user.
    /// This property can only be set through the constructor.
    /// </summary>
    public string Username { get; private set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// This is private to ensure secure access.
    /// </summary>
    private string Password { get; set; }

    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    /// <param name="username">The username for the user</param>
    /// <param name="password">The password for the user</param>
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    /// <summary>
    /// Validates if the provided password matches the stored password.
    /// </summary>
    /// <param name="inputPassword">The password to validate</param>
    /// <returns>True if the password matches, false otherwise</returns>
    public bool ValidatePassword(string inputPassword)
    {
        return Password == inputPassword;
    }
}