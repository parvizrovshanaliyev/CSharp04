using Practice.BankingSystem;
using Practice.CalculatorApp;
using Practice.GameScoreTracking;
using Practice.Loggers;
using Practice.MediaPlayer;
using Practice.SettingsManagement;
using Practice.ShapeCalculator;
using Practice.ShoppingCartSystem;
using Practice.StudentManagement;
using Practice.TemperatureConversion;
using Practice.TextEditorApp;
using Practice.UserProfileSystem;

namespace Practice;

internal class Program
{
    static void Main(string[] args)
    {
        LogggerTest();
    }


    private static void LogggerTest()
    {
        ILogger consoleLogger = new ConsoleLogger();
        ILogger fileLogger = new FileLogger();
        ILogger databaseLogger = new DatabaseLogger();

        consoleLogger.LogInfo("Application started.");
        consoleLogger.LogWarning("Low memory warning.");
        consoleLogger.LogError("Application crash detected.");

        fileLogger.LogInfo("User login.");
        fileLogger.LogWarning("Disk space running low.");
        fileLogger.LogError("File not found exception.");

        databaseLogger.LogInfo("DB connection established.");
        databaseLogger.LogWarning("High query execution time.");
        databaseLogger.LogError("Database timeout error.");

        Console.WriteLine("\nRecent Logs from Console Logger:");
        foreach (var log in consoleLogger.GetLatestLogs(3))
            Console.WriteLine(log);

        Console.WriteLine("\nRecent Logs from File Logger:");
        foreach (var log in fileLogger.GetLatestLogs(3))
            Console.WriteLine(log);

        Console.WriteLine("\nRecent Logs from Database Logger:");
        foreach (var log in databaseLogger.GetLatestLogs(3))
            Console.WriteLine(log);
    }


    private static void ShapeCalculatorTest()
    {
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);
        IShape triangle = new Triangle(3, 4, 5);

        Console.WriteLine($"Circle - Area: {circle.CalculateArea()}, Perimeter: {circle.CalculatePerimeter()}");
        Console.WriteLine($"Rectangle - Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.CalculatePerimeter()}");
        Console.WriteLine($"Triangle - Area: {triangle.CalculateArea()}, Perimeter: {triangle.CalculatePerimeter()}");

        IResizable resizableCircle = new Circle(5);
        resizableCircle.Resize(1.5);
        Console.WriteLine($"Resized Circle - Area: {(resizableCircle as IShape).CalculateArea()}, Perimeter: {(resizableCircle as IShape).CalculatePerimeter()}");
    }  
    
    private static void MediaPlayerTest()
    {
        AudioPlayer audioPlayer = new();
        VideoPlayer videoPlayer = new();
        StreamingPlayer streamingPlayer = new();

        audioPlayer.AddToPlaylist("Song A");
        audioPlayer.AddToPlaylist("Song B");
        audioPlayer.ShowPlaylist();
        audioPlayer.Play();
        audioPlayer.Pause();
        audioPlayer.Stop();

        Console.WriteLine();
        videoPlayer.Play();
        videoPlayer.Pause();
        videoPlayer.Stop();

        Console.WriteLine();
        streamingPlayer.Play();
        streamingPlayer.Pause();
        streamingPlayer.Stop();
    }  
    
    private static void ShoppingCartTest()
    {
        IShoppingCart cart = new ShoppingCart();
        IProduct laptop = new PhysicalProduct("Laptop", 999.99m, 2.5);
        IProduct ebook = new DigitalProduct("C# Guide", 29.99m, "http://download.com/csharp");
        IProduct phone = new BasicProduct("Smartphone", 499.99m);

        cart.AddProduct(laptop);
        cart.AddProduct(ebook);
        cart.AddProduct(phone);

        Console.WriteLine($"Cart total: ${cart.CalculateTotal():F2}");

        cart.RemoveProduct(phone);
        Console.WriteLine($"Cart total after removal: ${cart.CalculateTotal():F2}");

        cart.Checkout();
    }

    private static void StudentTest()
    {
        Student student = new Student
        {
            StudentID = 1,
            Name = "John Doe",
            DateOfBirth = new DateTime(2000, 5, 15),
            Major = "Computer Science",
            GPA = 3.8,
            Email = "johndoe@example.com",
            Phone = "123-456-7890",
            Address = "123 Main St, City, Country"
        };

        student.AddCourse("Data Structures");
        student.AddCourse("Algorithms");

        Console.WriteLine($"Student: {student.Name}, Major: {student.Major}, GPA: {student.GPA}");
        student.DisplayCourses();
    }

    private static void BankAccountTest()
    {
        BankAccount account = new BankAccount
        {
            AccountNumber = "12345678",
            AccountHolder = "Jane Doe"
        };

        account.Deposit(1000);
        account.Withdraw(200);
        account.Deposit(500);
        account.Withdraw(1300);

        Console.WriteLine($"Account Holder: {account.AccountHolder}, Balance: ${account.Balance:F2}");
        account.DisplayTransactionHistory();
    }

    private static void CalculatorTest()
    {
        Calculator calculator = new Calculator();

        double a = 10, b = 5;

        double sum = calculator.Add(a, b);
        calculator.LogHistory($"{a} + {b}", sum);
        Console.WriteLine($"Addition: {sum}");

        double difference = calculator.Subtract(a, b);
        calculator.LogHistory($"{a} - {b}", difference);
        Console.WriteLine($"Subtraction: {difference}");

        double product = calculator.Multiply(a, b);
        calculator.LogHistory($"{a} * {b}", product);
        Console.WriteLine($"Multiplication: {product}");

        double quotient = calculator.Divide(a, b);
        calculator.LogHistory($"{a} / {b}", quotient);
        Console.WriteLine($"Division: {quotient}");

        calculator.DisplayHistory();
    }

    private static void TextEditorTest()
    {
        TextEditor editor = new TextEditor();
        editor.Write("Hello, World!");
        editor.Write("This is a simple text editor.");
        editor.Display();

        editor.ToUpperCase();
        Console.WriteLine("\nAfter UpperCase Formatting:");
        editor.Display();

        editor.SaveToFile();
        editor.Clear();
        Console.WriteLine("\nAfter Clearing Content:");
        editor.Display();

        editor.LoadFromFile();
        Console.WriteLine("\nAfter Loading From File:");
        editor.Display();
    }  
    
    private static void UserProfileTest()
    {
        UserProfile user = new UserProfile("John Doe", 25, "johndoe@example.com");
        user.DisplayProfile();
    }

    private static void TemperatureConversionTest()
    {
        double tempC = 25;
        Console.WriteLine($"{tempC}°C = {TemperatureConverter.CelsiusToFahrenheit(tempC)}°F");
        Console.WriteLine($"{tempC}°C = {TemperatureConverter.CelsiusToKelvin(tempC)}K");

        double tempF = 77;
        Console.WriteLine($"{tempF}°F = {TemperatureConverter.FahrenheitToCelsius(tempF)}°C");

        double tempK = 298.15;
        Console.WriteLine($"{tempK}K = {TemperatureConverter.KelvinToCelsius(tempK)}°C");
    }

    private static void ScoreTrackerTest()
    {
        ScoreTracker game = new ScoreTracker();

        game.AddPoints(10);
        game.AddPoints(20);
        game.ResetScore();

        game.AddPoints(15);
        game.AddPoints(30);
        game.ResetScore();

        game.DisplayStats();
    }

    private static void SettingsManagementTest()
    {
        Console.WriteLine("Initializing Settings Manager...");
        SettingsManager settings = new SettingsManager();
        settings.DisplaySettings();

        Console.WriteLine("\nUpdating settings...");
        settings.UpdateSetting("UserName", "JohnDoe");
        settings.UpdateSetting("DisplayMode", "Dark");
        settings.DisplaySettings();

        Console.WriteLine("\nResetting to default settings...");
        settings.ResetToDefaults();
        settings.DisplaySettings();
    }
}
