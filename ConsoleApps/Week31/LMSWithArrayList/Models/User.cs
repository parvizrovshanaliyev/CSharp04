namespace LMSWithArrayList.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string username, string password, bool isAdmin = false)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }
}