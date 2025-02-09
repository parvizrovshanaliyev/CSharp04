using System;

namespace OOP.Abstraction.AbstractClass
{
    /// <summary>
    /// Represents an abstract bank with basic banking operations.
    /// </summary>
    public abstract class Bank
    {
        /// <summary>
        /// Validates the bank card. This method must be implemented by derived classes.
        /// </summary>
        public abstract void ValidateCard();

        /// <summary>
        /// Withdraws money from the bank. This method must be implemented by derived classes.
        /// </summary>
        public abstract void WithdrawMoney();

        /// <summary>
        /// Checks the balance in the bank account. This method must be implemented by derived classes.
        /// </summary>
        public abstract void CheckBalance();

        /// <summary>
        /// Transfers money to another bank account. This method must be implemented by derived classes.
        /// </summary>
        public abstract void BankTransfer();

        /// <summary>
        /// Displays a mini statement of the bank account.
        /// </summary>
        public virtual void MiniStatement()
        {
            Console.WriteLine("Mini Statement");
        }
    }

    /// <summary>
    /// Represents a specific implementation of a bank, RabiteBank.
    /// </summary>
    public class RabiteBank : Bank
    {
        /// <summary>
        /// Transfers money to another bank account.
        /// </summary>
        public override void BankTransfer()
        {
            Console.WriteLine("RabiteBank: Bank transfer completed.");
            // Simulate bank transfer logic
        }

        /// <summary>
        /// Checks the balance in the bank account.
        /// </summary>
        public override void CheckBalance()
        {
            Console.WriteLine("RabiteBank: Your balance is $1,000.");
            // Simulate balance checking logic
        }

        /// <summary>
        /// Validates the bank card.
        /// </summary>
        public override void ValidateCard()
        {
            Console.WriteLine("RabiteBank: Card validated successfully.");
            // Simulate card validation logic
        }

        /// <summary>
        /// Withdraws money from the bank.
        /// </summary>
        public override void WithdrawMoney()
        {
            Console.WriteLine("RabiteBank: $100 withdrawn successfully.");
            // Simulate money withdrawal logic
        }
    }

    /// <summary>
    /// Represents a specific implementation of a bank, ABB.
    /// </summary>
    public class ABB : Bank
    {
        /// <summary>
        /// Transfers money to another bank account.
        /// </summary>
        public override void BankTransfer()
        {
            Console.WriteLine("ABB: Bank transfer completed.");
            // Simulate bank transfer logic
        }

        /// <summary>
        /// Checks the balance in the bank account.
        /// </summary>
        public override void CheckBalance()
        {
            Console.WriteLine("ABB: Your balance is $2,000.");
            // Simulate balance checking logic
        }

        /// <summary>
        /// Validates the bank card.
        /// </summary>
        public override void ValidateCard()
        {
            Console.WriteLine("ABB: Card validated successfully.");
            // Simulate card validation logic
        }

        /// <summary>
        /// Withdraws money from the bank.
        /// </summary>
        public override void WithdrawMoney()
        {
            Console.WriteLine("ABB: $200 withdrawn successfully.");
            // Simulate money withdrawal logic
        }
    }
}
