namespace LibraryManagementSystem.Models;

/// <summary>
///  User class to store credentials
/// </summary>
public class User
{
    public string Username { get; private set; }
    private string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool ValidatePassword(string inputPassword)
    {
        return Password == inputPassword;
    }
}