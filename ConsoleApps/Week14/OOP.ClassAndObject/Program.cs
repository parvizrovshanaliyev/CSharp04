namespace OOP.ClassAndObject;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Demonstrating Property Types and Constructor Overloading ===");

        // Using default constructor
        Car car1 = new Car();
        car1.DisplayDetails();

        //car1.Model = "";
        car1.Color = "";
        car1.Speed = 0;

        Console.WriteLine(car1.Model);

        // Using constructor with model and color
        Car car2 = new Car("Tesla Model S", "Red");
        car2.DisplayDetails();

        Console.WriteLine();

        // Using fully parameterized constructor
        Car car3 = new Car("Ford Mustang", "Blue", 120);
        car3.DisplayDetails();

        Console.WriteLine();

        // Demonstrating computed property
        Console.WriteLine($"Car 3 Description: {car3.Description}");

        // Demonstrating property with validation
        car2.Speed = -10; // Invalid
        car2.Speed = 80;  // Valid

        // Demonstrating write-only property
        car3.Secret = "Top Secret";
        Console.WriteLine("Secret value has been set (but cannot be read).");

        Console.WriteLine();

        // Accelerating and braking
        car2.Accelerate(20);
        car3.Brake(100);

        Console.WriteLine("\nUpdated Car Details:");
        car2.DisplayDetails();
        car3.DisplayDetails();
    }
}