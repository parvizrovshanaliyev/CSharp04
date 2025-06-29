namespace CSharpToSqlDataTypes.Enums
{
    /// <summary>
    /// Represents all C# data types categorized by their usage and characteristics.
    /// This enum provides a comprehensive list of C# data types for comparison with SQL data types.
    /// </summary>
    public enum CSharpDataType
    {
        #region Integral Types

        /// <summary>
        /// 8-bit signed integer (-128 to 127)
        /// </summary>
        SByte,

        /// <summary>
        /// 8-bit unsigned integer (0 to 255)
        /// </summary>
        Byte,

        /// <summary>
        /// 16-bit signed integer (-32,768 to 32,767)
        /// </summary>
        Short,

        /// <summary>
        /// 16-bit unsigned integer (0 to 65,535)
        /// </summary>
        UShort,

        /// <summary>
        /// 32-bit signed integer (-2,147,483,648 to 2,147,483,647)
        /// </summary>
        Int,

        /// <summary>
        /// 32-bit unsigned integer (0 to 4,294,967,295)
        /// </summary>
        UInt,

        /// <summary>
        /// 64-bit signed integer (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807)
        /// </summary>
        Long,

        /// <summary>
        /// 64-bit unsigned integer (0 to 18,446,744,073,709,551,615)
        /// </summary>
        ULong,

        #endregion

        #region Floating-Point Types

        /// <summary>
        /// 32-bit floating-point number (approximately ±1.5 × 10^−45 to ±3.4 × 10^38)
        /// </summary>
        Float,

        /// <summary>
        /// 64-bit floating-point number (approximately ±5.0 × 10^−324 to ±1.7 × 10^308)
        /// </summary>
        Double,

        /// <summary>
        /// 128-bit decimal number (approximately ±1.0 × 10^−28 to ±7.9 × 10^28)
        /// </summary>
        Decimal,

        #endregion

        #region Character Types

        /// <summary>
        /// 16-bit Unicode character
        /// </summary>
        Char,

        #endregion

        #region Boolean Type

        /// <summary>
        /// Boolean value (true or false)
        /// </summary>
        Bool,

        #endregion

        #region String Types

        /// <summary>
        /// Sequence of Unicode characters
        /// </summary>
        String,

        #endregion

        #region Object Types

        /// <summary>
        /// Base class for all types
        /// </summary>
        Object,

        #endregion

        #region DateTime Types

        /// <summary>
        /// Represents a point in time, typically expressed as a date and time of day
        /// </summary>
        DateTime,

        /// <summary>
        /// Represents a time interval
        /// </summary>
        TimeSpan,

        /// <summary>
        /// Represents a date without time
        /// </summary>
        DateOnly,

        /// <summary>
        /// Represents a time without date
        /// </summary>
        TimeOnly,

        #endregion

        #region Guid Type

        /// <summary>
        /// Represents a globally unique identifier (GUID)
        /// </summary>
        Guid,

        #endregion

        #region Array Types

        /// <summary>
        /// Array of bytes
        /// </summary>
        ByteArray,

        /// <summary>
        /// Array of characters
        /// </summary>
        CharArray,

        #endregion

        #region Nullable Types

        /// <summary>
        /// Nullable integer
        /// </summary>
        NullableInt,

        /// <summary>
        /// Nullable double
        /// </summary>
        NullableDouble,

        /// <summary>
        /// Nullable boolean
        /// </summary>
        NullableBool,

        /// <summary>
        /// Nullable DateTime
        /// </summary>
        NullableDateTime,

        #endregion

        #region Special Types

        /// <summary>
        /// Dynamic type (resolved at runtime)
        /// </summary>
        Dynamic,

        /// <summary>
        /// Var type (implicitly typed)
        /// </summary>
        Var,

        #endregion
    }
} 