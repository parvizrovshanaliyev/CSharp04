using System;

namespace ATM
{
    class ATMWithArrayAndMethod
    {
        static void Run()
        {
            /*
             * Task: ATM System
             * 
             * Description:
             * Create a modular ATM system that performs the following tasks:
             * 1. PIN Authentication with up to 3 attempts.
             * 2. Main menu to check balance, deposit, withdraw, and exit.
             * 3. Handle cash withdrawals with denominations.
             * 
             * Features:
             * - Modular design with methods for each functionality.
             * - Input validation using `int.TryParse`.
             * - Use arrays for denominations in withdrawals.
             */

            int correctPIN = 1234;
            int balance = 1000;
            int maxAttempts = 3;

            if (!AuthenticateUser(correctPIN, maxAttempts))
            {
                Console.WriteLine("Too many incorrect attempts. Access denied.");
                return; // Exit the program if authentication fails
            }

            RunATM(balance);
        }

        /// <summary>
        /// Authenticates the user by prompting for a PIN with a maximum number of attempts.
        /// </summary>
        static bool AuthenticateUser(int correctPIN, int maxAttempts)
        {
            for (int attempts = 1; attempts <= maxAttempts; attempts++)
            {
                Console.Write("Enter PIN: ");
                if (int.TryParse(Console.ReadLine(), out int enteredPIN) && enteredPIN == correctPIN)
                {
                    Console.WriteLine("Access granted.\n");
                    return true;
                }
                Console.WriteLine($"Incorrect PIN. You have {maxAttempts - attempts} attempts remaining.");
            }
            return false;
        }

        /// <summary>
        /// Runs the ATM system, displaying the main menu and performing operations.
        /// </summary>
        static void RunATM(int balance)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("\nATM Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CheckBalance(balance);
                        break;

                    case 2:
                        balance = DepositMoney(balance);
                        break;

                    case 3:
                        balance = WithdrawMoney(balance);
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option from the menu.");
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Displays the current balance.
        /// </summary>
        static void CheckBalance(int balance)
        {
            Console.WriteLine($"Your balance is ${balance}");
        }

        /// <summary>
        /// Allows the user to deposit money and updates the balance.
        /// </summary>
        static int DepositMoney(int balance)
        {
            Console.Write("Enter amount to deposit: ");
            if (int.TryParse(Console.ReadLine(), out int depositAmount) && depositAmount > 0)
            {
                balance += depositAmount;
                Console.WriteLine($"${depositAmount} deposited successfully. Your new balance is ${balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
            return balance;
        }

        /// <summary>
        /// Allows the user to withdraw money and updates the balance. Displays denominations for the withdrawn amount.
        /// </summary>
        static int WithdrawMoney(int balance)
        {
            Console.Write("Enter amount to withdraw: ");
            if (!int.TryParse(Console.ReadLine(), out int withdrawAmount) || withdrawAmount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                return balance;
            }

            if (withdrawAmount > balance)
            {
                Console.WriteLine("Insufficient balance.");
                return balance;
            }

            int remainingAmount = withdrawAmount;
            int[] denominations = { 100, 50, 20, 10, 5, 1 };
            Console.WriteLine("Dispensing cash:");

            foreach (int denom in denominations)
            {
                int count = remainingAmount / denom;
                if (count > 0)
                {
                    Console.WriteLine($"${denom} bills: {count}");
                    remainingAmount %= denom;
                }
            }

            balance -= withdrawAmount;
            Console.WriteLine($"Remaining balance: ${balance}");
            return balance;
        }
    }
}
