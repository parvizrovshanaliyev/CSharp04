# Learning Exception Handling in C# - Tasks & Instructions

## Introduction
Exception handling is a crucial part of writing robust and error-resistant C# applications. This document provides **5 structured tasks** designed to help 
understand **exception handling logic** using both **logical implementation** and **try-catch implementation**.

Each task has **two approaches**:
1. **Logical Implementation:** Handling the error without using `try-catch`.
2. **Try Catch Implementation:** Handling the error using `try-catch` to catch exceptions gracefully.

---

## **Task 1: Division by Zero**
### **Instructions:**
- Create a program that asks the user for two numbers and performs division.
- Implement both **Logical Implementation** and **Try Catch Implementation**.

### **Logical Implementation:**
- Before performing division, check if the divisor is `0`.
- If it is, display an error message instead of dividing.

### **Try Catch Implementation:**
- Use a `try-catch` block to catch `DivideByZeroException`.
- Display an error message if the exception occurs.

### **Expected Behavior:**
- **Without try-catch:** The program prevents division by zero before execution.
- **With try-catch:** The program catches the exception and prevents crashing.

### **Sample Output:**
```
Enter numerator: 10
Enter denominator: 0
Error: Division by zero is not allowed.
```

---

## **Task 2: Invalid Input Handling**
### **Instructions:**
- Write a program that asks the user to enter an integer.
- Implement both **Logical Implementation** and **Try Catch Implementation**.

### **Logical Implementation:**
- Use `int.TryParse()` to check if the input is a valid number.
- If not, prompt the user to enter a valid number.

### **Try Catch Implementation:**
- Use a `try-catch` block to catch `FormatException`.
- If an exception occurs, display an error message and ask for valid input.

### **Expected Behavior:**
- **Without try-catch:** The program prevents errors by validating input before conversion.
- **With try-catch:** The program catches `FormatException` and prevents crashing.

### **Sample Output:**
```
Enter a number: abc
Error: Invalid input. Please enter a valid integer.
```

---

## **Task 3: Array Index Out of Bounds**
### **Instructions:**
- Create an integer array with **5 elements**.
- Ask the user for an index number and print the corresponding element.
- Implement both **Logical Implementation** and **Try Catch Implementation**.

### **Logical Implementation:**
- Before accessing the array, check if the index is within bounds.
- If not, display an error message.

### **Try Catch Implementation:**
- Use a `try-catch` block to catch `IndexOutOfRangeException`.
- Display an error message if the exception occurs.

### **Expected Behavior:**
- **Without try-catch:** The program prevents errors by checking the index before accessing the array.
- **With try-catch:** The program catches `IndexOutOfRangeException` and prevents crashing.

### **Sample Output:**
```
Enter an index: 7
Error: Index out of range. Please enter a valid index.
```

---

## **Task 4: Null Reference Handling**
### **Instructions:**
- Create a **string variable** and **set it to null**.
- Try to access a property or method on this null variable.
- Implement both **Logical Implementation** and **Try Catch Implementation**.

### **Logical Implementation:**
- Before accessing the variable, check if it is `null`.
- If it is, display an error message instead of accessing the method.

### **Try Catch Implementation:**
- Use a `try-catch` block to catch `NullReferenceException`.
- Display an error message if the exception occurs.

### **Expected Behavior:**
- **Without try-catch:** The program prevents null reference errors by checking before use.
- **With try-catch:** The program catches `NullReferenceException` and prevents crashing.

### **Sample Output:**
```
Error: The object is null. Cannot access properties of a null object.
```

---

## **Task 5: Bank Account System with Exception Handling**
### **Scenario:**
A bank provides customers with accounts where they can deposit and withdraw money. However, certain rules must be enforced:
- Customers **cannot withdraw more than their available balance**.
- A **minimum balance of $10** must always be maintained.
- Deposits must be **greater than zero**.

Using **OOP principles**, implement a **BankAccount** class that enforces these rules.

### **Instructions:**
1. **Define a `BankAccount` class:**
   - Add a property `Balance` to store the account balance.
   - Implement a `Deposit(decimal amount)` method.
   - Implement a `Withdraw(decimal amount)` method.
2. **Logical Implementation:**
   - Before allowing a withdrawal, check if the **remaining balance** would be below the allowed minimum.
   - Before allowing a deposit, check if the amount is **greater than zero**.
   - If any condition is not met, display an error message.
3. **Try Catch Implementation:**
   - Define a **custom exception** class called `InsufficientFundsException`.
   - Modify `Withdraw()` to throw an `InsufficientFundsException` if the withdrawal **violates bank rules**.
   - Use a `try-catch` block in the `Main()` method to catch and handle this exception.

### **Expected Behavior:**
- **Without try-catch:** The program prevents invalid transactions by checking conditions before execution.
- **With try-catch:** The program catches exceptions and displays error messages gracefully without crashing.

### **Sample Output:**
```
Enter withdrawal amount: 500
Error: Insufficient funds. Minimum balance of $10 must be maintained.
```

---

## Conclusion
These tasks progressively teach **exception handling logic** by comparing **logical checks vs. try-catch handling**. By implementing **OOP principles** in the banking scenario, students will learn how to structure programs using encapsulation and exception handling.

🚀 **Happy coding!**