# OOP Abstraction - Abstract Class and Abstract Methods in C#

## Table of Contents
- [Introduction](#introduction)
- [What is Abstraction?](#what-is-abstraction)
- [Abstract Classes](#abstract-classes)
- [Abstract Methods](#abstract-methods)
- [When to Use Abstract Classes](#when-to-use-abstract-classes)
- [Examples](#examples)
- [Best Practices](#best-practices)
- [Common Pitfalls](#common-pitfalls)

## Introduction
This project demonstrates the concept of abstraction in Object-Oriented Programming (OOP) using C#, specifically focusing on abstract classes and abstract methods. Abstraction is one of the four fundamental principles of OOP, alongside encapsulation, inheritance, and polymorphism.

## What is Abstraction?
Abstraction is the process of hiding complex implementation details and showing only the necessary features of an object. It helps in:
- Reducing complexity
- Avoiding code duplication
- Managing large codebases effectively
- Creating a clear and organized class hierarchy

## Abstract Classes
An abstract class in C# is a restricted class that cannot be instantiated on its own and must be inherited by another class. It serves as a base class for other classes to derive from.

Key characteristics:
- Declared using the `abstract` keyword
- Can have both abstract and concrete methods
- Can have constructors and destructors
- Can have fields, properties, and events
- Cannot be instantiated directly
- Must be inherited by a derived class

Example:
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

Characteristics:
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
    }
}

public class WordDocument : Document
{
    public string WordVersion { get; set; }

    public override void Process()
    {
        Console.WriteLine($"Processing Word document: {Title}");
        // Word-specific processing logic
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
    public abstract Task<bool> AuthorizePayment();
    public abstract Task<bool> ProcessPayment();
    public abstract Task<bool> RefundPayment(string transactionId);

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

    public override async Task<bool> AuthorizePayment()
    {
        // Credit card authorization logic
        await Task.Delay(1000); // Simulating API call
        return true;
    }

    public override async Task<bool> ProcessPayment()
    {
        ValidatePayment();
        // Credit card processing logic
        await Task.Delay(1000); // Simulating API call
        return true;
    }

    public override async Task<bool> RefundPayment(string transactionId)
    {
        // Credit card refund logic
        await Task.Delay(1000); // Simulating API call
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

    public override async Task<bool> AuthorizePayment()
    {
        // PayPal authorization logic
        await Task.Delay(1000); // Simulating API call
        return true;
    }

    public override async Task<bool> ProcessPayment()
    {
        ValidatePayment();
        // PayPal processing logic
        await Task.Delay(1000); // Simulating API call
        return true;
    }

    public override async Task<bool> RefundPayment(string transactionId)
    {
        // PayPal refund logic
        await Task.Delay(1000); // Simulating API call
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

// Usage Example:
public class GameExample
{
    public static async Task RunGameExample()
    {
        var warrior = new Warrior("Conan", 1);
        var mage = new Mage("Gandalf", 1);

        // Battle simulation
        Console.WriteLine("Battle begins!");
        
        warrior.UseSpecialAbility();
        var warriorDamage = warrior.CalculateDamage("heavy");
        mage.TakeDamage(warriorDamage);

        mage.UseSpecialAbility();
        var mageDamage = mage.CalculateDamage("arcane");
        warrior.TakeDamage(mageDamage);

        // Level up
        warrior.LevelUp();
        mage.LevelUp();
    }
}
```

These examples demonstrate different levels of complexity in using abstract classes:

1. The **Document Processing** example shows basic abstraction with simple method overriding.
2. The **Payment Processing** example demonstrates real-world business logic with async operations and multiple payment methods.
3. The **Game Character** example shows complex inheritance with multiple stats, abilities, and game mechanics.

Each example builds upon the previous one, showing how abstraction can be used to create increasingly sophisticated systems while maintaining clean, maintainable code.

## Best Practices
1. Name abstract classes with clear, descriptive names that reflect their purpose
2. Use abstract classes to provide a common base class implementation
3. Keep the abstraction level consistent
4. Document the expected behavior of abstract methods
5. Consider using interfaces instead if you only need to define a contract
6. Don't create abstract classes with too many abstract methods
7. Follow the Single Responsibility Principle

## Common Pitfalls
1. Creating abstract classes with too many responsibilities
2. Forgetting to implement all abstract methods in derived classes
3. Making an abstract class too specific
4. Not considering interfaces as an alternative
5. Creating deep inheritance hierarchies
6. Making concrete methods abstract when they don't need to be

---

For more information about abstract classes and methods in C#, refer to:
- [Microsoft Docs - Abstract Classes and Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/)

