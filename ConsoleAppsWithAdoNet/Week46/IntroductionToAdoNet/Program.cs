using IntroductionToAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace IntroductionToAdoNet;

internal class Program
{
    static void Main(string[] args)
    {
        /*
         * ADO.NET Database Connection Example
         * ==================================
         * This example demonstrates basic ADO.NET functionality including:
         * 1. Establishing a database connection
         * 2. Executing a SQL query
         * 3. Reading data from the database
         * 4. Mapping database records to C# objects
         */

        Console.WriteLine("Hello, World - Ado Net!");

        /*
         * Connection String Components:
         * - Data Source: Specifies the server name ('.' means local server)
         * - Initial Catalog: The database name
         * - Integrated Security: Uses Windows authentication
         * - Encrypt: Disabled for development/testing purposes
         */
        var connectionString = "Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True;Encrypt=False";

        /*
         * The 'using' statement ensures that the connection is properly disposed
         * This is important for managing database resources effectively
         */
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                /*
                 * Opening the Database Connection
                 * ==============================
                 * This establishes the actual connection to the database
                 * If the connection fails, it will throw an exception
                 */
                connection.Open();
                Console.WriteLine("Connection to database established successfully.");

                /*
                 * SQL Query and Command
                 * ====================
                 * - Creates a simple SELECT query to retrieve all customers
                 * - SqlCommand represents the SQL statement to be executed
                 */
                var sqlQuery = "SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                /*
                 * Data Reading Process
                 * ===================
                 * SqlDataReader provides a way of reading a forward-only stream of rows
                 * from the database. It's more efficient than loading all data at once.
                 */
                SqlDataReader reader = command.ExecuteReader();

                /*
                 * Data Storage
                 * ============
                 * Creating an array to store Customer objects
                 * Size is set to 2 assuming we know the number of customers
                 * In real applications, you'd typically use a List<T> for dynamic sizing
                 */
                var customers = new Customer[2];

                /*
                 * Reading and Mapping Data
                 * =======================
                 * While loop continues as long as there are rows to read
                 * Each iteration processes one customer record
                 */
                while (reader.Read())
                {
                    /*
                     * Two ways to access data:
                     * 1. Using column names: reader["ColumnName"]
                     * 2. Using column indices: reader.GetXXX(index)
                     * 
                     * First approach is more readable but slightly slower
                     * Second approach is faster but requires knowing column order
                     */
                    var customerId = reader["Id"];
                    var customerName = reader["Name"];
                    var customerSurname = reader["Surname"];

                    // Display the retrieved data
                    Console.WriteLine($"Customer ID: {customerId}, Name: {customerName}, Surname: {customerSurname}");

                    /*
                     * Object Mapping
                     * ==============
                     * Creating a new Customer object and populating its properties
                     * Using GetXXX methods for type-safe data access
                     */
                    var customer = new Customer
                    {
                        Id = reader.GetInt32(0),      // First column: Id
                        Name = reader.GetString(1),    // Second column: Name
                        Surname = reader.GetString(2)  // Third column: Surname
                    };

                    // Store the customer object in the array
                    // Subtracting 1 from Id to convert to zero-based array index
                    customers[customer.Id - 1] = customer;

                    // Additional console write to confirm object mapping
                    Console.WriteLine($"Mapped Customer Object: {customer.Id}, {customer.Name}, {customer.Surname}");
                }
            }
            catch (Exception ex)
            {
                /*
                 * Error Handling
                 * ==============
                 * In a production environment, you should:
                 * 1. Log the exception
                 * 2. Handle specific SQL exceptions differently
                 * 3. Provide user-friendly error messages
                 */
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Re-throwing for now, but should be properly handled in production
            }
        } // Connection is automatically closed when the using block ends
    }
}
