using Practice.BankingSystem;
using Practice.CalculatorApp;
using Practice.GameScoreTracking;
using Practice.Loggers;
using Practice.MediaPlayer;
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
        LoggerTest();
    }


    private static void LoggerTest()
    {
        Console.WriteLine("Starting Logger Test...\n");

        ILogger consoleLogger = new ConsoleLogger();
        ILogger fileLogger = new FileLogger();
        ILogger databaseLogger = new DatabaseLogger();

        Console.WriteLine("Logging to Console Logger:");
        consoleLogger.LogInfo("Application started.");
        consoleLogger.LogWarning("Low memory warning.");
        consoleLogger.LogError("Application crash detected.");

        Console.WriteLine("\nLogging to File Logger:");
        fileLogger.LogInfo("User login.");
        fileLogger.LogWarning("Disk space running low.");
        fileLogger.LogError("File not found exception.");

        Console.WriteLine("\nLogging to Database Logger:");
        databaseLogger.LogInfo("DB connection established.");
        databaseLogger.LogWarning("High query execution time.");
        databaseLogger.LogError("Database timeout error.");

        Console.WriteLine("\nRetrieving Recent Logs from Console Logger:");
        foreach (var log in consoleLogger.GetLatestLogs(3))
            Console.WriteLine($" - {log}");

        Console.WriteLine("\nRetrieving Recent Logs from File Logger:");
        foreach (var log in fileLogger.GetLatestLogs(3))
            Console.WriteLine($" - {log}");

        Console.WriteLine("\nRetrieving Recent Logs from Database Logger:");
        foreach (var log in databaseLogger.GetLatestLogs(3))
            Console.WriteLine($" - {log}");

        Console.WriteLine("\nLogger Test Completed.");
    }



    private static void ShapeCalculatorTest()
    {
        Console.WriteLine("Starting Shape Calculator Test...\n");

        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);
        IShape triangle = new Triangle(3, 4, 5);

        Console.WriteLine($"Circle - Area: {circle.CalculateArea():F2}, Perimeter: {circle.CalculatePerimeter():F2}");
        Console.WriteLine($"Rectangle - Area: {rectangle.CalculateArea():F2}, Perimeter: {rectangle.CalculatePerimeter():F2}");
        Console.WriteLine($"Triangle - Area: {triangle.CalculateArea():F2}, Perimeter: {triangle.CalculatePerimeter():F2}");

        Console.WriteLine("\nResizing Circle...");
        IResizable resizableCircle = new Circle(5);
        resizableCircle.Resize(1.5);
        Console.WriteLine($"Resized Circle - Area: {(resizableCircle as IShape).CalculateArea():F2}, Perimeter: {(resizableCircle as IShape).CalculatePerimeter():F2}");

        Console.WriteLine("\nShape Calculator Test Completed.");
    }


    private static void MediaPlayerTest()
    {
        Console.WriteLine("Starting Media Player Test...\n");

        AudioPlayer audioPlayer = new();
        VideoPlayer videoPlayer = new();
        StreamingPlayer streamingPlayer = new();

        Console.WriteLine("Testing Audio Player:");
        audioPlayer.AddToPlaylist("Song A");
        audioPlayer.AddToPlaylist("Song B");
        audioPlayer.ShowPlaylist();
        audioPlayer.Play();
        audioPlayer.Pause();
        audioPlayer.Stop();

        Console.WriteLine("\nTesting Video Player:");
        videoPlayer.Play();
        videoPlayer.Pause();
        videoPlayer.Stop();

        Console.WriteLine("\nTesting Streaming Player:");
        streamingPlayer.Play();
        streamingPlayer.Pause();
        streamingPlayer.Stop();

        Console.WriteLine("\nMedia Player Test Completed.");
    }


    private static void ShoppingCartTest()
    {
        Console.WriteLine("Starting Shopping Cart Test...\n");

        IShoppingCart cart = new ShoppingCart();
        IProduct laptop = new PhysicalProduct("Laptop", 999.99m, 2.5);
        IProduct ebook = new DigitalProduct("C# Guide", 29.99m, "http://download.com/csharp");
        IProduct phone = new BasicProduct("Smartphone", 499.99m);

        Console.WriteLine("Adding products to cart:");
        cart.AddProduct(laptop);
        cart.AddProduct(ebook);
        cart.AddProduct(phone);

        Console.WriteLine($"\nCart total: ${cart.CalculateTotal():F2}");

        Console.WriteLine("\nRemoving product: Smartphone");
        cart.RemoveProduct(phone);
        Console.WriteLine($"Cart total after removal: ${cart.CalculateTotal():F2}");

        Console.WriteLine("\nProceeding to Checkout...");
        cart.Checkout();

        Console.WriteLine("\nShopping Cart Test Completed.");
    }


    private static void StudentTest()
    {
        Console.WriteLine("Starting Student Test...\n");

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

        Console.WriteLine("Adding Courses...");
        student.AddCourse("Data Structures");
        student.AddCourse("Algorithms");

        Console.WriteLine($"\nStudent Information:");
        Console.WriteLine($" - Name: {student.Name}");
        Console.WriteLine($" - Major: {student.Major}");
        Console.WriteLine($" - GPA: {student.GPA:F2}");
        Console.WriteLine($" - Email: {student.Email}");
        Console.WriteLine($" - Phone: {student.Phone}");
        Console.WriteLine($" - Address: {student.Address}");

        Console.WriteLine("\nEnrolled Courses:");
        student.DisplayCourses();

        Console.WriteLine("\nStudent Test Completed.");
    }


    private static void BankAccountTest()
    {
        Console.WriteLine("Starting Bank Account Test...\n");

        BankAccount account = new BankAccount
        {
            AccountNumber = "12345678",
            AccountHolder = "Jane Doe"
        };

        Console.WriteLine("Performing Transactions...");
        account.Deposit(1000);
        account.Withdraw(200);
        account.Deposit(500);
        account.Withdraw(1300);

        Console.WriteLine("\nFinal Account Details:");
        Console.WriteLine($" - Account Holder: {account.AccountHolder}");
        Console.WriteLine($" - Account Number: {account.AccountNumber}");
        Console.WriteLine($" - Balance: ${account.Balance:F2}");

        Console.WriteLine("\nTransaction History:");
        account.DisplayTransactionHistory();

        Console.WriteLine("\nBank Account Test Completed.");
    }



    private static void CalculatorTest()
    {
        Console.WriteLine("Starting Calculator Test...\n");

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

        // Display all recorded calculations
        calculator.DisplayHistory();

        Console.WriteLine("\nCalculator Test Completed.");
    }


    private static void TextEditorTest()
    {
        Console.WriteLine("Starting Text Editor Test...\n");

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

        Console.WriteLine("\nText Editor Test Completed.");
    }


    private static void UserProfileTest()
    {
        Console.WriteLine("Starting User Profile Test...\n");

        UserProfile user = new UserProfile("John Doe", 25, "johndoe@example.com");
        user.DisplayProfile();

        Console.WriteLine("\nUser Profile Test Completed.");
    }


    private static void TemperatureConversionTest()
    {
        Console.WriteLine("Starting Temperature Conversion Test...\n");

        double tempC = 25;
        Console.WriteLine($"{tempC}°C = {TemperatureConverter.CelsiusToFahrenheit(tempC):F2}°F");
        Console.WriteLine($"{tempC}°C = {TemperatureConverter.CelsiusToKelvin(tempC):F2}K");

        double tempF = 77;
        Console.WriteLine($"{tempF}°F = {TemperatureConverter.FahrenheitToCelsius(tempF):F2}°C");

        double tempK = 298.15;
        Console.WriteLine($"{tempK}K = {TemperatureConverter.KelvinToCelsius(tempK):F2}°C");

        Console.WriteLine("\nTemperature Conversion Test Completed.");
    }


    private static void ScoreTrackerTest()
    {
        Console.WriteLine("Starting Score Tracker Test...\n");

        // Create an instance of ScoreTracker
        ScoreTracker game = new ScoreTracker();

        // Perform game score tracking
        game.AddPoints(10);
        game.AddPoints(20);
        game.ResetScore();

        game.AddPoints(15);
        game.AddPoints(30);
        game.ResetScore();

        // Display final statistics
        game.DisplayStats();
    }


    private static void SettingsManagementTest()
    {
        Console.WriteLine("Starting Settings Management Test...\n");

        // Create an instance of SettingsManager
        SettingsManager settingsManager = new SettingsManager();

        Console.WriteLine("Displaying Default Settings:");
        settingsManager.DisplaySettings();

        Console.WriteLine("\nUpdating Settings...");
        settingsManager.UpdateSetting("UserName", "JohnDoe");
        settingsManager.UpdateSetting("DisplayMode", "Dark");
        settingsManager.UpdateSetting("Sound", "Off");

        Console.WriteLine("\nDisplaying Updated Settings:");
        settingsManager.DisplaySettings();

        // Retrieve and print a specific setting
        string username = settingsManager.GetSetting("UserName");
        Console.WriteLine($"\nRetrieved UserName: {username}");

        // Attempt to update an invalid setting
        Console.WriteLine("\nAttempting to Update an Invalid Setting:");
        settingsManager.UpdateSetting("InvalidSetting", "TestValue");

        // Reset to default settings
        Console.WriteLine("\nResetting to Default Settings...");
        settingsManager.ResetToDefaults();

        Console.WriteLine("\nDisplaying Settings After Reset:");
        settingsManager.DisplaySettings();

        Console.WriteLine("\nSettings Management Test Completed.");
    }

}
