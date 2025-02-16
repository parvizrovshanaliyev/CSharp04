namespace OOP.PartialClass;

/// <summary>
/// Main program class that demonstrates the usage of the AuthService partial class implementation.
/// Provides an interactive console interface for testing various authentication methods.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point of the application. Creates an instance of AuthService and provides
    /// an interactive menu for testing different authentication features.
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    /// <remarks>
    /// This method:
    /// 1. Creates an AuthService instance
    /// 2. Displays an interactive menu
    /// 3. Handles user input
    /// 4. Executes selected authentication operations
    /// 5. Provides error handling for all operations
    /// </remarks>
    static void Main(string[] args)
    {
        Console.WriteLine("Authentication Service Demo\n");

        var authService = new AuthService();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nAvailable Operations:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login (Username/Password)");
            Console.WriteLine("3. Login with Facebook");
            Console.WriteLine("4. Login with Google");
            Console.WriteLine("5. Change Password");
            Console.WriteLine("6. Reset Password");
            Console.WriteLine("7. Verify Email");
            Console.WriteLine("8. Verify Phone");
            Console.WriteLine("9. Verify 2FA");
            Console.WriteLine("10. Verify Captcha");
            Console.WriteLine("11. Verify ReCaptcha");
            Console.WriteLine("12. Logout");
            Console.WriteLine("0. Exit");

            Console.Write("\nSelect an operation (0-12): ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    case 1:
                        authService.Register();
                        break;
                    case 2:
                        authService.Login();
                        break;
                    case 3:
                        authService.LoginWithFacebook();
                        break;
                    case 4:
                        authService.LoginWithGoogle();
                        break;
                    case 5:
                        authService.ChangePassword();
                        break;
                    case 6:
                        authService.ResetPassword();
                        break;
                    case 7:
                        authService.VerifyEmail();
                        break;
                    case 8:
                        authService.VerifyPhone();
                        break;
                    case 9:
                        authService.VerifyTwoFactor();
                        break;
                    case 10:
                        authService.VerifyCaptcha();
                        break;
                    case 11:
                        authService.VerifyRecaptcha();
                        break;
                    case 12:
                        authService.Logout();
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a number between 0 and 12.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
