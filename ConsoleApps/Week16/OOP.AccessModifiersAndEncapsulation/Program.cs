namespace OOP.AccessModifiersAndEncapsulation
{
    // Example of encapsulation and access modifiers
    public class BankAccount
    {
        // Private field to hold the balance (Encapsulation)
        private decimal balance;

        // Public property with a private setter for controlled access
        public string AccountHolder { get; private set; }

        // Constructor to initialize the account holder
        public BankAccount(string accountHolder)
        {
            AccountHolder = accountHolder;
        }

        // Public method to deposit money (Encapsulation via methods)
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"{amount:C} deposited. Current balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Public method to retrieve the balance (Encapsulation)
        public decimal GetBalance()
        {
            return balance;
        }

        // Public method to withdraw money (with validation)
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"{amount:C} withdrawn. Remaining balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }
    }

    // Example of inheritance with access modifiers
    public class Animal
    {
        protected string Name { get; set; } // Protected: Accessible in derived classes

        protected void Speak()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name)
        {
            Name = name; // Accessing protected member
        }

        public void Bark()
        {
            Speak(); // Accessing protected method
            Console.WriteLine($"{Name} barks loudly!");
        }
    }

    // Example of internal access modifier
    internal class InternalExample
    {
        internal string Message { get; set; } = "This is internal and accessible within the same project.";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Access Modifiers and Encapsulation Demo ===");

            // BankAccount Example
            var account = new BankAccount("John Doe");
            account.Deposit(100);
            account.Withdraw(30);
            Console.WriteLine($"Final Balance: {account.GetBalance():C}");
            Console.WriteLine();

            // Animal and Dog Example (Protected Access Modifier)
            var dog = new Dog("Buddy");
            dog.Bark();
            Console.WriteLine();

            // Internal Example
            var internalExample = new InternalExample();
            Console.WriteLine(internalExample.Message); // Allowed because it's in the same assembly
        }
    }
}

