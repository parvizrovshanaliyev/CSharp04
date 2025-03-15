## **Project: Intelligent User Profile System with Data Insights**

### **Objective**
This project will help you understand how to use **static methods and extension methods** by implementing them in **a real-world interactive user profile system**.
You will develop a dynamic application that:

1. **Creates a detailed user profile** by processing personal information like birthdate and bio.
2. **Enhances text input** by analyzing word count and formatting the user's bio properly.
3. **Performs intelligent numerical analysis** on a user-provided number, including checking if it’s even, computing its square, cube, and factorial.
4. **Explores mathematical sequences** by computing the Nth Fibonacci number for the user.
5. **Delivers a structured and reusable user experience** through an interactive menu-driven system.

---

### **Scenario**
You are developing an **intelligent user profile system** for a digital personal assistant used in smart applications. Users will enter personal details like their birthdate and bio, conduct mathematical operations on personal numbers (such as their lucky number), and explore mathematical patterns like Fibonacci sequences.

This system should:
- Provide **valuable insights** about the user’s data.
- Offer **clean and structured outputs**.
- Handle errors and invalid inputs **gracefully**.
- Be **interactive** with a well-designed menu-driven flow.

---

### **Instructions**

#### **Step 1: User Profile Setup**
1. Display a **welcome message** introducing the assistant.
2. Prompt the user to **enter their birthdate** in `YYYY-MM-DD` format.
   - Use `GetAge()` to calculate their current age.
   - Ensure proper validation to handle incorrect formats or future dates.
3. Ask the user to **enter a short bio** (a sentence about themselves).
   - Use `WordCount()` to count words in the bio.
   - Convert and display the bio in **title case** using `ToTitleCase()`.
   - Handle multiple spaces and punctuation correctly.

#### **Step 2: Perform Smart Number Analysis**
1. Ask the user to **input their favorite or lucky number**.
2. Use `IsEven()` to check if the number is even.
3. Compute and display:
   - **Square** using `MathUtilities.Square()`.
   - **Cube** using `MathUtilities.Cube()`.
   - **Factorial** using `MathUtilities.Factorial()`.
4. Ensure negative numbers are properly handled for factorial calculations.

#### **Step 3: Explore Mathematical Patterns**
1. Ask the user for a number `N` to compute the **Nth Fibonacci number**.
2. Use `NthFibonacci()` to calculate and display the result.
3. Ensure that input validation prevents negative values.

#### **Step 4: Interactive Menu & Reusability**
1. Implement a **menu-driven system** that allows users to:
   - View profile details.
   - Perform another text or number analysis.
   - Compute Fibonacci numbers.
   - Exit the program.
2. Ensure users can **repeat operations without restarting the application**.
3. Display **well-formatted outputs** for better readability.

---

### **Example Run**
```
Welcome to the Intelligent Digital Assistant!

Enter your birthdate (YYYY-MM-DD): 1998-06-15
Your age: 26

Enter a short bio about yourself: I love coding and solving problems.
Word count: 6
Title Case: I Love Coding And Solving Problems

Enter your lucky number: 5
Is even? False
Square: 25
Cube: 125
Factorial: 120

Enter N to find the Nth Fibonacci number: 7
7th Fibonacci number: 13

Would you like to:
1. View your profile details
2. Perform another text analysis
3. Perform another number analysis
4. Compute another Fibonacci sequence
5. Exit

Please enter your choice: 5
Thank you for using the Intelligent Digital Assistant!
```

---

### **Hints & Best Practices**
- Use `DateTime.TryParse(userInput, out DateTime date)` for safer date parsing.
- Use `sentence.WordCount()` and `sentence.ToTitleCase()` for efficient text processing.
- Use `number.IsEven()`, `MathUtilities.Square(number)`, `MathUtilities.Cube(number)`, and `MathUtilities.Factorial(number)` for smart numerical insights.
- Use `n.NthFibonacci()` for Fibonacci calculations while ensuring only valid inputs are accepted.
- Implement **exception handling** to prevent crashes from incorrect inputs.
- Format outputs cleanly to ensure clarity and user-friendliness.
