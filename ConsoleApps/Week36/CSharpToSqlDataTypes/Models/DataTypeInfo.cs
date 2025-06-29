namespace CSharpToSqlDataTypes.Models
{
    /// <summary>
    /// Represents comprehensive information about a data type including its characteristics,
    /// size, range, description, and usage examples. This class is used for both C# and SQL data types.
    /// </summary>
    public class DataTypeInfo
    {
        /// <summary>
        /// Gets or sets the name of the data type.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category of the data type (e.g., Integral, Floating-Point, String, etc.).
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the size of the data type in bytes.
        /// </summary>
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the range of values that can be stored in this data type.
        /// </summary>
        public string Range { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the precision for numeric data types.
        /// </summary>
        public string Precision { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the scale for decimal data types.
        /// </summary>
        public string Scale { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a detailed description of the data type.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets usage examples for the data type.
        /// </summary>
        public string[] UsageExamples { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the default value for this data type.
        /// </summary>
        public string DefaultValue { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether this data type is nullable.
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Gets or sets the equivalent data types in the other language (C# or SQL).
        /// </summary>
        public string[] EquivalentTypes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets best practices for using this data type.
        /// </summary>
        public string[] BestPractices { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets common pitfalls or warnings when using this data type.
        /// </summary>
        public string[] Warnings { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the syntax for declaring this data type.
        /// </summary>
        public string DeclarationSyntax { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the minimum value that can be stored in this data type.
        /// </summary>
        public string MinValue { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the maximum value that can be stored in this data type.
        /// </summary>
        public string MaxValue { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether this data type is commonly used.
        /// </summary>
        public bool IsCommonlyUsed { get; set; }

        /// <summary>
        /// Gets or sets the performance characteristics of this data type.
        /// </summary>
        public string PerformanceNotes { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the DataTypeInfo class with default values.
        /// </summary>
        public DataTypeInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DataTypeInfo class with specified values.
        /// </summary>
        /// <param name="name">The name of the data type.</param>
        /// <param name="category">The category of the data type.</param>
        /// <param name="size">The size of the data type.</param>
        /// <param name="range">The range of values.</param>
        /// <param name="description">The description of the data type.</param>
        public DataTypeInfo(string name, string category, string size, string range, string description)
        {
            Name = name;
            Category = category;
            Size = size;
            Range = range;
            Description = description;
        }

        /// <summary>
        /// Returns a string representation of the data type information.
        /// </summary>
        /// <returns>A formatted string containing the data type information.</returns>
        public override string ToString()
        {
            return $"{Name} ({Category}) - Size: {Size}, Range: {Range}";
        }

        /// <summary>
        /// Returns a detailed string representation of the data type information.
        /// </summary>
        /// <returns>A detailed formatted string containing all data type information.</returns>
        public string ToDetailedString()
        {
            var result = $"=== {Name} ===\n";
            result += $"Category: {Category}\n";
            result += $"Size: {Size}\n";
            result += $"Range: {Range}\n";
            
            if (!string.IsNullOrEmpty(Precision))
                result += $"Precision: {Precision}\n";
            
            if (!string.IsNullOrEmpty(Scale))
                result += $"Scale: {Scale}\n";
            
            result += $"Description: {Description}\n";
            result += $"Default Value: {DefaultValue}\n";
            result += $"Nullable: {(IsNullable ? "Yes" : "No")}\n";
            result += $"Commonly Used: {(IsCommonlyUsed ? "Yes" : "No")}\n";
            
            if (!string.IsNullOrEmpty(DeclarationSyntax))
                result += $"Declaration: {DeclarationSyntax}\n";
            
            if (!string.IsNullOrEmpty(PerformanceNotes))
                result += $"Performance: {PerformanceNotes}\n";
            
            if (EquivalentTypes.Length > 0)
            {
                result += $"Equivalent Types: {string.Join(", ", EquivalentTypes)}\n";
            }
            
            if (UsageExamples.Length > 0)
            {
                result += "\nUsage Examples:\n";
                for (int i = 0; i < UsageExamples.Length; i++)
                {
                    result += $"  {i + 1}. {UsageExamples[i]}\n";
                }
            }
            
            if (BestPractices.Length > 0)
            {
                result += "\nBest Practices:\n";
                for (int i = 0; i < BestPractices.Length; i++)
                {
                    result += $"  {i + 1}. {BestPractices[i]}\n";
                }
            }
            
            if (Warnings.Length > 0)
            {
                result += "\nWarnings:\n";
                for (int i = 0; i < Warnings.Length; i++)
                {
                    result += $"  {i + 1}. {Warnings[i]}\n";
                }
            }
            
            return result;
        }
    }
} 