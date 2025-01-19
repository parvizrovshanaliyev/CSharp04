using LibraryManagementSystem.Managers;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AuthenticationManager authManager = new AuthenticationManager();

            authManager.Login();
        }
    }
}
