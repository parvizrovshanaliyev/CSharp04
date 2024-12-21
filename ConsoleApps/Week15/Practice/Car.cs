namespace Practice;

public class Car
{
    // Properties
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public decimal Price { get; private set; }

    // Default Constructor
    public Car()
    {
        Make = "Unknown";
        Model = "Unknown";
        Year = 2000;
        Price = 10000.0m;
    }

    // Parameterized Constructor 1
    public Car(string make, string model, int year)
    {
        Make = string.IsNullOrWhiteSpace(make) ? "Unknown" : make;
        Model = string.IsNullOrWhiteSpace(model) ? "Unknown" : model;
        Year = year > 0 ? year : 2000;
        Price = 10000.0m;
    }

    // Parameterized Constructor 2
    public Car(string make, string model, int year, decimal price)
    {
        Make = string.IsNullOrWhiteSpace(make) ? "Unknown" : make;
        Model = string.IsNullOrWhiteSpace(model) ? "Unknown" : model;
        Year = year > 0 ? year : 2000;
        Price = price >= 0 ? price : 10000.0m;
    }

    // Methods
    public void DisplayDetails()
    {
        Console.WriteLine($"Make: {Make}, Model: {Model}, Year: {Year}, Price: ${Price:F2}");
    }

    public void ApplyDiscount(decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            Console.WriteLine("Discount percentage must be between 0 and 100.");
            return;
        }

        decimal discountAmount = Price * (discountPercentage / 100);
        Price -= discountAmount;
        Console.WriteLine($"The price after applying {discountPercentage}% discount is: ${Price:F2}");
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            Console.WriteLine("Price cannot be negative.");
            return;
        }

        Price = newPrice;
        Console.WriteLine($"The car's price has been updated to: ${Price:F2}");
    }

    public int AgeOfCar()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - Year;
    }
}