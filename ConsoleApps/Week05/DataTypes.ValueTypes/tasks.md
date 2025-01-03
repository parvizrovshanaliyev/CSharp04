### Homework

1. **Task 1**: Write a C# program that prints the following output:  
   `Hello, World!`
    - **Hint**: Use the `Console.WriteLine` method to display text in the console.
    - **Example**:
      ```csharp
      Console.WriteLine("Hello, World!");
      ```

2. **Task 2**: Write a C# program that uses both single-line and multi-line comments.
    - **Instructions**:
        - Write a program that prints any text.
        - Add a single-line comment above the `Console.WriteLine` statement.
        - Add a multi-line comment explaining what the program does.
    - **Example**:
      ```csharp
      // This is a single-line comment
      
      /*
      This program prints a greeting message
      to the console.
      */
      Console.WriteLine("Welcome to C# Programming!");
      ```

3. **Task 3**: Declare variables for the following value types and print their values:
    - `int` (integer)
    - `double` (decimal number)
    - `char` (character)
    - `bool` (true/false)
    - **Instructions**:
        - Declare each variable with an appropriate value.
        - Use `Console.WriteLine` to print the value of each variable.
    - **Example**:
      ```csharp
      int myInt = 25;
      double myDouble = 4.99;
      char myChar = 'A';
      bool myBool = true;
 
      Console.WriteLine("Integer: " + myInt);
      Console.WriteLine("Double: " + myDouble);
      Console.WriteLine("Character: " + myChar);
      Console.WriteLine("Boolean: " + myBool);
      ```

4. **Task 4**: Write a C# program that adds two numbers and prints the result.
    - **Instructions**:
        - Declare two integer variables, assign values to them.
        - Calculate their sum and store it in another variable.
        - Print the sum.
    - **Example**:
      ```csharp
      int num1 = 10;
      int num2 = 20;
      int sum = num1 + num2;
 
      Console.WriteLine("The sum is: " + sum);
      ```

5. **Task 5**: Write a C# program that explains the difference between an integer (`int`) and a floating-point number (`double`).
    - **Instructions**:
        - Declare one variable of type `int` and another of type `double`.
        - Assign appropriate values (e.g., `int myInt = 5; double myDouble = 5.99;`).
        - Print their values and explain their difference in a comment.
    - **Example**:
      ```csharp
      int myInt = 5;
      double myDouble = 5.99;
 
      // Integers store whole numbers, while doubles store decimal numbers
      Console.WriteLine("Integer: " + myInt);
      Console.WriteLine("Double: " + myDouble);
      ```

6. **Task 6**: Experiment with modifying variables.
    - **Instructions**:
        - Declare a variable and assign it a value.
        - Change the value of the variable later in the code.
        - Print the variable's value before and after the change.
    - **Example**:
      ```csharp
      int myNumber = 10;
      Console.WriteLine("Original value: " + myNumber);
 
      myNumber = 20;
      Console.WriteLine("Modified value: " + myNumber);
      ```

7. **Task 7**: Create a program that calculates the area of a rectangle.
    - **Instructions**:
        - Declare two variables for `length` and `width` of the rectangle.
        - Calculate the area (`length * width`).
        - Print the area to the console.
    - **Example**:
      ```csharp
      int length = 5;
      int width = 10;
      int area = length * width;
 
      Console.WriteLine("The area of the rectangle is: " + area);
      ```

8. **Task 8**: Write a C# program that swaps the values of two variables.
    - **Instructions**:
        - Declare two integer variables and assign them values.
        - Swap their values without using a third variable.
        - Print the values before and after swapping.
    - **Hint**: Use arithmetic operations (addition and subtraction).
    - **Example**:
      ```csharp
      int a = 10;
      int b = 20;
 
      Console.WriteLine("Before swap: a = " + a + ", b = " + b);
 
      a = a + b;  // Now a is 30
      b = a - b;  // Now b is 10 (original a)
      a = a - b;  // Now a is 20 (original b)
 
      Console.WriteLine("After swap: a = " + a + ", b = " + b);
      ```

9. **Task 9**: Create a C# program that concatenates two strings.
    - **Instructions**:
        - Declare two string variables and assign values to them.
        - Concatenate the strings using the `+` operator.
        - Print the result.
    - **Example**:
      ```csharp
      string firstName = "John";
      string lastName = "Doe";
      string fullName = firstName + " " + lastName;
 
      Console.WriteLine("Full Name: " + fullName);
      ```    


### Questions

1. Explain difference between .NET and C#?
2. What is IL (Intermediate Language) Code?
3. What is CLR (Common Language Runtime)?
4. What is JIT?