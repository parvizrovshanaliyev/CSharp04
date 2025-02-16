# OOP Partial Class in C#

## Overview
A partial class in C# allows you to split the definition of a class, struct, or interface across multiple source files. Each file contains a section of the type definition, and all parts are combined when the application is compiled.

## Basic Syntax
```csharp
// File1.cs
partial class MyClass
{
    public void Method1() { }
}

// File2.cs
partial class MyClass
{
    public void Method2() { }
}
```

## Key Features and Benefits
- Split large classes into smaller files for better organization
- Multiple developers can work on different parts of the class simultaneously
- Separate generated code from hand-written code
- Keep related functionality together
- Improve code maintainability and readability

## Rules and Guidelines
1. All partial class definitions must use the `partial` keyword
2. All parts must have the same accessibility (public, private, etc.)
3. If any part is declared abstract, the whole type is abstract
4. If any part is declared sealed, the whole type is sealed
5. If any part declares a base type, it must be the first part to declare it
6. All parts must be compiled together

## Practical Example: Authentication Service
This project demonstrates a real-world implementation of partial classes using an authentication service:

```csharp
// AuthService.cs - Main authentication methods
public partial class AuthService : IAuthService
{
    public void Login() { /* ... */ }
    public void Register() { /* ... */ }
    public void Logout() { /* ... */ }
    public void VerifyEmail() { /* ... */ }
    public void VerifyPhone() { /* ... */ }
    // ... other core authentication methods
    
    partial void PartialMethodExample(); // Declaration
}

// AuthServiceFacebook.cs - Facebook-specific authentication
public partial class AuthService
{
    public void LoginWithFacebook() { /* ... */ }
    
    partial void PartialMethodExample() // Implementation
    {
        Console.WriteLine("Partial Method");
    }
}

// AuthServiceGoogle.cs - Google-specific authentication
public partial class AuthService
{
    public void LoginWithGoogle() { /* ... */ }
}
```

### Benefits of This Approach
- Core authentication logic remains in the main file
- Social media authentication implementations are separated
- Easier maintenance with focused, smaller files
- New authentication methods can be added without modifying the core file

## Partial Methods
Partial methods provide a way to optionally implement methods in partial classes:

### Characteristics
- Must be declared with the `partial` keyword
- Must return `void`
- Can be declared in one part and implemented in another
- If not implemented, the compiler removes both the declaration and all calls to the method
- Are private by default and cannot include access modifiers
- Cannot be virtual or extern

### Example Usage
As shown in our AuthService example, partial methods can be:
- Declared in one file: `partial void PartialMethodExample();`
- Implemented in another: `partial void PartialMethodExample() { /* implementation */ }`

## Common Use Cases
1. **Code Generation**
   - Separating generated code from custom code
   - Windows Forms designer-generated code

2. **Large Classes**
   - Breaking down complex classes into manageable pieces
   - Example: Separating business logic from data access

3. **Team Development**
   - Multiple developers working on different parts
   - Clear separation of concerns

4. **Logical Organization**
   - Grouping related methods and properties
   - Example: Separating employee personal and work information:

```csharp
// Employee.Personal.cs
partial class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}

// Employee.Work.cs
partial class Employee
{
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}
```

## Best Practices
1. **File Naming**
   - Use meaningful file names that indicate the purpose
   - Follow a consistent naming convention
   - Example: `AuthService.cs`, `AuthService.Facebook.cs`, `AuthService.Google.cs`

2. **Code Organization**
   - Keep related functionality together
   - Use regions for better code organization
   - Document relationships between partial class files

3. **Design Considerations**
   - Avoid creating too many partial class files
   - Maintain clear separation of concerns
   - Consider using interfaces for better structure

## Limitations
- Partial classes must be in the same assembly
- All partial class definitions must use the same type parameters
- Cannot span multiple namespaces
- Cannot implement different interfaces in different parts

## See Also
- [Microsoft Docs - Partial Classes and Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods)
- [Partial Methods Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods#partial-methods)