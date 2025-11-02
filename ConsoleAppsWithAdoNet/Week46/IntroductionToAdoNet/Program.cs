using IntroductionToAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace IntroductionToAdoNet;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World - Ado Net!");

        var connectionString = "Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True;Encrypt=False";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection to database established successfully.");

                var sqlQuery = "SELECT * FROM Customers";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                var customers = new Customer[2];

                while (reader.Read())
                {
                    var customerId = reader["Id"];
                    var customerName = reader["Name"];
                    var customerSurname = reader["Surname"];

                    Console.WriteLine($"Customer ID: {customerId}, Name: {customerName}, Surname: {customerSurname}");

                    var customer = new Customer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2)
                    };

                    customers[customer.Id - 1] = customer;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
