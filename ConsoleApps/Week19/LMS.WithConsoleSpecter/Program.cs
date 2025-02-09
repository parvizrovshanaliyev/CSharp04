using Spectre.Console;
using LMS.WithConsoleSpecter.Managers;

namespace LMS.WithConsoleSpecter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var authManager = new AuthManager();
                if (authManager.AuthenticateUser())
                {
                    var libraryManager = new LibraryManager();
                    libraryManager.RunMainMenu();
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Authentication failed. Exiting...[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred: {ex.Message}[/]");
            }
        }
    }
}
