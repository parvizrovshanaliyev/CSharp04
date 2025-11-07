using SampleCrudOperations.Models;
using SampleCrudOperations.Services;

namespace SampleCrudOperations
{
    internal class Program
    {
        // Connection string for the database
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=SampleDb;Integrated Security=True;Encrypt=False";

        private static readonly DatabaseService _dbService = new(ConnectionString);

        static async Task Main(string[] args)
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Customer Management System");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await CreateCustomerAsync();
                        break;
                    case "2":
                        await ViewAllCustomersAsync();
                        break;
                    case "3":
                        await UpdateCustomerAsync();
                        break;
                    case "4":
                        await DeleteCustomerAsync();
                        break;
                    case "5":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static async Task CreateCustomerAsync()
        {
            Console.WriteLine("\nCreate New Customer");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            var customer = new Customer { Name = name, Email = email };
            var id = await _dbService.CreateCustomerAsync(customer);
            Console.WriteLine($"Customer created with ID: {id}");
        }

        private static async Task ViewAllCustomersAsync()
        {
            Console.WriteLine("\nAll Customers:");
            var customers = await _dbService.GetAllCustomersAsync();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, " +
                    $"Email: {customer.Email}, Created: {customer.CreatedAt}");
            }
        }

        private static async Task UpdateCustomerAsync()
        {
            Console.Write("\nEnter customer ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            Console.Write("New name: ");
            var name = Console.ReadLine();
            Console.Write("New email: ");
            var email = Console.ReadLine();

            var customer = new Customer { Id = id, Name = name, Email = email };
            var success = await _dbService.UpdateCustomerAsync(customer);
            Console.WriteLine(success ? "Customer updated successfully!" : "Update failed!");
        }

        private static async Task DeleteCustomerAsync()
        {
            Console.Write("\nEnter customer ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var success = await _dbService.DeleteCustomerAsync(id);
            Console.WriteLine(success ? "Customer deleted successfully!" : "Delete failed!");
        }
    }
}
