# Understanding Polymorphism in C#: A Comprehensive Guide from Zero to Hero

## Table of Contents
1. [Introduction to Polymorphism](#introduction-to-polymorphism)
2. [Types of Polymorphism](#types-of-polymorphism)
3. [Compile-time Polymorphism](#compile-time-polymorphism)
4. [Runtime Polymorphism](#runtime-polymorphism)
5. [Best Practices](#best-practices)
6. [Examples and Exercises](#examples-and-exercises)
7. [Common Pitfalls](#common-pitfalls)
8. [Advanced Topics](#advanced-topics)

## Introduction to Polymorphism

### What is Polymorphism?
Polymorphism, derived from Greek words meaning "many forms," stands as one of the four pillars of Object-Oriented Programming (OOP), alongside encapsulation, inheritance, and abstraction. In C#, polymorphism represents the ability of objects to take multiple forms and enables a single interface to represent different underlying implementations.

Think of polymorphism as a universal remote control - one device that can control multiple electronics. Each device responds differently to the same button press, just as polymorphic objects respond differently to the same method call.

### Why is Polymorphism Important?
Polymorphism serves as a cornerstone of modern software development by providing:
- **Code Reusability**: Write once, use many times with different implementations
- **Reduced Coupling**: Minimize dependencies between different parts of your application
- **Enhanced Maintainability**: Make changes without affecting the entire codebase
- **Flexible Architecture**: Easily extend functionality without modifying existing code
- **SOLID Principles Support**: Particularly the Open/Closed and Liskov Substitution principles

## Types of Polymorphism

### 1. Compile-time Polymorphism (Static)
Also known as early binding or static polymorphism, this type is resolved during compilation. It includes:
- Method Overloading
- Operator Overloading

### 2. Runtime Polymorphism (Dynamic)
Also known as late binding or dynamic polymorphism, this type is resolved during runtime. It includes:
- Method Overriding
- Virtual Methods
- Abstract Classes
- Interfaces

## Compile-time Polymorphism

### Method Overloading
Method overloading allows multiple methods with the same name but different parameters to coexist in the same class.

```csharp
/// <summary>
/// Demonstrates method overloading capabilities for arithmetic operations
/// </summary>
/// <remarks>
/// This class provides multiple ways to perform addition operations
/// with different parameter types and counts
/// </remarks>
public class Calculator
{
    /*
     * Method Overloading Example
     * 
     * This class demonstrates three different forms of the Add method:
     * 1. Two integer parameters
     * 2. Three integer parameters
     * 3. Two double parameters
     * 
     * The compiler determines which method to call based on:
     * - Number of parameters
     * - Types of parameters
     * - Order of parameters (in some cases)
     */

    /// <summary>
    /// Adds two integer values
    /// </summary>
    /// <param name="a">First integer to add</param>
    /// <param name="b">Second integer to add</param>
    /// <returns>The sum of the two integers</returns>
    public int Add(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// Adds three integer values
    /// </summary>
    /// <param name="a">First integer to add</param>
    /// <param name="b">Second integer to add</param>
    /// <param name="c">Third integer to add</param>
    /// <returns>The sum of the three integers</returns>
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    /// <summary>
    /// Adds two double values with higher precision
    /// </summary>
    /// <param name="a">First double to add</param>
    /// <param name="b">Second double to add</param>
    /// <returns>The sum of the two doubles</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }
}
```

### Operator Overloading
Operator overloading allows custom types to define how operators work with them.

```csharp
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
```

## Runtime Polymorphism

### Method Overriding
Method overriding allows a derived class to provide a different implementation of a method defined in its base class.

```csharp
/// <summary>
/// Represents a base class for geometric shapes
/// </summary>
/// <remarks>
/// This hierarchy demonstrates method overriding and
/// virtual method implementation in C#
/// </remarks>
public class Shape
{
    /*
     * Method Overriding Example
     * 
     * This hierarchy shows:
     * 1. Base class with virtual method
     * 2. Derived classes with specific implementations
     * 3. Runtime polymorphism in action
     * 
     * Key Points:
     * - Virtual keyword enables overriding
     * - Override keyword indicates implementation in derived class
     * - Base implementation can provide default behavior
     */

    /// <summary>
    /// Calculates the area of the shape
    /// </summary>
    /// <returns>The area of the shape</returns>
    public virtual double CalculateArea()
    {
        return 0;
    }
}

/// <summary>
/// Represents a circle shape
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Gets or sets the radius of the circle
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Calculates the area of the circle using πr²
    /// </summary>
    /// <returns>The area of the circle</returns>
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

/// <summary>
/// Represents a rectangle shape
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Gets or sets the width of the rectangle
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Calculates the area of the rectangle using width × height
    /// </summary>
    /// <returns>The area of the rectangle</returns>
    public override double CalculateArea()
    {
        return Width * Height;
    }
}
```

### Abstract Classes and Methods

```csharp
/// <summary>
/// Represents an abstract base class for animals
/// </summary>
/// <remarks>
/// This class demonstrates the use of abstract classes and methods
/// to enforce implementation in derived classes
/// </remarks>
public abstract class Animal
{
    /*
     * Abstract Class Example
     * 
     * This hierarchy demonstrates:
     * 1. Abstract methods requiring implementation
     * 2. Virtual methods with default behavior
     * 3. Mix of abstract and concrete members
     * 
     * Benefits:
     * - Enforces consistent interface
     * - Allows shared implementation
     * - Enables polymorphic behavior
     */

    /// <summary>
    /// Gets or sets the name of the animal
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Makes the sound specific to this animal
    /// </summary>
    public abstract void MakeSound();
    
    /// <summary>
    /// Defines default sleeping behavior for animals
    /// </summary>
    public virtual void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping...");
    }
}

/// <summary>
/// Represents a dog animal
/// </summary>
public class Dog : Animal
{
    /// <summary>
    /// Implements the dog's sound (bark)
    /// </summary>
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

/// <summary>
/// Represents a cat animal
/// </summary>
public class Cat : Animal
{
    /// <summary>
    /// Implements the cat's sound (meow)
    /// </summary>
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}
```

### Interfaces
```csharp
public interface IPayable
{
    decimal CalculatePay();
}

public class Employee : IPayable
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public decimal CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}

public class Contractor : IPayable
{
    public decimal ContractAmount { get; set; }

    public decimal CalculatePay()
    {
        return ContractAmount;
    }
}
```

## Best Practices

### 1. Use Virtual Methods Wisely
- Only mark methods as virtual if they are meant to be overridden
- Consider the impact on future maintenance
- Document the intended use of virtual methods

### 2. Interface Segregation
- Keep interfaces small and focused
- Don't force classes to implement methods they don't need
- Use multiple interfaces instead of one large interface

### 3. Liskov Substitution Principle
- Derived classes should be substitutable for their base classes
- Maintain the expected behavior when overriding methods
- Don't violate base class invariants

### 4. Documentation
- Clearly document the intended use of polymorphic methods
- Explain the purpose of overrides
- Provide examples for complex scenarios

## Examples and Exercises

### Exercise 1: Shape Hierarchy
Create a shape hierarchy with the following requirements:
```csharp
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

// TODO: Implement Circle, Rectangle, and Triangle classes
```

### Exercise 2: Animal Kingdom
Create an animal hierarchy demonstrating polymorphic behavior:
```csharp
public interface IAnimal
{
    void Eat();
    void Move();
    void Sleep();
}

// TODO: Implement different animal classes (Bird, Fish, Mammal)
```

### Exercise 3: Payment System
Create a payment processing system using interfaces:
```csharp
public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
    void RefundPayment(string transactionId);
}

// TODO: Implement CreditCard, PayPal, and BankTransfer processors
```

## Common Pitfalls

### 1. Overuse of Virtual Methods
- Performance impact
- Increased complexity
- Harder to maintain and understand

### 2. Deep Inheritance Hierarchies
- Avoid creating deep inheritance chains
- Consider composition over inheritance
- Keep hierarchies shallow and manageable

### 3. Interface Bloat
- Too many methods in an interface
- Forcing unnecessary implementations
- Not following Interface Segregation Principle

### 4. Breaking Liskov Substitution
- Throwing unexpected exceptions
- Changing method behavior drastically
- Violating base class contracts

## Advanced Topics

### 1. Generic Constraints with Polymorphism
```csharp
public class DataProcessor<T> where T : IProcessable
{
    public void Process(T item)
    {
        item.PreProcess();
        item.Process();
        item.PostProcess();
    }
}
```

### 2. Dynamic Method Dispatch
```csharp
public class Example
{
    public void DynamicDispatch(Shape shape)
    {
        // The correct CalculateArea method is called at runtime
        double area = shape.CalculateArea();
    }
}
```

### 3. Explicit Interface Implementation
```csharp
public class MultiPurpose : IDrawable, IPrintable
{
    void IDrawable.Draw()
    {
        // Implementation for IDrawable
    }

    void IPrintable.Print()
    {
        // Implementation for IPrintable
    }
}
```

## Implementation Examples and Usage

### 1. Calculator Usage Example
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of Calculator
        Calculator calc = new Calculator();

        // Using different overloads of Add method
        int sum1 = calc.Add(5, 3);                  // Uses int overload
        int sum2 = calc.Add(1, 2, 3);              // Uses three parameter overload
        double sum3 = calc.Add(3.14, 2.86);        // Uses double overload

        Console.WriteLine($"Sum1: {sum1}");         // Output: 8
        Console.WriteLine($"Sum2: {sum2}");         // Output: 6
        Console.WriteLine($"Sum3: {sum3}");         // Output: 6.0
    }
}
```

### 2. Complex Number Operations Example
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        // Create two complex numbers
        Complex c1 = new Complex { Real = 3, Imaginary = 2 };
        Complex c2 = new Complex { Real = 1, Imaginary = 4 };

        // Add complex numbers using overloaded + operator
        Complex result = c1 + c2;

        Console.WriteLine($"({c1.Real} + {c1.Imaginary}i) + ({c2.Real} + {c2.Imaginary}i) = " +
                         $"({result.Real} + {result.Imaginary}i)");
        // Output: (3 + 2i) + (1 + 4i) = (4 + 6i)
    }
}
```

### 3. Shape Hierarchy Implementation and Usage
```csharp
/// <summary>
/// Complete implementation of the Shape hierarchy with Circle, Rectangle, and Triangle
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Gets or sets the name of the shape
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Calculates the area of the shape
    /// </summary>
    public abstract double CalculateArea();

    /// <summary>
    /// Calculates the perimeter of the shape
    /// </summary>
    public abstract double CalculatePerimeter();
}

/// <summary>
/// Represents a circle shape
/// </summary>
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Name = "Circle";
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

/// <summary>
/// Represents a rectangle shape
/// </summary>
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

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}

/// <summary>
/// Represents a triangle shape
/// </summary>
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
        // Using Heron's formula
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }
}

// Usage in Main method
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

        // Process all shapes polymorphically
        foreach (var shape in shapes)
        {
            Console.WriteLine($"\n{shape.Name} Properties:");
            Console.WriteLine($"Area: {shape.CalculateArea():F2}");
            Console.WriteLine($"Perimeter: {shape.CalculatePerimeter():F2}");
        }
    }
}
```

### 4. Animal Kingdom Implementation and Usage
```csharp
/// <summary>
/// Interface defining basic animal behaviors
/// </summary>
public interface IAnimal
{
    void Eat();
    void Move();
    void Sleep();
}

/// <summary>
/// Abstract base class implementing common animal behaviors
/// </summary>
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

    public virtual void Sleep()
    {
        Console.WriteLine($"{Name} the {Species} is sleeping.");
    }
}

/// <summary>
/// Represents a bird animal
/// </summary>
public class Bird : Animal
{
    public Bird(string name) : base(name, "Bird")
    {
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} is pecking at seeds.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is flying through the air.");
    }
}

/// <summary>
/// Represents a fish animal
/// </summary>
public class Fish : Animal
{
    public Fish(string name) : base(name, "Fish")
    {
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} is catching small fish.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is swimming in the water.");
    }
}

/// <summary>
/// Represents a mammal animal
/// </summary>
public class Mammal : Animal
{
    public Mammal(string name) : base(name, "Mammal")
    {
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} is eating food.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is walking on the ground.");
    }
}

// Usage in Main method
public class Program
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Bird("Tweety"),
            new Fish("Nemo"),
            new Mammal("Leo")
        };

        foreach (var animal in animals)
        {
            Console.WriteLine($"\nObserving {animal.Name} the {animal.Species}:");
            animal.Eat();
            animal.Move();
            animal.Sleep();
        }
    }
}
```

### 5. Payment System Implementation and Usage
```csharp
/// <summary>
/// Interface for payment processing
/// </summary>
public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
    void RefundPayment(string transactionId);
}

/// <summary>
/// Represents a credit card payment processor
/// </summary>
public class CreditCardProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        // Simulate credit card processing
        Thread.Sleep(1000);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding credit card transaction {transactionId}");
    }
}

/// <summary>
/// Represents a PayPal payment processor
/// </summary>
public class PayPalProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
        // Simulate PayPal processing
        Thread.Sleep(1500);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding PayPal transaction {transactionId}");
    }
}

/// <summary>
/// Represents a bank transfer payment processor
/// </summary>
public class BankTransferProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer of ${amount}");
        // Simulate bank transfer
        Thread.Sleep(2000);
        return true;
    }

    public void RefundPayment(string transactionId)
    {
        Console.WriteLine($"Refunding bank transfer {transactionId}");
    }
}

// Usage in Main method
public class Program
{
    public static void Main(string[] args)
    {
        // Create list of payment processors
        List<IPaymentProcessor> processors = new List<IPaymentProcessor>
        {
            new CreditCardProcessor(),
            new PayPalProcessor(),
            new BankTransferProcessor()
        };

        decimal paymentAmount = 99.99m;
        string transactionId = "TX123456";

        // Process payment with each processor
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
    }
}
```

## Advanced Scenarios and Best Practices

### 1. Factory Pattern with Polymorphism
```csharp
/// <summary>
/// Demonstrates combining the Factory pattern with polymorphism
/// </summary>
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
/// Factory class to create different types of vehicles
/// </summary>
public class VehicleFactory
{
    public static IVehicle CreateVehicle(string vehicleType, string model)
    {
        return vehicleType.ToLower() switch
        {
            "car" => new Car(model),
            "motorcycle" => new Motorcycle(model),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        // Using factory to create vehicles
        var vehicles = new List<IVehicle>
        {
            VehicleFactory.CreateVehicle("car", "Tesla Model 3"),
            VehicleFactory.CreateVehicle("motorcycle", "Harley Davidson")
        };

        // Polymorphic behavior
        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Service();
            vehicle.Stop();
        }
    }
}
```

### 2. Generic Constraints with Polymorphism
```csharp
/// <summary>
/// Demonstrates using generic constraints with polymorphism
/// </summary>
public interface IEntity
{
    int Id { get; set; }
    DateTime CreatedDate { get; set; }
}

public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
}

public class Customer : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Product : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

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

// Usage
public class Program
{
    public static void Main()
    {
        // Create repositories
        var customerRepo = new GenericRepository<Customer>();
        var productRepo = new GenericRepository<Product>();

        // Add items
        customerRepo.Add(new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" });
        productRepo.Add(new Product { Id = 1, Name = "Laptop", Price = 999.99m });

        // Demonstrate polymorphic behavior
        void PrintEntityInfo<T>(IRepository<T> repo) where T : IEntity
        {
            var items = repo.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine($"Entity ID: {item.Id}, Created: {item.CreatedDate}");
            }
        }

        PrintEntityInfo(customerRepo);
        PrintEntityInfo(productRepo);
    }
}
```

### 3. Event Handling with Polymorphism
```csharp
/// <summary>
/// Demonstrates combining events with polymorphism
/// </summary>
public interface INotifiable
{
    event EventHandler<string> Notification;
    void SendNotification(string message);
}

public abstract class NotificationBase : INotifiable
{
    public event EventHandler<string> Notification;

    protected virtual void OnNotification(string message)
    {
        Notification?.Invoke(this, message);
    }

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

// Usage
public class Program
{
    public static void Main()
    {
        void NotificationHandler(object sender, string message)
        {
            Console.WriteLine($"Notification received from {sender.GetType().Name}: {message}");
        }

        var notifications = new List<INotifiable>
        {
            new EmailNotification(),
            new SMSNotification()
        };

        // Subscribe to notifications
        foreach (var notifier in notifications)
        {
            notifier.Notification += NotificationHandler;
        }

        // Send notifications
        foreach (var notifier in notifications)
        {
            notifier.SendNotification("Hello World!");
        }
    }
}
```

### 4. Exception Handling with Polymorphism
```csharp
/// <summary>
/// Demonstrates proper exception handling with polymorphic operations
/// </summary>
public class BusinessException : Exception
{
    public string ErrorCode { get; }

    public BusinessException(string message, string errorCode) 
        : base(message)
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
            // Simulate database operation
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
            // Simulate file operation
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

// Usage
public class Program
{
    public static void Main()
    {
        var operations = new List<IOperation>
        {
            new DatabaseOperation(),
            new FileOperation()
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
    }
}
```

### 5. Unit Testing Polymorphic Code
```csharp
// Using xUnit for testing
public class CalculatorTests
{
    [Fact]
    public void Add_WithIntegers_ReturnsCorrectSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(5, 3);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_WithDoubles_ReturnsCorrectSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        double result = calculator.Add(5.5, 3.3);

        // Assert
        Assert.Equal(8.8, result, precision: 2);
    }
}

public class ShapeTests
{
    [Theory]
    [InlineData(5, 78.54)]
    [InlineData(1, 3.14)]
    public void Circle_CalculateArea_ReturnsCorrectArea(double radius, double expectedArea)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, precision: 2);
    }
}
```

## Best Practices Summary

1. **SOLID Principles**
   - Single Responsibility: Each class should have one reason to change
   - Open/Closed: Open for extension, closed for modification
   - Liskov Substitution: Derived classes must be substitutable for base classes
   - Interface Segregation: Many specific interfaces are better than one general interface
   - Dependency Inversion: Depend on abstractions, not concretions

2. **Design Guidelines**
   - Use interfaces for behavior contracts
   - Prefer composition over inheritance
   - Keep inheritance hierarchies shallow
   - Use abstract classes for shared implementation
   - Make base classes abstract when appropriate

3. **Error Handling**
   - Use custom exceptions for domain-specific errors
   - Include relevant error information
   - Handle exceptions at appropriate levels
   - Log exceptions properly
   - Provide meaningful error messages

4. **Testing**
   - Test polymorphic behavior
   - Test edge cases
   - Use mocking for dependencies
   - Test exception scenarios
   - Use theory tests for parameterized testing

## Common Anti-patterns to Avoid

1. **Deep Inheritance**
```csharp
// Bad
class Animal { }
class Mammal : Animal { }
class Carnivore : Mammal { }
class BigCat : Carnivore { }
class Lion : BigCat { }

// Better
interface IAnimal { }
interface ICarnivore { }
class Lion : IAnimal, ICarnivore { }
```

2. **Type Checking**
```csharp
// Bad
if (shape is Circle)
    ((Circle)shape).Radius = 5;

// Better
public interface IShape
{
    void Resize(double factor);
}
```

3. **God Interfaces**
```csharp
// Bad
public interface IRepository
{
    void Add();
    void Update();
    void Delete();
    void Export();
    void Import();
    void Validate();
    void Calculate();
}

// Better
public interface IReadRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}

public interface IWriteRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}
```

Would you like me to:
1. Add more design patterns examples?
2. Include performance optimization techniques?
3. Add more unit testing scenarios?
4. Provide real-world application examples?