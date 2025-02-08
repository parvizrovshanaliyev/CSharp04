# **Tasks for Mastering Polymorphism in C#**

## Task 1: Understanding Polymorphism
- **Objective:** Understand the concept of polymorphism in C#.
- **Description:** Read about polymorphism and its types (static and dynamic).
- **Resources:** [Polymorphism in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism)

## Task 2: Implementing Method Overloading
- **Objective:** Implement method overloading to achieve static polymorphism.
- **Instructions:**
  - Create a class named `PaymentProcessor`.
  - Implement multiple `ProcessPayment` methods with different parameter lists:
    - One method should accept a credit card number and amount.
    - Another method should accept bank account details and amount.
    - Another method should accept cash amount.
  - Test the `ProcessPayment` methods by calling them with different arguments in a `Main` method.

## Task 3: Implementing Method Overriding
- **Objective:** Implement method overriding to achieve dynamic polymorphism.
- **Instructions:**
  - Create a base class named `Employee` with a virtual method `CalculateSalary` that returns a double.
  - Create derived classes `FullTimeEmployee` and `PartTimeEmployee` that override the `CalculateSalary` method:
    - `FullTimeEmployee` should have a fixed monthly salary.
    - `PartTimeEmployee` should have an hourly rate and hours worked.
  - Test the overridden methods by creating instances of `FullTimeEmployee` and `PartTimeEmployee` and calling `CalculateSalary` in a `Main` method.

## Task 4: Using Polymorphism with Arrays
- **Objective:** Use polymorphism with arrays.
- **Instructions:**
  - Create an array of type `Employee` with a size of 5.
  - Add instances of `FullTimeEmployee` and `PartTimeEmployee` to the array.
  - Iterate through the array and call the `CalculateSalary` method on each item.
  - Print the calculated salaries to the console.

## Task 5: Real-World Application
- **Objective:** Apply polymorphism in a real-world scenario.
- **Instructions:**
  - Design a simple inventory management system.
  - Create a base class `Product` with properties like `Name` and `Price`.
  - Create derived classes `Electronics`, `Clothing`, and `Food` that inherit from `Product`:
    - `Electronics` should have an additional property `WarrantyPeriod`.
    - `Clothing` should have an additional property `Size`.
    - `Food` should have an additional property `ExpirationDate`.
  - Implement a method in each derived class to display product details.
  - Test the system by creating instances of `Electronics`, `Clothing`, and `Food` and displaying their details in a `Main` method.

