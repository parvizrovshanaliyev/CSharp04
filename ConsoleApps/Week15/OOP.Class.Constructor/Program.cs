using System;

namespace OOP.Class.Constructor
{
    public class Product
    {
        // Fields to store product data
        public string Name;
        public decimal Price;
        public int Stock;

        // Implicit Constructor
        // If no explicit constructor is defined, this will be provided by the compiler.
        // Example of its behavior is demonstrated in the Main method.

        // Explicit Parameterless Constructor
        public Product()
        {
            Name = "Unnamed Product";
            Price = 0.0m;
            Stock = 0;
        }

        // Explicit Parameterized Constructor (Full Initialization)
        public Product(string name, decimal price, int stock)
        {
            // Validation to ensure proper initialization
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Product" : name;
            Price = price >= 0 ? price : 0.0m;
            Stock = stock >= 0 ? stock : 0;
        }

        // Explicit Overloaded Constructor (Name Only)
        public Product(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Product" : name;
            Price = 0.0m;
            Stock = 0;
        }

        // Display product details
        public void Display()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}, Stock: {Stock}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Constructor Demonstration ===\n");

            // 1. Implicit Constructor (Default behavior if no constructor is defined)
            Product implicitProduct = new Product(); // Uses parameterless constructor
            Console.WriteLine("1. Implicit Constructor (or default parameterless constructor):");
            implicitProduct.Display(); // Fields initialized to default values
            Console.WriteLine();

            // 2. Explicit Parameterless Constructor
            Product defaultProduct = new Product();
            Console.WriteLine("2. Explicit Parameterless Constructor:");
            defaultProduct.Display(); // Custom default values for fields
            Console.WriteLine();

            // 3. Explicit Parameterized Constructor (Full Initialization)
            Product laptop = new Product("Laptop", 1500.50m, 5);
            Console.WriteLine("3. Explicit Parameterized Constructor:");
            laptop.Display(); // Custom values for all fields
            Console.WriteLine();

            // 4. Explicit Overloaded Constructor (Name Only)
            Product smartphone = new Product("Smartphone");
            Console.WriteLine("4. Explicit Overloaded Constructor (Name Only):");
            smartphone.Display(); // Default values for Price and Stock
            Console.WriteLine();

            // 5. Custom Initialization with Validation in Constructor
            Product invalidProduct = new Product("Tablet", -500.99m, -10);
            Console.WriteLine("5. Parameterized Constructor with Validation:");
            invalidProduct.Display(); // Corrected invalid values to defaults
            Console.WriteLine();
        }
    }
}

