namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Student Class Demonstration ===");

        // Default student
        Student student1 = new Student();
        student1.DisplayDetails();

        // Custom student (name and age)
        Student student2 = new Student("Alice", 20);
        student2.DisplayDetails();

        // Fully custom student
        Student student3 = new Student("Bob", 22, 85, "Computer Science");
        student3.DisplayDetails();

        // Improving and reducing grades
        student3.ImproveGrade(10);
        student3.ReduceGrade(30);

        // Changing major
        student3.ChangeMajor("Data Science");

        // Display final details
        student3.DisplayDetails();



        Console.WriteLine("=== Book Class Demonstration ===");

        // Create a Default Book
        Book defaultBook = new Book();
        defaultBook.DisplayDetails();
        Console.WriteLine();

        // Create a Custom Book (Parameterized Constructor 1)
        Book customBook1 = new Book("C# Programming", "John Doe", 2020);
        customBook1.DisplayDetails();
        Console.WriteLine();

        // Create a Fully Custom Book (Parameterized Constructor 2)
        Book customBook2 = new Book("Advanced C# Programming", "Jane Smith", 2023, 49.99m);
        customBook2.DisplayDetails();
        Console.WriteLine();

        // Test the Methods
        // Apply a discount
        customBook2.DiscountPrice(10); // 10% discount
        Console.WriteLine();

        // Change the price
        customBook2.ChangePrice(39.99m);
        Console.WriteLine();

        // Update the year of publication
        customBook2.UpdateYearPublished(2024);
        Console.WriteLine();

        // Display updated details
        customBook2.DisplayDetails();


        Console.WriteLine("=== Car Class Demonstration ===\n");

        // Create a Default Car
        Car defaultCar = new Car();
        Console.WriteLine("1. Default Car:");
        defaultCar.DisplayDetails();
        Console.WriteLine();

        // Create a Custom Car (Parameterized Constructor 1)
        Car customCar1 = new Car("Toyota", "Corolla", 2015);
        Console.WriteLine("2. Custom Car (Make, Model, Year):");
        customCar1.DisplayDetails();
        Console.WriteLine();

        // Create a Fully Custom Car (Parameterized Constructor 2)
        Car customCar2 = new Car("Tesla", "Model 3", 2020, 40000.0m);
        Console.WriteLine("3. Fully Custom Car:");
        customCar2.DisplayDetails();
        Console.WriteLine();

        // Test the Methods
        // Apply a discount
        customCar2.ApplyDiscount(10); // 10% discount
        Console.WriteLine();

        // Update the price
        customCar2.UpdatePrice(35000.0m);
        Console.WriteLine();

        // Get and display the car's age
        int carAge = customCar2.AgeOfCar();
        Console.WriteLine($"The car's age is: {carAge} years.\n");

        // Display updated details
        Console.WriteLine("Updated Details:");
        customCar2.DisplayDetails();


        Console.WriteLine("=== Product Class Demonstration ===\n");

        // Create a Default Product
        Product defaultProduct = new Product();
        Console.WriteLine("1. Default Product:");
        defaultProduct.DisplayDetails();
        Console.WriteLine();

        // Create a Custom Product (Parameterized Constructor 1)
        Product customProduct1 = new Product("Smartphone", "Electronics");
        Console.WriteLine("2. Custom Product (Name, Category):");
        customProduct1.DisplayDetails();
        Console.WriteLine();

        // Create a Fully Custom Product (Parameterized Constructor 2)
        Product customProduct2 = new Product("Laptop", "Electronics", 999.99m, 10);
        Console.WriteLine("3. Fully Custom Product:");
        customProduct2.DisplayDetails();
        Console.WriteLine();

        // Test the Methods
        // Apply a discount
        customProduct2.ApplyDiscount(10); // 10% discount
        Console.WriteLine();

        // Change the price
        customProduct2.ChangePrice(799.99m);
        Console.WriteLine();

        // Update the stock
        customProduct2.UpdateStock(10); // Adding 10 units
        Console.WriteLine();

        // Display updated details
        Console.WriteLine("Updated Details:");
        customProduct2.DisplayDetails();
    }
}
