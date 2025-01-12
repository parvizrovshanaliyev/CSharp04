# Method Overriding in C# Inheritance

[← Back to Main Documentation](../OOp.Inheritance/README.md)

This project demonstrates method overriding concepts in C# inheritance, showing how derived classes can provide their own implementation of base class methods.

## Related Documentation
- [Introduction to Inheritance](../OOp.Inheritance/IntroductionToInheritance.md)
- [Best Practices Guide](../OOp.Inheritance/BestPracticesinInheritance.md)
- [Advanced Topics](../OOp.Inheritance/sections.md)
- [Access Modifiers Guide](../OOP.Inheritance.AccessModifiers/README.md)

## Method Overriding Concepts

### 1. **Basic Method Overriding**
```csharp
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks: Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows: Meow!");
    }
}
```

### 2. **Base Method Calling**
```csharp
public class Employee
{
    public virtual void CalculateSalary()
    {
        Console.WriteLine("Calculating base salary...");
    }
}

public class Manager : Employee
{
    public override void CalculateSalary()
    {
        base.CalculateSalary();  // Call base implementation
        Console.WriteLine("Adding manager bonus...");
    }
}
```

### 3. **Method Hiding (new keyword)**
```csharp
public class Parent
{
    public void Display()
    {
        Console.WriteLine("Parent's Display");
    }
}

public class Child : Parent
{
    public new void Display()  // Hides parent's method
    {
        Console.WriteLine("Child's Display");
    }
}
```

## Advanced Overriding Scenarios

### 1. **Abstract Methods**
```csharp
public abstract class Shape
{
    public abstract double CalculateArea();  // Must be implemented
}

public class Circle : Shape
{
    private double radius;

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}
```

### 2. **Sealed Methods**
```csharp
public class Animal
{
    public virtual void Breathe()
    {
        Console.WriteLine("Breathing...");
    }
}

public class Mammal : Animal
{
    public sealed override void Breathe()
    {
        Console.WriteLine("Breathing through lungs");
    }
}

public class Dog : Mammal
{
    // Cannot override Breathe because it's sealed
    // public override void Breathe() { } // Error!
}
```

### 3. **Multiple Level Overriding**
```csharp
public class Vehicle
{
    public virtual void Start()
    {
        Console.WriteLine("Vehicle starting");
    }
}

public class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car engine starting");
    }
}

public class ElectricCar : Car
{
    public override void Start()
    {
        Console.WriteLine("Electric car powering up");
    }
}
```

## Real-World Examples

### 1. **Document Processing**
```csharp
public abstract class Document
{
    public virtual void Open()
    {
        Console.WriteLine("Opening document...");
    }

    public abstract void Process();
    
    public virtual void Close()
    {
        Console.WriteLine("Closing document...");
    }
}

public class PdfDocument : Document
{
    public override void Open()
    {
        base.Open();
        Console.WriteLine("Loading PDF reader...");
    }

    public override void Process()
    {
        Console.WriteLine("Processing PDF content...");
    }

    public override void Close()
    {
        Console.WriteLine("Saving PDF changes...");
        base.Close();
    }
}
```

### 2. **Payment Processing**
```csharp
public abstract class PaymentProcessor
{
    protected decimal amount;

    public virtual void ValidatePayment()
    {
        if (amount <= 0)
            throw new ArgumentException("Invalid amount");
    }

    public abstract void ProcessPayment();
}

public class CreditCardProcessor : PaymentProcessor
{
    private string cardNumber;

    public override void ValidatePayment()
    {
        base.ValidatePayment();
        if (string.IsNullOrEmpty(cardNumber))
            throw new ArgumentException("Invalid card number");
    }

    public override void ProcessPayment()
    {
        ValidatePayment();
        Console.WriteLine($"Processing ${amount} via Credit Card: {cardNumber}");
    }
}
```

## Best Practices

1. **When to Override**
   - Use override when you need to change base behavior
   - Consider whether base implementation is still needed
   - Document any assumptions or requirements

2. **Base Method Calls**
   - Call base method when extending functionality
   - Be clear about execution order
   - Document when base method is not called

3. **Virtual Method Design**
   - Make methods virtual only if they're designed for overriding
   - Document expected override behavior
   - Consider abstract methods for required implementations

## Common Pitfalls

1. **Forgetting virtual/override Keywords**
```csharp
public class Base
{
    public void Method() { }  // Not virtual
}

public class Derived : Base
{
    public override void Method() { }  // Error!
}
```

2. **Incorrect Base Method Calls**
```csharp
public class Derived : Base
{
    public override void Method()
    {
        // Some code
        base.Method();  // Base call should usually be first
    }
}
```

## Running the Examples

1. Clone the repository
2. Navigate to the project directory
3. Run using .NET CLI:
```bash
dotnet run
```

## See Also
- [Core Inheritance Concepts](../OOp.Inheritance/IntroductionToInheritance.md#core-concepts)
- [Best Practices for Method Overriding](../OOp.Inheritance/BestPracticesinInheritance.md#test-for-side-effects-in-overridden-methods)
- [Advanced Design Patterns](../OOp.Inheritance/sections.md#advanced-design-patterns) 