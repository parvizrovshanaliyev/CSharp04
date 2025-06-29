namespace CSharpToSqlDataTypes.Enums
{
    /// <summary>
    /// Represents all SQL data types categorized by their usage and characteristics.
    /// This enum provides a comprehensive list of SQL data types for comparison with C# data types.
    /// </summary>
    public enum SqlDataType
    {
        #region Exact Numeric Types

        /// <summary>
        /// Fixed precision and scale numeric data (-10^38 + 1 to 10^38 - 1)
        /// </summary>
        Decimal,

        /// <summary>
        /// Fixed precision and scale numeric data (synonym for DECIMAL)
        /// </summary>
        Numeric,

        /// <summary>
        /// Integer data from -2,147,483,648 to 2,147,483,647
        /// </summary>
        Int,

        /// <summary>
        /// Integer data from -32,768 to 32,767
        /// </summary>
        SmallInt,

        /// <summary>
        /// Integer data from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        /// </summary>
        BigInt,

        /// <summary>
        /// Integer data from 0 to 255
        /// </summary>
        TinyInt,

        /// <summary>
        /// Integer data from 0 to 4,294,967,295
        /// </summary>
        UnsignedInt,

        #endregion

        #region Approximate Numeric Types

        /// <summary>
        /// Floating precision number data from -1.79E + 308 to 1.79E + 308
        /// </summary>
        Float,

        /// <summary>
        /// Floating precision number data from -3.40E + 38 to 3.40E + 38
        /// </summary>
        Real,

        #endregion

        #region Character String Types

        /// <summary>
        /// Fixed-length character string (1 to 8,000 characters)
        /// </summary>
        Char,

        /// <summary>
        /// Variable-length character string (1 to 8,000 characters)
        /// </summary>
        VarChar,

        /// <summary>
        /// Variable-length character string (up to 2GB)
        /// </summary>
        Text,

        /// <summary>
        /// Fixed-length Unicode character string (1 to 4,000 characters)
        /// </summary>
        NChar,

        /// <summary>
        /// Variable-length Unicode character string (1 to 4,000 characters)
        /// </summary>
        NVarChar,

        /// <summary>
        /// Variable-length Unicode character string (up to 2GB)
        /// </summary>
        NText,

        #endregion

        #region Binary String Types

        /// <summary>
        /// Fixed-length binary data (1 to 8,000 bytes)
        /// </summary>
        Binary,

        /// <summary>
        /// Variable-length binary data (1 to 8,000 bytes)
        /// </summary>
        VarBinary,

        /// <summary>
        /// Variable-length binary data (up to 2GB)
        /// </summary>
        Image,

        #endregion

        #region Date and Time Types

        /// <summary>
        /// Date and time data from January 1, 1753, to December 31, 9999
        /// </summary>
        DateTime,

        /// <summary>
        /// Date and time data from January 1, 1900, to June 6, 2079
        /// </summary>
        SmallDateTime,

        /// <summary>
        /// Date and time data from January 1, 0001, to December 31, 9999
        /// </summary>
        DateTime2,

        /// <summary>
        /// Date and time data with time zone awareness
        /// </summary>
        DateTimeOffset,

        /// <summary>
        /// Date data from January 1, 0001, to December 31, 9999
        /// </summary>
        Date,

        /// <summary>
        /// Time data with precision (00:00:00.0000000 to 23:59:59.9999999)
        /// </summary>
        Time,

        #endregion

        #region Boolean Type

        /// <summary>
        /// Boolean data type (true/false)
        /// </summary>
        Bit,

        #endregion

        #region Unique Identifier Type

        /// <summary>
        /// Globally unique identifier (GUID)
        /// </summary>
        UniqueIdentifier,

        #endregion

        #region Money Types

        /// <summary>
        /// Monetary data from -214,748.3648 to 214,748.3647
        /// </summary>
        Money,

        /// <summary>
        /// Monetary data from -922,337,203,685,477.5808 to 922,337,203,685,477.5807
        /// </summary>
        SmallMoney,

        #endregion

        #region XML Type

        /// <summary>
        /// XML data type for storing XML documents
        /// </summary>
        Xml,

        #endregion

        #region Table Type

        /// <summary>
        /// Table data type for storing result sets
        /// </summary>
        Table,

        #endregion

        #region Cursor Type

        /// <summary>
        /// Cursor data type for database cursors
        /// </summary>
        Cursor,

        #endregion

        #region Row Version Type

        /// <summary>
        /// Automatically generated binary number for row versioning
        /// </summary>
        RowVersion,

        /// <summary>
        /// Automatically generated binary number for row versioning (synonym for ROWVERSION)
        /// </summary>
        Timestamp,

        #endregion

        #region SQL Variant Type

        /// <summary>
        /// Data type that can store values of various SQL Server data types
        /// </summary>
        SqlVariant,

        #endregion

        #region Hierarchy ID Type

        /// <summary>
        /// Data type for representing hierarchical data
        /// </summary>
        HierarchyId,

        #endregion

        #region Geometry Type

        /// <summary>
        /// Spatial data type for geometric data
        /// </summary>
        Geometry,

        #endregion

        #region Geography Type

        /// <summary>
        /// Spatial data type for geographic data
        /// </summary>
        Geography,

        #endregion

        #region User-Defined Types

        /// <summary>
        /// User-defined data type
        /// </summary>
        UserDefined,

        #endregion
    }
} 