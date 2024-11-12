### Module 4: Functions and Methods in C#

#### **Objective**: 
By the end of this module, you should have a solid understanding of how to define, call, and use functions (also known as methods) in C#. You’ll learn how to work with parameters, return values, `void` methods, and method overloading. Through practical examples and an exercise, you’ll practice writing functions that calculate areas of different shapes.

---

### **Topics Covered:**

1. **Defining and Calling Functions**
2. **Parameters: Passing by Value and by Reference**
3. **Return Types and `void` Methods**
4. **Method Overloading**

---

### 1. **Defining and Calling Functions**

Functions (or methods) are blocks of code that perform a specific task. You can reuse them multiple times, making your code cleaner, more modular, and easier to debug. In C#, functions are defined within a class.

**Basic Syntax**:
```csharp
// Syntax for defining a function
returnType FunctionName(parameterType parameterName)
{
    // code to execute
    return value; // required only if returnType is not void
}
```

**Example**:
```csharp
public class Program
{
    public static void Main()
    {
        // Calling the function
        int result = AddNumbers(5, 3);
        Console.WriteLine("Sum: " + result);
    }

    // Function that returns the sum of two integers
    public static int AddNumbers(int a, int b)
    {
        return a + b;
    }
}
```

**Explanation**:
- **Return Type**: Specifies the data type of the value returned by the function. In this example, `int` is the return type.
- **Function Name**: `AddNumbers` is the name of the function.
- **Parameters**: `int a` and `int b` are parameters, which are input values passed to the function.

---

### 2. **Parameters: Passing by Value and by Reference**

When calling a function, you can pass parameters in two ways: by **value** (default) or by **reference**. 

#### Passing by Value
When passing by value, the function receives a copy of the parameter, meaning any changes to this parameter do not affect the original variable.

**Example**:
```csharp
public static void ModifyValue(int num)
{
    num += 10;
    Console.WriteLine("Inside ModifyValue: " + num); // Output: 15
}

public static void Main()
{
    int myNumber = 5;
    ModifyValue(myNumber);
    Console.WriteLine("Outside ModifyValue: " + myNumber); // Output: 5
}
```

#### Passing by Reference
Using `ref` or `out` allows the function to modify the actual variable.

**Example with `ref`**:
```csharp
public static void ModifyValue(ref int num)
{
    num += 10;
    Console.WriteLine("Inside ModifyValue: " + num); // Output: 15
}

public static void Main()
{
    int myNumber = 5;
    ModifyValue(ref myNumber);
    Console.WriteLine("Outside ModifyValue: " + myNumber); // Output: 15
}
```

---

### 3. **Return Types and `void` Methods**

In C#, functions can return a value or be `void`. A `void` function doesn’t return anything and is often used to perform actions like displaying information.

**Example of `void` Function**:
```csharp
public static void DisplayMessage()
{
    Console.WriteLine("Hello from a void function!");
}

public static void Main()
{
    DisplayMessage();
}
```

---

### 4. **Method Overloading**

Method overloading allows you to create multiple methods with the same name but different parameter lists. C# determines which method to call based on the number and types of arguments passed.

**Example of Overloading**:
```csharp
public static int Multiply(int a, int b)
{
    return a * b;
}

public static double Multiply(double a, double b)
{
    return a * b;
}

public static void Main()
{
    Console.WriteLine(Multiply(5, 10));    // Calls int version
    Console.WriteLine(Multiply(3.5, 2.0)); // Calls double version
}
```

**Explanation**: 
Both functions are named `Multiply` but accept different types of parameters. C# selects the appropriate function based on the arguments provided.

---

### **Exercise: Calculating Areas of Different Shapes**

Now that you understand how to define and call methods, let’s put this knowledge into practice by creating methods that calculate the area of different shapes (circle, rectangle, and triangle).

#### **Requirements**:
1. Create a program with methods to calculate the area of:
   - A **circle** (given its radius).
   - A **rectangle** (given its length and width).
   - A **triangle** (given its base and height).
2. Use method overloading to create a single `CalculateArea` method with different parameters for each shape.
3. Prompt the user to select a shape and enter the necessary dimensions.

---

#### **Solution Example**

```csharp
using System;

public class ShapeCalculator
{
    public static void Main()
    {
        Console.WriteLine("Choose a shape to calculate the area:");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Rectangle");
        Console.WriteLine("3. Triangle");
        
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Please enter a valid choice (1, 2, or 3):");
        }

        switch (choice)
        {
            case 1:
                CalculateCircleArea();
                break;
            case 2:
                CalculateRectangleArea();
                break;
            case 3:
                CalculateTriangleArea();
                break;
        }
    }

    // Method to calculate the area of a circle
    public static void CalculateCircleArea()
    {
        Console.Write("Enter radius of the circle: ");
        double radius;
        while (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for radius:");
        }
        double area = Math.PI * radius * radius;
        Console.WriteLine($"Area of the circle: {area}");
    }

    // Method to calculate the area of a rectangle
    public static void CalculateRectangleArea()
    {
        Console.Write("Enter length of the rectangle: ");
        double length;
        while (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for length:");
        }

        Console.Write("Enter width of the rectangle: ");
        double width;
        while (!double.TryParse(Console.ReadLine(), out width) || width <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for width:");
        }

        double area = length * width;
        Console.WriteLine($"Area of the rectangle: {area}");
    }

    // Method to calculate the area of a triangle
    public static void CalculateTriangleArea()
    {
        Console.Write("Enter base of the triangle: ");
        double baseLength;
        while (!double.TryParse(Console.ReadLine(), out baseLength) || baseLength <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for base:");
        }

        Console.Write("Enter height of the triangle: ");
        double height;
        while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for height:");
        }

        double area = 0.5 * baseLength * height;
        Console.WriteLine($"Area of the triangle: {area}");
    }
}
```

### **Explanation of Solution**

1. **User Input**: 
   - The program begins by prompting the user to choose a shape.
   - Input validation ensures that the user provides a valid choice.

2. **Function Definitions**:
   - Each shape has its own `CalculateArea` method.
   - We use input validation to make sure dimensions are positive numbers.
   
3. **Method Calls**:
   - Based on the user’s choice, the program calls the corresponding method to calculate the area.
   - The program uses method overloading by defining `CalculateArea` methods for each shape with different parameter lists.

---

### **Additional Notes**

- **Return Values**: You could modify these methods to return the calculated area instead of directly printing it, giving the calling code more flexibility.
- **Method Overloading and Parameters**: Using overloads of `CalculateArea` would allow you to simplify the `Main` method if you wanted to reuse the same function name for each shape’s area calculation.

### **Estimated Time**: 4 Hours

Completing this module and exercise will give you a solid understanding of defining, calling, and using methods in C#, along with practical experience in handling user input and performing basic mathematical operations.