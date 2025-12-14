namespace LibraryManagementSystem.Infrastructure.Data;

/// <summary>
/// Manages database connection string and configuration for ADO.NET.
/// </summary>
public static class DatabaseConfig
{
    // TODO: Update this connection string with your SQL Server details
    public static string ConnectionString { get; set; } = 
        "Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

    /// <summary>
    /// Sets the connection string.
    /// </summary>
    /// <param name="connectionString">The connection string to use.</param>
    public static void SetConnectionString(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));

        ConnectionString = connectionString;
    }
}
