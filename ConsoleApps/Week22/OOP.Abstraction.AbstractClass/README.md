# OOP Abstraction - Abstract Class and Abstract Methods in C#

## Introduction

In this article, we will explore the concept of abstraction in Object-Oriented Programming (OOP) using C#. Specifically, we will focus on abstract classes and abstract methods. Abstraction is one of the four fundamental principles of OOP, alongside encapsulation, inheritance, and polymorphism.

## What is Abstraction?

Abstraction is the process of hiding complex implementation details and showing only the necessary features of an object. It helps in:
- Reducing complexity
- Avoiding code duplication
- Managing large codebases effectively
- Creating a clear and organized class hierarchy

## Abstract Classes

An abstract class in C# is a restricted class that cannot be instantiated on its own and must be inherited by another class. It serves as a base class for other classes to derive from.

### Key Characteristics:
- Declared using the `abstract` keyword
- Can have both abstract and concrete methods
- Can have constructors and destructors
- Can have fields, properties, and events
- Cannot be instantiated directly
- Must be inherited by a derived class

### Example:
```csharp
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
    
    // Concrete method
    public void DisplayInfo()
    {
        Console.WriteLine($"Area: {CalculateArea()}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
    }
}
```

## Abstract Methods

Abstract methods are methods declared in an abstract class without implementation. They must be implemented by any non-abstract class that inherits from the abstract class.

### Characteristics:
- Declared using the `abstract` keyword
- Have no method body
- Must be implemented in derived classes using the `override` keyword
- Can only exist in abstract classes

## When to Use Abstract Classes

Use abstract classes when:
1. You want to share code among several related classes
2. You expect classes that inherit from the abstract class to have common methods or properties
3. You want to declare non-public members
4. You need some common functionality in several related classes

## Examples

### 1. Simple Example: Document Processing

This basic example shows how to handle different types of documents:

```csharp
public abstract class Document
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDate { get; set; }

    // Abstract method
    public abstract void Process();
    
    // Concrete method
    public void DisplayInfo()
    {
        Console.WriteLine($"Document: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Created: {CreatedDate}");
    }
}

public class PdfDocument : Document
{
    public string PdfVersion { get; set; }

    public override void Process()
    {
        Console.WriteLine($"Processing PDF document: {Title}");
        // PDF-specific processing logic
        Console.WriteLine($"PDF Version: {PdfVersion}");
    }
}

public class WordDocument : Document
{
    public string WordVersion { get; set; }

    public override void Process()
    {
        Console.WriteLine($"Processing Word document: {Title}");
        // Word-specific processing logic
        Console.WriteLine($"Word Version: {WordVersion}");
    }
}

public class ExcelDocument : Document
{
    public string ExcelVersion { get; set; }

    public override void Process()
    {
        Console.WriteLine($"Processing Excel document: {Title}");
        // Excel-specific processing logic
        Console.WriteLine($"Excel Version: {ExcelVersion}");
    }
}
```

### 2. Intermediate Example: Payment Processing System

This example demonstrates a payment processing system:

```csharp
public abstract class PaymentProcessor
{
    protected decimal Amount { get; set; }
    protected string Currency { get; set; }

    public PaymentProcessor(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    // Abstract methods
    public abstract bool AuthorizePayment();
    public abstract bool ProcessPayment();
    public abstract bool RefundPayment(string transactionId);

    // Concrete method
    public virtual void ValidatePayment()
    {
        if (Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");
        if (string.IsNullOrEmpty(Currency))
            throw new ArgumentException("Currency must be specified");
    }
}

public class CreditCardProcessor : PaymentProcessor
{
    private string CardNumber { get; set; }
    private string CVV { get; set; }
    private string ExpiryDate { get; set; }

    public CreditCardProcessor(decimal amount, string currency, string cardNumber, string cvv, string expiryDate) 
        : base(amount, currency)
    {
        CardNumber = cardNumber;
        CVV = cvv;
        ExpiryDate = expiryDate;
    }

    public override bool AuthorizePayment()
    {
        // Credit card authorization logic
        Console.WriteLine("CreditCardProcessor: Payment authorized.");
        return true;
    }

    public override bool ProcessPayment()
    {
        ValidatePayment();
        // Credit card processing logic
        Console.WriteLine("CreditCardProcessor: Payment processed.");
        return true;
    }

    public override bool RefundPayment(string transactionId)
    {
        // Credit card refund logic
        Console.WriteLine("CreditCardProcessor: Payment refunded.");
        return true;
    }
}

public class PayPalProcessor : PaymentProcessor
{
    private string EmailAddress { get; set; }

    public PayPalProcessor(decimal amount, string currency, string emailAddress) 
        : base(amount, currency)
    {
        EmailAddress = emailAddress;
    }

    public override bool AuthorizePayment()
    {
        // PayPal authorization logic
        Console.WriteLine("PayPalProcessor: Payment authorized.");
        return true;
    }

    public override bool ProcessPayment()
    {
        ValidatePayment();
        // PayPal processing logic
        Console.WriteLine("PayPalProcessor: Payment processed.");
        return true;
    }

    public override bool RefundPayment(string transactionId)
    {
        // PayPal refund logic
        Console.WriteLine("PayPalProcessor: Payment refunded.");
        return true;
    }
}
```

### 3. Complex Example: Game Character System

This example shows a more complex game character system with multiple levels of abstraction:

```csharp
public abstract class GameCharacter
{
    public string Name { get; set; }
    public int Level { get; protected set; }
    public double Health { get; protected set; }
    public double MaxHealth { get; protected set; }
    protected Dictionary<string, double> Stats { get; set; }

    protected GameCharacter(string name, int level)
    {
        Name = name;
        Level = level;
        Stats = new Dictionary<string, double>();
        InitializeStats();
    }

    // Abstract methods
    public abstract void InitializeStats();
    public abstract void LevelUp();
    public abstract double CalculateDamage(string attackType);
    public abstract void TakeDamage(double damage);
    public abstract void UseSpecialAbility();

    // Concrete methods
    public virtual void Heal(double amount)
    {
        Health = Math.Min(Health + amount, MaxHealth);
    }

    public virtual bool IsAlive()
    {
        return Health > 0;
    }

    protected virtual void UpdateStats(string stat, double value)
    {
        if (Stats.ContainsKey(stat))
            Stats[stat] = value;
        else
            Stats.Add(stat, value);
    }
}

public class Warrior : GameCharacter
{
    public double Rage { get; private set; }
    public double MaxRage { get; private set; }

    public Warrior(string name, int level) : base(name, level)
    {
        MaxRage = 100;
        Rage = MaxRage;
    }

    public override void InitializeStats()
    {
        MaxHealth = 100 + (Level * 10);
        Health = MaxHealth;
        UpdateStats("Strength", 10 + (Level * 2));
        UpdateStats("Defense", 8 + (Level * 1.5));
        UpdateStats("Agility", 5 + Level);
    }

    public override void LevelUp()
    {
        Level++;
        InitializeStats();
        Rage = MaxRage;
        Console.WriteLine($"{Name} has reached level {Level}!");
    }

    public override double CalculateDamage(string attackType)
    {
        double baseDamage = Stats["Strength"] * 1.5;
        return attackType switch
        {
            "normal" => baseDamage,
            "heavy" => baseDamage * 2.0,
            "special" => baseDamage * 3.0,
            _ => baseDamage
        };
    }

    public override void TakeDamage(double damage)
    {
        double reducedDamage = damage * (100 / (100 + Stats["Defense"]));
        Health -= reducedDamage;
        Rage = Math.Min(Rage + (reducedDamage * 0.5), MaxRage);

        if (!IsAlive())
            Console.WriteLine($"{Name} has fallen in battle!");
    }

    public override void UseSpecialAbility()
    {
        if (Rage >= 30)
        {
            Console.WriteLine($"{Name} uses Berserker Rage!");
            UpdateStats("Strength", Stats["Strength"] * 1.5);
            Rage -= 30;
        }
        else
        {
            Console.WriteLine($"{Name} doesn't have enough rage!");
        }
    }
}

public class Mage : GameCharacter
{
    public double Mana { get; private set; }
    public double MaxMana { get; private set; }

    public Mage(string name, int level) : base(name, level)
    {
        MaxMana = 100 + (Level * 10);
        Mana = MaxMana;
    }

    public override void InitializeStats()
    {
        MaxHealth = 70 + (Level * 7);
        Health = MaxHealth;
        UpdateStats("Intelligence", 15 + (Level * 2.5));
        UpdateStats("Defense", 4 + Level);
        UpdateStats("MagicResistance", 8 + (Level * 1.5));
    }

    public override void LevelUp()
    {
        Level++;
        InitializeStats();
        MaxMana += 10;
        Mana = MaxMana;
        Console.WriteLine($"{Name} has reached level {Level}!");
    }

    public override double CalculateDamage(string attackType)
    {
        double baseDamage = Stats["Intelligence"] * 2.0;
        return attackType switch
        {
            "fire" => baseDamage * 1.5,
            "ice" => baseDamage * 1.2,
            "arcane" => baseDamage * 2.0,
            _ => baseDamage
        };
    }

    public override void TakeDamage(double damage)
    {
        double reducedDamage = damage * (100 / (100 + Stats["MagicResistance"]));
        Health -= reducedDamage;

        if (!IsAlive())
            Console.WriteLine($"{Name} has been defeated!");
    }

    public override void UseSpecialAbility()
    {
        if (Mana >= 50)
        {
            Console.WriteLine($"{Name} casts Arcane Explosion!");
            // Implementation of area damage
            Mana -= 50;
        }
        else
        {
            Console.WriteLine($"{Name} doesn't have enough mana!");
        }
    }
}
```

## OOP Principles and SOLID Principles

### OOP Principles

1. **Abstraction**: The process of hiding complex implementation details and showing only the necessary features of an object.
2. **Encapsulation**: The bundling of data and methods that operate on that data within a single unit or class.
3. **Inheritance**: The mechanism by which one class can inherit the properties and methods of another class.
4. **Polymorphism**: The ability of different classes to be treated as instances of the same class through a common interface.

### SOLID Principles

1. **Single Responsibility Principle (SRP)**: A class should have only one reason to change, meaning it should have only one job or responsibility.
2. **Open/Closed Principle (OCP)**: Software entities should be open for extension but closed for modification.
3. **Liskov Substitution Principle (LSP)**: Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
4. **Interface Segregation Principle (ISP)**: Clients should not be forced to depend on interfaces they do not use.
5. **Dependency Inversion Principle (DIP)**: High-level modules should not depend on low-level modules. Both should depend on abstractions.

### Relation of OOP Principles with SOLID Principles in the Code

1. **Abstraction**:
   - Used in the `Document`, `PaymentProcessor`, and `GameCharacter` classes to provide a simplified interface for operations.
   - Related SOLID Principles: SRP, OCP, LSP.

2. **Encapsulation**:
   - Used to bundle data and methods within classes like `PdfDocument`, `CreditCardProcessor`, and `Warrior`.
   - Related SOLID Principles: SRP, ISP.

3. **Inheritance**:
   - Used to create a class hierarchy where derived classes inherit from base classes like `Document`, `PaymentProcessor`, and `GameCharacter`.
   - Related SOLID Principles: OCP, LSP.

4. **Polymorphism**:
   - Used to treat different classes as instances of the same class through a common interface, such as using `Document`, `PaymentProcessor`, and `GameCharacter` types.
   - Related SOLID Principles: LSP, DIP.

## Best Practices

1. Name abstract classes with clear, descriptive names that reflect their purpose.
2. Use abstract classes to provide a common base class implementation.
3. Keep the abstraction level consistent.
4. Document the expected behavior of abstract methods.
5. Consider using interfaces instead if you only need to define a contract.
6. Don't create abstract classes with too many abstract methods.
7. Follow the Single Responsibility Principle.

## Common Pitfalls

1. Creating abstract classes with too many responsibilities.
2. Forgetting to implement all abstract methods in derived classes.
3. Making an abstract class too specific.
4. Not considering interfaces as an alternative.
5. Creating deep inheritance hierarchies.
6. Making concrete methods abstract when they don't need to be.

## Liskov Substitution Principle (LSP)

The Liskov Substitution Principle (LSP) is one of the SOLID principles of object-oriented design. It states that objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program. In other words, if class B is a subclass of class A, then we should be able to replace objects of class A with objects of class B without altering the desirable properties of the program (e.g., correctness).

### Key Points:

- Subtypes must be substitutable for their base types.
- Derived classes must extend the base classes without changing their behavior.
- Clients should not need to know the difference between the base class and the derived class.

### Example:

Consider the following example where the LSP is violated:

```csharp
public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Ostriches can't fly.");
    }
}
```

In this example, the `Ostrich` class violates the LSP because it cannot fly, even though it inherits from the `Bird` class, which has a `Fly` method. To adhere to the LSP, we should refactor the design:

```csharp
public abstract class Bird
{
    // Common bird properties and methods
}

public abstract class FlyingBird : Bird
{
    public abstract void Fly();
}

public class Sparrow : FlyingBird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

public class Ostrich : Bird
{
    // Ostrich-specific properties and methods
}
```

By introducing a `FlyingBird` class, we ensure that only birds that can fly inherit the `Fly` method, thus adhering to the LSP.

---

For more information about abstract classes and methods in C#, refer to:
- [Microsoft Docs - Abstract Classes and Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/)

