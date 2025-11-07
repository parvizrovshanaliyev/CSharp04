# Sample CRUD Operations with ADO.NET

A console application demonstrating basic CRUD (Create, Read, Update, Delete) operations using ADO.NET and SQL Server.

## Features

- Create new customers
- View all customers
- Update customer details
- Delete customers
- Async database operations
- Parameter binding for SQL injection prevention

## Prerequisites

- .NET 6.0 SDK
- SQL Server (Local or Express)
- Visual Studio Code or Visual Studio 2022

## Project Structure

```
SampleCrudOperations/
├── Database/
│   └── create-database.sql
├── Models/
│   └── Customer.cs
├── Services/
│   └── DatabaseService.cs
├── Program.cs
├── README.md
└── SampleCrudOperations.csproj
```

## Database Setup

1. Open SQL Server Management Studio
2. Connect to your local SQL Server instance
3. Execute the following SQL script:

```sql
CREATE DATABASE SampleDb;
GO

USE SampleDb;
GO

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL
);
```

## Configuration

The application uses this connection string by default:
```csharp
"Data Source=.;Initial Catalog=SampleDb;Integrated Security=True;Encrypt=False"
```

Modify in `Program.cs` if your setup differs.

## Building and Running

1. Open terminal in VS Code
2. Navigate to project directory:
```bash
cd ConsoleAppsWithAdoNet/Week46/SampleCrudOperations
```

3. Restore packages:
```bash
dotnet restore
```

4. Build the project:
```bash
dotnet build
```

5. Run the application:
```bash
dotnet run
```

## Usage

The application presents a menu-driven interface:

1. Create Customer
   - Enter name and email
   - System assigns ID automatically

2. View All Customers
   - Displays all customers in tabular format
   - Shows ID, Name, Email, and Creation Date

3. Update Customer
   - Enter customer ID
   - Provide new name and email

4. Delete Customer
   - Enter customer ID to remove

5. Exit
   - Closes the application

## Error Handling

The application includes:
- Input validation
- Database error handling
- User-friendly error messages
- Resource cleanup

## Best Practices Demonstrated

- Async/await for database operations
- Parameter binding for security
- Resource disposal with `using` statements
- Separation of concerns (Models, Services)
- Clean code architecture

## Common Issues

1. Connection Failed
   ```
   Solution: Verify SQL Server is running and connection string is correct
   ```

2. Invalid Input
   ```
   Solution: Ensure input matches required format (e.g., valid email)
   ```

3. Customer Not Found
   ```
   Solution: Verify customer ID exists before update/delete
   ```
## ADO.NET Usage Guides

### SQL Parameter Types and Usage

#### Common SQL Parameter Types:
1. `SqlDbType.NVarChar` - For Unicode string data (e.g., names, emails).
2. `SqlDbType.Int` - For integer values (e.g., IDs, counts).
3. `SqlDbType.DateTime2` - For date and time values.
4. `SqlDbType.Decimal` - For precise numeric values.
5. `SqlDbType.Bit` - For boolean values.

#### Parameter Usage Methods:
1. **AddWithValue()** - Simple but may cause performance issues.
    ```csharp
    command.Parameters.AddWithValue("@Name", "John");
    ```
2. **Add() with SqlParameter** - Provides more control over data type.
    ```csharp
    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100));
    ```
3. **CreateParameter()** - Full control over parameter properties.
    ```csharp
    var param = command.CreateParameter();
    param.ParameterName = "@Name";
    param.SqlDbType = SqlDbType.NVarChar;
    ```

#### Why Use Parameters?
- **Security**: Prevents SQL injection attacks.
- **Performance**: Enables query plan caching.
- **Data Type Safety**: Ensures proper type conversion.
- **Special Characters**: Handles special characters automatically.

---

### ADO.NET Database Operations

#### Key Components:
1. **SqlConnection**: Manages database connections.
    - Use `using` statements for automatic disposal.
    - Connection pooling is handled automatically.
    - Async operations are recommended for better scalability.

2. **SqlCommand**: Represents a SQL query or stored procedure.
    - Use parameters to prevent SQL injection.
    - Execution methods:
      - `ExecuteScalarAsync()`: For single value returns.
      - `ExecuteReaderAsync()`: For result sets.
      - `ExecuteNonQueryAsync()`: For INSERT/UPDATE/DELETE.

3. **SqlDataReader**: Efficient forward-only data reading.
    - Faster than DataSet/DataTable.
    - Memory efficient for large result sets.
    - Use `GetXXX` methods for type-safe data access.

#### Connection String Components:
- **Data Source**: Server name.
- **Initial Catalog**: Database name.
- **Integrated Security**: Windows authentication.
- **Encrypt**: SSL encryption setting.

---

### Command Execution Methods

1. **ExecuteScalarAsync()**
    - Returns a single value (first column of the first row).
    - Use cases:
      - Getting newly inserted IDs.
      - Counting records.
      - Aggregate functions (e.g., SUM, AVG).
    ```csharp
    var count = await command.ExecuteScalarAsync();
    ```

2. **ExecuteReaderAsync()**
    - Returns `SqlDataReader` for row-by-row processing.
    - Memory efficient for large results.
    - Must be disposed after use.
    ```csharp
    using var reader = await command.ExecuteReaderAsync();
    ```

3. **ExecuteNonQueryAsync()**
    - Used for commands that don't return data.
    - Returns the number of rows affected.
    - Use cases: INSERT, UPDATE, DELETE.
    ```csharp
    var rowsAffected = await command.ExecuteNonQueryAsync();
    ```

---

### Data Type Mapping

#### C# to SQL Server Type Mappings:
- `string` -> `NVARCHAR`/`VARCHAR`
- `int` -> `INT`
- `long` -> `BIGINT`
- `decimal` -> `DECIMAL`/`MONEY`
- `DateTime` -> `DATETIME2`
- `bool` -> `BIT`
- `Guid` -> `UNIQUEIDENTIFIER`

#### Parameter Size Considerations:
- Specify size for string parameters.
- Use appropriate precision for decimals.
- Consider Unicode requirements (N-types).

#### Example:
```csharp
new SqlParameter
{
     ParameterName = "@Name",
     SqlDbType = SqlDbType.NVarChar,
     Size = 100,
     Value = customerName
};
```

---

### Error Handling Best Practices

#### Common SQL Exceptions:
1. **SqlException**
    - Connection failures.
    - Constraint violations.
    - Timeout issues.

2. **InvalidOperationException**
    - Connection state issues.
    - Invalid command execution.

3. **InvalidCastException**
    - Type conversion errors.
    - Incorrect `GetXXX` method usage.

#### Handling Strategy:
```csharp
try
{
     // Database operations
}
catch (SqlException ex)
{
     // Log error details
     // Check ex.Number for specific error
}
catch (InvalidOperationException ex)
{
     // Handle operational errors
}
```

## Contributing

1. Fork the repository
2. Create feature branch
3. Commit changes
4. Push to branch
5. Create Pull Request

## License

This project is licensed under the MIT License.