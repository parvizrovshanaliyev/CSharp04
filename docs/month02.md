
## **Month 2**

<details>
<summary><strong>Month 2 all topics</strong></summary>

### Week 6 - Day 1 (13.10.2024)
- Type Casting in C#
- User Input in C#

### Week 7 - Day 1 (19.10.2024)
- Demystifying Type Conversion in C#: A Comprehensive Guide
- C# Operators
- C# Math

### Week 8 - Day 1 (26.10.2024)
- C# Strings

### Week 8 - Day 2 (27.10.2024)
- Difference Between String and StringBuilder in C#
- C# If ... Else
- C# Switch

### Week 9 - Day 1 (03.11.2024)
- Code Practice (String Manipulation)

### Week 10 - Day 1 (09.11.2024)
- C# While Loop
- C# Do/While Loop
- C# For Loop
- C# Break and Continue

### Week 11 - Day 1 (11.11.2024)
- Practice
- ATM Program

### Week 12 - Day 1 (17.11.2024)
- C# Arrays
- C# Methods
- Git

</details>

---

### **Interview Questions with Answers for Month 2 Topics**

---

#### **Type Casting**

1. **What is type casting in C#?**  
   **Answer**:  
   Type casting converts a variable from one data type to another. It can be implicit (automatically done by the compiler) or explicit (requires manual casting).

2. **Explain the difference between implicit and explicit type casting.**  
   **Answer**:
    - **Implicit Casting**: Automatically performed by C# when converting a smaller data type to a larger type (e.g., `int` to `float`). No data loss occurs.
    - **Explicit Casting**: Requires a cast operator (e.g., `(int)`) and is used when converting a larger data type to a smaller type, which may result in data loss.

3. **What are the potential risks of explicit type casting?**  
   **Answer**:
    - Data loss: Converting a `float` to an `int` truncates the decimal part.
    - Runtime exceptions: Casting incompatible types can throw exceptions.

4. **Provide an example of implicit type casting.**  
   **Answer**:
   ```csharp
   int num = 10;
   double result = num; // Implicit casting from int to double
   ```

5. **Provide an example of explicit type casting.**  
   **Answer**:
   ```csharp
   double num = 10.5;
   int result = (int)num; // Explicit casting from double to int
   ```

6. **What is the `Convert` class used for in C#?**  
   **Answer**:  
   The `Convert` class provides methods to convert data between types. For example:
   ```csharp
   string str = "123";
   int num = Convert.ToInt32(str); // Converts string to int
   ```

---

#### **User Input**

7. **How do you take input from a user in C#?**  
   **Answer**:  
   Use the `Console.ReadLine()` method to take user input as a string.  
   Example:
   ```csharp
   Console.Write("Enter your name: ");
   string name = Console.ReadLine();
   Console.WriteLine($"Hello, {name}!");
   ```

8. **What is the `Console.ReadLine()` method used for, and how do you handle invalid input?**  
   **Answer**:  
   The `Console.ReadLine()` method reads input as a string. To handle invalid input:
   ```csharp
   Console.Write("Enter a number: ");
   string input = Console.ReadLine();
   if (int.TryParse(input, out int number))
   {
       Console.WriteLine($"You entered: {number}");
   }
   else
   {
       Console.WriteLine("Invalid input. Please enter a number.");
   }
   ```

---

#### **Type Conversion**

9. **What is type conversion in C#, and how does it differ from type casting?**  
   **Answer**:
    - **Type Conversion**: Uses methods like `Convert.ToInt32()` or `Parse()` to convert types. It is safer and more versatile.
    - **Type Casting**: Directly changes the type using operators like `(int)` and is limited to compatible types.

10. **Explain the difference between `Parse()` and `TryParse()` methods.**  
    **Answer**:
    - **`Parse()`**: Converts a string to a type but throws an exception if the conversion fails.
    - **`TryParse()`**: Safely attempts conversion and returns `true` or `false` without throwing an exception.

11. **When should you use `Convert.ToString()` over `.ToString()`?**  
    **Answer**:  
    Use `Convert.ToString()` when the input could be null, as it handles null values gracefully and returns an empty string, whereas `.ToString()` throws a `NullReferenceException`.

---

#### **Operators**

12. **What are the different types of operators in C#?**  
    **Answer**:
    - Arithmetic: `+`, `-`, `*`, `/`, `%`
    - Logical: `&&`, `||`, `!`
    - Relational: `==`, `!=`, `>`, `<`, `>=`, `<=`
    - Bitwise: `&`, `|`, `^`, `~`
    - Assignment: `=`, `+=`, `-=`, `*=`

13. **Explain the difference between logical AND (`&&`) and bitwise AND (`&`).**  
    **Answer**:
    - **`&&` (Logical AND)**: Evaluates the second condition only if the first condition is true.
    - **`&` (Bitwise AND)**: Operates at the binary level, comparing corresponding bits.

14. **What is operator precedence in C#, and how does it affect expressions?**  
    **Answer**:  
    Operator precedence determines the order in which operators are evaluated. For example:
    ```csharp
    int result = 10 + 2 * 5; // Multiplication is evaluated before addition
    ```

---

#### **Math**

15. **How can you perform mathematical calculations in C#?**  
    **Answer**:  
    Use arithmetic operators (`+`, `-`, `*`, `/`, `%`) or the `Math` class for advanced operations.

16. **What is the `Math` class, and what are some common methods it provides?**  
    **Answer**:  
    The `Math` class provides methods for mathematical calculations:
    - `Math.Abs(x)`: Absolute value
    - `Math.Pow(x, y)`: Power
    - `Math.Sqrt(x)`: Square root
    - `Math.Round(x)`: Rounds a number

---

#### **Strings**

17. **What is the difference between `string` and `StringBuilder` in C#?**  
    **Answer**:
    - `string`: Immutable; modifying it creates a new instance.
    - `StringBuilder`: Mutable; allows efficient string modifications.

18. **How do you concatenate strings in C#?**  
    **Answer**:
    - Using `+`: `"Hello" + " World"`
    - Using `String.Concat()`: `String.Concat("Hello", " World")`

19. **What are immutable objects, and why is the `string` class immutable?**  
    **Answer**:  
    Immutable objects cannot be changed after creation. The `string` class is immutable for efficiency and thread safety.

20. **How do you compare strings in C#?**  
    **Answer**:  
    Use:
    - `Equals()`: `string1.Equals(string2)`
    - `Compare()`: `string.Compare(string1, string2)`

---

#### **Conditions**

21. **What is the difference between `if-else` and `switch` statements in C#?**  
    **Answer**:
    - `if-else`: Used for complex, variable conditions.
    - `switch`: Simplifies fixed, multiple conditions.

22. **How does the `switch` statement handle multiple cases with the same logic?**  
    **Answer**:  
    Group cases together:
    ```csharp
    switch (value)
    {
        case 1:
        case 2:
            Console.WriteLine("Case 1 or 2");
            break;
    }
    ```

23. **Can you use ranges in `switch` cases in C#?**  
    **Answer**:  
    Yes, in C# 9.0 and later using pattern matching:
    ```csharp
    switch (value)
    {
        case >= 1 and <= 10:
            Console.WriteLine("Value is between 1 and 10");
            break;
    }
    ```

---

#### **Loops**

24. **What is the difference between `while` and `do/while` loops in C#?**  
    **Answer**:
    - `while`: Checks the condition before executing.
    - `do/while`: Executes the body at least once, then checks the condition.

25. **How do you exit a loop prematurely in C#?**  
    **Answer**:  
    Use the `break` statement to terminate the loop.

26. **What is the purpose of the `continue` statement in a loop?**  
    **Answer**:  
    Skips the current iteration and moves to the next.

---

#### **Arrays**

27. **What are arrays in C#, and how are they initialized?**  
    **Answer**:  
    Arrays store multiple values of the same type.  
    Example:
    ```csharp
    int[] numbers = { 1, 2, 3 };
    ```

28. **Explain the difference between single-dimensional and multi-dimensional arrays.**  
    **Answer**:
    - **Single-dimensional**: Stores elements in a single row or column.
    - **Multi-dimensional**: Stores elements in a matrix format. Example: `int[,] matrix = new int[2, 3];`

29. **How do you iterate through an array using `foreach` in C#?**  
    **Answer**:
    ```csharp
    int[] numbers = { 1, 2, 3 };
    foreach (int num in numbers)
    {
        Console.WriteLine(num);
    }
    ```

---

#### **Methods**

30. **What is the difference between `void` and `return` methods in C#?**  
    **Answer**:
    - `void`: Performs an action without returning a value.
    - `return`: Returns a value to the caller.

31. **How do you pass parameters to a method in C#?**  
    **Answer**:  
    Parameters are passed by value by default:
    ```csharp
    void PrintMessage(string message) { Console.WriteLine(message); }
    ```

32. **What are optional parameters in C#, and how are they defined?**  
    **Answer**:  
    Parameters with default values:
    ```csharp
    void PrintMessage(string message = "Default Message") { Console.WriteLine(message); }
    ```

---

#### **Git**

33. **What is Git, and why is it used in software development?**  
    **Answer**:  
    Git is a version control system that tracks changes and enables collaboration.

34. **What is the difference between `git commit` and `git push`?**  
    **Answer**:
    - `git commit`: Saves changes locally.
    - `git push`: Uploads changes to a remote repository.

35. **How do you resolve merge conflicts in Git?**  
    **Answer**:
    - Edit conflicting files.
    - Mark resolved sections.
    - Commit the resolved changes.

36. **What is the purpose of branching in Git?**  
    **Answer**:  
    Allows developers to work on features independently without affecting the main codebase.

