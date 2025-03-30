using System.Text;

namespace IntelligentUserProfileApp
{
    class Program
    {
        static IUserService _userService;
        static IMenuService _menuService;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Welcome to the Intelligent Digital Assistant!\n");

            _userService = new UserService();
            User user = _userService.CreateProfile();

            _menuService = new MenuService(user, _userService);
            _menuService.Run();
        }
    }
}
