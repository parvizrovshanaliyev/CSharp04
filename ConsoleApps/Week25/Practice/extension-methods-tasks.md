# Extension Methods Tasks

---

## Task 1: Extend Integer Functionality
### Objective:
Create an extension method for the `int` type that determines if a number is even.

### Requirements:
- Method name: `IsEven()`
- Returns `true` if the number is even, otherwise `false`.

### How to Implement:
1. Create a **static class**.
2. Define a **static method** for `int`.
3. Use the modulus operator (`%`) to check divisibility by 2.

---


## Task 2: Get Age from a Date
### Objective:
Create an extension method for the `DateTime` type that calculates the age based on a birthdate.

### Requirements:
- Method name: `GetAge()`
- Returns the age in years.
- Considers leap years and future dates.

### How to Implement:
1. Define an extension method for `DateTime`.
2. Subtract the birth year from the current year.
3. Adjust for whether the birthday has passed this year.

---

## Task 3: Count Words in a String
### Objective:
Implement an extension method that counts the number of words in a given string.

### Requirements:
- Method name: `WordCount()`
- Returns the count of words separated by spaces.
- Handles multiple spaces and punctuation properly.

### How to Implement:
1. Define an extension method for `string`.
2. Use `Split()` with space and punctuation delimiters.
3. Filter out empty entries and return the count.

---


## Task 4: Get the Nth Fibonacci Number
### Objective:
Write an extension method for `int` that returns the Nth Fibonacci number.

### Requirements:
- Method name: `NthFibonacci()`
- Uses an efficient approach (recursion or iteration).
- Handles cases where N is negative or too large.

### How to Implement:
1. Define an extension method for `int`.
2. Use a loop or recursion to compute Fibonacci numbers.
3. Ensure it handles edge cases like `0` and `1` correctly.
