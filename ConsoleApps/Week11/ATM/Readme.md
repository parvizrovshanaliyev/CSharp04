## ATM Program Overview

This program simulates a basic ATM with a few key features:
1. **PIN Authentication**: Ensures only users with the correct PIN can access the ATM.
2. **Balance Inquiry**: Allows users to check their current balance.
3. **Deposit**: Users can add money to their account.
4. **Withdraw**: Users can withdraw money in specific denominations.
5. **Exit**: Ends the program.

---

### Task 1: PIN Authentication

**Description**: Prompt the user to enter a PIN before they can access the ATM menu. Give the user a maximum of 3 attempts. If the correct PIN is entered, grant access; if not, deny access after the maximum attempts.

**Explanation**:
- Use a `for` loop to allow up to 3 attempts for PIN entry.
- If the user enters the correct PIN, set an `isAuthenticated` flag to `true` and proceed to the main ATM menu.
- If the user fails to enter the correct PIN after 3 attempts, display an "Access Denied" message and terminate the program.

**Sample Input and Output**:
```
Enter PIN: 1234
Output: Access granted.

Enter PIN: 0000
Output: Incorrect PIN. You have 2 attempts remaining.
...
Output: Too many incorrect attempts. Access denied.
```

---

### Task 2: ATM Main Menu

**Description**: After successful PIN authentication, display the ATM main menu with the following options: 
1. **Check Balance**
2. **Deposit**
3. **Withdraw**
4. **Exit**

The user enters the number corresponding to their choice to access the function.

**Explanation**:
- Use a `do-while` loop to keep displaying the menu until the user chooses **Exit**.
- Validate the user’s input using `int.TryParse` to ensure a valid menu choice.
- Use a `switch` statement to handle the selected option.

---

### Task 3: Check Balance

**Description**: Allow the user to view their current account balance.

**Explanation**:
- Use a variable `balance` to store and display the current balance when **Check Balance** is selected.

**Sample Output**:
```
Your balance is $1000
```

---

### Task 4: Deposit Money

**Description**: Enable the user to add money to their account balance. Prompt the user to enter the deposit amount, validate it, and add it to the balance if valid.

**Explanation**:
- Use `int.TryParse` to ensure the deposit amount is a valid integer.
- Check if the deposit amount is positive. If not, display an error message.

**Sample Input and Output**:
```
Enter amount to deposit: 500
Output: $500 deposited successfully. Your new balance is $1500

Enter amount to deposit: -100
Output: Invalid amount. Please enter a positive value.
```

---

### Task 5: Withdraw Money with Denominations

**Description**: Allow the user to withdraw money from their account. Prompt them to enter the amount, check if the balance is sufficient, and then calculate the bills to dispense in denominations of `$100`, `$50`, `$20`, `$10`, `$5`, and `$1`.

**Explanation**:
- Use `int.TryParse` to handle invalid input for the withdrawal amount.
- Check if the `balance` is sufficient for the withdrawal. If not, display an error message.
- Calculate the number of each denomination using a `foreach` loop. Start with the largest denomination to minimize the number of bills dispensed.
- Deduct the total withdrawal amount from the balance.

**Sample Input and Output**:
```
Enter amount to withdraw: 286
Output:
$100 bills: 2
$50 bills: 1
$20 bills: 1
$10 bills: 1
$5 bills: 1
$1 bills: 1
Remaining balance: $714
```

---

### Task 6: Exit ATM

**Description**: Add an option for the user to exit the ATM. When selected, display a goodbye message and end the program.

**Explanation**:
- When **Exit** is chosen, break out of the `do-while` loop and display a goodbye message.

**Sample Output**:
```
Thank you for using the ATM. Goodbye!
```

---


### Explanation of Each Step in the Program

1. **PIN Authentication**:
   - Users have up to 3 attempts to enter the correct PIN.
   - `int.TryParse` ensures the input is valid.
   - If the PIN is correct, proceed; otherwise, display error messages and lockout after 3 failed attempts.

2. **Main Menu**:
   - Uses a `do-while` loop to keep displaying the menu until the user exits.
   - `int.TryParse` validates the menu selection to handle invalid inputs.

3. **Check Balance**:
   - Simply displays the current balance.

4. **Deposit Money**:
   - Accepts an amount, validates it, and adds it to the balance if positive.

5. **Withdraw Money with Denominations**:
   - Checks if there’s enough balance.
   - Calculates the number of bills for each denomination using division and modulus.
   - Updates the balance after successful withdrawal.

6. **Exit**:
   - Exits the program with a goodbye message.

