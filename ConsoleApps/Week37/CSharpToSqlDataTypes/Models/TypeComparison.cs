namespace CSharpToSqlDataTypes.Models
{
    /// <summary>
    /// Represents a comparison between C# and SQL data types, including mapping information,
    /// conversion notes, and best practices for data type selection.
    /// </summary>
    public class TypeComparison
    {
        /// <summary>
        /// Gets or sets the C# data type information.
        /// </summary>
        public DataTypeInfo CSharpType { get; set; } = new();

        /// <summary>
        /// Gets or sets the SQL data type information.
        /// </summary>
        public DataTypeInfo SqlType { get; set; } = new();

        /// <summary>
        /// Gets or sets the compatibility level between the two data types.
        /// </summary>
        public CompatibilityLevel Compatibility { get; set; }

        /// <summary>
        /// Gets or sets notes about the conversion between the two data types.
        /// </summary>
        public string ConversionNotes { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets potential data loss warnings when converting between types.
        /// </summary>
        public string[] DataLossWarnings { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets performance considerations when using these data types.
        /// </summary>
        public string PerformanceNotes { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets recommended scenarios for using this type combination.
        /// </summary>
        public string[] RecommendedScenarios { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets scenarios where this type combination should be avoided.
        /// </summary>
        public string[] AvoidScenarios { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets code examples showing the conversion between these types.
        /// </summary>
        public string[] CodeExamples { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the precision loss when converting from C# to SQL.
        /// </summary>
        public string PrecisionLoss { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the range loss when converting from C# to SQL.
        /// </summary>
        public string RangeLoss { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether this is a recommended mapping.
        /// </summary>
        public bool IsRecommended { get; set; }

        /// <summary>
        /// Gets or sets the confidence level of this mapping (1-10).
        /// </summary>
        public int ConfidenceLevel { get; set; }

        /// <summary>
        /// Initializes a new instance of the TypeComparison class.
        /// </summary>
        public TypeComparison()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TypeComparison class with specified C# and SQL types.
        /// </summary>
        /// <param name="csharpType">The C# data type information.</param>
        /// <param name="sqlType">The SQL data type information.</param>
        /// <param name="compatibility">The compatibility level between the types.</param>
        public TypeComparison(DataTypeInfo csharpType, DataTypeInfo sqlType, CompatibilityLevel compatibility)
        {
            CSharpType = csharpType;
            SqlType = sqlType;
            Compatibility = compatibility;
        }

        /// <summary>
        /// Returns a string representation of the type comparison.
        /// </summary>
        /// <returns>A formatted string containing the comparison information.</returns>
        public override string ToString()
        {
            return $"{CSharpType.Name} ↔ {SqlType.Name} ({Compatibility})";
        }

        /// <summary>
        /// Returns a detailed string representation of the type comparison.
        /// </summary>
        /// <returns>A detailed formatted string containing all comparison information.</returns>
        public string ToDetailedString()
        {
            var result = $"=== Type Comparison ===\n";
            result += $"C# Type: {CSharpType.Name}\n";
            result += $"SQL Type: {SqlType.Name}\n";
            result += $"Compatibility: {Compatibility}\n";
            result += $"Confidence Level: {ConfidenceLevel}/10\n";
            result += $"Recommended: {(IsRecommended ? "Yes" : "No")}\n\n";
            
            if (!string.IsNullOrEmpty(ConversionNotes))
            {
                result += $"Conversion Notes:\n{ConversionNotes}\n\n";
            }
            
            if (!string.IsNullOrEmpty(PrecisionLoss))
            {
                result += $"Precision Loss: {PrecisionLoss}\n";
            }
            
            if (!string.IsNullOrEmpty(RangeLoss))
            {
                result += $"Range Loss: {RangeLoss}\n";
            }
            
            if (!string.IsNullOrEmpty(PerformanceNotes))
            {
                result += $"Performance Notes: {PerformanceNotes}\n";
            }
            
            if (DataLossWarnings.Length > 0)
            {
                result += "\nData Loss Warnings:\n";
                for (int i = 0; i < DataLossWarnings.Length; i++)
                {
                    result += $"  {i + 1}. {DataLossWarnings[i]}\n";
                }
            }
            
            if (RecommendedScenarios.Length > 0)
            {
                result += "\nRecommended Scenarios:\n";
                for (int i = 0; i < RecommendedScenarios.Length; i++)
                {
                    result += $"  {i + 1}. {RecommendedScenarios[i]}\n";
                }
            }
            
            if (AvoidScenarios.Length > 0)
            {
                result += "\nAvoid These Scenarios:\n";
                for (int i = 0; i < AvoidScenarios.Length; i++)
                {
                    result += $"  {i + 1}. {AvoidScenarios[i]}\n";
                }
            }
            
            if (CodeExamples.Length > 0)
            {
                result += "\nCode Examples:\n";
                for (int i = 0; i < CodeExamples.Length; i++)
                {
                    result += $"  {i + 1}. {CodeExamples[i]}\n";
                }
            }
            
            return result;
        }
    }

    /// <summary>
    /// Represents the compatibility level between C# and SQL data types.
    /// </summary>
    public enum CompatibilityLevel
    {
        /// <summary>
        /// Perfect compatibility - no data loss or precision issues.
        /// </summary>
        Perfect,

        /// <summary>
        /// Good compatibility - minor precision or range differences.
        /// </summary>
        Good,

        /// <summary>
        /// Fair compatibility - some data loss or precision issues possible.
        /// </summary>
        Fair,

        /// <summary>
        /// Poor compatibility - significant data loss or precision issues.
        /// </summary>
        Poor,

        /// <summary>
        /// Incompatible - cannot be converted without data loss.
        /// </summary>
        Incompatible,

        /// <summary>
        /// No direct mapping available.
        /// </summary>
        NoMapping
    }
} 