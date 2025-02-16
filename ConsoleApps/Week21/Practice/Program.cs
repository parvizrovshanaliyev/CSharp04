using Practice.EmployeeSalaryCalculations;
using Practice.Payment;
using Practice.ProductSystemDemo;

namespace Practice
{
    /// <summary>
    /// Main program class that demonstrates various implementations of polymorphism.
    /// Contains examples of both static and dynamic polymorphism through different scenarios.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Demonstrates the usage of payment processing, employee salary calculations,
        /// and product inventory management using polymorphism.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            /*
            * The following code demonstrates the PaymentProcessor class using static polymorphism.
            * It shows how the same method name can be used to process different types of payments
            * by calling the appropriate overload based on the parameters provided.
            */
            Console.WriteLine("Polymorphism Practice Tasks\n");

            // Task 2: Testing Payment Processor
            Console.WriteLine("Task 2: Payment Processor Demo");
            Console.WriteLine("------------------------------");
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ProcessPayment("1234-5678-9012-3456", 100.50);
            paymentProcessor.ProcessPayment("9876543210", "087654321", 500.75);
            paymentProcessor.ProcessPayment(50.25);
            Console.WriteLine();

            /*
            * The following section demonstrates dynamic polymorphism using an array of Employee objects.
            * It shows how different employee types can be stored in the same array and how the appropriate
            * CalculateSalary method is called based on the actual type of each employee at runtime.
            */
            Console.WriteLine("Task 3 & 4: Employee Salary Calculations");
            Console.WriteLine("---------------------------------------");
            Employee[] employees = new Employee[5];

            // { Name = "John Doe", MonthlySalary = 5000 }
            employees[0] = new FullTimeEmployee(name:"John Doe",monthlySalary: 5000);
            employees[1] = new PartTimeEmployee() { Name = "Jane Smith", HourlyRate = 20, HoursWorked = 80 };
            employees[2] = new FullTimeEmployee() { Name = "Bob Johnson", MonthlySalary = 6000 };
            employees[3] = new PartTimeEmployee() { Name = "Alice Brown", HourlyRate = 25, HoursWorked = 60 };
            employees[4] = new FullTimeEmployee() { Name = "Charlie Wilson", MonthlySalary = 5500 };

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}'s Salary: ${employee.CalculateSalary()}");
            }
            Console.WriteLine();

            /*
            * The following section demonstrates polymorphism in the product inventory system.
            * It shows how different types of products can be created and managed while maintaining
            * their specific attributes and behaviors. The DisplayDetails method demonstrates how
            * each product type can display its information in a specialized way.
            */
            Console.WriteLine("Task 5: Product System Demo");
            Console.WriteLine("--------------------------");
            var laptop = new Electronics
            {
                Name = "Gaming Laptop",
                Price = 1299.99,
                WarrantyPeriod = 24
            };

            var tShirt = new Clothing
            {
                Name = "Cotton T-Shirt",
                Price = 19.99,
                Size = "L"
            };

            var apple = new Food
            {
                Name = "Organic Apples",
                Price = 4.99,
                ExpirationDate = DateTime.Now.AddDays(14)
            };

            laptop.DisplayDetails();
            Console.WriteLine();
            tShirt.DisplayDetails();
            Console.WriteLine();
            apple.DisplayDetails();
        }
    }
}
