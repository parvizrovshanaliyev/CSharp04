using CSharpToSqlDataTypes.Models;
using CSharpToSqlDataTypes.Enums;

namespace CSharpToSqlDataTypes.Data
{
    /// <summary>
    /// Provides comprehensive data about C# data types including size, range, examples, and best practices.
    /// This class serves as a data source for the C# to SQL Data Types learning application.
    /// </summary>
    public static class CSharpDataTypes
    {
        /// <summary>
        /// Gets all C# data type information as a dictionary for easy lookup.
        /// </summary>
        /// <returns>A dictionary containing all C# data type information.</returns>
        public static Dictionary<CSharpDataType, DataTypeInfo> GetAllDataTypes()
        {
            var dataTypes = new Dictionary<CSharpDataType, DataTypeInfo>();

            // Integral Types
            dataTypes[CSharpDataType.Int] = new DataTypeInfo
            {
                Name = "int",
                Category = "Integral Types",
                Size = "4 bytes",
                Range = "-2,147,483,648 to 2,147,483,647",
                Description = "32-bit signed integer type. The most commonly used integer type in C#.",
                DefaultValue = "0",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "int variableName = 0;",
                UsageExamples = new[] { "int age = 25;", "int count = 1000000;" },
                BestPractices = new[] { "Default choice for integer values", "Good balance of range and performance" },
                Warnings = new[] { "Overflow can occur with large calculations", "Consider long for very large numbers" }
            };

            dataTypes[CSharpDataType.Long] = new DataTypeInfo
            {
                Name = "long",
                Category = "Integral Types",
                Size = "8 bytes",
                Range = "-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807",
                Description = "64-bit signed integer type. Used for very large numbers.",
                DefaultValue = "0",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "long variableName = 0L;",
                UsageExamples = new[] { "long fileSize = 9223372036854775807L;", "long timestamp = 1640995200000L;" },
                BestPractices = new[] { "Use for very large integer values", "Good for file sizes and timestamps" },
                Warnings = new[] { "Overflow can still occur", "Slightly slower than int" }
            };

            dataTypes[CSharpDataType.Short] = new DataTypeInfo
            {
                Name = "short",
                Category = "Integral Types",
                Size = "2 bytes",
                Range = "-32,768 to 32,767",
                MinValue = "-32768",
                MaxValue = "32767",
                Description = "16-bit signed integer type. Used for medium-sized signed numbers.",
                DefaultValue = "0",
                IsNullable = false,
                IsCommonlyUsed = false,
                DeclarationSyntax = "short variableName = 0;",
                PerformanceNotes = "Efficient for medium-sized signed integers.",
                UsageExamples = new[]
                {
                    "short year = 2024;",
                    "short temperature = -273;",
                    "short score = 32000;"
                },
                BestPractices = new[]
                {
                    "Use for medium-sized signed integers",
                    "Good for memory optimization when range is known",
                    "Consider int for general-purpose integer storage"
                },
                Warnings = new[]
                {
                    "Limited range compared to int",
                    "Not commonly used in modern applications",
                    "Consider int for better compatibility"
                }
            };

            dataTypes[CSharpDataType.Byte] = new DataTypeInfo
            {
                Name = "byte",
                Category = "Integral Types",
                Size = "1 byte",
                Range = "0 to 255",
                MinValue = "0",
                MaxValue = "255",
                Description = "8-bit unsigned integer type. Used for small positive numbers and binary data.",
                DefaultValue = "0",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "byte variableName = 0;",
                PerformanceNotes = "Efficient for small unsigned integers and binary data.",
                UsageExamples = new[]
                {
                    "byte age = 25;",
                    "byte[] imageData = new byte[1024];",
                    "byte flags = 0x0F;"
                },
                BestPractices = new[]
                {
                    "Use for small positive integers (0 to 255)",
                    "Excellent for binary data and flags",
                    "Good for memory optimization"
                },
                Warnings = new[]
                {
                    "Limited range - overflow can occur",
                    "Cannot store negative values",
                    "Consider int for general-purpose integer storage"
                }
            };

            // Floating-Point Types
            dataTypes[CSharpDataType.Double] = new DataTypeInfo
            {
                Name = "double",
                Category = "Floating-Point Types",
                Size = "8 bytes",
                Range = "±5.0 × 10^−324 to ±1.7 × 10^308",
                Description = "64-bit double-precision floating-point type. Default for decimal numbers in C#.",
                DefaultValue = "0.0",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "double variableName = 0.0;",
                UsageExamples = new[] { "double pi = 3.141592653589793;", "double temperature = 98.6;" },
                BestPractices = new[] { "Default choice for decimal numbers", "Good for scientific calculations" },
                Warnings = new[] { "Not suitable for financial calculations", "Use decimal for monetary values" }
            };

            dataTypes[CSharpDataType.Decimal] = new DataTypeInfo
            {
                Name = "decimal",
                Category = "Floating-Point Types",
                Size = "16 bytes",
                Range = "±1.0 × 10^−28 to ±7.9 × 10^28",
                Description = "128-bit decimal type. Used for financial calculations and high-precision decimal arithmetic.",
                DefaultValue = "0.0m",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "decimal variableName = 0.0m;",
                UsageExamples = new[] { "decimal price = 19.99m;", "decimal interest = 0.0525m;" },
                BestPractices = new[] { "Use for financial calculations", "Good for high-precision decimal arithmetic" },
                Warnings = new[] { "Slower than double", "Limited range compared to double" }
            };

            dataTypes[CSharpDataType.Float] = new DataTypeInfo
            {
                Name = "float",
                Category = "Floating-Point Types",
                Size = "4 bytes",
                Range = "±1.5 × 10^−45 to ±3.4 × 10^38",
                Precision = "7 digits",
                Description = "32-bit single-precision floating-point type. Used for decimal numbers with moderate precision.",
                DefaultValue = "0.0f",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "float variableName = 0.0f;",
                PerformanceNotes = "Faster than double but less precise.",
                UsageExamples = new[]
                {
                    "float temperature = 98.6f;",
                    "float pi = 3.14159f;",
                    "float price = 19.99f;"
                },
                BestPractices = new[]
                {
                    "Use for decimal numbers with moderate precision",
                    "Good for performance-critical applications",
                    "Use f suffix for clarity"
                },
                Warnings = new[]
                {
                    "Limited precision compared to double",
                    "Not suitable for financial calculations",
                    "Use decimal for monetary values"
                }
            };

            // Character and String Types
            dataTypes[CSharpDataType.String] = new DataTypeInfo
            {
                Name = "string",
                Category = "String Types",
                Size = "Variable (reference type)",
                Range = "0 to 2,147,483,647 characters",
                Description = "Reference type for sequences of Unicode characters. Immutable by default.",
                DefaultValue = "null",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "string variableName = \"Hello\";",
                UsageExamples = new[] { "string name = \"John Doe\";", "string message = \"Hello, World!\";" },
                BestPractices = new[] { "Use for text data", "Consider StringBuilder for frequent modifications" },
                Warnings = new[] { "Immutable - modifications create new objects", "Can be null" }
            };

            dataTypes[CSharpDataType.Char] = new DataTypeInfo
            {
                Name = "char",
                Category = "Character Types",
                Size = "2 bytes",
                Range = "U+0000 to U+FFFF",
                Description = "16-bit Unicode character type. Used for single characters.",
                DefaultValue = "'\\0'",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "char variableName = 'A';",
                PerformanceNotes = "Efficient for single character storage.",
                UsageExamples = new[]
                {
                    "char grade = 'A';",
                    "char symbol = '€';",
                    "char newline = '\\n';"
                },
                BestPractices = new[]
                {
                    "Use for single Unicode characters",
                    "Good for character-based operations",
                    "Use single quotes for char literals"
                },
                Warnings = new[]
                {
                    "Limited to single characters",
                    "Use string for multiple characters",
                    "Be aware of Unicode encoding"
                }
            };

            // Boolean Type
            dataTypes[CSharpDataType.Bool] = new DataTypeInfo
            {
                Name = "bool",
                Category = "Boolean Type",
                Size = "1 byte",
                Range = "true or false",
                Description = "Boolean type representing true or false values.",
                DefaultValue = "false",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "bool variableName = false;",
                UsageExamples = new[] { "bool isActive = true;", "bool isValid = false;" },
                BestPractices = new[] { "Use for logical true/false values", "Good for conditional logic" },
                Warnings = new[] { "Cannot be null", "Cannot be converted to 0/1 automatically" }
            };

            // DateTime Types
            dataTypes[CSharpDataType.DateTime] = new DataTypeInfo
            {
                Name = "DateTime",
                Category = "DateTime Types",
                Size = "8 bytes",
                Range = "January 1, 0001 to December 31, 9999",
                Description = "Represents a point in time, typically expressed as a date and time of day.",
                DefaultValue = "DateTime.MinValue",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "DateTime variableName = DateTime.Now;",
                UsageExamples = new[] { "DateTime now = DateTime.Now;", "DateTime birthday = new DateTime(1990, 5, 15);" },
                BestPractices = new[] { "Use for date and time values", "Consider DateTimeOffset for timezone awareness" },
                Warnings = new[] { "No timezone information", "Use DateTimeOffset for timezone-aware applications" }
            };

            dataTypes[CSharpDataType.Guid] = new DataTypeInfo
            {
                Name = "Guid",
                Category = "Guid Type",
                Size = "16 bytes",
                Range = "Any valid GUID",
                Description = "Represents a globally unique identifier (GUID).",
                DefaultValue = "Guid.Empty",
                IsNullable = false,
                IsCommonlyUsed = true,
                DeclarationSyntax = "Guid variableName = Guid.NewGuid();",
                UsageExamples = new[] { "Guid id = Guid.NewGuid();", "Guid sessionId = Guid.Parse(\"12345678-1234-1234-1234-123456789012\");" },
                BestPractices = new[] { "Use for unique identifiers", "Good for database primary keys" },
                Warnings = new[] { "Large size (16 bytes)", "Not suitable for sequential IDs" }
            };

            // Nullable Types
            dataTypes[CSharpDataType.NullableInt] = new DataTypeInfo
            {
                Name = "int?",
                Category = "Nullable Types",
                Size = "4 bytes + 1 byte (nullable overhead)",
                Range = "-2,147,483,648 to 2,147,483,647 or null",
                Description = "Nullable integer type that can also be null.",
                DefaultValue = "null",
                IsNullable = true,
                IsCommonlyUsed = true,
                DeclarationSyntax = "int? variableName = null;",
                PerformanceNotes = "Slight overhead compared to non-nullable int.",
                UsageExamples = new[]
                {
                    "int? age = null;",
                    "int? score = 100;",
                    "int? result = GetNullableValue();"
                },
                BestPractices = new[]
                {
                    "Use when value can be null",
                    "Good for optional parameters",
                    "Use null-coalescing operator (??) for defaults"
                },
                Warnings = new[]
                {
                    "Slight performance overhead",
                    "Must check for null before use",
                    "Use non-nullable when possible"
                }
            };

            return dataTypes;
        }

        /// <summary>
        /// Gets C# data types grouped by category.
        /// </summary>
        /// <returns>A dictionary containing C# data types grouped by category.</returns>
        public static Dictionary<string, CSharpDataType[]> GetDataTypesByCategory()
        {
            return new Dictionary<string, CSharpDataType[]>
            {
                ["Integral Types"] = new[] { CSharpDataType.Int, CSharpDataType.Long },
                ["Floating-Point Types"] = new[] { CSharpDataType.Double, CSharpDataType.Decimal },
                ["String Types"] = new[] { CSharpDataType.String },
                ["Boolean Type"] = new[] { CSharpDataType.Bool },
                ["DateTime Types"] = new[] { CSharpDataType.DateTime },
                ["Guid Type"] = new[] { CSharpDataType.Guid }
            };
        }
    }
} 