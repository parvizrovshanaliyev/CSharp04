## **Task 1: Creating and Calling a Simple Method**

### **Description**  
Write a program with a method that prints a greeting message to the console.

### **Explanation**  
Methods allow you to group code into reusable blocks. Define a method with `void` to indicate it doesn’t return any value, and call it from the `Main` method.

### **Sample Input and Output**  
No input required.  
**Output**:  
```
Hello, welcome to C# programming!
```

---

## **Task 2: Method with Parameters**

### **Description**  
Write a program with a method that takes a name as a parameter and prints a personalized greeting.

### **Explanation**  
Methods can accept input values (parameters). Pass a string parameter to the method and use it in the greeting.

### **Sample Input and Output**  
**Input**:  
```
Enter your name: Alice
```

**Output**:  
```
Hello, Alice! Welcome to C# programming.
```

---

## **Task 3: Method with Return Value**

### **Description**  
Write a program with a method that calculates the square of a number and returns the result.

### **Explanation**  
Use the `return` keyword to send a value back to the calling method.

### **Sample Input and Output**  
**Input**:  
```
Enter a number: 4
```

**Output**:  
```
The square of 4 is 16.
```

---

## **Task 4: Method Overloading**

### **Description**  
Write a program with two methods named `Add`. One method should take two integers, and the other should take three integers.

### **Explanation**  
Method overloading allows you to define multiple methods with the same name but different parameter lists.

### **Sample Input and Output**  
**Input**:  
```
Enter two numbers: 3, 5
Enter three numbers: 2, 4, 6
```

**Output**:  
```
Sum of two numbers: 8
Sum of three numbers: 12
```

---

## **Task 5: Passing Parameters by Value**

### **Description**  
Write a program to demonstrate passing parameters by value. Create a method that modifies a number, but the change doesn’t affect the original value.

### **Explanation**  
When you pass parameters by value, a copy of the variable is sent to the method, leaving the original value unchanged.

### **Sample Input and Output**  
**Input**:  
```
Enter a number: 10
```

**Output**:  
```
Original value: 10
Modified value inside method: 20
Value after method call: 10
```

---

## **Task 6: Passing Parameters by Reference**

### **Description**  
Write a program to demonstrate passing parameters by reference. Create a method that doubles a number, and the change affects the original variable.

### **Explanation**  
Use the `ref` keyword to pass the reference of the variable to the method.

### **Sample Input and Output**  
**Input**:  
```
Enter a number: 5
```

**Output**:  
```
Value before method call: 5
Value inside method: 10
Value after method call: 10
```

---

## **Task 7: Using `out` Parameters**

### **Description**  
Write a program with a method that calculates the quotient and remainder of two numbers using `out` parameters.

### **Explanation**  
The `out` keyword allows a method to return multiple values through its parameters.

### **Sample Input and Output**  
**Input**:  
```
Enter dividend: 10
Enter divisor: 3
```

**Output**:  
```
Quotient: 3
Remainder: 1
```

---

## **Task 8: Method with Optional Parameters**

### **Description**  
Write a program with a method that calculates the area of a rectangle. If only one parameter is provided, treat it as a square.

### **Explanation**  
Optional parameters allow you to call a method with fewer arguments. Assign default values to parameters.

### **Sample Input and Output**  
**Input**:  
```
Enter length: 5
Enter width (or press Enter to skip): (skipped)
```

**Output**:  
```
Area: 25
```

---

## **Task 9: Recursion in Methods**

### **Description**  
Write a program to calculate the factorial of a number using recursion.

### **Explanation**  
Recursion occurs when a method calls itself. It’s useful for problems that can be divided into smaller sub-problems.

### **Sample Input and Output**  
**Input**:  
```
Enter a number: 5
```

**Output**:  
```
Factorial of 5 is 120
```

---

## **Task 10: Using Method to Work with Arrays**

### **Description**  
Write a program with a method that takes an array of integers and returns the largest element.

### **Explanation**  
Pass an array as a parameter to the method and iterate through it to find the maximum value.

### **Sample Input and Output**  
**Input**:  
```
Enter array elements (comma-separated): 3, 7, 1, 9, 5
```

**Output**:  
```
Largest element: 9
```

---

## **Task 11: Real-World Scenario - Simple Calculator**

### **Description**  
Write a program with methods to perform basic calculator operations: addition, subtraction, multiplication, and division.

### **Explanation**  
Create separate methods for each operation. Call these methods based on user input.

### **Sample Input and Output**  
**Input**:  
```
Enter first number: 8
Enter second number: 4
Choose operation (+, -, *, /): /
```

**Output**:  
```
Result: 2
```

---
