# Introduction to Inheritance in C#

[← Back to Main Documentation](README.md)

## Related Guides
- [Method Overriding Guide](OOP.Inheritance.MethodOverriding/README.md) - Detailed examples of method overriding
- [Access Modifiers Guide](OOP.Inheritance.AccessModifiers/README.md) - In-depth coverage of access modifiers
- [Best Practices](BestPracticesinInheritance.md) - Guidelines for effective inheritance
- [Advanced Topics](sections.md) - Advanced inheritance concepts

## Getting Started

### What is Inheritance?
Inheritance is a key concept in Object-Oriented Programming (OOP) that allows a class (known as the **derived** or **child class**) to inherit members such as fields, properties, methods, and events from another class (the **base** or **parent class**). This promotes **code reusability**, simplifies maintenance, and establishes a logical **"is-a" relationship** between classes.

### Basic Implementation
Inheritance in C# is implemented using the colon (`:`) symbol. The general syntax is:

```csharp
class Child : Parent
{
    // Child class members
}
```

#### Example:
```csharp
public class Parent
{
    public string Name { get; set; }
}

public class Child : Parent
{
    public void DisplayName()
    {
        Console.WriteLine($"Name: {Name}"); // Accessing inherited property
    }
}
```

## Core Concepts

### Access Modifiers in Inheritance
Access modifiers control member visibility for derived classes:

- **`private`**: Accessible only within the parent class
- **`protected`**: Accessible within the parent class and its derived classes
- **`public`**: Accessible from anywhere
- **`internal`**: Accessible within the same assembly

#### Example:

```csharp
class Parent
{
    private string secretData; // Not accessible to Child
    protected string accessibleData; // Accessible to Child
}

class Child : Parent
{
    public void AccessData()
    {
        // Console.WriteLine(secretData); // Not allowed
        Console.WriteLine(accessibleData); // Allowed
    }
}
```

### Constructor Chaining in Inheritance
When a derived class is instantiated, its **parent class constructor** is called first. This ensures proper initialization of inherited members.

#### Example:

```csharp
class Parent
{
    public Parent()
    {
        Console.WriteLine("Parent Constructor Called");
    }
}

class Child : Parent
{
    public Child() : base() // Calls parent constructor explicitly
    {
        Console.WriteLine("Child Constructor Called");
    }
}
```

### Passing Values to Parent Constructor
Values can be passed to the parent class constructor using the `base` keyword:

```csharp
class Parent
{
    protected string name;
    
    public Parent(string name)
    {
        this.name = name;
    }
}

class Child : Parent
{
    public Child(string name) : base(name)
    {
        Console.WriteLine($"Child created with name: {name}");
    }
}
```

### Method Overriding in Inheritance
Derived classes can override base class methods using the `override` keyword. The base class method must be declared `virtual`, `abstract`, or `override`.

#### Example:

```csharp
class Parent
{
    public virtual void DisplayInfo()
    {
        Console.WriteLine("This is the parent class.");
    }
}

class Child : Parent
{
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Optional: Calls the parent method
        Console.WriteLine("This is the child class.");
    }
}
```

### Default Parent Class in C#
All classes in C# implicitly inherit from `System.Object`. This makes `Object` the root of the class hierarchy.

#### Example:

```csharp
class MyClass // Implicitly inherits from System.Object
{
}
```

Equivalent to:

```csharp
class MyClass : System.Object
{
}
```

## Advantages of Inheritance in C#

1. **Code Reusability**: Common logic resides in the base class.
2. **Polymorphism**: Customize behavior using method overriding.
3. **Extensibility**: Add functionality to existing classes without modifying them.
4. **Organized Hierarchy**: Logical structuring of classes.
5. **Efficiency**: Reduces redundancy and simplifies maintenance.

## Best Practices

1. Use inheritance only for **"is-a" relationships** (e.g., a Dog **is-a** Animal).
2. Avoid deep inheritance hierarchies for better readability and maintainability.
3. Use `protected` for members that should be accessible to derived classes but hidden from external code.
4. Document virtual methods with clear guidelines for overriding behavior.
5. Prefer **composition** over inheritance when objects have a "has-a" relationship.
6. Avoid overriding methods unnecessarily; ensure overriding serves a clear purpose.

## Summary

- Inheritance is a fundamental OOP concept enabling code reuse and logical class relationships.
- Access modifiers (`private`, `protected`, `public`) control member visibility in inheritance.
- Constructors in inheritance use `base` to ensure proper initialization.
- Overriding methods enables customization of inherited behavior.
- Use inheritance wisely to maintain clear and efficient code structure.

## See Also
- [Method Overriding Examples](OOP.Inheritance.MethodOverriding/README.md#method-overriding-concepts)
- [Access Modifier Types](OOP.Inheritance.AccessModifiers/README.md#access-modifier-types-with-examples)
- [Best Practices Guide](BestPracticesinInheritance.md#best-practices)
- [Advanced Design Patterns](sections.md#advanced-design-patterns)