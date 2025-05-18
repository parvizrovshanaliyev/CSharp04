using System.Collections;
using LMSWithArrayList.Models;

namespace LMSWithArrayList.Managers
{
    public class AuthenticationManager
    {
        private readonly ArrayList _users;
        private const int MaxLoginAttempts = 3;
        private User? _currentUser;

        public AuthenticationManager()
        {
            _users = new ArrayList();
            _currentUser = null;
            InitializeDefaultUsers();
        }

        private void InitializeDefaultUsers()
        {
            AddUser(new User("admin", "admin123", true));
            AddUser(new User("user", "user123"));
        }

        public bool AddUser(User user)
        {
            if (user == null)
            {
                Console.WriteLine("User cannot be null.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                Console.WriteLine("Username cannot be empty.");
                return false;
            }

            if (IsUsernameExists(user.Username))
            {
                Console.WriteLine("Username already exists.");
                return false;
            }

            _users.Add(user);
            Console.WriteLine($"User '{user.Username}' added successfully.");
            return true;
        }

        private bool IsUsernameExists(string username)
        {
            foreach (User user in _users)
            {
                if (user.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login()
        {
            int attempts = 0;
            while (attempts < MaxLoginAttempts)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter password: ");
                string password = Console.ReadLine() ?? string.Empty;

                foreach (User user in _users)
                {
                    if (user.Username == username && user.ValidatePassword(password))
                    {
                        _currentUser = user;
                        Console.WriteLine($"Welcome, {username}!");
                        return true;
                    }
                }

                attempts++;
                Console.WriteLine($"Invalid credentials. {MaxLoginAttempts - attempts} attempts remaining.");
            }

            Console.WriteLine("Maximum login attempts reached. Access denied.");
            return false;
        }

        public void Logout()
        {
            if (_currentUser != null)
            {
                Console.WriteLine($"Goodbye, {_currentUser.Username}!");
                _currentUser = null;
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }

        public bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        public bool IsAdmin()
        {
            return _currentUser?.IsAdmin ?? false;
        }

        public string GetCurrentUsername()
        {
            return _currentUser?.Username ?? "Guest";
        }
    }
}