using CSharpToSqlDataTypes.Models;
using CSharpToSqlDataTypes.Enums;
using CSharpToSqlDataTypes.Constants;

namespace CSharpToSqlDataTypes.Services
{
    /// <summary>
    /// Service class that handles user interface interactions and displays information
    /// in a user-friendly console format.
    /// </summary>
    public class UserInterfaceService
    {
        private readonly DataTypeComparisonService _comparisonService;

        /// <summary>
        /// Initializes a new instance of the UserInterfaceService class.
        /// </summary>
        /// <param name="comparisonService">The data type comparison service.</param>
        public UserInterfaceService(DataTypeComparisonService comparisonService)
        {
            _comparisonService = comparisonService;
        }

        /// <summary>
        /// Displays the main menu and gets user selection.
        /// </summary>
        /// <returns>The selected menu option.</returns>
        public MenuOption DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.ApplicationTitle);
            Console.WriteLine(ApplicationConstants.ApplicationSubtitle);
            Console.WriteLine(ApplicationConstants.ApplicationVersion);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("Main Menu:");
            Console.WriteLine(ApplicationConstants.MenuOption1);
            Console.WriteLine(ApplicationConstants.MenuOption2);
            Console.WriteLine(ApplicationConstants.MenuOption3);
            Console.WriteLine(ApplicationConstants.MenuOption4);
            Console.WriteLine(ApplicationConstants.MenuOption5);
            Console.WriteLine(ApplicationConstants.MenuOption6);
            Console.WriteLine(ApplicationConstants.MenuOption7);
            Console.WriteLine(ApplicationConstants.MenuOption8);
            Console.WriteLine(ApplicationConstants.MenuOption9);
            Console.WriteLine(ApplicationConstants.MenuOption10);
            Console.WriteLine(ApplicationConstants.MenuOption11);
            Console.WriteLine();

            return GetMenuChoice();
        }

        /// <summary>
        /// Displays C# data types grouped by category.
        /// </summary>
        public void DisplayCSharpDataTypes()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.CSharpDataTypesHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            var categories = _comparisonService.GetCSharpDataTypesByCategory();
            var allTypes = _comparisonService.GetAllCSharpDataTypes();

            foreach (var category in categories)
            {
                Console.WriteLine($"=== {category.Key} ===");
                Console.WriteLine();

                foreach (var dataType in category.Value)
                {
                    if (allTypes.TryGetValue(dataType, out var typeInfo))
                    {
                        Console.WriteLine($"• {typeInfo.Name}");
                        Console.WriteLine($"  Size: {typeInfo.Size}");
                        Console.WriteLine($"  Range: {typeInfo.Range}");
                        Console.WriteLine($"  Description: {typeInfo.Description}");
                        Console.WriteLine($"  Commonly Used: {(typeInfo.IsCommonlyUsed ? "Yes" : "No")}");
                        Console.WriteLine();
                    }
                }
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Displays SQL data types grouped by category.
        /// </summary>
        public void DisplaySqlDataTypes()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.SqlDataTypesHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            var categories = _comparisonService.GetSqlDataTypesByCategory();
            var allTypes = _comparisonService.GetAllSqlDataTypes();

            foreach (var category in categories)
            {
                Console.WriteLine($"=== {category.Key} ===");
                Console.WriteLine();

                foreach (var dataType in category.Value)
                {
                    if (allTypes.TryGetValue(dataType, out var typeInfo))
                    {
                        Console.WriteLine($"• {typeInfo.Name}");
                        Console.WriteLine($"  Size: {typeInfo.Size}");
                        Console.WriteLine($"  Range: {typeInfo.Range}");
                        Console.WriteLine($"  Description: {typeInfo.Description}");
                        Console.WriteLine($"  Commonly Used: {(typeInfo.IsCommonlyUsed ? "Yes" : "No")}");
                        Console.WriteLine();
                    }
                }
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Displays comprehensive comparison between C# and SQL data types.
        /// </summary>
        public void DisplayDataTypeComparison()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.ComparisonHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            var comparisons = _comparisonService.GetAllComparisons();

            foreach (var comparison in comparisons)
            {
                Console.WriteLine($"C#: {comparison.CSharpType.Name} ↔ SQL: {comparison.SqlType.Name}");
                Console.WriteLine($"Compatibility: {comparison.Compatibility}");
                Console.WriteLine($"Confidence: {comparison.ConfidenceLevel}/10");
                Console.WriteLine($"Recommended: {(comparison.IsRecommended ? "Yes" : "No")}");
                
                if (!string.IsNullOrEmpty(comparison.ConversionNotes))
                {
                    Console.WriteLine($"Notes: {comparison.ConversionNotes}");
                }

                Console.WriteLine(ApplicationConstants.ShortSeparatorLine);
                Console.WriteLine();
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Finds and displays SQL equivalents for a C# data type.
        /// </summary>
        public void FindSqlEquivalent()
        {
            Console.Clear();
            Console.WriteLine("Find SQL Equivalent for C# Data Type");
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            // Display available C# data types
            var csharpTypes = _comparisonService.GetAllCSharpDataTypes();
            Console.WriteLine("Available C# Data Types:");
            Console.WriteLine();

            var typeList = csharpTypes.Values.ToList();
            for (int i = 0; i < typeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {typeList[i].Name}");
            }

            Console.WriteLine();
            Console.Write("Enter the number of the C# data type: ");
            
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= typeList.Count)
            {
                var selectedType = typeList[choice - 1];
                var csharpEnum = csharpTypes.First(kvp => kvp.Value.Name == selectedType.Name).Key;
                
                DisplaySqlEquivalents(csharpEnum);
            }
            else
            {
                Console.WriteLine(ApplicationConstants.InvalidInputError);
                WaitForUserInput();
            }
        }

        /// <summary>
        /// Finds and displays C# equivalents for a SQL data type.
        /// </summary>
        public void FindCSharpEquivalent()
        {
            Console.Clear();
            Console.WriteLine("Find C# Equivalent for SQL Data Type");
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            // Display available SQL data types
            var sqlTypes = _comparisonService.GetAllSqlDataTypes();
            Console.WriteLine("Available SQL Data Types:");
            Console.WriteLine();

            var typeList = sqlTypes.Values.ToList();
            for (int i = 0; i < typeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {typeList[i].Name}");
            }

            Console.WriteLine();
            Console.Write("Enter the number of the SQL data type: ");
            
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= typeList.Count)
            {
                var selectedType = typeList[choice - 1];
                var sqlEnum = sqlTypes.First(kvp => kvp.Value.Name == selectedType.Name).Key;
                
                DisplayCSharpEquivalents(sqlEnum);
            }
            else
            {
                Console.WriteLine(ApplicationConstants.InvalidInputError);
                WaitForUserInput();
            }
        }

        /// <summary>
        /// Displays conversion examples between C# and SQL data types.
        /// </summary>
        public void DisplayConversionExamples()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.ConversionExamplesHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            var recommendedMappings = _comparisonService.GetRecommendedMappings();

            foreach (var mapping in recommendedMappings)
            {
                Console.WriteLine($"=== {mapping.CSharpType.Name} ↔ {mapping.SqlType.Name} ===");
                Console.WriteLine($"Compatibility: {mapping.Compatibility}");
                Console.WriteLine($"Confidence: {mapping.ConfidenceLevel}/10");
                Console.WriteLine();

                if (!string.IsNullOrEmpty(mapping.ConversionNotes))
                {
                    Console.WriteLine("Conversion Notes:");
                    Console.WriteLine(mapping.ConversionNotes);
                    Console.WriteLine();
                }

                if (mapping.CodeExamples.Length > 0)
                {
                    Console.WriteLine("Code Examples:");
                    foreach (var example in mapping.CodeExamples)
                    {
                        Console.WriteLine($"  {example}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine(ApplicationConstants.ShortSeparatorLine);
                Console.WriteLine();
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Displays best practices for data type selection.
        /// </summary>
        public void DisplayBestPractices()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.BestPracticesHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("=== General Best Practices ===");
            Console.WriteLine();
            Console.WriteLine("1. Choose the smallest data type that can accommodate your data");
            Console.WriteLine("2. Use appropriate precision for decimal numbers");
            Console.WriteLine("3. Consider performance implications of data type choices");
            Console.WriteLine("4. Use Unicode types (NVARCHAR) for international text");
            Console.WriteLine("5. Use DATETIME2 instead of DATETIME for new applications");
            Console.WriteLine("6. Use DECIMAL for financial calculations");
            Console.WriteLine("7. Use appropriate integer types based on range requirements");
            Console.WriteLine("8. Consider nullable types when values can be null");
            Console.WriteLine();

            Console.WriteLine("=== Performance Considerations ===");
            Console.WriteLine();
            Console.WriteLine("• Smaller data types use less storage and memory");
            Console.WriteLine("• Fixed-length types can be faster for exact-length data");
            Console.WriteLine("• Variable-length types save space but may be slower");
            Console.WriteLine("• Index performance depends on data type size");
            Console.WriteLine("• Network transfer time is affected by data type size");
            Console.WriteLine();

            Console.WriteLine("=== Common Pitfalls ===");
            Console.WriteLine();
            Console.WriteLine("• Using FLOAT for financial calculations");
            Console.WriteLine("• Using VARCHAR for Unicode text");
            Console.WriteLine("• Using DATETIME instead of DATETIME2");
            Console.WriteLine("• Not considering precision requirements");
            Console.WriteLine("• Using unnecessarily large integer types");
            Console.WriteLine();

            WaitForUserInput();
        }

        /// <summary>
        /// Displays search functionality for data types.
        /// </summary>
        public void SearchDataTypes()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.SearchResultsHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.Write("Enter search term: ");
            var searchTerm = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                WaitForUserInput();
                return;
            }

            var (csharpTypes, sqlTypes) = _comparisonService.SearchDataTypes(searchTerm);
            var allCsharpTypes = _comparisonService.GetAllCSharpDataTypes();
            var allSqlTypes = _comparisonService.GetAllSqlDataTypes();

            Console.WriteLine();
            Console.WriteLine($"Search results for '{searchTerm}':");
            Console.WriteLine();

            if (csharpTypes.Length > 0)
            {
                Console.WriteLine("C# Data Types:");
                foreach (var type in csharpTypes)
                {
                    if (allCsharpTypes.TryGetValue(type, out var typeInfo))
                    {
                        Console.WriteLine($"  • {typeInfo.Name} - {typeInfo.Description}");
                    }
                }
                Console.WriteLine();
            }

            if (sqlTypes.Length > 0)
            {
                Console.WriteLine("SQL Data Types:");
                foreach (var type in sqlTypes)
                {
                    if (allSqlTypes.TryGetValue(type, out var typeInfo))
                    {
                        Console.WriteLine($"  • {typeInfo.Name} - {typeInfo.Description}");
                    }
                }
                Console.WriteLine();
            }

            if (csharpTypes.Length == 0 && sqlTypes.Length == 0)
            {
                Console.WriteLine(ApplicationConstants.NoSearchResultsError);
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Displays size and range information for data types.
        /// </summary>
        public void DisplaySizeAndRanges()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.SizeAndRangeHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("=== C# Data Types ===");
            Console.WriteLine();
            var csharpTypes = _comparisonService.GetAllCSharpDataTypes();
            foreach (var type in csharpTypes.Values)
            {
                Console.WriteLine($"{type.Name,-15} | Size: {type.Size,-10} | Range: {type.Range}");
            }

            Console.WriteLine();
            Console.WriteLine("=== SQL Data Types ===");
            Console.WriteLine();
            var sqlTypes = _comparisonService.GetAllSqlDataTypes();
            foreach (var type in sqlTypes.Values)
            {
                Console.WriteLine($"{type.Name,-15} | Size: {type.Size,-10} | Range: {type.Range}");
            }

            Console.WriteLine();
            WaitForUserInput();
        }

        /// <summary>
        /// Displays SQL equivalents for a specific C# data type.
        /// </summary>
        /// <param name="csharpType">The C# data type to find equivalents for.</param>
        private void DisplaySqlEquivalents(CSharpDataType csharpType)
        {
            var equivalents = _comparisonService.FindSqlEquivalents(csharpType);
            var csharpInfo = _comparisonService.GetAllCSharpDataTypes()[csharpType];

            Console.Clear();
            Console.WriteLine($"SQL Equivalents for C# {csharpInfo.Name}");
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            if (equivalents.Length == 0)
            {
                Console.WriteLine("No SQL equivalents found for this C# data type.");
            }
            else
            {
                foreach (var equivalent in equivalents)
                {
                    Console.WriteLine($"SQL Type: {equivalent.SqlType.Name}");
                    Console.WriteLine($"Compatibility: {equivalent.Compatibility}");
                    Console.WriteLine($"Confidence: {equivalent.ConfidenceLevel}/10");
                    Console.WriteLine($"Recommended: {(equivalent.IsRecommended ? "Yes" : "No")}");
                    
                    if (!string.IsNullOrEmpty(equivalent.ConversionNotes))
                    {
                        Console.WriteLine($"Notes: {equivalent.ConversionNotes}");
                    }

                    if (equivalent.CodeExamples.Length > 0)
                    {
                        Console.WriteLine("Code Examples:");
                        foreach (var example in equivalent.CodeExamples)
                        {
                            Console.WriteLine($"  {example}");
                        }
                    }

                    Console.WriteLine(ApplicationConstants.ShortSeparatorLine);
                    Console.WriteLine();
                }
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Displays C# equivalents for a specific SQL data type.
        /// </summary>
        /// <param name="sqlType">The SQL data type to find equivalents for.</param>
        private void DisplayCSharpEquivalents(SqlDataType sqlType)
        {
            var equivalents = _comparisonService.FindCSharpEquivalents(sqlType);
            var sqlInfo = _comparisonService.GetAllSqlDataTypes()[sqlType];

            Console.Clear();
            Console.WriteLine($"C# Equivalents for SQL {sqlInfo.Name}");
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            if (equivalents.Length == 0)
            {
                Console.WriteLine("No C# equivalents found for this SQL data type.");
            }
            else
            {
                foreach (var equivalent in equivalents)
                {
                    Console.WriteLine($"C# Type: {equivalent.CSharpType.Name}");
                    Console.WriteLine($"Compatibility: {equivalent.Compatibility}");
                    Console.WriteLine($"Confidence: {equivalent.ConfidenceLevel}/10");
                    Console.WriteLine($"Recommended: {(equivalent.IsRecommended ? "Yes" : "No")}");
                    
                    if (!string.IsNullOrEmpty(equivalent.ConversionNotes))
                    {
                        Console.WriteLine($"Notes: {equivalent.ConversionNotes}");
                    }

                    if (equivalent.CodeExamples.Length > 0)
                    {
                        Console.WriteLine("Code Examples:");
                        foreach (var example in equivalent.CodeExamples)
                        {
                            Console.WriteLine($"  {example}");
                        }
                    }

                    Console.WriteLine(ApplicationConstants.ShortSeparatorLine);
                    Console.WriteLine();
                }
            }

            WaitForUserInput();
        }

        /// <summary>
        /// Gets user menu choice and validates input.
        /// </summary>
        /// <returns>The selected menu option.</returns>
        private MenuOption GetMenuChoice()
        {
            while (true)
            {
                Console.Write(ApplicationConstants.EnterChoiceMessage);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (Enum.IsDefined(typeof(MenuOption), choice))
                    {
                        return (MenuOption)choice;
                    }
                }

                Console.WriteLine(ApplicationConstants.InvalidChoiceError);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Waits for user input to continue.
        /// </summary>
        private void WaitForUserInput()
        {
            Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
            Console.ReadKey();
        }
    }
} 