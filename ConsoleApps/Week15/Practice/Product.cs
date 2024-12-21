namespace Practice;

public class Product
{
    // Properties
    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    // Default Constructor
    public Product()
    {
        Name = "Unnamed Product";
        Category = "General";
        Price = 0.0m;
        Stock = 0;
    }

    // Parameterized Constructor 1
    public Product(string name, string category)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Product" : name;
        Category = string.IsNullOrWhiteSpace(category) ? "General" : category;
        Price = 0.0m;
        Stock = 0;
    }

    // Parameterized Constructor 2
    public Product(string name, string category, decimal price, int stock)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Product" : name;
        Category = string.IsNullOrWhiteSpace(category) ? "General" : category;
        Price = price >= 0 ? price : 0.0m;
        Stock = stock >= 0 ? stock : 0;
    }

    // Methods
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Category: {Category}, Price: ${Price:F2}, Stock: {Stock}");
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
        Console.WriteLine($"The price after a {discountPercentage}% discount is: ${Price:F2}");
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            Console.WriteLine("Price cannot be negative.");
            return;
        }

        Price = newPrice;
        Console.WriteLine($"The price has been updated to: ${Price:F2}");
    }

    public void UpdateStock(int quantity)
    {
        if (Stock + quantity < 0)
        {
            Console.WriteLine("Stock cannot be negative.");
            return;
        }

        Stock += quantity;
        Console.WriteLine($"{quantity} units have been added to stock. Current stock: {Stock}");
    }
}