using CSharpToSqlDataTypes.Models;
using CSharpToSqlDataTypes.Enums;
using CSharpToSqlDataTypes.Data;

namespace CSharpToSqlDataTypes.Services
{
    /// <summary>
    /// Service class that provides comprehensive data type comparison functionality
    /// between C# and SQL data types, including mapping, conversion examples, and best practices.
    /// </summary>
    public class DataTypeComparisonService
    {
        private readonly Dictionary<CSharpDataType, DataTypeInfo> _csharpDataTypes;
        private readonly Dictionary<SqlDataType, DataTypeInfo> _sqlDataTypes;
        private readonly Dictionary<CSharpDataType, SqlDataType[]> _csharpToSqlMappings;
        private readonly Dictionary<SqlDataType, CSharpDataType[]> _sqlToCsharpMappings;

        /// <summary>
        /// Initializes a new instance of the DataTypeComparisonService class.
        /// </summary>
        public DataTypeComparisonService()
        {
            _csharpDataTypes = CSharpDataTypes.GetAllDataTypes();
            _sqlDataTypes = SqlDataTypes.GetAllDataTypes();
            _csharpToSqlMappings = InitializeCSharpToSqlMappings();
            _sqlToCsharpMappings = InitializeSqlToCsharpMappings();
        }

        /// <summary>
        /// Gets all C# data types.
        /// </summary>
        /// <returns>A dictionary containing all C# data types.</returns>
        public Dictionary<CSharpDataType, DataTypeInfo> GetAllCSharpDataTypes()
        {
            return _csharpDataTypes;
        }

        /// <summary>
        /// Gets all SQL data types.
        /// </summary>
        /// <returns>A dictionary containing all SQL data types.</returns>
        public Dictionary<SqlDataType, DataTypeInfo> GetAllSqlDataTypes()
        {
            return _sqlDataTypes;
        }

        /// <summary>
        /// Gets C# data types grouped by category.
        /// </summary>
        /// <returns>A dictionary containing C# data types grouped by category.</returns>
        public Dictionary<string, CSharpDataType[]> GetCSharpDataTypesByCategory()
        {
            return CSharpDataTypes.GetDataTypesByCategory();
        }

        /// <summary>
        /// Gets SQL data types grouped by category.
        /// </summary>
        /// <returns>A dictionary containing SQL data types grouped by category.</returns>
        public Dictionary<string, SqlDataType[]> GetSqlDataTypesByCategory()
        {
            return SqlDataTypes.GetDataTypesByCategory();
        }

        /// <summary>
        /// Finds SQL equivalent data types for a given C# data type.
        /// </summary>
        /// <param name="csharpType">The C# data type to find equivalents for.</param>
        /// <returns>An array of TypeComparison objects containing the mappings.</returns>
        public TypeComparison[] FindSqlEquivalents(CSharpDataType csharpType)
        {
            if (!_csharpToSqlMappings.ContainsKey(csharpType))
            {
                return Array.Empty<TypeComparison>();
            }

            var sqlTypes = _csharpToSqlMappings[csharpType];
            var comparisons = new List<TypeComparison>();

            foreach (var sqlType in sqlTypes)
            {
                var comparison = CreateTypeComparison(csharpType, sqlType);
                comparisons.Add(comparison);
            }

            return comparisons.ToArray();
        }

        /// <summary>
        /// Finds C# equivalent data types for a given SQL data type.
        /// </summary>
        /// <param name="sqlType">The SQL data type to find equivalents for.</param>
        /// <returns>An array of TypeComparison objects containing the mappings.</returns>
        public TypeComparison[] FindCSharpEquivalents(SqlDataType sqlType)
        {
            if (!_sqlToCsharpMappings.ContainsKey(sqlType))
            {
                return Array.Empty<TypeComparison>();
            }

            var csharpTypes = _sqlToCsharpMappings[sqlType];
            var comparisons = new List<TypeComparison>();

            foreach (var csharpType in csharpTypes)
            {
                var comparison = CreateTypeComparison(csharpType, sqlType);
                comparisons.Add(comparison);
            }

            return comparisons.ToArray();
        }

        /// <summary>
        /// Compares all C# and SQL data types and returns comprehensive comparison information.
        /// </summary>
        /// <returns>An array of TypeComparison objects for all mappings.</returns>
        public TypeComparison[] GetAllComparisons()
        {
            var comparisons = new List<TypeComparison>();

            foreach (var mapping in _csharpToSqlMappings)
            {
                foreach (var sqlType in mapping.Value)
                {
                    var comparison = CreateTypeComparison(mapping.Key, sqlType);
                    comparisons.Add(comparison);
                }
            }

            return comparisons.ToArray();
        }

        /// <summary>
        /// Searches for data types by name (case-insensitive).
        /// </summary>
        /// <param name="searchTerm">The search term to look for.</param>
        /// <returns>A tuple containing matching C# and SQL data types.</returns>
        public (CSharpDataType[] CSharpTypes, SqlDataType[] SqlTypes) SearchDataTypes(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return (Array.Empty<CSharpDataType>(), Array.Empty<SqlDataType>());
            }

            var csharpResults = new List<CSharpDataType>();
            var sqlResults = new List<SqlDataType>();

            // Search in C# data types
            foreach (var kvp in _csharpDataTypes)
            {
                if (kvp.Value.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    kvp.Value.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    csharpResults.Add(kvp.Key);
                }
            }

            // Search in SQL data types
            foreach (var kvp in _sqlDataTypes)
            {
                if (kvp.Value.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    kvp.Value.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    sqlResults.Add(kvp.Key);
                }
            }

            return (csharpResults.ToArray(), sqlResults.ToArray());
        }

        /// <summary>
        /// Gets recommended data type mappings for common scenarios.
        /// </summary>
        /// <returns>An array of TypeComparison objects for recommended mappings.</returns>
        public TypeComparison[] GetRecommendedMappings()
        {
            var recommendedMappings = new[]
            {
                (CSharpDataType.Int, SqlDataType.Int),
                (CSharpDataType.Long, SqlDataType.BigInt),
                (CSharpDataType.Double, SqlDataType.Float),
                (CSharpDataType.Decimal, SqlDataType.Decimal),
                (CSharpDataType.String, SqlDataType.VarChar),
                (CSharpDataType.String, SqlDataType.NVarChar),
                (CSharpDataType.Bool, SqlDataType.Bit),
                (CSharpDataType.DateTime, SqlDataType.DateTime2),
                (CSharpDataType.Guid, SqlDataType.UniqueIdentifier)
            };

            var comparisons = new List<TypeComparison>();

            foreach (var (csharpType, sqlType) in recommendedMappings)
            {
                var comparison = CreateTypeComparison(csharpType, sqlType);
                comparison.IsRecommended = true;
                comparison.ConfidenceLevel = 10;
                comparisons.Add(comparison);
            }

            return comparisons.ToArray();
        }

        /// <summary>
        /// Creates a TypeComparison object for the given C# and SQL data types.
        /// </summary>
        /// <param name="csharpType">The C# data type.</param>
        /// <param name="sqlType">The SQL data type.</param>
        /// <returns>A TypeComparison object with detailed mapping information.</returns>
        private TypeComparison CreateTypeComparison(CSharpDataType csharpType, SqlDataType sqlType)
        {
            var csharpInfo = _csharpDataTypes[csharpType];
            var sqlInfo = _sqlDataTypes[sqlType];

            var comparison = new TypeComparison(csharpInfo, sqlInfo, DetermineCompatibility(csharpType, sqlType))
            {
                ConfidenceLevel = DetermineConfidenceLevel(csharpType, sqlType),
                IsRecommended = IsRecommendedMapping(csharpType, sqlType)
            };

            // Set conversion notes and warnings based on the mapping
            SetConversionDetails(comparison, csharpType, sqlType);

            return comparison;
        }

        /// <summary>
        /// Determines the compatibility level between C# and SQL data types.
        /// </summary>
        /// <param name="csharpType">The C# data type.</param>
        /// <param name="sqlType">The SQL data type.</param>
        /// <returns>The compatibility level.</returns>
        private CompatibilityLevel DetermineCompatibility(CSharpDataType csharpType, SqlDataType sqlType)
        {
            return (csharpType, sqlType) switch
            {
                // Perfect compatibility
                (CSharpDataType.Int, SqlDataType.Int) => CompatibilityLevel.Perfect,
                (CSharpDataType.Long, SqlDataType.BigInt) => CompatibilityLevel.Perfect,
                (CSharpDataType.Bool, SqlDataType.Bit) => CompatibilityLevel.Perfect,
                (CSharpDataType.Guid, SqlDataType.UniqueIdentifier) => CompatibilityLevel.Perfect,

                // Good compatibility
                (CSharpDataType.Double, SqlDataType.Float) => CompatibilityLevel.Good,
                (CSharpDataType.Decimal, SqlDataType.Decimal) => CompatibilityLevel.Good,
                (CSharpDataType.String, SqlDataType.VarChar) => CompatibilityLevel.Good,
                (CSharpDataType.String, SqlDataType.NVarChar) => CompatibilityLevel.Good,
                (CSharpDataType.DateTime, SqlDataType.DateTime2) => CompatibilityLevel.Good,

                // Fair compatibility
                (CSharpDataType.DateTime, SqlDataType.DateTime) => CompatibilityLevel.Fair,
                (CSharpDataType.Int, SqlDataType.BigInt) => CompatibilityLevel.Fair,
                (CSharpDataType.Long, SqlDataType.Int) => CompatibilityLevel.Fair,

                // Poor compatibility
                (CSharpDataType.Double, SqlDataType.Decimal) => CompatibilityLevel.Poor,
                (CSharpDataType.Decimal, SqlDataType.Float) => CompatibilityLevel.Poor,

                // Default
                _ => CompatibilityLevel.NoMapping
            };
        }

        /// <summary>
        /// Determines the confidence level for a data type mapping (1-10).
        /// </summary>
        /// <param name="csharpType">The C# data type.</param>
        /// <param name="sqlType">The SQL data type.</param>
        /// <returns>The confidence level from 1 to 10.</returns>
        private int DetermineConfidenceLevel(CSharpDataType csharpType, SqlDataType sqlType)
        {
            return (csharpType, sqlType) switch
            {
                // High confidence (9-10)
                (CSharpDataType.Int, SqlDataType.Int) => 10,
                (CSharpDataType.Long, SqlDataType.BigInt) => 10,
                (CSharpDataType.Bool, SqlDataType.Bit) => 10,
                (CSharpDataType.Guid, SqlDataType.UniqueIdentifier) => 10,
                (CSharpDataType.String, SqlDataType.VarChar) => 9,
                (CSharpDataType.String, SqlDataType.NVarChar) => 9,

                // Medium confidence (6-8)
                (CSharpDataType.Double, SqlDataType.Float) => 8,
                (CSharpDataType.Decimal, SqlDataType.Decimal) => 8,
                (CSharpDataType.DateTime, SqlDataType.DateTime2) => 8,
                (CSharpDataType.DateTime, SqlDataType.DateTime) => 7,

                // Low confidence (3-5)
                (CSharpDataType.Int, SqlDataType.BigInt) => 5,
                (CSharpDataType.Long, SqlDataType.Int) => 4,

                // Very low confidence (1-2)
                (CSharpDataType.Double, SqlDataType.Decimal) => 2,
                (CSharpDataType.Decimal, SqlDataType.Float) => 2,

                // Default
                _ => 1
            };
        }

        /// <summary>
        /// Determines if a mapping is recommended.
        /// </summary>
        /// <param name="csharpType">The C# data type.</param>
        /// <param name="sqlType">The SQL data type.</param>
        /// <returns>True if the mapping is recommended, false otherwise.</returns>
        private bool IsRecommendedMapping(CSharpDataType csharpType, SqlDataType sqlType)
        {
            return (csharpType, sqlType) switch
            {
                (CSharpDataType.Int, SqlDataType.Int) => true,
                (CSharpDataType.Long, SqlDataType.BigInt) => true,
                (CSharpDataType.Double, SqlDataType.Float) => true,
                (CSharpDataType.Decimal, SqlDataType.Decimal) => true,
                (CSharpDataType.String, SqlDataType.VarChar) => true,
                (CSharpDataType.String, SqlDataType.NVarChar) => true,
                (CSharpDataType.Bool, SqlDataType.Bit) => true,
                (CSharpDataType.DateTime, SqlDataType.DateTime2) => true,
                (CSharpDataType.Guid, SqlDataType.UniqueIdentifier) => true,
                _ => false
            };
        }

        /// <summary>
        /// Sets conversion details for a type comparison.
        /// </summary>
        /// <param name="comparison">The TypeComparison object to update.</param>
        /// <param name="csharpType">The C# data type.</param>
        /// <param name="sqlType">The SQL data type.</param>
        private void SetConversionDetails(TypeComparison comparison, CSharpDataType csharpType, SqlDataType sqlType)
        {
            switch ((csharpType, sqlType))
            {
                case (CSharpDataType.Int, SqlDataType.Int):
                    comparison.ConversionNotes = "Direct mapping with no data loss.";
                    comparison.CodeExamples = new[] { "int csharpValue = 42;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.Int) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.Long, SqlDataType.BigInt):
                    comparison.ConversionNotes = "Direct mapping with no data loss.";
                    comparison.CodeExamples = new[] { "long csharpValue = 9223372036854775807L;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.BigInt) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.Double, SqlDataType.Float):
                    comparison.ConversionNotes = "Good mapping with minor precision differences.";
                    comparison.PrecisionLoss = "May lose some precision due to different floating-point representations.";
                    comparison.CodeExamples = new[] { "double csharpValue = 3.141592653589793;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.Float) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.Decimal, SqlDataType.Decimal):
                    comparison.ConversionNotes = "Direct mapping with exact precision preservation.";
                    comparison.CodeExamples = new[] { "decimal csharpValue = 123.456789m;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.Decimal) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.String, SqlDataType.VarChar):
                    comparison.ConversionNotes = "Good mapping for ASCII strings.";
                    comparison.DataLossWarnings = new[] { "Unicode characters may not display correctly", "Use NVARCHAR for international text" };
                    comparison.CodeExamples = new[] { "string csharpValue = \"Hello World\";", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.VarChar, 100) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.String, SqlDataType.NVarChar):
                    comparison.ConversionNotes = "Excellent mapping for Unicode strings.";
                    comparison.CodeExamples = new[] { "string csharpValue = \"Hello 世界\";", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.NVarChar, 100) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.Bool, SqlDataType.Bit):
                    comparison.ConversionNotes = "Direct mapping (true/false to 1/0).";
                    comparison.CodeExamples = new[] { "bool csharpValue = true;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.Bit) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.DateTime, SqlDataType.DateTime2):
                    comparison.ConversionNotes = "Excellent mapping with high precision.";
                    comparison.CodeExamples = new[] { "DateTime csharpValue = DateTime.Now;", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.DateTime2) { Value = csharpValue };" };
                    break;

                case (CSharpDataType.Guid, SqlDataType.UniqueIdentifier):
                    comparison.ConversionNotes = "Direct mapping with no data loss.";
                    comparison.CodeExamples = new[] { "Guid csharpValue = Guid.NewGuid();", "SqlParameter param = new SqlParameter(\"@value\", SqlDbType.UniqueIdentifier) { Value = csharpValue };" };
                    break;

                default:
                    comparison.ConversionNotes = "This mapping may have compatibility issues.";
                    comparison.DataLossWarnings = new[] { "Data loss or precision issues may occur", "Consider alternative mappings" };
                    break;
            }
        }

        /// <summary>
        /// Initializes the C# to SQL data type mappings.
        /// </summary>
        /// <returns>A dictionary mapping C# data types to their SQL equivalents.</returns>
        private Dictionary<CSharpDataType, SqlDataType[]> InitializeCSharpToSqlMappings()
        {
            return new Dictionary<CSharpDataType, SqlDataType[]>
            {
                [CSharpDataType.Int] = new[] { SqlDataType.Int, SqlDataType.BigInt },
                [CSharpDataType.Long] = new[] { SqlDataType.BigInt, SqlDataType.Int },
                [CSharpDataType.Double] = new[] { SqlDataType.Float, SqlDataType.Decimal },
                [CSharpDataType.Decimal] = new[] { SqlDataType.Decimal, SqlDataType.Float },
                [CSharpDataType.String] = new[] { SqlDataType.VarChar, SqlDataType.NVarChar },
                [CSharpDataType.Bool] = new[] { SqlDataType.Bit },
                [CSharpDataType.DateTime] = new[] { SqlDataType.DateTime2, SqlDataType.DateTime },
                [CSharpDataType.Guid] = new[] { SqlDataType.UniqueIdentifier }
            };
        }

        /// <summary>
        /// Initializes the SQL to C# data type mappings.
        /// </summary>
        /// <returns>A dictionary mapping SQL data types to their C# equivalents.</returns>
        private Dictionary<SqlDataType, CSharpDataType[]> InitializeSqlToCsharpMappings()
        {
            return new Dictionary<SqlDataType, CSharpDataType[]>
            {
                [SqlDataType.Int] = new[] { CSharpDataType.Int, CSharpDataType.Long },
                [SqlDataType.BigInt] = new[] { CSharpDataType.Long, CSharpDataType.Int },
                [SqlDataType.Float] = new[] { CSharpDataType.Double, CSharpDataType.Decimal },
                [SqlDataType.Decimal] = new[] { CSharpDataType.Decimal, CSharpDataType.Double },
                [SqlDataType.VarChar] = new[] { CSharpDataType.String },
                [SqlDataType.NVarChar] = new[] { CSharpDataType.String },
                [SqlDataType.Bit] = new[] { CSharpDataType.Bool },
                [SqlDataType.DateTime2] = new[] { CSharpDataType.DateTime },
                [SqlDataType.DateTime] = new[] { CSharpDataType.DateTime },
                [SqlDataType.UniqueIdentifier] = new[] { CSharpDataType.Guid }
            };
        }
    }
} 