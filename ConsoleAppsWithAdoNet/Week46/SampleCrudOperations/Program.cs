using SampleCrudOperations.Models;
using SampleCrudOperations.Services;

namespace SampleCrudOperations
{
    /*
     * =====================================================================================================
     *  Customer Management System (Synchronous, ADO.NET)
     *  -----------------------------------------------------------------------------------------------------
     *  PURPOSE
     *  -------
     *  This console application demonstrates end-to-end CRUD operations against a SQL Server database
     *  using *synchronous* ADO.NET calls. It is intentionally simple and explicit to make the data-access
     *  flow easy to follow for learning purposes.
     *
     *  WHAT YOU'LL SEE HERE
     *  --------------------
     *  1) A menu-driven console UI that loops until the user chooses to Exit.
     *  2) Input validation (ID parsing, required fields).
     *  3) Clear separation of concerns:
     *     - Program.cs: user interaction, validation, and flow control
     *     - DatabaseService.cs: database access (SqlConnection/SqlCommand/etc.)
     *     - Customer.cs: a minimal POCO entity for mapping DB rows to objects
     *
     *  DESIGN CHOICES
     *  --------------
     *  • Synchronous calls: easier to understand step-by-step execution; suitable for console demos/tools.
     *  • Defensive coding: validate inputs, catch exceptions at safe boundaries, keep user informed.
     *  • Console UX: consistent menu layout, pauses between operations to let the user read results.
     *
     *  PREREQUISITES
     *  -------------
     *  • SQL Server instance available on the local machine (or adjust ConnectionString accordingly).
     *  • A database named "SampleDb" containing a "Customers" table with the schema shown at the bottom.
     *
     *  TABLE SCHEMA (for reference)
     *  ----------------------------
     *      CREATE TABLE dbo.Customers
     *      (
     *          Id        INT IDENTITY(1,1) PRIMARY KEY,
     *          Name      NVARCHAR(100) NOT NULL,
     *          Email     NVARCHAR(200) NOT NULL,
     *          CreatedAt DATETIME2(0)  NOT NULL DEFAULT SYSDATETIME()
     *      );
     *
     *  LIMITATIONS
     *  -----------
     *  • No paging for "View All" (kept simple).
     *  • Minimal email format validation (only required, no regex).
     *
     *  NEXT STEPS (if you extend this)
     *  -------------------------------
     *  • Add input sanitization beyond basic checks (email pattern, name length limits, etc.).
     *  • Add "View by Id", "Search by Name/Email".
     *  • Introduce a service layer for business rules and unit tests.
     *  • Replace ad-hoc Console.ReadLine() with a typed input helper to centralize parsing/validation logic.
     * =====================================================================================================
     */

    internal class Program
    {
        /*
         * -------------------------------------------------------------------------------------------------
         * CONNECTION STRING
         * -------------------------------------------------------------------------------------------------
         *  • Data Source=.;                // "." means local SQL Server instance
         *  • Initial Catalog=SampleDb;     // target database name
         *  • Integrated Security=True;     // use Windows Authentication
         *  • Encrypt=False                 // disable TLS encryption (OK for local dev; use True in prod)
         *
         *  Adjust for your environment (server name, database, credentials, encryption).
         */
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=SampleDb;Integrated Security=True;Encrypt=False";

        /*
         * DatabaseService is a thin wrapper that holds all ADO.NET interactions.
         * Keeping it as a readonly field enforces a single configuration source for DB operations.
         */
        private static readonly DatabaseService _dbService = new(ConnectionString);

        /*
         * -------------------------------------------------------------------------------------------------
         * MENU OPTIONS
         * -------------------------------------------------------------------------------------------------
         * Using an enum prevents "magic numbers" in code. Casting user input to this enum centralizes
         * valid choices and makes the switch statement exhaustive and self-documenting.
         */
        private enum MenuOption
        {
            Create = 1,
            ViewAll,
            Update,
            Delete,
            Exit
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * ENTRY POINT
         * -------------------------------------------------------------------------------------------------
         * Main() is intentionally tiny. All orchestration happens in RunApplication().
         * Top-level try/catch here acts as the global exception boundary for unhandled errors.
         */
        static void Main(string[] args)
        {
            try
            {
                RunApplication();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Application error: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * MAIN APPLICATION LOOP (SYNCHRONOUS)
         * -------------------------------------------------------------------------------------------------
         *  • Shows the menu
         *  • Reads and processes the user's choice
         *  • Pauses to let the user review output (so results aren’t lost in a flash)
         *  • Repeats until "Exit" is selected
         */
        private static void RunApplication()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessMenuChoice();

                if (continueRunning)
                {
                    WaitForKeyPress(); // Give the user a moment before clearing the screen on next loop.
                }
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * MENU RENDERING
         * -------------------------------------------------------------------------------------------------
         * Clears the screen and prints a consistently formatted menu.
         * Keeping the console UI tidy improves the learning/debugging experience.
         */
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║  Customer Management System  ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Create Customer          ║");
            Console.WriteLine("║  2. View All Customers       ║");
            Console.WriteLine("║  3. Update Customer          ║");
            Console.WriteLine("║  4. Delete Customer          ║");
            Console.WriteLine("║  5. Exit                     ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.Write("\nSelect an option (1-5): ");
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * MENU CHOICE PROCESSING
         * -------------------------------------------------------------------------------------------------
         * 1) Read a line from console.
         * 2) Try to parse it to our MenuOption enum (Enum.TryParse avoids exceptions).
         * 3) Delegate to HandleMenuOption() if valid; otherwise handle invalid input.
         *
         * Returning a bool makes the "keep looping or exit" decision explicit to the caller.
         */
        private static bool ProcessMenuChoice()
        {
            return Enum.TryParse(Console.ReadLine(), out MenuOption choice)
                ? HandleMenuOption(choice)
                : HandleInvalidInput();
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * ROUTE TO HANDLERS
         * -------------------------------------------------------------------------------------------------
         * Central switch that translates a valid menu option into the associated operation.
         * Each operation is wrapped in its own try/catch to keep failures isolated and messages precise.
         */
        private static bool HandleMenuOption(MenuOption choice)
        {
            switch (choice)
            {
                case MenuOption.Create:
                    CreateCustomer();
                    return true;

                case MenuOption.ViewAll:
                    ViewAllCustomers();
                    return true;

                case MenuOption.Update:
                    UpdateCustomer();
                    return true;

                case MenuOption.Delete:
                    DeleteCustomer();
                    return true;

                case MenuOption.Exit:
                    Console.WriteLine("Thank you for using the system!");
                    return false;

                default:
                    // Should never hit default due to enum parsing, but keep it defensive.
                    return HandleInvalidInput();
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * INPUT HELPER: CUSTOMER ID
         * -------------------------------------------------------------------------------------------------
         * Prompts the user with a message and tries to parse an integer.
         * Returns:
         *   • int? with value if parsing succeeded
         *   • null if parsing failed (caller decides what to do on failure)
         *
         * Reason to return nullable instead of throwing:
         *   • Parsing invalid input is a common/expected event in console apps;
         *     we avoid using exceptions for normal control flow.
         */
        private static int? GetValidCustomerId(string prompt)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out int id) ? id : (int?)null;
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * INPUT HELPER: CUSTOMER DETAILS
         * -------------------------------------------------------------------------------------------------
         * Collects Name and Email from the console and performs basic validation:
         *   • Non-empty strings are required for both
         *   • Trims whitespace at boundaries
         *
         * Throws:
         *   • ArgumentException when required values are not provided.
         *     (Caller will catch and display the message.)
         *
         * NOTE:
         *   • This method does not validate email format rigorously; that’s intentional for brevity.
         *     If needed, add a regex or dedicated validator here.
         */
        private static Customer GetCustomerDetails(int? id = null)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine()?.Trim();

            Console.Write("Email: ");
            var email = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Name and email are required.");
            }

            return new Customer
            {
                Id = id ?? 0,  // For Create we don’t use Id; for Update we pass the existing Id.
                Name = name,
                Email = email
            };
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * CREATE FLOW
         * -------------------------------------------------------------------------------------------------
         * 1) Prompt for details.
         * 2) Call DatabaseService.CreateCustomer().
         * 3) Print the newly generated ID (from OUTPUT INSERTED.Id).
         *
         * Errors are caught and displayed as user-friendly messages.
         */
        private static void CreateCustomer()
        {
            try
            {
                Console.WriteLine("\nCreate New Customer");
                var customer = GetCustomerDetails();
                var id = _dbService.CreateCustomer(customer);
                Console.WriteLine($"Customer created successfully with ID: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating customer: {ex.Message}");
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * READ ALL FLOW
         * -------------------------------------------------------------------------------------------------
         * Fetches all customers (ordered by Id) and prints a formatted table.
         * If no rows exist, informs the user explicitly.
         */
        private static void ViewAllCustomers()
        {
            try
            {
                var customers = _dbService.GetAllCustomers();
                DisplayCustomers(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving customers: {ex.Message}");
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * TABLE RENDERING
         * -------------------------------------------------------------------------------------------------
         * • Prints a simple ASCII table with fixed-width columns.
         * • Uses alignment specifiers (e.g., {value,-20}) for readable columns.
         * • "g" format on CreatedAt gives a concise “general” date/time display.
         */
        private static void DisplayCustomers(IEnumerable<Customer> customers)
        {
            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }

            Console.WriteLine("\nCustomer List:");
            Console.WriteLine("".PadRight(80, '='));
            Console.WriteLine($"{"ID",-4} {"Name",-20} {"Email",-30} {"Created",-20}");
            Console.WriteLine("".PadRight(80, '-'));

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id,-4} {customer.Name,-20} {customer.Email,-30} {customer.CreatedAt,-20:g}");
            }

            Console.WriteLine("".PadRight(80, '='));
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * UPDATE FLOW
         * -------------------------------------------------------------------------------------------------
         * 1) Ask for a valid Id (nullable parsing used; exit early on invalid).
         * 2) Prompt for new Name/Email (required).
         * 3) Call DatabaseService.UpdateCustomer(); report success/failure.
         *
         * Notes:
         *  • We don’t fetch the existing record for display here (kept simple).
         *  • In a richer UI, you could first show current values, then prompt for changes.
         */
        private static void UpdateCustomer()
        {
            try
            {
                var id = GetValidCustomerId("\nEnter customer ID to update: ");
                if (!id.HasValue)
                {
                    Console.WriteLine("Invalid ID provided.");
                    return;
                }

                var customer = GetCustomerDetails(id.Value);
                var success = _dbService.UpdateCustomer(customer);
                Console.WriteLine(success
                    ? "Customer updated successfully!"
                    : "Update failed. Customer not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating customer: {ex.Message}");
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * DELETE FLOW
         * -------------------------------------------------------------------------------------------------
         * 1) Ask for a valid Id.
         * 2) Confirm intent to delete (y/n).
         * 3) Call DatabaseService.DeleteCustomer(); report success/failure.
         *
         * Safety:
         *  • A confirmation gate (“Are you sure?”) helps prevent accidental deletes.
         */
        private static void DeleteCustomer()
        {
            try
            {
                var id = GetValidCustomerId("\nEnter customer ID to delete: ");
                if (!id.HasValue)
                {
                    Console.WriteLine("Invalid ID provided.");
                    return;
                }

                Console.Write($"Are you sure you want to delete customer {id}? (y/n): ");
                if (Console.ReadLine()?.Trim().ToLower() != "y")
                {
                    Console.WriteLine("Delete cancelled.");
                    return;
                }

                var success = _dbService.DeleteCustomer(id.Value);
                Console.WriteLine(success
                    ? "Customer deleted successfully!"
                    : "Delete failed. Customer not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
            }
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * INVALID INPUT HANDLER
         * -------------------------------------------------------------------------------------------------
         * Single place to respond to invalid menu selections. Returning true
         * means "keep the application loop running".
         */
        private static bool HandleInvalidInput()
        {
            Console.WriteLine("Invalid option! Please enter a number between 1 and 5.");
            WaitForKeyPress();
            return true;
        }

        /*
         * -------------------------------------------------------------------------------------------------
         * UX HELPER: PAUSE
         * -------------------------------------------------------------------------------------------------
         * Gives the user a chance to read output before the next screen refresh.
         * Using Console.ReadKey(true) avoids echoing the pressed key to the console.
         */
        private static void WaitForKeyPress()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
