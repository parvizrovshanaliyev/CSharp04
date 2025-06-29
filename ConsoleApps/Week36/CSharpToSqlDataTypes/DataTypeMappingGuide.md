# C# to SQL Data Types Mapping Guide

## Overview
This document provides a comprehensive guide to C# and SQL data types, their characteristics, mappings, usage scenarios, and best practices. It is designed to help developers understand how to select and map data types between C# and SQL Server for robust and efficient applications.

---

## Quick Reference (Most Common Types)

| C# Type   | SQL Type      | When to Use                    | Example                    |
|-----------|---------------|--------------------------------|----------------------------|
| `int`     | `INT`         | User IDs, counts, ages         | `UserId INT PRIMARY KEY`   |
| `long`    | `BIGINT`      | File sizes, timestamps         | `FileSize BIGINT`          |
| `double`  | `FLOAT`       | Scientific calculations        | `Temperature FLOAT`        |
| `decimal` | `DECIMAL(18,2)` | Money, prices               | `Price DECIMAL(18,2)`      |
| `string`  | `NVARCHAR(100)` | Names, messages             | `Name NVARCHAR(100)`       |
| `bool`    | `BIT`         | Yes/no flags                  | `IsActive BIT`             |
| `DateTime`| `DATETIME2`   | Dates and times               | `CreatedDate DATETIME2`    |
| `Guid`    | `UNIQUEIDENTIFIER` | Unique IDs              | `UserId UNIQUEIDENTIFIER`  |

---

## 1. C# Data Types

C# offers a variety of built-in data types, each with specific size, range, and use cases. Below are the most common types:

| C# Type   | Category            | Size      | Range                                      | Description                                 |
|-----------|---------------------|-----------|--------------------------------------------|---------------------------------------------|
| `int`     | Integral            | 4 bytes   | -2,147,483,648 to 2,147,483,647            | 32-bit signed integer                      |
| `long`    | Integral            | 8 bytes   | -9,223,372,036,854,775,808 to 9,223,372... | 64-bit signed integer                      |
| `double`  | Floating-Point      | 8 bytes   | ±5.0 × 10⁻³²⁴ to ±1.7 × 10³⁰⁸              | 64-bit double-precision floating point      |
| `decimal` | Floating-Point      | 16 bytes  | ±1.0 × 10⁻²⁸ to ±7.9 × 10²⁸                | 128-bit high-precision decimal              |
| `string`  | String              | Variable  | 0 to 2,147,483,647 characters              | Sequence of Unicode characters              |
| `bool`    | Boolean             | 1 byte    | true or false                              | Boolean value                               |
| `DateTime`| Date/Time           | 8 bytes   | 01/01/0001 to 12/31/9999                   | Date and time value                         |
| `Guid`    | Unique Identifier   | 16 bytes  | Any valid GUID                             | Globally unique identifier                  |

> **Tip:** Use `decimal` for financial calculations, `string` for text, and `DateTime` for date/time values.

---

## 2. SQL Data Types

SQL Server provides a rich set of data types for storing different kinds of data. Here are the most relevant types for C# mapping:

| SQL Type           | Category            | Size      | Range                                      | Description                                 |
|--------------------|---------------------|-----------|--------------------------------------------|---------------------------------------------|
| `INT`              | Exact Numeric       | 4 bytes   | -2,147,483,648 to 2,147,483,647            | 32-bit signed integer                      |
| `BIGINT`           | Exact Numeric       | 8 bytes   | -9,223,372,036,854,775,808 to 9,223,372... | 64-bit signed integer                      |
| `FLOAT`            | Approximate Numeric | 8 bytes   | -1.79E+308 to 1.79E+308                    | Floating-point number                      |
| `DECIMAL(p,s)`     | Exact Numeric       | 5-17 bytes| -10³⁸+1 to 10³⁸-1                          | Fixed precision and scale                  |
| `VARCHAR(n)`       | String              | Variable  | 1 to 8,000 characters                      | Variable-length non-Unicode string         |
| `NVARCHAR(n)`      | String              | Variable  | 1 to 4,000 characters                      | Variable-length Unicode string             |
| `BIT`              | Boolean             | 1 byte    | 0, 1, or NULL                              | Boolean value                              |
| `DATETIME2`        | Date/Time           | 6-8 bytes | 01/01/0001 to 12/31/9999                   | Date and time with high precision          |
| `UNIQUEIDENTIFIER` | Unique Identifier   | 16 bytes  | Any valid GUID                             | Globally unique identifier                 |

> **Tip:** Use `NVARCHAR` for international text, `DECIMAL` for money, and `DATETIME2` for new date/time columns.

---

## 3. C# to SQL Data Type Mapping Table

| C# Type     | Recommended SQL Type(s)   | Compatibility   | Notes                                      |
|-------------|--------------------------|-----------------|---------------------------------------------|
| `int`       | `INT`                    | Perfect         | Direct mapping                             |
| `long`      | `BIGINT`                 | Perfect         | Direct mapping                             |
| `double`    | `FLOAT`                  | Good            | Minor precision differences                |
| `decimal`   | `DECIMAL(p,s)`           | Good            | Specify precision and scale                |
| `string`    | `VARCHAR(n)`, `NVARCHAR(n)` | Good         | Use NVARCHAR for Unicode                   |
| `bool`      | `BIT`                    | Perfect         | true/false maps to 1/0                     |
| `DateTime`  | `DATETIME2`              | Good            | Use DATETIME2 for new columns              |
| `Guid`      | `UNIQUEIDENTIFIER`       | Perfect         | Direct mapping                             |

---

## 4. Usage Examples

**C# to SQL Parameter Mapping:**
```csharp
int csharpValue = 42;
SqlParameter param = new SqlParameter("@value", SqlDbType.Int) { Value = csharpValue };
```

**String with Unicode:**
```csharp
string name = "世界";
SqlParameter param = new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = name };
```

**DateTime:**
```csharp
DateTime now = DateTime.Now;
SqlParameter param = new SqlParameter("@date", SqlDbType.DateTime2) { Value = now };
```

**Complete Table Creation Example:**
```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Age TINYINT,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    LastLoginDate DATETIME2 NULL,
    ProfilePicture VARBINARY(MAX) NULL
);
```

---

## 5. Best Practices
- **Choose the smallest data type** that fits your data to save space and improve performance.
- **Use `DECIMAL` for financial data** to avoid rounding errors.
- **Use `NVARCHAR` for international text**; use `VARCHAR` for ASCII-only text.
- **Use `DATETIME2` instead of `DATETIME`** for new applications.
- **Avoid using `FLOAT` for money**; use `DECIMAL` instead.
- **Always specify length for string types** (e.g., `VARCHAR(100)`).
- **Consider nullability**: Use nullable types in C# (`int?`, `DateTime?`) for columns that allow NULL in SQL.
- **Use appropriate precision for DECIMAL**: `DECIMAL(18,2)` for money, `DECIMAL(10,4)` for precise measurements.

---

## 6. Common Pitfalls
- Using `FLOAT` for currency or financial data (use `DECIMAL` instead).
- Using `VARCHAR` for Unicode text (use `NVARCHAR`).
- Not specifying precision and scale for `DECIMAL`.
- Using `DATETIME` instead of `DATETIME2` for new columns.
- Not matching nullability between C# and SQL types.
- Using `TEXT` or `NTEXT` (deprecated types).
- Not considering storage size when choosing integer types.

---

## 7. Performance Tips
- **Index performance**: Smaller data types create smaller indexes, which are faster to scan.
- **Storage efficiency**: Choose the smallest type that fits your data to reduce storage costs.
- **Network transfer**: Smaller data types transfer faster over the network.
- **Memory usage**: Smaller types use less memory in your application.
- **String length**: Always specify appropriate lengths for string columns to prevent waste.

---

## 8. Common Mistakes and How to Fix Them

### Mistake 1: Using VARCHAR for International Names
```sql
-- WRONG
CREATE TABLE Users (Name VARCHAR(50));

-- RIGHT
CREATE TABLE Users (Name NVARCHAR(50));
```

### Mistake 2: Using FLOAT for Money
```sql
-- WRONG
CREATE TABLE Products (Price FLOAT);

-- RIGHT
CREATE TABLE Products (Price DECIMAL(18,2));
```

### Mistake 3: Not Specifying String Length
```sql
-- WRONG
CREATE TABLE Users (Email VARCHAR);

-- RIGHT
CREATE TABLE Users (Email VARCHAR(100));
```

### Mistake 4: Using DATETIME Instead of DATETIME2
```sql
-- WRONG (for new tables)
CREATE TABLE Events (EventDate DATETIME);

-- RIGHT
CREATE TABLE Events (EventDate DATETIME2);
```

---

## 9. Key Differences Between SQL Data Types (Beginner-Friendly)

When you design a database, you will see that SQL has many data types that look similar. Choosing the right one is important for saving space, making your database faster, and avoiding bugs. Here are the most important differences, explained simply:

### VARCHAR vs NVARCHAR
- **VARCHAR** is for normal English text (like names, addresses in English). It uses 1 byte for each character.
- **NVARCHAR** is for text in any language (like Turkish, Chinese, Arabic, emojis). It uses 2 bytes for each character, so it takes more space, but it can store any character from any language.
- **Analogy:** Think of `VARCHAR` as a notebook with only English letters, and `NVARCHAR` as a notebook that can hold any language.
- **When to use:**
  - Use `VARCHAR` if you are sure your data will always be English or basic Latin characters.
  - Use `NVARCHAR` if you might have names, addresses, or messages in other languages.
- **Example:**
  - `VARCHAR(50)` can store "John Smith".
  - `NVARCHAR(50)` can store "李小龙" or "Çağdaş".

### CHAR vs VARCHAR
- **CHAR(n)** is for text that is always the same length. For example, a country code like "USA" or "TUR" is always 3 letters. If you store "US" in `CHAR(3)`, it will actually be "US " (with a space).
- **VARCHAR(n)** is for text that can be any length up to `n`. It only uses as much space as needed.
- **Analogy:** `CHAR` is like a row of lockers that are always the same size, even if you put a small item inside. `VARCHAR` is like a bag that grows or shrinks to fit what you put in it.
- **When to use:**
  - Use `CHAR` for things like codes, fixed-length IDs.
  - Use `VARCHAR` for names, emails, descriptions.
- **Example:**
  - `CHAR(2)` for country codes: "US", "TR".
  - `VARCHAR(100)` for a person's name: "Alexander" or "Li".

### NCHAR vs NVARCHAR
- **NCHAR(n)** is like `CHAR`, but for Unicode (all languages). Always uses the same space.
- **NVARCHAR(n)** is like `VARCHAR`, but for Unicode. Uses only as much space as needed.
- **When to use:**
  - Use `NCHAR` for fixed-length international codes.
  - Use `NVARCHAR` for variable-length international text.
- **Example:**
  - `NCHAR(5)` for a fixed-length code in any language.
  - `NVARCHAR(100)` for a message or name in any language.

### TEXT, NTEXT, IMAGE (Deprecated)
- These are old types for big text or binary data. They are not recommended anymore.
- **Use instead:**
  - `VARCHAR(MAX)` for very long text (up to 2GB).
  - `NVARCHAR(MAX)` for very long international text.
  - `VARBINARY(MAX)` for big files or images.
- **Tip:** If you see `TEXT`, `NTEXT`, or `IMAGE` in old databases, plan to change them to the new types.

### DECIMAL vs FLOAT
- **DECIMAL(p,s)** is for numbers where you need exact values, like money. You set how many digits you want (precision) and how many after the decimal point (scale).
- **FLOAT** is for numbers that can be very big or very small, but not always exact. Good for scientific data, not for money.
- **Analogy:** `DECIMAL` is like a ruler with clear, exact marks. `FLOAT` is like a stretchy tape measure—close, but not always exact.
- **When to use:**
  - Use `DECIMAL` for prices, quantities, anything where "1.00" must always be exactly "1.00".
  - Use `FLOAT` for measurements, scientific data, or when a tiny error is okay.
- **Example:**
  - `DECIMAL(10,2)` for money: 12345.67
  - `FLOAT` for temperature: 36.6, 98.6

### MONEY vs DECIMAL
- **MONEY** is a special type for currency, but it can have rounding errors and is less flexible.
- **DECIMAL** is more precise and is the modern choice for money.
- **Best practice:** Always use `DECIMAL` for new financial columns.
- **Example:**
  - `DECIMAL(18,4)` for storing prices: 1234.5678

### DATETIME vs DATETIME2
- **DATETIME** is the old date/time type. It has a smaller range (starts at 1753) and is less accurate (rounded to 3 milliseconds).
- **DATETIME2** is newer, has a bigger range (starts at year 1), and is more accurate (down to 100 nanoseconds). It can also use less space.
- **When to use:**
  - Use `DATETIME2` for all new tables and columns.
  - Use `DATETIME` only if you must match an old system.
- **Example:**
  - `DATETIME2` can store "0001-01-01 00:00:00.0000000"
  - `DATETIME` can only store from "1753-01-01"

### SMALLINT, INT, BIGINT, TINYINT
- These are all for whole numbers, but with different ranges and storage sizes:
  - **TINYINT**: 0 to 255 (1 byte)
  - **SMALLINT**: -32,768 to 32,767 (2 bytes)
  - **INT**: -2,147,483,648 to 2,147,483,647 (4 bytes)
  - **BIGINT**: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 (8 bytes)
- **Tip:** Always choose the smallest type that fits your data. This saves space and makes your database faster.
- **Example:**
  - Use `TINYINT` for age (if max is 120), `INT` for user IDs, `BIGINT` for very large numbers like file sizes.

### BIT
- **BIT** is for true/false (yes/no) values. It stores 0 (false), 1 (true), or NULL (unknown).
- **Efficient:** Up to 8 BIT columns are stored in 1 byte.
- **Example:**
  - `IsActive BIT` for "Is this user active?"

### UNIQUEIDENTIFIER
- **UNIQUEIDENTIFIER** stores a GUID (Globally Unique Identifier), which is a long, unique value like `6F9619FF-8B86-D011-B42D-00C04FC964FF`.
- **Use for:** When you need a value that is unique across all tables, databases, or even servers (for example, in distributed systems).
- **Note:** Not as fast for searching or sorting as integer IDs.
- **Example:**
  - `UserId UNIQUEIDENTIFIER` for a user ID that must be unique everywhere.

---

**Summary Table (Beginner-Friendly):**

| Type Pair         | Main Difference                        | Best Use Case                        |
|-------------------|----------------------------------------|--------------------------------------|
| VARCHAR vs NVARCHAR | NVARCHAR stores all languages         | NVARCHAR for names/messages          |
| CHAR vs VARCHAR     | CHAR is always same length            | CHAR for codes, VARCHAR for text     |
| DECIMAL vs FLOAT    | DECIMAL is exact, FLOAT is "close"    | DECIMAL for money, FLOAT for science |
| DATETIME vs DATETIME2 | DATETIME2 is newer, more accurate   | DATETIME2 for all new dates/times    |
| MONEY vs DECIMAL    | DECIMAL is more precise               | DECIMAL for all new money columns    |
| TINYINT/SMALLINT/INT/BIGINT | Different number ranges       | Use smallest that fits your data     |
| BIT                | True/false values                     | Flags, yes/no columns                |
| UNIQUEIDENTIFIER   | Very large, unique value              | IDs that must be unique everywhere   |

---

## 10. Troubleshooting Common Issues

### Issue: "String or binary data would be truncated"
**Cause:** You're trying to insert data that's too long for the column.
**Solution:** Increase the column size or truncate the data.

### Issue: "Arithmetic overflow error"
**Cause:** Number is too large for the data type.
**Solution:** Use a larger data type (e.g., `BIGINT` instead of `INT`).

### Issue: "Conversion failed when converting date and/or time"
**Cause:** Date format or range issue.
**Solution:** Use `DATETIME2` for better range and format support.

### Issue: "Implicit conversion from data type varchar to numeric"
**Cause:** SQL Server is trying to convert string to number automatically.
**Solution:** Use explicit conversion or fix the data type.

---

## 11. References & Further Reading
- [Microsoft C# Data Types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [SQL Server Data Types](https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql)
- [Best Practices for Data Type Selection](https://learn.microsoft.com/en-us/sql/relational-databases/sql-server-index-design-guide)

---

## 12. About This Project
This guide is part of the **C# to SQL Data Types Learning System**. The console application allows you to:
- Explore C# and SQL data types
- Compare and map types
- View conversion examples
- Learn best practices
- Search for data type information

Happy coding! 