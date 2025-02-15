# OOP Abstraction - Interface in C#

## Table of Contents
1. [What is an Interface?](#what-is-an-interface)
2. [Basic Interface Syntax](#basic-interface-syntax)
3. [Interface Features](#interface-features)
4. [Real-World Examples](#real-world-examples)
5. [Interface vs Abstract Class](#interface-vs-abstract-class)
6. [Best Practices](#best-practices)
7. [Advanced Interface Concepts](#advanced-interface-concepts)

## What is an Interface?
An interface in C# is a contract that defines a set of members (methods, properties, events, and indexers) that implementing classes must provide. Think of it as a blueprint or template that enforces consistent behavior across different classes. Interfaces are fundamental to achieving abstraction, polymorphism, and loose coupling in object-oriented programming.

Core Concepts:
- Interfaces define "what" needs to be done, not "how" it should be done
- Classes can implement multiple interfaces (unlike inheritance which is limited to one base class)
- Interface names conventionally start with 'I' (e.g. IDisposable, IEnumerable)
- All interface members are implicitly public and abstract
- Interfaces support polymorphic behavior through common contracts

Evolution of Interfaces in C#:
1. Traditional Features (C# 1.0+):
   - Method, property, event, and indexer declarations
   - Multiple interface implementation
   - Interface inheritance

2. Modern Enhancements (C# 8.0+):
   - Default interface methods
   - Static members and constants
   - Private, protected, and internal members
   - Virtual extension methods
   - Explicit interface implementation for conflict resolution

Advanced Capabilities:
- Generic interfaces with variance annotations (in/out)
- Async interface methods (C# 5.0+)
- Nested type declarations (interfaces, classes, enums)
- Duck typing pattern implementation
- Interface segregation for better modularity

Best Practices:
- Keep interfaces focused and cohesive (Interface Segregation Principle)
- Design for extensibility while maintaining backward compatibility
- Use explicit implementation to resolve naming conflicts
- Consider default implementations for optional functionality
- Document interface contracts thoroughly with XML comments

## Basic Interface Syntax

```csharp
/// <summary>
/// Represents a vehicle with basic functionality and properties.
/// This interface defines the contract that all vehicle types must implement.
/// </summary>
public interface IVehicle
{
    /// <summary>
    /// Gets or sets the brand name of the vehicle.
    /// </summary>
    string Brand { get; set; }

    /// <summary>
    /// Gets or sets the model name of the vehicle.
    /// </summary>
    string Model { get; set; }

    /// <summary>
    /// Gets or sets the manufacturing year of the vehicle.
    /// </summary>
    int Year { get; set; }

    /// <summary>
    /// Starts the vehicle's engine.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the vehicle's engine.
    /// </summary>
    void Stop();

    /// <summary>
    /// Gets a formatted string containing the vehicle's information.
    /// </summary>
    /// <returns>A string containing the year, brand, and model of the vehicle.</returns>
    string GetVehicleInfo();
}

/// <summary>
/// Represents a basic car implementation of the IVehicle interface.
/// </summary>
public class Car : IVehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    
    /// <summary>
    /// Tracks whether the car's engine is currently running.
    /// </summary>
    private bool _isRunning;

    /// <summary>
    /// Starts the car's engine if it's not already running.
    /// </summary>
    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            Console.WriteLine($"Starting {Brand} {Model}...");
        }
    }

    /// <summary>
    /// Stops the car's engine if it's currently running.
    /// </summary>
    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            Console.WriteLine($"Stopping {Brand} {Model}...");
        }
    }

    /// <summary>
    /// Returns a formatted string with the car's details.
    /// </summary>
    /// <returns>A string in the format "Year Brand Model"</returns>
    public string GetVehicleInfo()
    {
        return $"{Year} {Brand} {Model}";
    }
}
```

## Interface Features

### 1. Multiple Interface Implementation
In C#, a class can implement multiple interfaces simultaneously, unlike inheritance where a class can only inherit from one base class. This powerful feature enables flexible and modular design by allowing a class to fulfill multiple contracts or roles. For example, a class could implement both IComparable for sorting and IDisposable for resource cleanup.

Key benefits of multiple interface implementation:
- Promotes code reuse and modularity
- Enables polymorphic behavior through different interface contracts
- Allows classes to provide multiple distinct functionalities
- Facilitates loose coupling between components
- Supports the Interface Segregation Principle (ISP)

```csharp
/// <summary>
/// Defines functionality for electric-powered vehicles.
/// </summary>
public interface IElectricPowered
{
    /// <summary>
    /// Gets the current battery level as a percentage.
    /// </summary>
    int BatteryLevel { get; }

    /// <summary>
    /// Initiates the charging process for the electric vehicle.
    /// </summary>
    void Charge();
}

/// <summary>
/// Defines functionality for autonomous vehicles.
/// </summary>
public interface IAutonomous
{
    /// <summary>
    /// Gets whether the autonomous driving mode is currently enabled.
    /// </summary>
    bool IsAutoPilotEnabled { get; }

    /// <summary>
    /// Enables the autonomous driving mode.
    /// </summary>
    void EnableAutoPilot();

    /// <summary>
    /// Disables the autonomous driving mode.
    /// </summary>
    void DisableAutoPilot();
}

/// <summary>
/// Represents a Tesla Model S that implements multiple interfaces to provide
/// electric vehicle capabilities and autonomous driving features.
/// </summary>
public class TeslaModelS : IVehicle, IElectricPowered, IAutonomous
{
    public string Brand { get; set; } = "Tesla";
    public string Model { get; set; } = "Model S";
    public int Year { get; set; }
    public int BatteryLevel { get; private set; }
    public bool IsAutoPilotEnabled { get; private set; }

    public void Start()
    {
        if (BatteryLevel > 0)
            Console.WriteLine("Tesla starting silently...");
    }

    public void Stop()
    {
        Console.WriteLine("Tesla powered off.");
    }

    public string GetVehicleInfo()
    {
        return $"{Year} {Brand} {Model} (Battery: {BatteryLevel}%)";
    }

    public void Charge()
    {
        Console.WriteLine("Charging at Tesla Supercharger...");
        BatteryLevel = 100;
    }

    public void EnableAutoPilot()
    {
        IsAutoPilotEnabled = true;
        Console.WriteLine("AutoPilot enabled. Please keep hands on the wheel.");
    }

    public void DisableAutoPilot()
    {
        IsAutoPilotEnabled = false;
        Console.WriteLine("AutoPilot disabled. You have full control.");
    }
}
```

### 2. Interface Inheritance
Interfaces can inherit from other interfaces, allowing for hierarchical contract definitions. This enables the creation of specialized interfaces that build upon more general ones, promoting code reuse and maintaining the Interface Segregation Principle (ISP). For example, a base interface might define fundamental operations, while derived interfaces add more specific functionality for specialized use cases.

Key points about interface inheritance:
- An interface can inherit from multiple interfaces
- Derived interfaces inherit all members from base interfaces
- Classes implementing a derived interface must implement all members from both base and derived interfaces
- Helps organize and structure interface hierarchies in a logical way

```csharp
/// <summary>
/// Defines basic media playback functionality.
/// </summary>
public interface IMediaPlayer
{
    /// <summary>
    /// Starts playing the current media content.
    /// </summary>
    void Play();

    /// <summary>
    /// Pauses the currently playing media content.
    /// </summary>
    void Pause();

    /// <summary>
    /// Stops the media playback completely.
    /// </summary>
    void Stop();
}

/// <summary>
/// Extends IMediaPlayer with smart TV capabilities.
/// </summary>
public interface ISmartMediaPlayer : IMediaPlayer
{
    /// <summary>
    /// Establishes connection to a WiFi network.
    /// </summary>
    void ConnectToWifi();

    /// <summary>
    /// Streams content from the specified URL.
    /// </summary>
    /// <param name="contentUrl">The URL of the content to stream.</param>
    void StreamContent(string contentUrl);

    /// <summary>
    /// Gets whether the device is currently connected to the internet.
    /// </summary>
    bool IsConnectedToInternet { get; }
}

public class SmartTV : ISmartMediaPlayer
{
    private bool _isPlaying;
    private bool _isConnected;

    public bool IsConnectedToInternet => _isConnected;

    public void Play()
    {
        _isPlaying = true;
        Console.WriteLine("Smart TV started playing content");
    }

    public void Pause()
    {
        if (_isPlaying)
            Console.WriteLine("Content paused");
    }

    public void Stop()
    {
        _isPlaying = false;
        Console.WriteLine("Content stopped");
    }

    public void ConnectToWifi()
    {
        _isConnected = true;
        Console.WriteLine("Connected to WiFi network");
    }

    public void StreamContent(string contentUrl)
    {
        if (IsConnectedToInternet)
            Console.WriteLine($"Streaming content from: {contentUrl}");
        else
            Console.WriteLine("Please connect to internet first");
    }
}
```

## Real-World Examples

### 1. E-Commerce System
This example demonstrates how interfaces can be used to create a modular and maintainable e-commerce system. By using interfaces like `IShoppingCart` and `IInventoryManager`, we can:

- Decouple components to make the system more flexible and testable
- Enable easy swapping of implementations (e.g. different cart or inventory systems)
- Enforce consistent contracts across different parts of the application
- Support dependency injection for better unit testing
- Allow for future extensibility without modifying existing code

```csharp
/// <summary>
/// Defines the contract for shopping cart operations.
/// </summary>
public interface IShoppingCart
{
    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="quantity">The quantity of the product.</param>
    /// <exception cref="ArgumentNullException">Thrown when product is null.</exception>
    /// <exception cref="ArgumentException">Thrown when quantity is less than 1.</exception>
    void AddItem(Product product, int quantity);

    /// <summary>
    /// Removes a product from the shopping cart.
    /// </summary>
    /// <param name="productId">The ID of the product to remove.</param>
    /// <returns>True if the product was removed successfully; otherwise, false.</returns>
    void RemoveItem(int productId);

    /// <summary>
    /// Calculates the total cost of items in the cart.
    /// </summary>
    /// <returns>The total cost including any applicable taxes and discounts.</returns>
    decimal CalculateTotal();

    /// <summary>
    /// Applies a discount coupon to the cart.
    /// </summary>
    /// <param name="couponCode">The coupon code to apply.</param>
    /// <exception cref="InvalidCouponException">Thrown when the coupon is invalid or expired.</exception>
    void ApplyDiscount(string couponCode);

    /// <summary>
    /// Processes the checkout operation for the cart.
    /// </summary>
    /// <exception cref="InsufficientStockException">Thrown when there's not enough stock for any item.</exception>
    /// <exception cref="PaymentFailedException">Thrown when payment processing fails.</exception>
    void Checkout();
}

/// <summary>
/// Defines the contract for inventory management operations.
/// </summary>
public interface IInventoryManager
{
    /// <summary>
    /// Checks if a product is in stock.
    /// </summary>
    /// <param name="productId">The ID of the product to check.</param>
    /// <returns>True if the product is in stock; otherwise, false.</returns>
    bool CheckStock(int productId);

    /// <summary>
    /// Updates the stock quantity for a product.
    /// </summary>
    /// <param name="productId">The ID of the product to update.</param>
    /// <param name="quantity">The quantity to add (positive) or remove (negative).</param>
    /// <exception cref="InvalidOperationException">Thrown when the operation would result in negative stock.</exception>
    void UpdateStock(int productId, int quantity);

    /// <summary>
    /// Initiates a reorder for a product when stock is low.
    /// </summary>
    /// <param name="productId">The ID of the product to reorder.</param>
    void ReorderStock(int productId);

    /// <summary>
    /// Gets the current available quantity for a product.
    /// </summary>
    /// <param name="productId">The ID of the product to check.</param>
    /// <returns>The current quantity available in stock.</returns>
    int GetAvailableQuantity(int productId);
}
```

### 2. File Processing System
A practical example demonstrating interfaces for robust file processing operations. This system shows:

- Separation of concerns between file processing and data extraction
- Comprehensive error handling for file operations
- Proper logging of operations and errors
- Support for different file formats and processing strategies
- Clean interface design following SOLID principles

```csharp
/// <summary>
/// Defines the contract for file processing operations.
/// </summary>
public interface IFileProcessor
{
    /// <summary>
    /// Processes a file at the specified path.
    /// </summary>
    /// <param name="filePath">The path to the file to process.</param>
    /// <exception cref="FileNotFoundException">Thrown when the file doesn't exist.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    void ProcessFile(string filePath);

    /// <summary>
    /// Validates if the file is in the correct format and can be processed.
    /// </summary>
    /// <param name="filePath">The path to the file to validate.</param>
    /// <returns>True if the file is valid; otherwise, false.</returns>
    bool ValidateFile(string filePath);

    /// <summary>
    /// Gets the type/format of the file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>A string describing the file type.</returns>
    string GetFileType(string filePath);
}

/// <summary>
/// Defines the contract for extracting data from files.
/// </summary>
public interface IDataExtractor
{
    /// <summary>
    /// Extracts metadata from a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>A dictionary containing the metadata key-value pairs.</returns>
    /// <exception cref="FileFormatException">Thrown when the file format is invalid.</exception>
    Dictionary<string, string> ExtractMetadata(string filePath);

    /// <summary>
    /// Extracts text content from a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>The extracted text content.</returns>
    /// <exception cref="TextExtractionException">Thrown when text extraction fails.</exception>
    string ExtractText(string filePath);
}
```

## Best Practices

1. **Interface Segregation Principle (ISP)**
   - Keep interfaces small and focused on a single responsibility
   - Split large interfaces into smaller, more cohesive ones
   - Clients should only need to implement methods they actually use
   - Each interface should represent one clear capability or behavior
   - Consider creating role interfaces that define specific functionality
   - Avoid "fat" interfaces that try to do too many things
   - Look for natural groupings of methods when splitting interfaces
   - Make interfaces easy to implement by keeping them minimal

```csharp
// Bad example - too many responsibilities
public interface IUserManager
{
    void CreateUser(User user);
    void DeleteUser(int userId);
    void SendEmail(string to, string subject, string body);
    void GenerateReport();
    void ProcessPayment(decimal amount);
}

// Good example - segregated interfaces
public interface IUserManager
{
    void CreateUser(User user);
    void DeleteUser(int userId);
}

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public interface IReportGenerator
{
    void GenerateReport();
}

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
```

2. **Dependency Inversion Principle (DIP)**
   - High-level modules should not depend on low-level modules
   - Both should depend on abstractions
   - Abstractions should not depend on details
   - Details should depend on abstractions
   - Use interfaces or abstract classes to define contracts
   - Inject dependencies rather than creating them internally
   - This enables loose coupling and easier testing
   - Makes code more flexible and maintainable
   - Facilitates mocking for unit tests
   - Allows swapping implementations without changing client code

```csharp
/// <summary>
/// Service for sending notifications through multiple channels.
/// Demonstrates proper dependency injection and interface usage.
/// </summary>
public class NotificationService
{
    private readonly IEmailSender _emailSender;
    private readonly ISMSSender _smsSender;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the NotificationService.
    /// </summary>
    /// <param name="emailSender">The email sending service.</param>
    /// <param name="smsSender">The SMS sending service.</param>
    /// <param name="logger">The logging service.</param>
    public NotificationService(
        IEmailSender emailSender,
        ISMSSender smsSender,
        ILogger logger)
    {
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        _smsSender = smsSender ?? throw new ArgumentNullException(nameof(smsSender));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Sends a notification to a user through multiple channels.
    /// </summary>
    /// <param name="userId">The ID of the user to notify.</param>
    /// <param name="message">The message to send.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown when userId or message is null or empty.</exception>
    public async Task SendNotification(string userId, string message)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        
        if (string.IsNullOrEmpty(message))
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));

        try
        {
            await _emailSender.SendEmailAsync(userId, "Notification", message);
            await _smsSender.SendSMSAsync(userId, message);
            _logger.LogInfo($"Notification sent to user: {userId}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to send notification to user: {userId}", ex);
            throw new NotificationFailedException($"Failed to send notification to user: {userId}", ex);
        }
    }
}
```

## Advanced Interface Concepts

### 1. Default Interface Methods (C# 8.0+) - A Modern C# Feature

Default interface methods were introduced in C# 8.0 to enable interface evolution - the ability to add new members to interfaces without breaking existing implementations. This feature helps maintain backward compatibility while adding new functionality.

Key points:
- Allows adding method implementations directly in interfaces
- Implementations are optional for implementing classes
- Useful for providing default behavior that can be overridden
- Helps evolve interfaces without breaking existing code
```csharp
/// <summary>
/// Defines the contract for customer-related operations with a default validation method.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Retrieves a customer by their ID.
    /// </summary>
    /// <param name="id">The customer ID.</param>
    /// <returns>The customer object if found; otherwise, null.</returns>
    Customer GetCustomer(int id);

    /// <summary>
    /// Updates customer information.
    /// </summary>
    /// <param name="customer">The customer object with updated information.</param>
    void UpdateCustomer(Customer customer);
    
    /// <summary>
    /// Validates customer information.
    /// This is a default implementation that can be overridden if needed.
    /// </summary>
    /// <param name="customer">The customer to validate.</param>
    /// <returns>True if the customer is valid; otherwise, false.</returns>
    bool ValidateCustomer(Customer customer)
    {
        if (customer == null) return false;
        if (string.IsNullOrEmpty(customer.Name)) return false;
        if (customer.Age < 18) return false;
        if (string.IsNullOrEmpty(customer.Email)) return false;
        if (!IsValidEmail(customer.Email)) return false;
        return true;
    }

    /// <summary>
    /// Validates an email address format.
    /// </summary>
    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
```

# Interface Best Practices in C#

## Key Guidelines

1. **XML Documentation**
   - Document all interfaces and members with XML comments
   - Include parameter descriptions and return value details
   - Document exceptions that may be thrown
   - Example:
   ```csharp
   /// <summary>
   /// Provides customer management functionality.
   /// </summary>
   public interface ICustomerService { }
   ```

2. **Interface Segregation Principle (ISP)**
   - Keep interfaces small and focused
   - Split large interfaces into smaller ones
   - Clients should only depend on methods they use
   - Example: Split `ICustomerService` into `ICustomerReader` and `ICustomerWriter`

3. **Dependency Injection**
   - Design for dependency injection
   - Program to interfaces, not implementations
   - Use constructor injection for required dependencies
   - Example:
   ```csharp
   public class CustomerService
   {
       private readonly ICustomerRepository _repository;
       public CustomerService(ICustomerRepository repository) 
       {
           _repository = repository;
       }
   }
   ```

4. **Interface Design**
   - Use clear, descriptive names (e.g., IDisposable, IComparable)
   - Keep interfaces cohesive - one primary responsibility
   - Consider default interface methods for optional behavior
   - Follow .NET naming conventions (prefix with 'I')

5. **Best Practices**
   - Favor composition over inheritance
   - Use interfaces for loose coupling
   - Consider interface inheritance carefully
   - Test interface implementations thoroughly
   - Document interface contracts clearly

## Benefits

- Improved maintainability
- Better testability through mocking
- Flexible dependency injection
- Clear separation of concerns
- Easier code modifications
- Better code organization

Following these guidelines helps create robust, maintainable applications that are easier to test and modify over time.

