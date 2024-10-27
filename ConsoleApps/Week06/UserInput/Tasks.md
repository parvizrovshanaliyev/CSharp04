#### 1. **Understanding Type Casting**

Create a C# console application to demonstrate both **implicit** and **explicit** casting, along with type conversion using the `Convert` class.

##### **Instructions:**
- Declare variables of different types such as `int`, `double`, `float`, `char`, etc.
- Perform **implicit casting** where smaller types are automatically cast to larger types (e.g., `int` to `double`).
- Perform **explicit casting** where larger types are manually cast to smaller types (e.g., `double` to `int`). Show how data loss occurs (e.g., losing decimal precision when casting `double` to `int`).
- Demonstrate the use of **Convert methods** to safely convert values between types (e.g., `Convert.ToInt32()`, `Convert.ToDouble()`).
- Print the results of each casting operation to the console.

##### **Example:**
```csharp
int age = 25; // Declare an integer variable 'age' and assign it the value 25
double salary = 50000.75; // Declare a double variable 'salary' and assign it the value 50000.75

// Implicit casting (int to double)
double newAge = age; // Implicitly cast the integer 'age' to a double and assign it to 'newAge'
Console.WriteLine($"Implicit Casting - Age as double: {newAge}"); // Print the value of 'newAge' to the console

// Explicit casting (double to int)
int roundedSalary = (int)salary; // Explicitly cast the double 'salary' to an integer and assign it to 'roundedSalary'
Console.WriteLine($"Explicit Casting - Rounded Salary: {roundedSalary}"); // Print the value of 'roundedSalary' to the console

// Conversion using Convert
int ageFromString = Convert.ToInt32("25"); // Convert the string "25" to an integer using the Convert.ToInt32 method and assign it to 'ageFromString'
Console.WriteLine($"Convert from string to int: {ageFromString}"); // Print the value of 'ageFromString' to the console
```

---

#### 2. **User Input and Type Conversion**

Build a C# console application that takes **user input** for two numbers and performs basic arithmetic operations on them. Convert the user input from string to appropriate data types for performing the calculations.

##### **Instructions:**
- Prompt the user to input two numbers using `Console.ReadLine()`.
- Convert the input strings to **int** or **double** using `Convert.ToInt32()` or `Convert.ToDouble()`.
- Perform basic operations like **addition**, **subtraction**, **multiplication**, and **division** on the two numbers.
- Display the results of each operation to the user.

##### **Example:**
```csharp
// Prompt the user to enter the first number
Console.WriteLine("Enter the first number: ");
// Read the user input and store it in a string variable
string firstInput = Console.ReadLine();
// Convert the input string to a double
double number1 = Convert.ToDouble(firstInput);

// Prompt the user to enter the second number
Console.WriteLine("Enter the second number: ");
// Read the user input and store it in a string variable
string secondInput = Console.ReadLine();
// Convert the input string to a double
double number2 = Convert.ToDouble(secondInput);

// Perform addition and store the result
double sum = number1 + number2;
// Perform subtraction and store the result
double difference = number1 - number2;
// Perform multiplication and store the result
double product = number1 * number2;
// Perform division and store the result
double quotient = number1 / number2;

// Print the sum to the console
Console.WriteLine($"Sum: {sum}");
// Print the difference to the console
Console.WriteLine($"Difference: {difference}");
// Print the product to the console
Console.WriteLine($"Product: {product}");
// Print the quotient to the console
Console.WriteLine($"Quotient: {quotient}");
```

---

#### 3. **Challenge Task (Optional)**

Write a C# program that asks the user to input their **age** and **monthly salary**, then performs the following:

- Implicitly cast the `age` to a `double`.
- Convert the `salary` to an `int`.
- Calculate the user's annual salary.
- Display the user's **age**, **monthly salary**, and **annual salary**.

##### **Example:**
```csharp
// Sample Input: 
// Age: 28
// Monthly Salary: 3000.75

// Output:
// Your age as a double is: 28.0
// Your monthly salary as an integer is: 3000
// Your annual salary is: 36000
```