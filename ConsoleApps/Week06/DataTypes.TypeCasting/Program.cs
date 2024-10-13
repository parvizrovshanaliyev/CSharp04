namespace DataTypes.TypeCasting;

public class Program
{
    public static void Main()
    {
        // C# Type Casting
        // Type casting is the process of converting a variable from one data type to another.
        // It can happen automatically (implicit casting) or manually (explicit casting).
        
        // 1. Implicit Casting (automatically handled by the compiler)
        //    - When converting a smaller type to a larger type. This is safe as there is no data loss.
        //    - Examples: char -> int -> long -> float -> double
        
        // Imagine you're pouring water (byte) into larger containers (int, long, double).
        // Since the container is larger, nothing spills, and all the data fits.
        
        byte age = 24;         // 8-bit: holds values from 0 to 255
        int ageInYears = age;  // 32-bit: can hold much larger numbers than byte
        long ageInMilliseconds = ageInYears * 365 * 24 * 60 * 60 * 1000L;  // 64-bit: age in milliseconds
        
        Console.WriteLine($"Age in years (int): {ageInYears}");
        Console.WriteLine($"Age in milliseconds (long): {ageInMilliseconds}");

        // Notice that the smaller type (byte) was automatically converted to larger types (int, long).

        // Further implicit casting: long to double (128-bit)
        // Example: You can imagine this as pouring data into an even larger container, no data loss.
        double preciseAge = ageInMilliseconds;
        Console.WriteLine($"Precise age in milliseconds (double): {preciseAge}");

        // 2. Explicit Casting (requires manual conversion)
        //    - Used when converting a larger type to a smaller type.
        //    - Since this may cause data loss, it must be done manually.
        //    - Examples: double -> float -> long -> int -> char

        // Real-world analogy: Imagine pouring water from a big bucket (double) into a small cup (float).
        // If the bucket has more water than the cup can hold, some data will "spill out" (be lost).

        double largeNumber = 123456.789;  // A large double value
        // Casting double to float (less precision)
        float smallerNumber = (float)largeNumber;
        Console.WriteLine($"Original double value: {largeNumber}");  // 123456.789
        Console.WriteLine($"Casted float value: {smallerNumber}");   // Precision may be lost, e.g., 123456.79

        // Casting from float to int (even more data loss)
        // Here, any decimal values will be lost during conversion.
        int integerNumber = (int)smallerNumber;
        Console.WriteLine($"Casted int value (truncated): {integerNumber}");  // 123456 (decimals are gone)

        // Example: Casting from float to long (another explicit cast)
        long longNumber = (long)smallerNumber;
        Console.WriteLine($"Casted long value: {longNumber}");

        // In these conversions, precision was lost as we moved from larger types to smaller types.

        // 3. Type Conversion using Convert methods
        //    - Convert class provides built-in methods for safe type conversion between different data types.
        //    - These methods handle edge cases and throw exceptions if the conversion fails.

        // Example of using Convert methods to safely convert between types
        int myIntValue = 100;
        double myDoubleValue = 9.99;
        bool myBoolValue = true;

        // Convert int to string
        string intAsString = Convert.ToString(myIntValue);
        Console.WriteLine($"Integer as string: {intAsString}");  // "100"

        // Convert int to double
        double intAsDouble = Convert.ToDouble(myIntValue);
        Console.WriteLine($"Integer as double: {intAsDouble}");  // 100.0

        // Convert double to int (decimal part will be lost)
        int doubleAsInt = Convert.ToInt32(myDoubleValue);
        Console.WriteLine($"Double as integer: {doubleAsInt}");  // 9 (decimal part is truncated)

        // Convert boolean to string
        string boolAsString = Convert.ToString(myBoolValue);
        Console.WriteLine($"Boolean as string: {boolAsString}");  // "True"

        // Convert string to int (if the string is a valid number)
        string strNumber = "123";
        int strToInt = Convert.ToInt32(strNumber);
        Console.WriteLine($"String '123' as integer: {strToInt}");  // 123

        // Example where Convert can throw an exception: invalid string-to-int conversion
        try
        {
            string invalidStr = "ABC";  // Not a number
            int invalidConversion = Convert.ToInt32(invalidStr);  // Will throw an exception
        }
        catch (FormatException e)
        {
            Console.WriteLine("Error during conversion: " + e.Message);
        }

        // 4. The Difference between Type Casting and Type Conversion:
        //    - Type Casting: More low-level, often requires explicit cast when there's potential data loss.
        //    - Type Conversion: Higher-level, uses built-in methods (Convert.ToInt32, Convert.ToString, etc.) to safely change types.

        // Summary of Key Points:
        // - Implicit casting is automatic and safe, as there's no data loss.
        // - Explicit casting must be done manually, as data loss may occur.
        // - Use Convert methods for safe conversions between types with built-in error handling.

        // Example: Safe conversion with Convert.ToInt32 to ensure that incorrect conversions don't occur.
        string safeStr = "42";
        int safeInt = Convert.ToInt32(safeStr);
        Console.WriteLine($"Safely converted string '42' to integer: {safeInt}");
    }
}

