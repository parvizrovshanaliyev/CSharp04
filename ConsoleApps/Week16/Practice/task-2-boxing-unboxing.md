# **Task 2: Understanding Boxing and Unboxing**

**File**: [task-2-boxing-unboxing.md](https://github.com/parvizrovshanaliyev/CSharp04/blob/main/ConsoleApps/Week16/Practice/task-2-boxing-unboxing.md)

---

### **Objective**
This task demonstrates the concepts of **boxing** and **unboxing** in C#. By completing it, you will learn:
1. How value types can be converted into reference types (`object`) through **boxing**.
2. How boxed values can be extracted back into their original value types through **unboxing**.
3. The implications of type conversion in C# and how to verify the runtime type of an object.

---

### **Key Concepts**

1. **Boxing**:
   - Boxing is the process of converting a value type (e.g., `int`, `bool`) into a reference type (specifically `object`).
   - The value is allocated on the heap and wrapped in an `object`.

   **Example**:
   ```csharp
   int number = 42;         // Value type on the stack
   object boxedNumber = number; // Boxing: value is moved to the heap
   ```

2. **Unboxing**:
   - Unboxing reverses boxing by extracting the value type from an `object`.
   - It requires **explicit casting** and a runtime type check.

   **Example**:
   ```csharp
   object boxedNumber = 42;       // Boxing
   int unboxedNumber = (int)boxedNumber; // Unboxing with explicit cast
   ```

3. **Type Verification**:
   - Use the `GetType()` method to confirm the runtime type of a boxed object.
   - This helps prevent runtime errors during unboxing.

---

### **Instructions**

1. **Set Up an Array**:
   - Create an `object[]` array with a size of 5.

2. **Store Values**:
   - Store the following values in the array:
     - `int`
     - `double`
     - `char`
     - `bool`
     - `string` (no boxing needed since it's already a reference type).

   Boxing will occur automatically for the value types.

3. **Retrieve Values**:
   - Access each element of the array and unbox the values back into their original types using explicit casting.

4. **Print Details**:
   - Print each value and its runtime type using the `GetType()` method.

---

### **Enhanced Example Code**
```csharp
using System;

class BoxingUnboxingDemo
{
    static void Main()
    {
        // Step 1: Create an object array
        object[] data = new object[5];

        // Step 2: Boxing - Store value types into the array
        data[0] = 42;          // int
        data[1] = 3.14;        // double
        data[2] = 'A';         // char
        data[3] = true;        // bool
        data[4] = "Hello";     // string (no boxing)

        // Step 3: Unboxing - Retrieve and display values
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"data[{i}]: {data[i]} (Type: {data[i].GetType()})");
        }

        // Step 4: Explicitly unbox values into their original types
        int number = (int)data[0];
        double pi = (double)data[1];
        char letter = (char)data[2];
        bool flag = (bool)data[3];
        string text = (string)data[4];

        Console.WriteLine($"Unboxed values: {number}, {pi}, {letter}, {flag}, {text}");
    }
}
```

---

### **Expected Output**
```plaintext
data[0]: 42 (Type: System.Int32)
data[1]: 3.14 (Type: System.Double)
data[2]: A (Type: System.Char)
data[3]: True (Type: System.Boolean)
data[4]: Hello (Type: System.String)
Unboxed values: 42, 3.14, A, True, Hello
```

---

### **Hints**
1. **Use Explicit Casting**:
   - Always cast explicitly when unboxing (e.g., `(int)data[0]`).
   - Without explicit casting, the compiler will throw an error.

2. **Handle Runtime Exceptions**:
   - Unboxing requires the type to match exactly. If you attempt to unbox to the wrong type, a `System.InvalidCastException` will occur.

   **Example**:
   ```csharp
   object boxedNumber = 42;    // Boxing
   double wrongType = (double)boxedNumber; // InvalidCastException
   ```

3. **Type Confirmation**:
   - Use `GetType()` or the `is` keyword to verify the type before unboxing.

   **Example**:
   ```csharp
   if (data[0] is int)
   {
       int number = (int)data[0];
       Console.WriteLine($"Unboxed int: {number}");
   }
   ```

---

### **Real-World Applications**

1. **Data Storage**:
   - Boxing allows value types to be stored in generic data structures like `object[]` or non-generic collections (e.g., `ArrayList` in legacy systems).

2. **Interoperability**:
   - Frameworks or APIs often use `object` parameters to handle values of different types dynamically.

3. **Dynamic Programming**:
   - In scenarios like scripting engines or data processing, boxing and unboxing allow value types to be treated as objects.

---

### **Learning Goals**
By completing this task, you will:
1. Understand how boxing and unboxing work in C#.
2. Recognize the impact of boxing on memory and performance.
3. Learn to handle runtime type conversions safely and efficiently.

---

