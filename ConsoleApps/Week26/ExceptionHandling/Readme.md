# Exception Handling in C# - Zero to Hero

## Introduction
Exception handling is an essential skill for writing robust and error-resistant C# applications. When an unexpected issue occurs at runtime, 
    exception handling allows us to catch, diagnose, and handle these errors gracefully, preventing the program from crashing.

This guide is designed for **students and beginners** who are just starting with **console applications in C#**. By the end of this guide,
you will be able to handle exceptions efficiently and write more reliable programs.

## Table of Contents
1. [What is an Exception?](#what-is-an-exception)
2. [Try-Catch Block](#try-catch-block)
3. [Multiple Catch Blocks](#multiple-catch-blocks)
4. [Finally Block](#finally-block)
5. [Throwing Exceptions](#throwing-exceptions)
6. [Custom Exceptions](#custom-exceptions)
7. [Inner Exceptions](#inner-exceptions)
8. [Exception Filters](#exception-filters)
9. [Checked and Unchecked Blocks](#checked-and-unchecked-blocks)
10. [Best Practices for Beginners](#best-practices-for-beginners)

---

## What is an Exception?
An **exception** is an error that occurs at runtime and disrupts the normal execution of a program. Common examples include:
- **Dividing by zero** → `DivideByZeroException`
- **Accessing an invalid index in an array** → `IndexOutOfRangeException`
- **Trying to open a missing file** → `FileNotFoundException`
- **Working with a null object** → `NullReferenceException`

C# provides a structured way to handle exceptions using **try**, **catch**, **finally**, and **throw** statements.

## Try-Catch Block
The `try-catch` block is the simplest way to handle exceptions. Any code that might cause an error should be placed inside a `try` block. If an error occurs, execution jumps to the corresponding `catch` block.

```csharp
using System;

class Program
{
    static void Main()
    {
        try
        {
            int x = 10;
            int y = 0;
            int result = x / y; // Causes a DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
```

## Multiple Catch Blocks
You can have multiple `catch` blocks to handle different types of exceptions separately.

```csharp
try
{
    string[] names = { "Alice", "Bob" };
    Console.WriteLine(names[5]); // IndexOutOfRangeException
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Array index is out of range!");
}
catch (Exception ex)
{
    Console.WriteLine($"General error: {ex.Message}");
}
```

## Finally Block
The `finally` block is used to execute code **regardless of whether an exception occurs or not**. It is typically used for resource cleanup (e.g., closing files or database connections).

```csharp
try
{
    Console.WriteLine("Attempting risky operation...");
}
catch (Exception ex)
{
    Console.WriteLine($"Caught an exception: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleaning up resources...");
}
```

## Throwing Exceptions
You can create and throw your own exceptions using the `throw` keyword.

```csharp
void CheckAge(int age)
{
    if (age < 18)
        throw new ArgumentException("Age must be 18 or older.");
}

try
{
    CheckAge(16);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation failed: {ex.Message}");
}
```

## Custom Exceptions
Creating custom exceptions helps define application-specific error handling.

```csharp
public class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
}

try
{
    throw new CustomException("Something unexpected happened!");
}
catch (CustomException ex)
{
    Console.WriteLine($"Custom Exception: {ex.Message}");
}
```

## Inner Exceptions
Inner exceptions help track the root cause of an exception.

```csharp
try
{
    try
    {
        int[] numbers = new int[2];
        Console.WriteLine(numbers[5]);
    }
    catch (Exception ex)
    {
        throw new Exception("An error occurred in the outer block.", ex);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Outer Exception: {ex.Message}");
    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
}
```

## Exception Filters (C# 6.0+)
Exception filters allow you to catch exceptions based on specific conditions.

```csharp
try
{
    throw new Exception("Network Error");
}
catch (Exception ex) when (ex.Message.Contains("Network"))
{
    Console.WriteLine("Handling network-related exceptions.");
}
```

## Checked and Unchecked Blocks
C# provides `checked` and `unchecked` keywords to control arithmetic overflow behavior. By default, arithmetic operations do not check for overflow unless explicitly specified.

### Checked Block
The `checked` block forces C# to check for overflow in arithmetic operations and throw an `OverflowException`.

```csharp
checked
{
    int maxValue = int.MaxValue;
    int result = maxValue + 1; // This will throw an OverflowException
}
```

### Unchecked Block
The `unchecked` block allows arithmetic operations to overflow silently without throwing an exception.

```csharp
unchecked
{
    int maxValue = int.MaxValue;
    int result = maxValue + 1; // No exception, wraps around to negative value
    Console.WriteLine(result);
}
```

### When to Use?
- Use `checked` when working with **critical financial or scientific calculations** where overflow must be detected.
- Use `unchecked` in performance-sensitive scenarios where overflow is acceptable or expected.

## Best Practices for Beginners
- Always use `try-catch` for operations that might fail.
- Be specific when catching exceptions (`catch (IndexOutOfRangeException ex)` instead of `catch (Exception ex)`).
- Avoid empty `catch` blocks (always log or display error messages).
- Use `finally` to release resources like file handles and database connections.
- Never throw exceptions in `catch` blocks without context.
- Use `Environment.Exit(1);` when you need to exit the application due to an unhandled error.

---

## Conclusion
Exception handling is a powerful tool in C# that allows you to write more stable and predictable applications.
By mastering these techniques, even as a beginner, you can prevent runtime crashes and improve your coding skills.


---

## Advanced Interview Questions
If you're preparing for an interview, here are some advanced exception handling questions you might encounter, along with their answers.

### 1. What is the difference between `throw` and `throw ex`?
#### Answer:
- `throw;` rethrows the original exception while preserving the original stack trace.
- `throw ex;` creates a new exception instance, resetting the stack trace, which makes debugging harder.

Example:
```csharp
try
{
    throw new Exception("Original Exception");
}
catch (Exception ex)
{
    throw; // Preserves stack trace
    // throw ex; // Resets stack trace (Not recommended)
}
```

### 2. Can we have multiple `finally` blocks?
#### Answer:
No, a single `try` block can have only one `finally` block. However, nested `try-finally` structures are allowed.

```csharp
try
{
    try
    {
        Console.WriteLine("Inner try block");
    }
    finally
    {
        Console.WriteLine("Inner finally block");
    }
}
finally
{
    Console.WriteLine("Outer finally block");
}
```

### 3. What is the purpose of `Environment.FailFast()`?
#### Answer:
`Environment.FailFast()` terminates the process immediately without running `finally` blocks or exception handlers. It's used in critical failures where the application state is corrupted.

```csharp
Environment.FailFast("Critical error occurred!");
```

### 4. How does `Task.Exception` work in asynchronous programming?
#### Answer:
When using `async` and `await`, unhandled exceptions in tasks are stored in the `Exception` property of the `Task` object. They must be accessed explicitly.

```csharp
Task.Run(() => { throw new Exception("Async error"); }).Wait();
```

### 5. How can we catch all unhandled exceptions globally in a C# console application?
#### Answer:
Use `AppDomain.CurrentDomain.UnhandledException` to catch all unhandled exceptions in the application.

```csharp
AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
{
    Console.WriteLine($"Unhandled Exception: {((Exception)args.ExceptionObject).Message}");
};
```

### 6. What is the difference between checked and unchecked exceptions in C#?
#### Answer:
- **Checked exceptions** (using `checked`) force arithmetic overflow detection.
- **Unchecked exceptions** (using `unchecked`) allow overflow without throwing an exception.

Example:
```csharp
checked
{
    int max = int.MaxValue;
    int overflow = max + 1; // Throws OverflowException
}

unchecked
{
    int max = int.MaxValue;
    int overflow = max + 1; // No exception, wraps around to negative
}
```

### 7. What are exception filters, and how are they different from multiple catch blocks?
#### Answer:
Exception filters (`when`) allow conditions to be checked before entering the catch block, making exception handling more precise.

Example:
```csharp
try
{
    throw new Exception("Network Error");
}
catch (Exception ex) when (ex.Message.Contains("Network"))
{
    Console.WriteLine("Handling network exception");
}
```

Unlike multiple `catch` blocks, filters allow conditions before executing exception-handling logic.

### 8. How can we log exceptions effectively in a C# application?
#### Answer:
Use logging frameworks like **Serilog, NLog, or Log4Net** to record exceptions in files, databases, or cloud services.

Example using Serilog:
```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs.txt")
    .CreateLogger();

try
{
    throw new Exception("Test Exception");
}
catch (Exception ex)
{
    Log.Error(ex, "An error occurred");
}
```

---

