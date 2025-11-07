using System.Data.SqlClient;
using SampleCrudOperations.Models;

namespace SampleCrudOperations.Services
{
    /// <summary>
    /// Handles all database operations for the Customer table
    /// Implements CRUD operations using ADO.NET and async/await pattern
    /// </summary>
    public class DatabaseService
    {
        /*
         * Connection string is stored as a private readonly field
         * This ensures it can't be modified after initialization
         * and is only accessible within this class
         */
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /*
         * CreateCustomerAsync
         * ==================
         * Purpose: Inserts a new customer record into the database
         * 
         * Process:
         * 1. Creates a new database connection
         * 2. Opens the connection asynchronously
         * 3. Prepares SQL command with parameters to prevent SQL injection
         * 4. Executes the command and retrieves the new ID
         * 
         * Returns: The ID of the newly created customer
         * 
         * Note: SCOPE_IDENTITY() is used to get the last inserted ID safely
         * in a concurrent environment
         */
        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            // Create and open connection asynchronously
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            // SQL command with parameterized query
            const string sql = @"
                INSERT INTO Customers (Name, Email, CreatedAt) 
                VALUES (@Name, @Email, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            // Create command and add parameters
            using var command = new SqlCommand(sql, connection);


            /*
             * Parameter Usage Example:
             * =======================
             * 1. @Name - NVarChar type for Unicode text
             *    - Handles special characters in names
             *    - Prevents SQL injection
             * 
             * 2. @Email - NVarChar type for email addresses
             *    - Safely handles special characters like '@' and '.'
             * 
             * 3. @CreatedAt - DateTime2 for precise timestamp
             *    - Ensures accurate date/time storage
             */
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            // Alternative approach with explicit types:
            /*
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Name",
                SqlDbType = SqlDbType.NVarChar,
                Size = 100,
                Value = customer.Name
            });
            */

            // Execute and get the new ID
            var id = Convert.ToInt32(await command.ExecuteScalarAsync());
            return id;

        }

        /*
         * GetAllCustomersAsync
         * ===================
         * Purpose: Retrieves all customers from the database
         * 
         * Process:
         * 1. Creates and opens database connection
         * 2. Executes SELECT query
         * 3. Uses DataReader to efficiently read results
         * 4. Maps database records to Customer objects
         * 
         * Returns: List of Customer objects
         * 
         * Note: Uses forward-only, read-only DataReader for optimal performance
         */
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "SELECT Id, Name, Email, CreatedAt FROM Customers";
            using var command = new SqlCommand(sql, connection);

            var customers = new List<Customer>();

            // ExecuteReaderAsync is used for SELECT queries
            using var reader = await command.ExecuteReaderAsync();

            // Read each row and map to Customer object
            while (await reader.ReadAsync())
            {
                customers.Add(new Customer
                {
                    Id = reader.GetInt32(0),        // Column index 0: Id
                    Name = reader.GetString(1),      // Column index 1: Name
                    Email = reader.GetString(2),     // Column index 2: Email
                    CreatedAt = reader.GetDateTime(3)// Column index 3: CreatedAt
                });
            }

            return customers;
        }

        /*
         * UpdateCustomerAsync
         * ==================
         * Purpose: Updates an existing customer's information
         * 
         * Process:
         * 1. Creates and opens connection
         * 2. Prepares UPDATE command with parameters
         * 3. Executes the command
         * 
         * Returns: Boolean indicating success (true) or failure (false)
         * 
         * Note: ExecuteNonQueryAsync is used for UPDATE operations
         * The return value > 0 indicates at least one row was affected
         */
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            /*
            * Parameter Safety and Performance
            * ==============================
            * 1. SQL Injection Prevention:
            *    Bad:  "UPDATE Customers SET Name = '" + name + "'"
            *    Good: "UPDATE Customers SET Name = @Name"
            * 
            * 2. Query Plan Caching:
            *    - Parameterized queries enable plan reuse
            *    - Improves performance for repeated executions
            * 
            * 3. Type Safety:
            *    - Parameters ensure proper type conversion
            *    - Prevents format-related errors
            */
            const string sql = @"
                UPDATE Customers 
                SET Name = @Name, Email = @Email 
                WHERE Id = @Id";

            using var command = new SqlCommand(sql, connection);

            /*
             * Parameter Type Examples:
             * ======================
             * 1. Integer Parameter (Id):
             *    - Used for primary key
             *    - Direct numeric comparison
             * 
             * 2. String Parameters (Name, Email):
             *    - Unicode support for international characters
             *    - Automatic escaping of special characters
             */
            command.Parameters.AddWithValue("@Id", customer.Id);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Email", customer.Email);

            // Returns true if any rows were affected
            return await command.ExecuteNonQueryAsync() > 0;


        }

        /*
         * DeleteCustomerAsync
         * ==================
         * Purpose: Removes a customer record from the database
         * 
         * Process:
         * 1. Creates and opens connection
         * 2. Prepares DELETE command with ID parameter
         * 3. Executes the command
         * 
         * Returns: Boolean indicating success (true) or failure (false)
         * 
         * Note: Uses parameterized query to prevent SQL injection
         * Returns true if a record was actually deleted
         */
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            /*
             * Simple Parameter Usage
             * ====================
             * Even for simple queries, parameters are crucial:
             * 1. Security:
             *    - Prevents SQL injection even for numeric values
             *    - Validates input type
             * 
             * 2. Query Plan:
             *    - Enables plan caching
             *    - Improves performance
             * 
             * 3. Code Consistency:
             *    - Maintains consistent coding style
             *    - Improves maintainability
             */
            const string sql = "DELETE FROM Customers WHERE Id = @Id";
            using var command = new SqlCommand(sql, connection);

            // Numeric parameter for ID
            command.Parameters.AddWithValue("@Id", id);

            // Alternative with explicit type:
            /*
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Value = id
            });
            */

            // Returns true if any rows were affected
            return await command.ExecuteNonQueryAsync() > 0;


        }
    }
}