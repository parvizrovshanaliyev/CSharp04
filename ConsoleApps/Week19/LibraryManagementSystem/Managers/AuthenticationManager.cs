using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Managers;

/// <summary>
/// Represents an authentication manager in the library system.
/// Handles user authentication, login, and session management.
/// </summary>
public class AuthenticationManager
{
    /// <summary>
    /// Gets the array of registered users.
    /// This is private to ensure secure access.
    /// </summary>
    private readonly User[] _users;

    /// <summary>
    /// Gets or sets the current count of registered users.
    /// </summary>
    private int _userCount;

    /// <summary>
    /// The maximum number of users that can be registered.
    /// </summary>
    private const int MaxUsers = 10;

    /// <summary>
    /// The maximum number of login attempts allowed before access is denied.
    /// </summary>
    private const int MaxLoginAttempts = 3;

    /// <summary>
    /// Gets or sets the currently logged in user.
    /// Null if no user is logged in.
    /// </summary>
    private User? loggedInUser = null;

    /// <summary>
    /// Initializes a new instance of the AuthenticationManager class.
    /// Creates default admin and moderator users.
    /// </summary>
    public AuthenticationManager()
    {
        /*
         * Initialize the users array with the maximum capacity
         * and set initial user count to 0
         */
        _users = new User[MaxUsers];
        _userCount = 0;

        /*
         * Create default admin and moderator users with secure passwords
         * These users are created on system initialization to ensure
         * there are always administrative accounts available
         */
        var user1 = new User(username: "admin", password: "admin1234@");
        var user2 = new User(username: "moderator", password: "moderator1234@");

        /*
         * Add the default users to the system
         * The AddUser method handles incrementing _userCount
         * and checking capacity limits
         */
        AddUser(user1);
        AddUser(user2);
    }

    /// <summary>
    /// Adds a new user to the system if space is available.
    /// </summary>
    /// <param name="user">The user to add to the system</param>
    /// <returns>True if user was added successfully, false if at capacity</returns>
    public bool AddUser(User user)
    {
        /*
         * Check if we've reached the maximum number of allowed users.
         * If so, display an error message and return false to indicate failure.
         */
        if (_userCount >= MaxUsers)
        {
            Console.WriteLine($"User limit reached. {_userCount}/{MaxUsers} users are already registered.");
            return false;
        }

        /*
         * Add the new user to the array at the current count position,
         * then increment the count. The post-increment operator (++) 
         * ensures the user is added at the current position before
         * incrementing.
         */
        _users[_userCount++] = user;
        return true;
    }

    /// <summary>
    /// Handles the user login process with retry attempts.
    /// </summary>
    /// <returns>True if login successful, false otherwise</returns>
    public bool Login()
    {
        /*
         * Keep track of how many login attempts have been made.
         * This is used to enforce the MaxLoginAttempts limit.
         */
        int attemptCount = 0;

        /*
         * Allow the user to attempt logging in until they either:
         * 1. Successfully log in
         * 2. Exceed the maximum number of allowed attempts
         */
        while (attemptCount < MaxLoginAttempts)
        {
            /*
             * Get the username and password from the user.
             * The GetValidatedInput method ensures neither can be empty.
             * Password input is masked for security.
             */
            string username = GetValidatedInput(
                prompt: "Enter username:",
                errorMessage: "Username cannot be empty.Please try again.");

            string password = GetValidatedInput(
                prompt: "Enter password:",
                errorMessage: "Password cannot be empty.Please try again.",
                maskInput: true);

            /*
             * Search through all registered users to find a matching username/password.
             * If found, set that user as logged in and return success.
             */
            for (int i = 0; i < _userCount; i++)
            {
                if (username == _users[i].Username && _users[i].ValidatePassword(password))
                {
                    loggedInUser = _users[i];
                    Console.WriteLine($"Welcome, {username}");
                    return true;
                }
            }

            /*
             * If we get here, the login attempt failed.
             * Increment the attempt counter and notify the user of remaining attempts.
             */
            attemptCount++;
            Console.WriteLine($"Invalid credentials. Please try again. You have {MaxLoginAttempts - attemptCount} attempts remaining.");
        }

        /*
         * If we exit the while loop, the user has exceeded their allowed attempts.
         * Notify them and return failure.
         */
        Console.WriteLine("Maximum login attempts exceeded. Access denied.");
        return false;
    }

    /// <summary>
    /// Logs out the current user if one is logged in.
    /// </summary>
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

    /// <summary>
    /// Checks if a user is currently logged in.
    /// </summary>
    /// <returns>True if a user is logged in, false otherwise</returns>
    public bool IsLoggedIn()
    {
        return loggedInUser != null;
    }

    /// <summary>
    /// Gets validated input from the user with optional input masking.
    /// </summary>
    /// <param name="prompt">The prompt to display to the user</param>
    /// <param name="errorMessage">The error message to show for invalid input</param>
    /// <param name="maskInput">Whether to mask the input (for passwords)</param>
    /// <returns>The validated input string</returns>
    private string GetValidatedInput(string prompt, string errorMessage, bool maskInput = false)
    {
        /*
         * Declare a variable to store user input. This will be populated either through
         * direct console input or through the password masking method depending on the
         * maskInput parameter.
         */
        string input;

        do
        {
            /*
             * Display the prompt to the user and get their input.
             * If maskInput is true, use ReadPassword() which masks the input with asterisks.
             * Otherwise, use standard Console.ReadLine() for visible input.
             */
            Console.WriteLine(prompt);
            input = maskInput ? ReadPassword() : Console.ReadLine();

            /*
             * Validate that the input is not null, empty, or just whitespace.
             * If validation fails, display the error message to the user.
             */
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(errorMessage);
            }
        } while (string.IsNullOrWhiteSpace(input)); // Continue loop until valid input is received

        /*
         * Return the validated input string back to the calling method
         */
        return input;
    }

    /// <summary>
    /// Reads a password from the console while masking input.
    /// </summary>
    /// <returns>The password string entered by the user</returns>
    private string ReadPassword()
    {
        /*
         * Initialize an empty password string and a variable to store the pressed key.
         * The password will be built up character by character as the user types.
         */
        string password = string.Empty;
        ConsoleKey key;

        do
        {
            /*
             * Read the next keypress from the console without displaying it (intercept: true).
             * Store both the ConsoleKeyInfo object and extract just the key enum for convenience.
             */
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            /*
             * Handle backspace key - if pressed and password is not empty:
             * 1. Remove the last character from the password
             * 2. Move cursor back, write a space to erase *, move cursor back again
             */
            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            /*
             * For any other non-control character (regular keys):
             * 1. Add the character to the password string
             * 2. Display an asterisk to mask the actual character
             */
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }

        } while (key != ConsoleKey.Enter); // Continue until Enter key is pressed

        /*
         * Move to the next line after password entry is complete
         * Return the collected password string
         */
        Console.WriteLine();
        return password;
    }
}