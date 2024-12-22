namespace OOP.AccessModifiersAndEncapsulation
{
    /// <summary>
    /// Demonstrates encapsulation using a bank account example.
    /// Encapsulation ensures that the internal state of an object is hidden from the outside world,
    /// and access to it is controlled via methods or properties.
    /// </summary>
    public class BankAccount
    {
        // === Encapsulation: Private Fields ===
        // The 'balance' field is private, ensuring it cannot be directly modified from outside this class.
        private decimal balance;

        // === Public Properties with Controlled Access ===
        // The 'AccountHolder' property can only be set during object creation, preventing external modifications.
        public string AccountHolder { get; private set; }

        /// <summary>
        /// Constructor to initialize the bank account with the account holder's name.
        /// Demonstrates the use of a public constructor to set private or protected fields.
        /// </summary>
        /// <param name="accountHolder">The name of the account holder.</param>
        public BankAccount(string accountHolder)
        {
            AccountHolder = accountHolder; // Initialize the account holder's name.
        }

        /// <summary>
        /// Deposits a specified amount into the bank account.
        /// Demonstrates controlled access to modify the balance while ensuring validation (e.g., positive amounts only).
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount; // Update the balance safely.
                Console.WriteLine($"{amount:C} deposited. Current balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        /// <summary>
        /// Retrieves the current balance of the account.
        /// Demonstrates encapsulation by exposing a method instead of directly accessing the balance field.
        /// </summary>
        /// <returns>The current balance.</returns>
        public decimal GetBalance()
        {
            return balance; // Return the current balance safely.
        }

        /// <summary>
        /// Withdraws a specified amount from the bank account.
        /// Demonstrates controlled access with validation to prevent overdrafts or invalid withdrawals.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount; // Deduct the amount from the balance.
                Console.WriteLine($"{amount:C} withdrawn. Remaining balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount. Ensure you have sufficient balance.");
            }
        }
    }

    /// <summary>
    /// Represents a generic user with protected fields and methods for inheritance demonstration.
    /// Demonstrates how protected members can be accessed by derived classes but remain hidden from external classes.
    /// </summary>
    public class User
    {
        // === Protected Fields ===
        // The 'Name' field is protected, allowing derived classes to access it.
        protected string Name { get; set; }

        // === Protected Method ===
        /// <summary>
        /// Displays basic user information.
        /// This method is only accessible within this class or derived classes.
        /// </summary>
        protected void DisplayInfo()
        {
            Console.WriteLine($"User Name: {Name}");
        }
    }

    /// <summary>
    /// Represents an employee, inheriting from the User class.
    /// Demonstrates how derived classes can access protected members of the base class.
    /// </summary>
    public class Employee : User
    {
        // Additional property specific to the Employee class
        public string JobTitle { get; private set; }

        /// <summary>
        /// Constructor to initialize an employee with their name and job title.
        /// Demonstrates how protected members can be initialized through derived class constructors.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="jobTitle">The job title of the employee.</param>
        public Employee(string name, string jobTitle)
        {
            Name = name;       // Access the protected 'Name' field from the base class.
            JobTitle = jobTitle; // Initialize the job title property.
        }

        /// <summary>
        /// Displays detailed information about the employee.
        /// Combines access to protected members from the base class with derived class-specific members.
        /// </summary>
        public void DisplayEmployeeDetails()
        {
            DisplayInfo(); // Call the protected method from the base class.
            Console.WriteLine($"Job Title: {JobTitle}");
        }
    }

    /// <summary>
    /// Demonstrates the internal access modifier.
    /// Internal members are accessible within the same project but are hidden from other projects.
    /// </summary>
    internal class InternalExample
    {
        internal string Message { get; set; } = "This is internal and accessible within the same project.";
    }

    /// <summary>
    /// The main program that demonstrates access modifiers and encapsulation.
    /// Includes examples of private, public, protected, and internal access modifiers.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Access Modifiers and Encapsulation Demo ===\n");

            // === BankAccount Example ===
            Console.WriteLine("--- BankAccount Example ---");
            var account = new BankAccount("John Doe");
            account.Deposit(100); // Deposit a valid amount.
            account.Withdraw(30); // Withdraw a valid amount.
            Console.WriteLine($"Final Balance: {account.GetBalance():C}"); // Retrieve and display the final balance.
            Console.WriteLine();

            // === User and Employee Example (Inheritance and Protected Access Modifier) ===
            Console.WriteLine("--- User and Employee Example ---");
            var employee = new Employee("Alice Johnson", "Software Engineer");
            employee.DisplayEmployeeDetails(); // Display employee-specific details.
            Console.WriteLine();

            // === Internal Access Modifier Example ===
            Console.WriteLine("--- Internal Example ---");
            var internalExample = new InternalExample();
            Console.WriteLine(internalExample.Message); // Access internal member within the same assembly.
        }
    }
}
