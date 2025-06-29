# Phone Book Management System

A console-based phone book management system built in C# using non-generic `SortedList` collection, following OOP, SOLID, and DRY principles.

## Features

- ✅ Add new contacts with validation
- ✅ Update existing contact information
- ✅ Search contacts by name (using binary search via SortedList)
- ✅ View all contacts sorted alphabetically
- ✅ Delete contacts with confirmation
- ✅ Persistent storage using text file
- ✅ Input validation for phone numbers and email addresses
- ✅ Error handling and user-friendly messages
- ✅ **Enum-based menu system for type safety**
- ✅ **Centralized constants for maintainability**

## 🚀 Step-by-Step Development Guide

### **Phase 1: Project Setup and Basic Structure**

#### **Step 1: Create Project Structure**
```bash
# Create the main project directory
mkdir PhoneBookManagementSystem
cd PhoneBookManagementSystem

# Create subdirectories for organization
mkdir Models
mkdir Interfaces
mkdir Services
mkdir Enums
mkdir Constants
```

#### **Step 2: Create Basic Contact Model**
**File: `Models/Contact.cs`**
```csharp
// Start with a simple Contact class
public class Contact
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
```

#### **Step 3: Create Simple Program.cs**
**File: `Program.cs`**
```csharp
// Start with basic console application
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Phone Book Management System");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
```

### **Phase 2: Core Data Structure**

#### **Step 4: Implement SortedList Storage**
**File: `Services/PhoneBookRepository.cs`**
```csharp
using System.Collections;

public class PhoneBookRepository
{
    private readonly SortedList _contacts = new SortedList();
    
    public void AddContact(Contact contact)
    {
        _contacts.Add(contact.Name, contact);
    }
    
    public Contact? SearchContact(string name)
    {
        return _contacts.ContainsKey(name) ? (Contact)_contacts[name]! : null;
    }
}
```

#### **Step 5: Create Basic Menu System**
**File: `Program.cs`** (Updated)
```csharp
class Program
{
    static void Main(string[] args)
    {
        var repository = new PhoneBookRepository();
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("=== Phone Book Management System ===");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. Search contact");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine() ?? "";
            
            switch (choice)
            {
                case "1":
                    // Add contact logic
                    break;
                case "2":
                    // Search contact logic
                    break;
                case "3":
                    exit = true;
                    break;
            }
        }
    }
}
```

### **Phase 3: User Interface Layer**

#### **Step 6: Create User Interface Interface**
**File: `Interfaces/IUserInterface.cs`**
```csharp
public interface IUserInterface
{
    void DisplayMenu();
    int GetUserChoice();
    Contact GetContactInput();
    string GetContactName();
    void DisplayContact(Contact contact);
    void DisplayMessage(string message);
    void DisplayError(string error);
}
```

#### **Step 7: Implement Console User Interface**
**File: `Services/ConsoleUserInterface.cs`**
```csharp
public class ConsoleUserInterface : IUserInterface
{
    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Phone Book Management System ===");
        Console.WriteLine("1. Add new contact");
        Console.WriteLine("2. Search contact");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice: ");
    }
    
    public int GetUserChoice()
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
            return choice;
        return 0;
    }
    
    public Contact GetContactInput()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine() ?? "";
        
        Console.Write("Enter phone: ");
        string phone = Console.ReadLine() ?? "";
        
        return new Contact { Name = name, PhoneNumber = phone };
    }
}
```

### **Phase 4: Validation System**

#### **Step 8: Create Validation Interface**
**File: `Interfaces/IValidator.cs`**
```csharp
public interface IValidator
{
    bool IsValidName(string name);
    bool IsValidPhoneNumber(string phoneNumber);
    string? GetValidationError(string name, string phoneNumber);
}
```

#### **Step 9: Implement Basic Validation**
**File: `Services/ContactValidator.cs`**
```csharp
public class ContactValidator : IValidator
{
    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 2;
    }
    
    public bool IsValidPhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrWhiteSpace(phoneNumber);
    }
    
    public string? GetValidationError(string name, string phoneNumber)
    {
        if (!IsValidName(name))
            return "Name must be at least 2 characters long.";
        
        if (!IsValidPhoneNumber(phoneNumber))
            return "Phone number cannot be empty.";
        
        return null;
    }
}
```

### **Phase 5: Constants and Enums**

#### **Step 10: Create Constants**
**File: `Constants/ApplicationConstants.cs`**
```csharp
public static class ApplicationConstants
{
    public const string ApplicationTitle = "=== Phone Book Management System ===";
    public const string ContactAddedSuccess = "Contact added successfully.";
    public const string ContactNotFoundError = "Contact '{0}' not found.";
    public const int MinNameLength = 2;
    public const int MaxNameLength = 50;
}
```

#### **Step 11: Create Enums**
**File: `Enums/MenuOption.cs`**
```csharp
public enum MenuOption
{
    AddContact = 1,
    SearchContact = 2,
    Exit = 3
}
```

### **Phase 6: Enhanced Features**

#### **Step 12: Add File Persistence**
**File: `Services/PhoneBookRepository.cs`** (Updated)
```csharp
public void SaveToFile(string filePath)
{
    using var writer = new StreamWriter(filePath);
    foreach (DictionaryEntry entry in _contacts)
    {
        var contact = (Contact)entry.Value!;
        writer.WriteLine($"{contact.Name}|{contact.PhoneNumber}|{contact.Email}|{contact.Address}");
    }
}

public void LoadFromFile(string filePath)
{
    if (!File.Exists(filePath)) return;
    
    _contacts.Clear();
    string[] lines = File.ReadAllLines(filePath);
    
    for (int i = 0; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split('|');
        if (parts.Length >= 2)
        {
            var contact = new Contact
            {
                Name = parts[0],
                PhoneNumber = parts[1],
                Email = parts.Length > 2 ? parts[2] : "",
                Address = parts.Length > 3 ? parts[3] : ""
            };
            _contacts.Add(contact.Name, contact);
        }
    }
}
```

#### **Step 13: Add More Menu Options**
**File: `Enums/MenuOption.cs`** (Updated)
```csharp
public enum MenuOption
{
    AddContact = 1,
    UpdateContact = 2,
    SearchContact = 3,
    ViewAllContacts = 4,
    DeleteContact = 5,
    SaveAndExit = 6
}
```

### **Phase 7: Advanced Features**

#### **Step 14: Add Email and Address Validation**
**File: `Services/ContactValidator.cs`** (Updated)
```csharp
using System.Text.RegularExpressions;

public class ContactValidator : IValidator
{
    private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    
    public bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && _emailRegex.IsMatch(email);
    }
    
    // ... existing methods
}
```

#### **Step 15: Add Confirmation Dialogs**
**File: `Services/ConsoleUserInterface.cs`** (Updated)
```csharp
public bool ConfirmAction(string message)
{
    Console.Write($"{message} (y/n): ");
    string? response = Console.ReadLine()?.ToLower();
    return response == "y" || response == "yes";
}
```

### **Phase 8: Service Layer and Dependency Injection**

#### **Step 16: Create Service Layer**
**File: `Services/PhoneBookService.cs`**
```csharp
public class PhoneBookService
{
    private readonly IPhoneBookRepository _repository;
    private readonly IUserInterface _userInterface;
    private readonly IValidator _validator;
    
    public PhoneBookService(IPhoneBookRepository repository, 
                          IUserInterface userInterface, 
                          IValidator validator)
    {
        _repository = repository;
        _userInterface = userInterface;
        _validator = validator;
    }
    
    public void Run()
    {
        // Main application loop
    }
}
```

#### **Step 17: Implement Dependency Injection**
**File: `Program.cs`** (Final Version)
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Dependency Injection setup
        IValidator validator = new ContactValidator();
        IPhoneBookRepository repository = new PhoneBookRepository(validator);
        IUserInterface userInterface = new ConsoleUserInterface(validator);
        
        var phoneBookService = new PhoneBookService(repository, userInterface, validator);
        phoneBookService.Initialize();
        phoneBookService.Run();
    }
}
```

### **Phase 9: Testing and Refinement**

#### **Step 18: Add Comprehensive Error Handling**
- Add try-catch blocks around file operations
- Add input validation for all user inputs
- Add graceful error messages

#### **Step 19: Add XML Documentation**
- Add XML comments to all public methods
- Add detailed remarks for complex operations
- Document exceptions and parameters

#### **Step 20: Final Testing**
- Test all menu options
- Test file persistence
- Test validation rules
- Test error scenarios

## 📚 Learning Progression

### **Beginner Level (Steps 1-5)**
- Basic C# syntax
- Console input/output
- Simple classes and properties
- Basic control structures

### **Intermediate Level (Steps 6-10)**
- Interfaces and abstraction
- Basic validation
- Constants and enums
- File I/O operations

### **Advanced Level (Steps 11-15)**
- Regular expressions
- Advanced validation
- Error handling
- User experience improvements

### **Expert Level (Steps 16-20)**
- Dependency injection
- Service layer architecture
- Comprehensive documentation
- Professional coding standards

## 🎯 Key Learning Objectives

### **Programming Fundamentals**
- ✅ Variables and data types
- ✅ Control structures (if, switch, loops)
- ✅ Methods and parameters
- ✅ Classes and objects
- ✅ Arrays and collections

### **Object-Oriented Programming**
- ✅ Encapsulation
- ✅ Inheritance
- ✅ Polymorphism
- ✅ Abstraction

### **Software Design Principles**
- ✅ SOLID principles
- ✅ DRY principle
- ✅ Separation of concerns
- ✅ Dependency injection

### **Advanced C# Features**
- ✅ Interfaces
- ✅ Enums
- ✅ Constants
- ✅ Exception handling
- ✅ File I/O
- ✅ Regular expressions

## 🔧 Development Tips

### **Start Small**
- Begin with basic functionality
- Add features incrementally
- Test each step before moving forward

### **Use Version Control**
- Commit after each major step
- Use descriptive commit messages
- Keep a development log

### **Test Thoroughly**
- Test with valid inputs
- Test with invalid inputs
- Test edge cases
- Test error scenarios

### **Document as You Go**
- Add comments for complex logic
- Document design decisions
- Keep a learning journal

## Project Structure

```
PhoneBookManagementSystem/
├── Models/
│   └── Contact.cs                 # Contact entity model
├── Interfaces/
│   ├── IPhoneBookRepository.cs    # Repository interface
│   ├── IUserInterface.cs          # UI interface
│   └── IValidator.cs              # Validation interface
├── Services/
│   ├── PhoneBookRepository.cs     # Data access layer using SortedList
│   ├── ConsoleUserInterface.cs    # Console UI implementation
│   ├── ContactValidator.cs        # Input validation logic
│   └── PhoneBookService.cs        # Business logic layer
├── Enums/
│   ├── MenuOption.cs              # Menu options enumeration
│   └── ValidationResult.cs        # Validation result enumeration
├── Constants/
│   ├── ApplicationConstants.cs    # Application-wide constants
│   └── RegexPatterns.cs           # Regex pattern constants
├── Program.cs                     # Application entry point
└── README.md                      # This file
```

## OOP Principles Applied

### 1. Encapsulation
- Contact properties are encapsulated with getters and setters
- Private fields in services with controlled access through methods
- Data validation logic is encapsulated within the validator service

### 2. Inheritance
- All services implement their respective interfaces
- Contact class inherits from Object (implicit) and overrides ToString()

### 3. Polymorphism
- Interface-based programming allows for different implementations
- Services can be easily swapped with different implementations

## SOLID Principles Applied

### 1. Single Responsibility Principle (SRP)
- `ContactValidator`: Only handles validation logic
- `PhoneBookRepository`: Only handles data operations
- `ConsoleUserInterface`: Only handles user interaction
- `PhoneBookService`: Only handles business logic coordination

### 2. Open/Closed Principle (OCP)
- New validation rules can be added without modifying existing code
- New UI implementations can be created by implementing `IUserInterface`
- New storage mechanisms can be added by implementing `IPhoneBookRepository`

### 3. Liskov Substitution Principle (LSP)
- All implementations can be substituted for their interfaces
- Any service implementing an interface can be used interchangeably

### 4. Interface Segregation Principle (ISP)
- Interfaces are small and focused on specific responsibilities
- `IValidator` only contains validation methods
- `IUserInterface` only contains UI interaction methods

### 5. Dependency Inversion Principle (DIP)
- High-level modules depend on abstractions (interfaces)
- Low-level modules implement these abstractions
- Dependencies are injected through constructors

## DRY Principle Applied

- **Validation logic is centralized** in `ContactValidator`
- **Common UI patterns are reused** through interface methods
- **File operations are centralized** in the repository
- **Error handling patterns are consistent** across services
- **All string constants are centralized** in `ApplicationConstants`
- **Regex patterns are reusable** in `RegexPatterns`
- **Menu options are type-safe** using `MenuOption` enum

## Key Technical Features

### Non-Generic SortedList Usage
The application uses `System.Collections.SortedList` (non-generic) as specified in the requirements:
- Automatically maintains alphabetical sorting by contact names
- Provides efficient binary search for lookups
- Keys are strings (contact names), values are Contact objects

### Enum-Based Menu System
```csharp
public enum MenuOption
{
    AddContact = 1,
    UpdateContact = 2,
    SearchContact = 3,
    ViewAllContacts = 4,
    DeleteContact = 5,
    SaveAndExit = 6
}
```

### Centralized Constants
All application constants are centralized for easy maintenance:
- **UI Messages**: All user-facing text
- **Validation Rules**: Length limits and patterns
- **File Operations**: Separators and file names
- **Error Messages**: Consistent error handling

### Validation System
Enhanced validation with enum-based results:
```csharp
public enum ValidationResult
{
    Valid,
    InvalidName,
    InvalidPhoneNumber,
    InvalidEmail,
    InvalidAddress,
    EmptyInput
}
```

### File Storage Format
Contacts are stored in `phonebook.txt` using pipe-separated values:
```
Name|PhoneNumber|Email|Address|LastModified
```

### Input Validation
- **Name**: 2-50 characters, non-empty
- **Phone Number**: Valid international format with optional separators
- **Email**: Standard email format validation
- **Address**: Non-empty, max 200 characters

## How to Run

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Use the menu system:**
   - Choose options 1-6 to perform different operations
   - Follow the prompts to enter contact information
   - Data is automatically saved when you choose option 6

## Sample Usage

```
=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 1

Enter contact name: John Smith
Enter phone number: +1-555-0123
Enter email: john.smith@email.com
Enter address: 123 Main St
Contact added successfully.
```

## Error Handling

The application includes comprehensive error handling:
- Invalid input validation with user-friendly messages
- File I/O error handling
- Duplicate contact prevention
- Graceful handling of missing contacts

## Performance Considerations

- **SortedList**: Provides O(log n) lookup time using binary search
- **Automatic Sorting**: Contacts are always maintained in alphabetical order
- **Memory Efficient**: Only loads contacts into memory when needed
- **File I/O**: Optimized with using statements for proper resource disposal

## Extensibility

The architecture makes it easy to add new features:
- **New validation rules** in `ContactValidator`
- **Different UI implementations** (GUI, Web, etc.)
- **Alternative storage mechanisms** (database, cloud, etc.)
- **Additional contact properties** or search methods
- **New menu options** by extending `MenuOption` enum
- **Additional constants** in `ApplicationConstants`

## Benefits of Using Enums and Constants

### Enums Benefits:
- **Type Safety**: Prevents invalid menu selections
- **Maintainability**: Easy to add/remove menu options
- **Readability**: Self-documenting code
- **IntelliSense Support**: Better IDE experience

### Constants Benefits:
- **DRY Principle**: No string duplication
- **Maintainability**: Change messages in one place
- **Consistency**: Uniform error messages and UI text
- **Localization Ready**: Easy to implement multiple languages

## Testing Recommendations

To test the application thoroughly:
1. Add multiple contacts with different names
2. Test duplicate name prevention
3. Verify alphabetical sorting
4. Test search functionality
5. Test update and delete operations
6. Verify file persistence by restarting the application
7. Test input validation with invalid data
8. Test enum-based menu system with edge cases 