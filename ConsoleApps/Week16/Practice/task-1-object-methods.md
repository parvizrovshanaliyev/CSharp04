### **Task 1: Exploring Object Methods**

**File**: [task-1-object-methods.md](https://github.com/parvizrovshanaliyev/CSharp04/blob/main/ConsoleApps/Week16/Practice/task-1-object-methods.md)

---

# **Task 1: Exploring Object Methods**

### **Objective**
This task focuses on understanding and utilizing the key methods inherited from the **`object`** base class.
These methods are fundamental to the C# type system and provide essential functionality such as type identification, 
object comparison, and string representation. By completing this task, you will:
- Learn how **`GetType()`**, **`ToString()`**, **`Equals(object obj)`**, and **`GetHashCode()`** work.
- Implement custom logic to override these methods for real-world use cases.

---

### **Key Concepts**

1. **`GetType()`**:
   - Determines the runtime type of an object.
   - Commonly used in reflection and debugging.

2. **`ToString()`**:
   - Converts an object into a human-readable string representation.
   - Can be overridden in custom classes to display meaningful information.

3. **`Equals(object obj)`**:
   - Compares two objects for logical equality.
   - Default behavior:
     - For reference types, it compares object references (i.e., memory addresses).
     - For value types, it compares the actual data.

4. **`GetHashCode()`**:
   - Generates a hash code for an object.
   - Hash codes are used in hash-based collections like dictionaries and hash sets.
   - When overriding `Equals()`, you should also override `GetHashCode()` for consistency.

---

### **Instructions**

1. **Create a `Person` Class**:
   - Define a class named `Person` with the following properties:
     - `Name` (string)
     - `Age` (int)

2. **Override the `ToString()` Method**:
   - Implement a custom string representation for the `Person` class:
     ```csharp
     public override string ToString()
     {
         return $"Name: {Name}, Age: {Age}";
     }
     ```

3. **Test in the `Main()` Method**:
   - Create two `Person` objects with identical `Name` and `Age` values.
   - Perform the following operations:
     - Print the runtime type of the objects using `GetType()`.
     - Compare the two objects using the default implementation of `Equals()` and display the result.
     - Print the hash codes of both objects using `GetHashCode()`.

4. **Enhance Equality Comparison (Optional)**:
   - Override the `Equals()` method to compare the `Name` and `Age` properties for logical equality.
   - Override the `GetHashCode()` method to ensure it aligns with the custom equality logic.

---

### **Enhanced Example Code**

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Override ToString for a meaningful string representation
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    // Override Equals to compare logical equality based on Name and Age
    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return this.Name == other.Name && this.Age == other.Age;
        }
        return false;
    }

    // Override GetHashCode to maintain consistency with Equals
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}

class Program
{
    static void Main()
    {
        // Create two identical Person objects
        Person person1 = new Person { Name = "Alice", Age = 25 };
        Person person2 = new Person { Name = "Alice", Age = 25 };

        // GetType
        Console.WriteLine($"Type of person1: {person1.GetType()}");
        Console.WriteLine($"Type of person2: {person2.GetType()}");

        // Equals
        Console.WriteLine($"Are person1 and person2 equal? {person1.Equals(person2)}");

        // ToString
        Console.WriteLine($"String representation of person1: {person1}");

        // GetHashCode
        Console.WriteLine($"HashCode of person1: {person1.GetHashCode()}");
        Console.WriteLine($"HashCode of person2: {person2.GetHashCode()}");
    }
}
```

---

### **Expected Output**

```plaintext
Type of person1: Person
Type of person2: Person
Are person1 and person2 equal? True
String representation of person1: Name: Alice, Age: 25
HashCode of person1: 12345678
HashCode of person2: 12345678
```

---

### **Hints**
- **Equality Consistency**: Always override `GetHashCode()` when you override `Equals()` to ensure the objects behave correctly in hash-based collections like dictionaries.
- **Debugging**: Use `ToString()` to provide a clear, human-readable representation of your objects for easier debugging.
- **Use `HashCode.Combine`**: When implementing `GetHashCode()`, prefer `HashCode.Combine()` for generating consistent hash codes based on multiple properties.

---

### **Additional Notes**
1. **Default Behavior**:
   - Without overriding, `Equals()` for reference types compares object references, so two objects with identical properties will return `False` unless explicitly overridden.
   - The default `ToString()` method returns the fully qualified class name (e.g., `Namespace.Person`).

2. **Real-World Applications**:
   - These methods are frequently used in debugging, logging, and when working with collections like dictionaries or LINQ queries.

---
