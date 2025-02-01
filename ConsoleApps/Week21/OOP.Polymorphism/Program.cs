using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP.Polymorphism;

/// <summary>
/// Demonstrates various types of polymorphism in C#
/// </summary>
/// <remarks>
/// This program showcases:
/// - Runtime Polymorphism (Method Overriding)
/// - Compile-time Polymorphism (Method and Operator Overloading)
/// - Interface-based Polymorphism
/// - Abstract Classes and Methods
/// - Factory Pattern with Polymorphism
/// - Event Handling with Polymorphism
/// - Exception Handling with Polymorphism
/// </remarks>
internal class Program
{
    /// <summary>
    /// Entry point of the application demonstrating various polymorphism examples
    /// </summary>
    static void Main(string[] args)
    {
        /*
         * This main method demonstrates different types of polymorphism in C#.
         * Each section is clearly marked and shows a different aspect of polymorphic behavior.
         * The examples progress from simple to more complex implementations.
         */

        Console.WriteLine("=== Polymorphism Examples ===\n");

        // ==========================================
        // 1. Runtime Polymorphism Example
        // Demonstrates method overriding where the actual method implementation
        // is determined at runtime based on the object's type
        // ==========================================
        Console.WriteLine("1. Runtime Polymorphism Example:");
        Class1 obj1 = new Class1();
        Class2 obj2 = new Class2();
        obj1.Show(); // Parent Class Show Method
        obj2.Show(); // Child Class Show Method

        // ==========================================
        // 2. Complex Number Operations
        // Demonstrates operator overloading, a form of compile-time polymorphism
        // where operators can have different meanings for user-defined types
        // ==========================================
        Console.WriteLine("\n2. Complex Number Operations:");
        Complex c1 = new Complex { Real = 3, Imaginary = 2 };
        Complex c2 = new Complex { Real = 1, Imaginary = 4 };
        Complex result = c1 + c2;
        Console.WriteLine($"({c1.Real} + {c1.Imaginary}i) + ({c2.Real} + {c2.Imaginary}i) = " +
                         $"({result.Real} + {result.Imaginary}i)");

        // ==========================================
        // 3. Shape Hierarchy Example
        // Demonstrates abstract classes and method overriding
        // Shows how different shapes can provide their own implementations
        // of area and perimeter calculations
        // ==========================================
        Console.WriteLine("\n3. Shape Hierarchy Example:");
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5),
            new Square(5) // Additional shape example
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"\n{shape.Name} Properties:");
            Console.WriteLine($"Area: {shape.CalculateArea():F2}");
            Console.WriteLine($"Perimeter: {shape.CalculatePerimeter():F2}");
        }

        // ==========================================
        // 4. Animal Kingdom Example
        // Demonstrates interface implementation and inheritance
        // Shows how different animals can provide specific implementations
        // of common behaviors
        // ==========================================
        Console.WriteLine("\n4. Animal Kingdom Example:");
        List<Animal> animals = new List<Animal>
        {
            new Bird("Tweety"),
            new Fish("Nemo"),
            new Mammal("Leo"),
            new Reptile("Rex") // Additional animal example
        };

        foreach (var animal in animals)
        {
            Console.WriteLine($"\nObserving {animal.Name} the {animal.Species}:");
            animal.Eat();
            animal.Move();
            animal.Sleep();
        }

        // ==========================================
        // 5. Payment System Example
        // Demonstrates interface-based polymorphism with real-world scenario
        // Shows how different payment methods can be processed uniformly
        // ==========================================
        Console.WriteLine("\n5. Payment System Example:");
        List<IPaymentProcessor> processors = new List<IPaymentProcessor>
        {
            new CreditCardProcessor(),
            new PayPalProcessor(),
            new BankTransferProcessor(),
            new CryptoCurrencyProcessor() // Additional payment processor
        };

        decimal paymentAmount = 99.99m;
        string transactionId = "TX123456";

        foreach (var processor in processors)
        {
            Console.WriteLine($"\nUsing {processor.GetType().Name}:");
            bool success = processor.ProcessPayment(paymentAmount);

            if (success)
            {
                Console.WriteLine("Payment successful!");
                processor.RefundPayment(transactionId);
            }
            else
            {
                Console.WriteLine("Payment failed!");
            }
        }

        // ==========================================
        // 6. Vehicle Factory Example
        // Demonstrates Factory Pattern with polymorphism
        // Shows how objects can be created without exposing creation logic
        // ==========================================
        Console.WriteLine("\n6. Vehicle Factory Example:");
        var vehicles = new List<IVehicle>
        {
            VehicleFactory.CreateVehicle("car", "Tesla Model 3"),
            VehicleFactory.CreateVehicle("motorcycle", "Harley Davidson"),
            VehicleFactory.CreateVehicle("truck", "Ford F-150") // Additional vehicle type
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Service();
            vehicle.Stop();
        }

        // ==========================================
        // 7. Notification System Example
        // Demonstrates event handling with polymorphism
        // Shows how different notification types can be handled uniformly
        // ==========================================
        Console.WriteLine("\n7. Notification System Example:");
        void NotificationHandler(object sender, string message)
        {
            Console.WriteLine($"Notification received from {sender.GetType().Name}: {message}");
        }

        var notifications = new List<INotifiable>
        {
            new EmailNotification(),
            new SMSNotification(),
            new PushNotification() // Additional notification type
        };

        foreach (var notifier in notifications)
        {
            notifier.Notification += NotificationHandler;
        }

        foreach (var notifier in notifications)
        {
            notifier.SendNotification("Hello World!");
        }

        // ==========================================
        // 8. Exception Handling Example
        // Demonstrates polymorphic exception handling
        // Shows how different types of operations can throw and handle exceptions
        // ==========================================
        Console.WriteLine("\n8. Exception Handling Example:");
        var operations = new List<IOperation>
        {
            new DatabaseOperation(),
            new FileOperation(),
            new NetworkOperation() // Additional operation type
        };

        foreach (var operation in operations)
        {
            try
            {
                operation.Execute();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine($"Error Code: {ex.ErrorCode}");
                Console.WriteLine($"Message: {ex.Message}");
                if (ex.Data["InnerException"] is Exception inner)
                {
                    Console.WriteLine($"Inner Exception: {inner.Message}");
                }
            }
        }

        // ==========================================
        // 9. Generic Repository Example
        // Demonstrates generic constraints with polymorphism
        // Shows how to implement type-safe repositories
        // ==========================================
        Console.WriteLine("\n9. Generic Repository Example:");
        var customerRepo = new GenericRepository<Customer>();
        var productRepo = new GenericRepository<Product>();

        // Add sample data
        var customer = new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" };
        var product = new Product { Id = 1, Name = "Laptop", Price = 999.99m };

        customerRepo.Add(customer);
        productRepo.Add(product);

        // Display entities
        Console.WriteLine("\nCustomers:");
        foreach (var c in customerRepo.GetAll())
        {
            Console.WriteLine($"Customer: {c.Name}, Email: {c.Email}");
        }

        Console.WriteLine("\nProducts:");
        foreach (var p in productRepo.GetAll())
        {
            Console.WriteLine($"Product: {p.Name}, Price: ${p.Price}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

class Class1
{
    //Virtual Function (Overridable Method)
    public virtual void Show()
    {
        //Parent Class Logic Same for All Child Classes
        Console.WriteLine("Parent Class Show Method");
    }
}
class Class2 : Class1
{
    //Overriding Method
    public override void Show()
    {
        //Child Class Reimplementing the Logic
        Console.WriteLine("Child Class Show Method");
    }
}

/// <summary>
/// Represents a complex number with real and imaginary parts
/// </summary>
/// <remarks>
/// This class demonstrates operator overloading by implementing
/// custom behavior for the addition operator
/// </remarks>
public class Complex
{
    /*
     * Operator Overloading Example
     * 
     * This class shows how to:
     * 1. Override the + operator for complex numbers
     * 2. Implement custom type arithmetic
     * 3. Maintain mathematical properties of complex numbers
     * 
     * Benefits:
     * - Natural syntax for mathematical operations
     * - Intuitive code that mirrors mathematical notation
     * - Type-safe operations
     */

    /// <summary>
    /// Gets or sets the real part of the complex number
    /// </summary>
    public int Real { get; set; }

    /// <summary>
    /// Gets or sets the imaginary part of the complex number
    /// </summary>
    public int Imaginary { get; set; }

    /// <summary>
    /// Overloads the addition operator for Complex numbers
    /// </summary>
    /// <param name="c1">First complex number</param>
    /// <param name="c2">Second complex number</param>
    /// <returns>A new Complex number representing the sum</returns>
    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex
        {
            Real = c1.Real + c2.Real,
            Imaginary = c1.Imaginary + c2.Imaginary
        };
    }
}

// Shape Hierarchy
public abstract class Shape
{
    public string Name { get; set; }
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Name = "Circle";
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;
    public override double CalculatePerimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Name = "Rectangle";
        Width = width;
        Height = height;
    }

    public override double CalculateArea() => Width * Height;
    public override double CalculatePerimeter() => 2 * (Width + Height);
}

public class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double a, double b, double c)
    {
        Name = "Triangle";
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override double CalculatePerimeter() => SideA + SideB + SideC;
}

/// <summary>
/// Represents a square shape, demonstrating inheritance and method overriding
/// </summary>
public class Square : Shape
{
    /// <summary>
    /// Gets or sets the side length of the square
    /// </summary>
    public double Side { get; set; }

    /// <summary>
    /// Initializes a new instance of the Square class
    /// </summary>
    /// <param name="side">Length of the square's side</param>
    public Square(double side)
    {
        Name = "Square";
        Side = side;
    }

    /// <summary>
    /// Calculates the area of the square
    /// </summary>
    /// <returns>The area of the square</returns>
    public override double CalculateArea() => Side * Side;

    /// <summary>
    /// Calculates the perimeter of the square
    /// </summary>
    /// <returns>The perimeter of the square</returns>
    public override double CalculatePerimeter() => 4 * Side;
}

// Animal Kingdom
public interface IAnimal
{
    void Eat();
    void Move();
    void Sleep();
}

public abstract class Animal : IAnimal
{
    public string Name { get; set; }
    public string Species { get; set; }

    protected Animal(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public abstract void Eat();
    public abstract void Move();
    public virtual void Sleep() => Console.WriteLine($"{Name} the {Species} is sleeping.");
}

public class Bird : Animal
{
    public Bird(string name) : base(name, "Bird") { }
    public override void Eat() => Console.WriteLine($"{Name} is pecking at seeds.");
    public override void Move() => Console.WriteLine($"{Name} is flying through the air.");
}

public class Fish : Animal
{
    public Fish(string name) : base(name, "Fish") { }
    public override void Eat() => Console.WriteLine($"{Name} is catching small fish.");
    public override void Move() => Console.WriteLine($"{Name} is swimming in the water.");
}

public class Mammal : Animal
{
    public Mammal(string name) : base(name, "Mammal") { }
    public override void Eat() => Console.WriteLine($"{Name} is eating food.");
    public override void Move() => Console.WriteLine($"{Name} is walking on the ground.");
}

/// <summary>
/// Represents a reptile animal
/// </summary>
public class Reptile : Animal
{
    /// <summary>
    /// Initializes a new instance of the Reptile class
    /// </summary>
    /// <param name="name">The name of the reptile</param>
    public Reptile(string name) : base(name, "Reptile") { }

    /// <summary>
    /// Implements the eating behavior for reptiles
    /// </summary>
    public override void Eat() => Console.WriteLine($"{Name} is hunting prey.");

    /// <summary>
    /// Implements the movement behavior for reptiles
    /// </summary>
    public override void Move() => Console.WriteLine($"{Name} is crawling on the ground.");
}

// Payment System
public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
    void RefundPayment(string transactionId);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        Thread.Sleep(1000);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding credit card transaction {transactionId}");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
        Thread.Sleep(1500);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding PayPal transaction {transactionId}");
    }
}

public class BankTransferProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer of ${amount}");
        Thread.Sleep(2000);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding bank transfer {transactionId}");
    }
}

/// <summary>
/// Represents a cryptocurrency payment processor
/// </summary>
public class CryptoCurrencyProcessor : IPaymentProcessor
{
    /// <summary>
    /// Processes a cryptocurrency payment
    /// </summary>
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cryptocurrency payment of ${amount}");
        Thread.Sleep(1200);
        return true;
    }

    /// <summary>
    /// Refunds a cryptocurrency payment
    /// </summary>
    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding cryptocurrency transaction {transactionId}");
    }
}

// Vehicle System
public interface IVehicle
{
    void Start();
    void Stop();
    void Service();
}

public class Car : IVehicle
{
    public string Model { get; set; }
    public Car(string model) => Model = model;
    public void Start() => Console.WriteLine($"{Model} car is starting the engine");
    public void Stop() => Console.WriteLine($"{Model} car is stopping the engine");
    public void Service() => Console.WriteLine($"{Model} car is being serviced");
}

public class Motorcycle : IVehicle
{
    public string Model { get; set; }
    public Motorcycle(string model) => Model = model;
    public void Start() => Console.WriteLine($"{Model} motorcycle is kickstarting");
    public void Stop() => Console.WriteLine($"{Model} motorcycle is stopping");
    public void Service() => Console.WriteLine($"{Model} motorcycle is being serviced");
}

/// <summary>
/// Represents a truck vehicle
/// </summary>
public class Truck : IVehicle
{
    public string Model { get; set; }
    public Truck(string model) => Model = model;
    public void Start() => Console.WriteLine($"{Model} truck is starting the diesel engine");
    public void Stop() => Console.WriteLine($"{Model} truck is stopping the engine");
    public void Service() => Console.WriteLine($"{Model} truck is being serviced");
}

public class VehicleFactory
{
    public static IVehicle CreateVehicle(string vehicleType, string model)
    {
        return vehicleType.ToLower() switch
        {
            "car" => new Car(model),
            "motorcycle" => new Motorcycle(model),
            "truck" => new Truck(model),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}

// Notification System
public interface INotifiable
{
    event EventHandler<string> Notification;
    void SendNotification(string message);
}

public abstract class NotificationBase : INotifiable
{
    public event EventHandler<string> Notification;
    protected virtual void OnNotification(string message) => Notification?.Invoke(this, message);
    public abstract void SendNotification(string message);
}

public class EmailNotification : NotificationBase
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"Sending email: {message}");
        OnNotification($"Email sent: {message}");
    }
}

public class SMSNotification : NotificationBase
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
        OnNotification($"SMS sent: {message}");
    }
}

/// <summary>
/// Represents a push notification service
/// </summary>
public class PushNotification : NotificationBase
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"Sending push notification: {message}");
        OnNotification($"Push notification sent: {message}");
    }
}

// Exception Handling
public class BusinessException : Exception
{
    public string ErrorCode { get; }
    public BusinessException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}

public interface IOperation
{
    void Execute();
}

public class DatabaseOperation : IOperation
{
    public void Execute()
    {
        try
        {
            throw new Exception("Database connection failed");
        }
        catch (Exception ex)
        {
            throw new BusinessException("Database operation failed", "DB001")
            {
                Data = { ["InnerException"] = ex }
            };
        }
    }
}

public class FileOperation : IOperation
{
    public void Execute()
    {
        try
        {
            throw new Exception("File not found");
        }
        catch (Exception ex)
        {
            throw new BusinessException("File operation failed", "FILE001")
            {
                Data = { ["InnerException"] = ex }
            };
        }
    }
}

/// <summary>
/// Represents a network operation
/// </summary>
public class NetworkOperation : IOperation
{
    public void Execute()
    {
        try
        {
            throw new Exception("Network connection timeout");
        }
        catch (Exception ex)
        {
            throw new BusinessException("Network operation failed", "NET001")
            {
                Data = { ["InnerException"] = ex }
            };
        }
    }
}

/// <summary>
/// Represents an entity that can be stored in a repository
/// </summary>
public interface IEntity
{
    int Id { get; set; }
    DateTime CreatedDate { get; set; }
}

/// <summary>
/// Generic repository interface for managing entities
/// </summary>
public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
}

/// <summary>
/// Generic repository implementation
/// </summary>
public class GenericRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public void Add(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        _items.Add(entity);
    }

    public void Update(T entity)
    {
        var index = _items.FindIndex(i => i.Id == entity.Id);
        if (index != -1)
            _items[index] = entity;
    }

    public void Delete(int id)
    {
        _items.RemoveAll(i => i.Id == id);
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }
}

/// <summary>
/// Represents a customer entity
/// </summary>
public class Customer : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

/// <summary>
/// Represents a product entity
/// </summary>
public class Product : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
