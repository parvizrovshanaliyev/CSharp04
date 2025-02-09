using Spectre.Console;

namespace LMS.WithConsoleSpecter.Managers
{
    public class AuthManager
    {
        private const string Username = "admin";
        private const string Password = "password";

        public bool AuthenticateUser()
        {
            try
            {
                string username = AnsiConsole.Ask<string>("Enter username:");
                string password = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter password:")
                        .PromptStyle("red")
                        .Secret());

                if (username == Username && password == Password)
                {
                    AnsiConsole.MarkupLine("[bold green]Authentication successful![/]");
                    return true;
                }

                AnsiConsole.MarkupLine("[bold red]Invalid username or password.[/]");
                return false;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred during authentication: {ex.Message}[/]");
                return false;
            }
        }
    }
}
