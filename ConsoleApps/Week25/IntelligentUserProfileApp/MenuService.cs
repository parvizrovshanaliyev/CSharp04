namespace IntelligentUserProfileApp;

public class MenuService : IMenuService
{
    private readonly User _user;
    private readonly IUserService _userService;

    public MenuService(User user, IUserService userService)
    {
        _user = user;
        _userService = userService;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("1. View your profile details");
            Console.WriteLine("2. Perform another text analysis");
            Console.WriteLine("3. Perform another number analysis");
            Console.WriteLine("4. Compute another Fibonacci sequence");
            Console.WriteLine("5. Exit");
            Console.Write("\nPlease enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1": _userService.DisplayProfile(_user); break;
                case "2": _userService.AnalyzeBio(_user); break;
                case "3": AnalyzeNumber(); break;
                case "4": ComputeFibonacci(); break;
                case "5":
                    Console.WriteLine("Thank you for using the Intelligent Digital Assistant!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private int GetValidatedInteger(string prompt, Func<int, bool> validator = null)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number) && (validator == null || validator(number)))
                return number;
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    private void AnalyzeNumber()
    {
        int number = GetValidatedInteger("Enter your favorite or lucky number: ");
        Console.WriteLine($"Is even? {number.IsEven()}");
        Console.WriteLine($"Square: {MathUtilities.Square(number)}");
        Console.WriteLine($"Cube: {MathUtilities.Cube(number)}");
        Console.WriteLine(number < 0
            ? "Factorial: Not defined for negative numbers."
            : $"Factorial: {MathUtilities.Factorial(number)}");
    }

    private void ComputeFibonacci()
    {
        int n = GetValidatedInteger("Enter N to find the Nth Fibonacci number: ", n => n >= 0);
        Console.WriteLine($"{n}th Fibonacci number: {n.NthFibonacci()}");
    }
}