# Introduction to ADO.NET

A simple console application demonstrating basic ADO.NET functionality for database operations.

## Project Overview

This project shows how to:
- Connect to a SQL Server database
- Execute SQL queries
- Read data from database
- Map database records to C# objects
- Handle database operations safely

## Prerequisites

- .NET 6.0 SDK
- SQL Server (Local or Express)
- Visual Studio Code or Visual Studio 2022
- SQL Server Management Studio (SSMS) - Optional

## Required NuGet Packages

```xml
<PackageReference Include="System.Data.SqlClient" Version="4.9.0" />
```

## Database Setup

1. Create a new database named `TestDatabase`
2. Execute the following SQL script:

```sql
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL
);

-- Insert sample data
INSERT INTO Customers (Name, Surname) VALUES 
('John', 'Doe'),
('Jane', 'Smith');
```

## Configuration

The application uses the following connection string:
```csharp
```csharp
// For SQL Server
"Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True;Encrypt=False"

// For LocalDB
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True;Encrypt=False"
```
```

Modify the connection string in `Program.cs` if your setup differs.

## Project Structure

```
IntroductionToAdoNet/
├── Models/
│   └── Customer.cs       # Customer entity model
├── Program.cs           # Main program with database operations
├── README.md           # This file
└── IntroductionToAdoNet.csproj
```

## Running the Application

1. Open terminal in Visual Studio Code
2. Navigate to the project directory:
```bash
cd ConsoleAppsWithAdoNet/Week46/IntroductionToAdoNet
```
3. Run the application:
```bash
dotnet run
```

## Features

- Database connection management
- Basic CRUD operations
- Error handling
- Object mapping
- Resource cleanup

## Best Practices Demonstrated

- Using `using` statements for resource disposal
- Proper exception handling
- Connection string management
- Data mapping patterns
- Code organization and documentation

## Common Issues

1. **Connection Failed**
   - Verify SQL Server is running
   - Check connection string
   - Ensure Windows Authentication is enabled

2. **Table Not Found**
   - Verify database exists
   - Check if Customers table was created
   - Confirm user permissions

## Contributing

1. Fork the project
2. Create a feature branch
3. Commit changes
4. Push to the branch
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.