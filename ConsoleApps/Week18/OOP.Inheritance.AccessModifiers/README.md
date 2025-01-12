# Access Modifiers in C# Inheritance

[← Back to Main Documentation](../OOp.Inheritance/README.md)

This project demonstrates the various access modifiers and their behavior in inheritance scenarios.

## Related Documentation
- [Introduction to Inheritance](../OOp.Inheritance/IntroductionToInheritance.md)
- [Best Practices Guide](../OOp.Inheritance/BestPracticesinInheritance.md)
- [Advanced Topics](../OOp.Inheritance/sections.md)
- [Method Overriding Guide](../OOP.Inheritance.MethodOverriding/README.md)

## Access Modifier Types with Examples

### 1. **public**
```csharp
public class Vehicle
{
    public string Brand { get; set; }  // Accessible everywhere
    
    public void StartEngine()  // Public method
    {
        Console.WriteLine($"{Brand}'s engine is starting...");
    }
}

public class Car : Vehicle
{
    public void Drive()
    {
        Brand = "Toyota";  // Can access public member
        StartEngine();     // Can access public method
    }
}
```

### 2. **private**
```csharp
public class BankAccount
{
    private decimal balance;  // Only accessible within BankAccount
    
    private void UpdateBalance(decimal amount)  // Private method
    {
        balance += amount;
    }

    public void Deposit(decimal amount)
    {
        UpdateBalance(amount);  // Can access private method
    }
}

public class SavingsAccount : BankAccount
{
    public void AddInterest()
    {
        // Cannot access balance or UpdateBalance
        // balance = 100;           // Error!
        // UpdateBalance(100);      // Error!
        Deposit(100);              // OK - public method
    }
}
```

### 3. **protected**
```csharp
public class Animal
{
    protected string name;  // Accessible in Animal and derived classes
    
    protected void Eat()  // Protected method
    {
        Console.WriteLine($"{name} is eating...");
    }
}

public class Dog : Animal
{
    public void Feed()
    {
        name = "Rex";  // Can access protected field
        Eat();         // Can access protected method
    }
}
```

### 4. **internal**
```csharp
// Assembly1
internal class Logger
{
    internal void Log(string message)
    {
        Console.WriteLine($"Logging: {message}");
    }
}

// Same Assembly
public class ErrorLogger : Logger
{
    public void LogError(string error)
    {
        Log($"Error: {error}");  // Can access internal method
    }
}

// Different Assembly
public class ExternalLogger : Logger  // Error! Cannot inherit internal class
{
    // Cannot access internal members from different assembly
}
```

### 5. **protected internal**
```csharp
public class Database
{
    protected internal void Connect()
    {
        Console.WriteLine("Connecting to database...");
    }
}

// Same Assembly
public class SqlDatabase : Database
{
    public void Initialize()
    {
        Connect();  // Can access protected internal method
    }
}

// Different Assembly
public class OracleDatabase : Database
{
    public void Initialize()
    {
        Connect();  // Can access because it's a derived class
    }
}
```

## Real-World Scenarios

### 1. Base Class with Mixed Access Levels
```csharp
public class Employee
{
    public string Name { get; set; }           // Public - accessible everywhere
    protected decimal Salary { get; set; }     // Protected - for inheritance
    private string ssn;                        // Private - highly sensitive
    internal string department;                // Internal - same assembly only

    public Employee(string name, decimal salary, string ssn)
    {
        Name = name;
        Salary = salary;
        this.ssn = ssn;
    }

    protected virtual decimal CalculateBonus()
    {
        return Salary * 0.1m;
    }
}

public class Manager : Employee
{
    public Manager(string name, decimal salary, string ssn) 
        : base(name, salary, ssn)
    {
    }

    protected override decimal CalculateBonus()
    {
        return Salary * 0.2m;  // Can access protected Salary
    }

    public void AssignDepartment(string dept)
    {
        department = dept;     // Can access internal field
        // ssn = "123-45-6789"; // Error! Cannot access private field
    }
}
```

## Best Practices with Examples

### 1. Use the Most Restrictive Level Possible
```csharp
public class Customer
{
    private string creditCardNumber;  // Correctly private - sensitive data
    public string Name { get; set; }  // Public - needs external access
    protected virtual void Validate() // Protected - for inheritance
    {
        // Validation logic
    }
}
```

### 2. Protected Members for Inheritance
```csharp
public class Shape
{
    protected double area;  // Needed by derived classes
    
    protected virtual void CalculateArea()
    {
        // Base calculation
    }
}

public class Circle : Shape
{
    private double radius;
    
    protected override void CalculateArea()
    {
        area = Math.PI * radius * radius;
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
- [Best Practices for Access Modifiers](../OOp.Inheritance/BestPracticesinInheritance.md#use-sealed-when-necessary)
- [Advanced Design Patterns](../OOp.Inheritance/sections.md#advanced-design-patterns)