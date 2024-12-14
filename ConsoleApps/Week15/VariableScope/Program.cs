namespace VariableScope
{
    class Globals
    {
        public static string ApplicationName = "ScopeMaster"; // Simulated global variable
    }

    class Product
    {
        // Class-Level Variables (Fields)
        private string _name;
        private decimal _price;
        private int _stock;

        // Static Scope
        public static int TotalProductsCreated = 0;

        // Constructor (Explicit Parameterized Constructor)
        public Product(string name, decimal price, int stock)
        {
            this._name = string.IsNullOrWhiteSpace(name) ? "Unnamed Product" : name;
            this._price = price >= 0 ? price : 0.0m;
            this._stock = stock >= 0 ? stock : 0;
            TotalProductsCreated++; // Increment static counter
        }

        // Method to display product details (Accessing Class-Level Variables)
        public void Display()
        {
            Console.WriteLine($"Product: {_name}, Price: ${_price:F2}, Stock: {_stock}");
        }

        // Method Parameter Scope
        public decimal ApplyDiscount(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Invalid discount percentage");
            }
            _price -= _price * (discountPercentage / 100); // Accessing class-level variable
            return _price;
        }

        // Method to update stock
        public void UpdateStock(int quantity)
        {
            if (quantity < 0 && Math.Abs(quantity) > _stock)
            {
                Console.WriteLine("Not enough stock to remove!");
            }
            else
            {
                _stock += quantity;
                Console.WriteLine($"Updated stock: {_stock}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Global Scope (Static Variables)
            Console.WriteLine($"Welcome to {Globals.ApplicationName}!");

            // Local Scope
            int number = 15; // Local to Main method
            if (number > 10)
            {
                string message = "Number is greater than 10"; // Local to the if block
                Console.WriteLine(message);
            }
            // Console.WriteLine(message); // Error: message is not accessible here

            // Creating Product Instances (Class-Level and Static Scope)
            Product laptop = new Product("Laptop", 1500.00m, 10);
            Product smartphone = new Product("Smartphone", 899.99m, 15);

            // Display Product Details
            laptop.Display();
            smartphone.Display();

            // Static Scope: Access total products created
            Console.WriteLine($"Total products created: {Product.TotalProductsCreated}");

            // Block Scope in Loops
            for (int i = 0; i < 3; i++) // 'i' has block scope
            {
                Console.WriteLine($"Loop iteration: {i}");
            }
            // Console.WriteLine(i); // Error: i is not accessible outside the loop

            // Method Parameter Scope
            Console.WriteLine("\nApplying discounts...");
            decimal newLaptopPrice = laptop.ApplyDiscount(10); // 10% discount
            Console.WriteLine($"Laptop price after discount: ${newLaptopPrice:F2}");

            decimal newSmartphonePrice = smartphone.ApplyDiscount(15); // 15% discount
            Console.WriteLine($"Smartphone price after discount: ${newSmartphonePrice:F2}");

            // Updating Stock
            Console.WriteLine("\nUpdating stock...");
            laptop.UpdateStock(5);  // Adding 5 units
            smartphone.UpdateStock(-10); // Removing 10 units

            // Attempting to remove more stock than available
            smartphone.UpdateStock(-10); // Should display an error

            // Accessing Static Variable Again
            Console.WriteLine($"Final product count: {Product.TotalProductsCreated}");
        }
    }

}
