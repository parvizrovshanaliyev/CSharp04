---

### C# Loop Tasks with Examples of Break, Continue, While, Do-While, and For Loops

---

### Task 1: Print Multiplication Table Using a For Loop

**Description**: Write a program that prompts the user to enter a number, then prints the multiplication table for that number up to 10.

**Explanation**: 
- Use a `for` loop to iterate from 1 to 10 and multiply the user’s input by each value in the loop.

**Sample Input and Output**:
```
Enter a number: 5
Output:
5 x 1 = 5
5 x 2 = 10
5 x 3 = 15
...
5 x 10 = 50
```

---

### Task 2: Sum of First N Numbers Using a While Loop

**Description**: Ask the user to enter a positive integer `N` and calculate the sum of the first `N` natural numbers.

**Explanation**: 
- Use a `while` loop to add each number from `1` to `N` to a running total.

**Sample Input and Output**:
```
Enter a positive integer: 5
Output: The sum of the first 5 numbers is 15
```

---

### Task 3: Find Factorial of a Number Using a For Loop

**Description**: Write a program that calculates the factorial of a number entered by the user.

**Explanation**: 
- Factorial of `N` (written as `N!`) is calculated as `N * (N - 1) * ... * 1`.
- Use a `for` loop to multiply each number from `1` to `N`.

**Sample Input and Output**:
```
Enter a positive integer: 4
Output: The factorial of 4 is 24
```

---

### Task 4: Count Down from N to 1 Using a Do-While Loop

**Description**: Prompt the user to enter a positive integer `N`, then print all numbers from `N` down to `1`.

**Explanation**: 
- Use a `do-while` loop that starts at `N` and decreases by `1` in each iteration until it reaches `1`.

**Sample Input and Output**:
```
Enter a positive integer: 5
Output:
5
4
3
2
1
```

---

### Task 5: Count Occurrences of a Character Using Foreach Loop with Continue

**Description**: Ask the user to enter a string and a character, then count how many times the character appears in the string.

**Explanation**: 
- Use a `foreach` loop to iterate through each character in the string.
- Use `continue` to skip characters that don’t match the specified character.

**Sample Input and Output**:
```
Enter a string: Mississippi
Enter a character to count: s
Output: The character 's' appears 4 times.
```

---

### Task 6: Calculate the Average of N Numbers Using For Loop with Break

**Description**: Write a program that asks the user for a number `N` and then asks them to input `N` numbers, calculating the average of these numbers. Stop input if the user enters `0`.

**Explanation**: 
- Use a `for` loop to accumulate a sum of `N` numbers.
- Use `break` to stop if the user enters `0` before reaching `N`.

**Sample Input and Output**:
```
Enter the number of values: 3
Enter number 1: 5
Enter number 2: 0
Output: Input stopped early. The average is 5
```

---

### Task 7: Find the Largest Number Using a For Loop

**Description**: Prompt the user to enter a number `N` for how many numbers they’d like to input. Then ask for each number and determine the largest among them.

**Explanation**: 
- Use a `for` loop to compare each entered number to the current largest number.

**Sample Input and Output**:
```
How many numbers will you enter? 4
Enter number 1: 5
Enter number 2: 10
Enter number 3: 3
Enter number 4: 8
Output: The largest number is 10
```

---

### Task 8: Check if a Number is Prime Using a For Loop with Break

**Description**: Write a program that prompts the user to enter a positive integer and checks if it’s a prime number.

**Explanation**:
- A prime number has no divisors other than 1 and itself.
- Use a `for` loop to check if any number from `2` to `N-1` divides `N` evenly.
- Use `break` if a divisor is found, indicating the number is not prime.

**Sample Input and Output**:
```
Enter a positive integer: 7
Output: 7 is a prime number.

Enter a positive integer: 9
Output: 9 is not a prime number.
```

---

### Task 9: Print Multiples of a Number Up to N Using While Loop with Continue

**Description**: Write a program that asks for two numbers: a base number and a limit `N`. Print all multiples of the base number up to `N`.

**Explanation**:
- Use a `while` loop to print multiples of the base number up to `N`.
- Use `continue` if the current number is not a multiple of the base number.

**Sample Input and Output**:
```
Enter the base number: 3
Enter the limit: 20
Output:
3
6
9
12
15
18
```

---

### Task 10: Reverse a String Using a For Loop

**Description**: Ask the user to enter a string and display it in reverse order.

**Explanation**:
- Use a `for` loop to iterate through the string from the end to the beginning, constructing the reversed version.

**Sample Input and Output**:
```
Enter a string: Hello
Output: Reversed string: olleH
```

---

### Task 11: Find the First Multiple of 7 Using a For Loop with Break

**Description**: Write a program that prompts the user to enter a positive integer `N`. Then, use a loop to find the first multiple of 7 between `1` and `N`. If a multiple is found, stop the loop.

**Explanation**: 
- Use a `for` loop to iterate from `1` to `N`.
- Check if each number is divisible by 7 (`number % 7 == 0`). If true, display the number and use `break` to exit the loop.

**Sample Input and Output**:
```
Enter a positive integer: 20
Output: The first multiple of 7 between 1 and 20 is 7
```

**Example**:
```
Enter a positive integer: 5
Output: There is no multiple of 7 between 1 and 5
```

---

### Task 12: Print Odd Numbers Using a For Loop with Continue

**Description**: Write a program that prompts the user to enter a positive integer `N` and then prints all odd numbers from `1` to `N`.

**Explanation**:
- Use a `for` loop to iterate from `1` to `N`.
- Use `continue` to skip even numbers and only print odd numbers.

**Sample Input and Output**:
```
Enter a positive integer: 10
Output:
1
3
5
7
9
```

---
