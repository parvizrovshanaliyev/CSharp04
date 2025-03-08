# Static Class Tasks

## Task 1: Create a Utility Class
### Objective:
Create a static class named `MathUtilities` that provides utility methods for basic mathematical operations. This class will help perform common calculations without requiring an instance of the class.

### Requirements:
- `Square(int number)`: Returns the square of a number.
- `Cube(int number)`: Returns the cube of a number.
- `Factorial(int number)`: Returns the factorial of a given number.

### How to Implement:
1. Create a **static class** named `MathUtilities`.
2. Implement static methods for `Square`, `Cube`, and `Factorial`.
3. Use recursion or iteration for computing factorial.

### Example Usage:
```csharp
Console.WriteLine(MathUtilities.Square(4)); // Output: 16
Console.WriteLine(MathUtilities.Cube(3)); // Output: 27
Console.WriteLine(MathUtilities.Factorial(5)); // Output: 120
```

---

## Task 2: Implement a Logging System
### Objective:
Create a static class named `Logger` that provides a simple logging system for applications.

### Requirements:
- `Log(string message)`: Prints log messages with timestamps.
- `Error(string message)`: Logs error messages.
- `EnableLogging`: A boolean flag to control whether logging is active.

### How to Implement:
1. Define a **static class** `Logger`.
2. Implement static methods `Log` and `Error` that prepend timestamps.
3. Add a `bool` flag `EnableLogging` to toggle logging on/off.

```

### Example Usage:
```csharp
Logger.EnableLogging = true;
Logger.Log("Application started"); // Output: [2025-03-08 10:00:00] Application started
Logger.Error("Null reference exception occurred"); // Output: [2025-03-08 10:01:00] ERROR: Null reference exception occurred
```

---

## Task 3: Create a Configuration Manager
### Objective:
Develop a static class `ConfigManager` to store and reload application settings.

### Requirements:
- `ApplicationName`: Readonly property storing the app name.
- `Version`: Readonly property storing the app version.
- `Reload()`: Simulates reloading configuration settings.

### How to Implement:
1. Define `ConfigManager` as a static class.
2. Store static `readonly` fields for app configuration.
3. Implement a `Reload` method to simulate reloading settings.

### Example Usage:
```csharp
Console.WriteLine(ConfigManager.ApplicationName); // Output: MyApp
ConfigManager.Reload(); // Output: Configuration reloaded successfully.
```

---

## Task 4: Create a Helper for String Operations
### Objective:
Implement a static class `StringHelper` with methods to enhance string handling.

### Requirements:
- `IsPalindrome(string input)`: Checks if a string is a palindrome.
- `ToTitleCase(string input)`: Converts a sentence to title case.

### How to Implement:
1. Create a static class `StringHelper`.
2. Implement `IsPalindrome` by reversing the string and checking equality.
3. Implement `ToTitleCase` using string manipulation.

### Example Usage:
```csharp
Console.WriteLine("racecar".IsPalindrome()); // Output: True
Console.WriteLine("hello world".ToTitleCase()); // Output: Hello World
```
---

## Task 5: Implement a Date and Time Utility
### Objective:
Create a static class `DateTimeHelper` with date-related functions.

### Requirements:
- `GetCurrentDate()`: Returns today’s date in `yyyy-MM-dd` format.
- `DaysBetween(DateTime start, DateTime end)`: Returns the number of days between two dates.

### Example Usage:
```csharp
Console.WriteLine(DateTimeHelper.GetCurrentDate()); // Output: 2025-03-08
Console.WriteLine(DateTimeHelper.DaysBetween(DateTime.Now, new DateTime(2025, 12, 31))); // Output: X days
```

---


