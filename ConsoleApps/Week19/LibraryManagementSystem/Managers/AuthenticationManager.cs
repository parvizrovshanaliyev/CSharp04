using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Managers;

public class AuthenticationManager
{
    private readonly User[] _users;
    private int _userCount;
    private const int MaxUsers = 10;
    private const int MaxLoginAttempts = 3;
    private User? loggedInUser = null;

    public AuthenticationManager()
    {
        _users = new User[MaxUsers];
        _userCount = 0;

        var user1 = new User(username: "admin", password: "admin1234@");
        var user2 = new User(username: "moderator", password: "moderator1234@");

        AddUser(user1);
        AddUser(user2);

    }

    public bool AddUser(User user)
    {
        if (_userCount >= MaxUsers)
        {
            Console.WriteLine($"User limit reached. {_userCount}/{MaxUsers} users are already registered.");
            return false;
        }

        // 0
        _users[_userCount++] = user;
        return true;
    }

    public bool Login()
    {
        int attemptCount = 0;


        while (attemptCount < MaxLoginAttempts)
        {

            // admin
            string username = GetValidatedInput(
                prompt: "Enter username:",
                errorMessage: "Username cannot be empty.Please try again.");

            // ******
            string password = GetValidatedInput(
                prompt: "Enter password:",
                errorMessage: "Password cannot be empty.Please try again.",
                maskInput: true);


            for (int i = 0; i < _userCount; i++)
            {
                if (username == _users[i].Username && _users[i].ValidatePassword(password))
                {
                    loggedInUser = _users[i];
                    Console.WriteLine($"Welcome, {username}");
                    return true;
                }
            }

            attemptCount++;
            Console.WriteLine($"Invalid credentials. Please try again. You have {MaxLoginAttempts - attemptCount} attempts remaining.");
        }

        Console.WriteLine("Maximum login attempts exceeded. Access denied.");
        return false;
    }

    public void Logout()
    {
        if (IsLoggedIn())
        {
            Console.WriteLine("goodbye");
            loggedInUser = null;
        }
        else
        {
            Console.WriteLine("No user is currently logged in.");
        }
    }

    public bool IsLoggedIn()
    {
        return loggedInUser != null;
    }

    private string GetValidatedInput(string prompt, string errorMessage, bool maskInput = false)
    {
        string input;

        do
        {
            Console.WriteLine(prompt);
            input = maskInput ? ReadPassword() : Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(errorMessage);
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    private string ReadPassword()
    {
        string password = string.Empty;


        ConsoleKey key;

        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }

        } while (key != ConsoleKey.Enter);

        Console.WriteLine();

        return password;
    }

}