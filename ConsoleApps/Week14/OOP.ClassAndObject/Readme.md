# **Comprehensive Guide to Classes, Objects, Constructor Overloading, and Property Types in C#**

![](https://github.com/parvizrovshanaliyev/CSharp04/blob/main/docs/lesson-imgs/oop-classAndObject.png)
---

## **What Are Classes and Objects?**

### **Class**
- A **class** is a blueprint for creating objects.
- It defines:
  - **Fields**: Variables that hold the state of the object.
  - **Properties**: Encapsulated access to fields for data security and validation.
  - **Methods**: Define the behavior or actions of the object.
  - **Constructors**: Initialize objects with meaningful default or provided values.

### **Object**
- An **object** is an instance of a class.
- Think of a **class** as a "Car Blueprint" and an **object** as the actual car built from it.
- Objects represent specific entities with:
  - **State**: Defined by fields and properties.
  - **Behavior**: Defined by methods.

---

## **Key OOP Concepts**

### **1. Fields**
- **Definition**: Variables that store the internal state of an object.
- Typically kept `private` for **encapsulation** to protect data.
- Accessed via **properties** or **methods**.

### **2. Properties**
- **Definition**: Provide **controlled access** to fields.
- Types of properties:
  1. **Auto-Implemented Properties**: Simple `get` and `set`.
  2. **Read-Only Properties**: Allow reading but prevent modification.
  3. **Write-Only Properties**: Allow writing but prevent direct reading.
  4. **Computed Properties**: Dynamically calculated from other fields.
  5. **Properties with Validation**: Include logic to ensure data integrity.

### **3. Constructors**
- **Definition**: Special methods for initializing objects.
- Overloaded constructors allow flexible object creation.
- Types:
  - **Default Constructor**: No parameters, initializes with default values.
  - **Parameterized Constructor**: Accepts parameters to set specific values.
  - **Constructor Overloading**: Multiple constructors with different signatures.

### **4. The `this` Keyword**
- Refers to the **current instance** of a class.
- Used to:
  - Distinguish between fields and parameters with the same name.
  - Invoke other constructors in the same class.

---

## **Complete Example: A `Car` Class**

This example demonstrates:
1. **Encapsulation**: Using fields and properties.
2. **Constructor Overloading**: For flexible initialization.
3. **Property Types**: Including validation, computed, and read-only properties.

```csharp
namespace OOP.ClassAndObject
{
    /// <summary>
    /// Represents a Car with fields, properties, constructors, and methods.
    /// Demonstrates constructor overloading and various property types.
    /// </summary>
    public class Car
    {
        // Private field for the read-only property
        private readonly string model;

        // Auto-implemented property
        public string Color { get; set; }

        // Property with validation
        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                if (value >= 0) speed = value;
                else Console.WriteLine("Speed cannot be negative.");
            }
        }

        // Read-Only Property
        public string Model => model;

        // Computed Property
        public string Description => $"{Model} - {Color}";

        // Write-Only Property
        private string _secret;
        public string Secret
        {
            set { _secret = value; } // Can only be set, not read
        }

        // Default constructor
        public Car()
        {
            model = "Unknown";
            Color = "White";
            Speed = 0;
            Console.WriteLine("Default constructor called: Car initialized with default values.");
        }

        // Constructor with model and color
        public Car(string model, string color)
        {
            this.model = model;
            this.Color = color;
            Speed = 0; // Default speed
            Console.WriteLine($"Constructor called: Car initialized with Model: {model}, Color: {color}, Speed: {Speed}");
        }

        // Fully parameterized constructor
        public Car(string model, string color, int speed)
        {
            this.model = model;
            this.Color = color;
            this.Speed = speed;
            Console.WriteLine($"Constructor called: Car initialized with Model: {model}, Color: {color}, Speed: {speed}");
        }

        // Method to display details
        public void DisplayDetails()
        {
            Console.WriteLine($"Model: {Model}, Color: {Color}, Speed: {Speed} km/h, Description: {Description}");
        }

        // Method to accelerate
        public void Accelerate(int increment)
        {
            Speed += increment;
            Console.WriteLine($"{Model} accelerated by {increment} km/h. New Speed: {Speed} km/h");
        }

        // Method to brake
        public void Brake(int decrement)
        {
            Speed -= decrement;
            if (Speed < 0) Speed = 0; // Prevent negative speed
            Console.WriteLine($"{Model} slowed down by {decrement} km/h. New Speed: {Speed} km/h");
        }
    }
}
```

---

## **Program Class: Demonstrating Usage**

```csharp
namespace OOP.ClassAndObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demonstrating Property Types and Constructor Overloading ===");

            // Using default constructor
            Car car1 = new Car();
            car1.DisplayDetails();

            Console.WriteLine();

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
}
```

---

## **Sample Output**

```
=== Demonstrating Property Types and Constructor Overloading ===
Default constructor called: Car initialized with default values.
Model: Unknown, Color: White, Speed: 0 km/h, Description: Unknown - White

Constructor called: Car initialized with Model: Tesla Model S, Color: Red, Speed: 0
Model: Tesla Model S, Color: Red, Speed: 0 km/h, Description: Tesla Model S - Red

Constructor called: Car initialized with Model: Ford Mustang, Color: Blue, Speed: 120
Model: Ford Mustang, Color: Blue, Speed: 120 km/h, Description: Ford Mustang - Blue

Car 3 Description: Ford Mustang - Blue
Speed cannot be negative.
Tesla Model S accelerated by 20 km/h. New Speed: 100 km/h
Ford Mustang slowed down by 100 km/h. New Speed: 20 km/h

Updated Car Details:
Model: Tesla Model S, Color: Red, Speed: 100 km/h, Description: Tesla Model S - Red
Model: Ford Mustang, Color: Blue, Speed: 20 km/h, Description: Ford Mustang - Blue
```

---

## **Real-World Applications**

| **Feature**            | **Real-World Use Case**                                                                                                     |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------|
| **Auto-Implemented**    | Simple attributes like `Color`, `OwnerName`.                                                                              |
| **Read-Only Properties**| Attributes that never change after initialization, such as `VIN` (Vehicle Identification Number).                         |
| **Write-Only Properties**| Sensitive data like passwords or API keys.                                                                                |
| **Computed Properties** | Attributes derived from others, such as `FullName = FirstName + LastName`.                                                |
| **Validation**          | Ensuring data integrity, such as `Age >= 0` or `Speed >= 0`.                                                              |
| **Constructor Overloading**| Providing flexibility in object creation, for example, initializing with basic or advanced settings.                     |

---

## **Further Resources**
- **Microsoft Official Documentation**: [C# Classes and Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/)
- **Microsoft Official Documentation**: [C# Class Members](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members)
