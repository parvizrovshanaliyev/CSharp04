### Quiz Game 

---

### Task Description

**Goal**: Build a simple quiz game that helps students learn basic C# concepts while practicing using `for` loops, conditionals (`if-else`), and input handling with `int.TryParse`. This quiz presents 15 questions, each with four multiple-choice answers. The program tracks the user's score and provides feedback at the end.

### Steps and Explanations

1. **Display Each Question**: Present each question along with four possible answers. Use `Console.WriteLine` to show the question and options.

2. **User Input Validation**: Use `int.TryParse` to handle the user’s input. Ensure they enter a valid integer (1-4), re-prompting if necessary. 

3. **Answer Checking**: After each answer, check if it’s correct and, if so, increment the score by one.

4. **Final Score and Feedback**: At the end of the quiz, display the user’s score out of 15 and provide feedback.

### Example Input and Output

**Question Example**:
```
Question 1: What is the default value of an integer in C#?
1. 0
2. 1
3. -1
4. null
Enter your answer (1-4): 1
Correct!
```

**Final Score Example**:
```
Quiz Complete! You scored 10 out of 15.
Good job! You got some answers right.
```
---

### Quiz Questions for C# Beginners

1. **Question 1: Basic Output in C#**
   - **Description**: Learn how to display text on the console.
   - **Question**: What is the correct syntax to output "Hello, World!" in C#?
     - 1. `print("Hello, World!");`
     - 2. `Console.WriteLine("Hello, World!");`
     - 3. `echo "Hello, World!";`
     - 4. `printf("Hello, World!");`
   - **Correct Answer**: 2

---

2. **Question 2: Data Types - String**
   - **Description**: Understand which data types are used for text.
   - **Question**: Which data type is used to store text in C#?
     - 1. `text`
     - 2. `char`
     - 3. `string`
     - 4. `txt`
   - **Correct Answer**: 3

---

3. **Question 3: Arithmetic Operators**
   - **Description**: Identify operators used for basic arithmetic.
   - **Question**: Which operator is used to add two numbers in C#?
     - 1. `*`
     - 2. `+`
     - 3. `&`
     - 4. `%`
   - **Correct Answer**: 2

---

4. **Question 4: Declaring Variables**
   - **Description**: Understand how to declare a variable in C#.
   - **Question**: How do you create an integer variable named "x" with the value 5?
     - 1. `int x = 5;`
     - 2. `x int = 5;`
     - 3. `int x = "5";`
     - 4. `5 = int x;`
   - **Correct Answer**: 1

---

5. **Question 5: Conditional Statements**
   - **Description**: Learn the keywords for conditional statements.
   - **Question**: Which keyword is commonly used to create a basic conditional statement in C#?
     - 1. `if`
     - 2. `case`
     - 3. `switch`
     - 4. `goto`
   - **Correct Answer**: 1

---

6. **Question 6: Basic Loops - While Loop**
   - **Description**: Understand the basics of a `while` loop.
   - **Question**: How do you start a `while` loop in C#?
     - 1. `while x > y {}`
     - 2. `while (x > y) {}`
     - 3. `while x > y: {}`
     - 4. `while (x > y):`
   - **Correct Answer**: 2

---

7. **Question 7: Breaking Out of Loops**
   - **Description**: Know how to exit a loop before it naturally ends.
   - **Question**: Which keyword is used to exit a loop in C#?
     - 1. `stop`
     - 2. `end`
     - 3. `break`
     - 4. `exit`
   - **Correct Answer**: 3

---

8. **Question 8: Comparison Operators**
   - **Description**: Recognize operators used for comparisons.
   - **Question**: Which operator is used to compare two values in C#?
     - 1. `<>`
     - 2. `>`
     - 3. `<<`
     - 4. `||`
   - **Correct Answer**: 2

---

9. **Question 9: Logical Operators**
   - **Description**: Identify operators used to combine conditions.
   - **Question**: Which operator can be used to combine two conditions in C#?
     - 1. `&`
     - 2. `|`
     - 3. `&&`
     - 4. `$$`
   - **Correct Answer**: 3

---

10. **Question 10: For Loop Syntax**
    - **Description**: Understand the syntax for `for` loops in C#.
    - **Question**: How do you start a `for` loop in C#?
      - 1. `for (int i = 0; i < 5; i++) {}`
      - 2. `for int i = 0 to 5 {}`
      - 3. `foreach (i in range(5)) {}`
      - 4. `for each i = 0; i < 5`
    - **Correct Answer**: 1

---

11. **Question 11: Multi-Line Comments**
    - **Description**: Learn how to create comments that span multiple lines.
    - **Question**: What is the correct syntax for a multi-line comment in C#?
      - 1. `/* comment */`
      - 2. `// comment`
      - 3. `# comment`
      - 4. `** comment **`
    - **Correct Answer**: 1

---

12. **Question 12: Float Variables**
    - **Description**: Understand how to create variables with decimal values.
    - **Question**: How do you create a variable with a floating point value in C#?
      - 1. `float f = 5.99f;`
      - 2. `int f = 5.99;`
      - 3. `double f = "5.99";`
      - 4. `num f = 5.99f;`
    - **Correct Answer**: 1

---

13. **Question 13: Value and Reference Types**
    - **Description**: Recognize the difference between value types and reference types.
    - **Question**: Which of the following is a reference type in C#?
      - 1. `int`
      - 2. `string`
      - 3. `bool`
      - 4. `char`
    - **Correct Answer**: 2

---

14. **Question 14: Loop Types in C#**
    - **Description**: Identify the different types of loops in C#.
    - **Question**: Which is NOT a loop type in C#?
      - 1. `while`
      - 2. `do-while`
      - 3. `foreach`
      - 4. `repeat`
    - **Correct Answer**: 4

---


15. **Question 15: Type Casting**
    - **Description**: Understand the process of casting between data types in C#.
    - **Question**: Which syntax is correct for casting an `int` to `double`?
      - 1. `(double)x`
      - 2. `[double]x`
      - 3. `{double}x`
      - 4. `convert(double, x)`


---

16. **Question 16: Ternary Operator**
    - **Description**: Learn how the ternary operator works in conditional expressions.
    - **Question**: Which is the correct syntax for a ternary operator in C#?
      - 1. `x ? y : z`
      - 2. `x ? y ? z`
      - 3. `x : y ? z`
      - 4. `x : (y) : z`

---

