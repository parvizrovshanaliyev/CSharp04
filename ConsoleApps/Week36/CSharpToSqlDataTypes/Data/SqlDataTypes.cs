using CSharpToSqlDataTypes.Models;
using CSharpToSqlDataTypes.Enums;

namespace CSharpToSqlDataTypes.Data
{
    public static class SqlDataTypes
    {
        public static Dictionary<SqlDataType, DataTypeInfo> GetAllDataTypes()
        {
            var dataTypes = new Dictionary<SqlDataType, DataTypeInfo>();

            // Exact Numeric Types
            dataTypes[SqlDataType.Int] = new DataTypeInfo
            {
                Name = "INT",
                Category = "Exact Numeric Types",
                Size = "4 bytes",
                Range = "-2,147,483,648 to 2,147,483,647",
                Description = "Integer data from -2,147,483,648 to 2,147,483,647. Most commonly used integer type.",
                DefaultValue = "0",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "INT",
                UsageExamples = new[] { "CREATE TABLE Users (Id INT PRIMARY KEY);", "Age INT NOT NULL;" },
                BestPractices = new[] { "Use for integer values", "Good for primary keys and foreign keys" },
                Warnings = new[] { "Overflow can occur with large calculations", "Consider BIGINT for very large numbers" }
            };

            dataTypes[SqlDataType.BigInt] = new DataTypeInfo
            {
                Name = "BIGINT",
                Category = "Exact Numeric Types",
                Size = "8 bytes",
                Range = "-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807",
                Description = "Integer data from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.",
                DefaultValue = "0",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "BIGINT",
                UsageExamples = new[] { "CREATE TABLE Files (Id BIGINT PRIMARY KEY);", "FileSize BIGINT;" },
                BestPractices = new[] { "Use for very large integer values", "Good for file sizes and timestamps" },
                Warnings = new[] { "Overflow can still occur", "Uses more storage than INT" }
            };

            dataTypes[SqlDataType.Decimal] = new DataTypeInfo
            {
                Name = "DECIMAL",
                Category = "Exact Numeric Types",
                Size = "Variable (5-17 bytes)",
                Range = "-10^38 + 1 to 10^38 - 1",
                Description = "Fixed precision and scale numeric data. Used for financial calculations.",
                DefaultValue = "0",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "DECIMAL(p,s)",
                UsageExamples = new[] { "CREATE TABLE Prices (Amount DECIMAL(10,2));", "Balance DECIMAL(18,4);" },
                BestPractices = new[] { "Use for financial calculations", "Specify precision and scale" },
                Warnings = new[] { "Slower than FLOAT", "Limited range compared to FLOAT" }
            };

            // Approximate Numeric Types
            dataTypes[SqlDataType.Float] = new DataTypeInfo
            {
                Name = "FLOAT",
                Category = "Approximate Numeric Types",
                Size = "8 bytes",
                Range = "-1.79E + 308 to 1.79E + 308",
                Description = "Floating precision number data. Used for scientific calculations.",
                DefaultValue = "0",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "FLOAT",
                UsageExamples = new[] { "CREATE TABLE Measurements (Value FLOAT);", "Temperature FLOAT;" },
                BestPractices = new[] { "Use for scientific calculations", "Good for approximate values" },
                Warnings = new[] { "Not suitable for financial calculations", "Precision issues with some values" }
            };

            // Character String Types
            dataTypes[SqlDataType.VarChar] = new DataTypeInfo
            {
                Name = "VARCHAR",
                Category = "Character String Types",
                Size = "Variable (1 to 8,000 characters)",
                Range = "1 to 8,000 characters",
                Description = "Variable-length character string. Most commonly used string type.",
                DefaultValue = "NULL",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "VARCHAR(n)",
                UsageExamples = new[] { "CREATE TABLE Users (Name VARCHAR(100));", "Email VARCHAR(255);" },
                BestPractices = new[] { "Use for variable-length strings", "Specify appropriate length" },
                Warnings = new[] { "Truncation can occur", "Use NVARCHAR for Unicode support" }
            };

            dataTypes[SqlDataType.NVarChar] = new DataTypeInfo
            {
                Name = "NVARCHAR",
                Category = "Character String Types",
                Size = "Variable (1 to 4,000 characters)",
                Range = "1 to 4,000 characters",
                Description = "Variable-length Unicode character string. Supports international characters.",
                DefaultValue = "NULL",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "NVARCHAR(n)",
                UsageExamples = new[] { "CREATE TABLE Users (Name NVARCHAR(100));", "Description NVARCHAR(500);" },
                BestPractices = new[] { "Use for international text", "Good for Unicode support" },
                Warnings = new[] { "Uses more storage than VARCHAR", "Limited to 4000 characters" }
            };

            // Date and Time Types
            dataTypes[SqlDataType.DateTime] = new DataTypeInfo
            {
                Name = "DATETIME",
                Category = "Date and Time Types",
                Size = "8 bytes",
                Range = "January 1, 1753 to December 31, 9999",
                Description = "Date and time data. Legacy type with limited range.",
                DefaultValue = "1900-01-01 00:00:00",
                IsNullable = true,
                IsCommonlyUsed = false,
                DeclarationSyntax = "DATETIME",
                UsageExamples = new[] { "CREATE TABLE Events (CreatedDate DATETIME);", "UpdatedDate DATETIME;" },
                BestPractices = new[] { "Consider DATETIME2 instead", "Use for legacy compatibility" },
                Warnings = new[] { "Limited date range", "Deprecated in favor of DATETIME2" }
            };

            dataTypes[SqlDataType.DateTime2] = new DataTypeInfo
            {
                Name = "DATETIME2",
                Category = "Date and Time Types",
                Size = "6-8 bytes",
                Range = "January 1, 0001 to December 31, 9999",
                Description = "Date and time data with higher precision. Recommended for new applications.",
                DefaultValue = "1900-01-01 00:00:00",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "DATETIME2",
                UsageExamples = new[] { "CREATE TABLE Events (CreatedDate DATETIME2);", "UpdatedDate DATETIME2;" },
                BestPractices = new[] { "Use for new applications", "Good for high precision" },
                Warnings = new[] { "Not backward compatible with DATETIME", "Slightly larger storage" }
            };

            // Boolean Type
            dataTypes[SqlDataType.Bit] = new DataTypeInfo
            {
                Name = "BIT",
                Category = "Boolean Type",
                Size = "1 byte",
                Range = "0, 1, or NULL",
                Description = "Boolean data type. Stores 0, 1, or NULL.",
                DefaultValue = "0",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "BIT",
                UsageExamples = new[] { "CREATE TABLE Users (IsActive BIT);", "IsDeleted BIT;" },
                BestPractices = new[] { "Use for boolean values", "Good for flags" },
                Warnings = new[] { "Stores 0/1, not true/false", "Cannot store more than 8 bits efficiently" }
            };

            // Unique Identifier Type
            dataTypes[SqlDataType.UniqueIdentifier] = new DataTypeInfo
            {
                Name = "UNIQUEIDENTIFIER",
                Category = "Unique Identifier Type",
                Size = "16 bytes",
                Range = "Any valid GUID",
                Description = "Globally unique identifier (GUID).",
                DefaultValue = "NULL",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "UNIQUEIDENTIFIER",
                UsageExamples = new[] { "CREATE TABLE Users (Id UNIQUEIDENTIFIER PRIMARY KEY);", "SessionId UNIQUEIDENTIFIER;" },
                BestPractices = new[] { "Use for unique identifiers", "Good for distributed systems" },
                Warnings = new[] { "Large size (16 bytes)", "Not suitable for sequential IDs" }
            };

            return dataTypes;
        }

        public static Dictionary<string, SqlDataType[]> GetDataTypesByCategory()
        {
            return new Dictionary<string, SqlDataType[]>
            {
                ["Exact Numeric Types"] = new[] { SqlDataType.Int, SqlDataType.BigInt, SqlDataType.Decimal },
                ["Approximate Numeric Types"] = new[] { SqlDataType.Float },
                ["Character String Types"] = new[] { SqlDataType.VarChar, SqlDataType.NVarChar },
                ["Date and Time Types"] = new[] { SqlDataType.DateTime, SqlDataType.DateTime2 },
                ["Boolean Type"] = new[] { SqlDataType.Bit },
                ["Unique Identifier Type"] = new[] { SqlDataType.UniqueIdentifier }
            };
        }
    }
} 