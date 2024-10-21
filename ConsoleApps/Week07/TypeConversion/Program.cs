namespace TypeConversion;

internal class Program
{
    static void Main(string[] args)
    {
        // Example 1: Convert double to int (decimal part will be lost)
        double myDoubleValue = 9.78;
        int doubleAsInt = Convert.ToInt32(myDoubleValue);
        Console.WriteLine($"Double as integer: {doubleAsInt}");  // 9 (decimal part is truncated)

        // Example 2: Convert boolean to string
        bool myBoolValue = true;
        string boolAsString = Convert.ToString(myBoolValue);
        Console.WriteLine($"Boolean as string: {boolAsString}");  // "True"

        // Example 3: Convert string to int (if the string is a valid number)
        string strNumber = "123";
        int strToInt = Convert.ToInt32(strNumber);
        Console.WriteLine($"String '123' as integer: {strToInt}");  // 123

        // Example 4: Convert string to int with invalid input (throws exception)
        try
        {
            string invalidStr = "ABC";  // Not a number
            int invalidConversion = Convert.ToInt32(invalidStr);  // Will throw an exception
        }
        catch (FormatException e)
        {
            Console.WriteLine("Error during conversion: " + e.Message);
        }

        // Example 5: Convert string to double
        string strDouble = "123.45";
        double strToDouble = Convert.ToDouble(strDouble);
        Console.WriteLine($"String '123.45' as double: {strToDouble}");  // 123.45

        // Example 6: Convert string to boolean
        string strBool = "true";
        bool strToBool = Convert.ToBoolean(strBool);
        Console.WriteLine($"String 'true' as boolean: {strToBool}");  // True

        // Example 7: Convert string to DateTime
        string strDate = "2023-10-01";
        DateTime strToDate = Convert.ToDateTime(strDate);
        Console.WriteLine($"String '2023-10-01' as DateTime: {strToDate.ToShortDateString()}");  // 10/1/2023

        // The Difference between Type Casting and Type Conversion:
        // - Type Casting: More low-level, often requires explicit cast when there's potential data loss.
        // - Type Conversion: Higher-level, uses built-in methods (Convert.ToInt32, Convert.ToString, etc.) to safely change types.

        // Summary of Key Points:
        // - Implicit casting is automatic and safe, as there's no data loss.
        // - Explicit casting must be done manually, as data loss may occur.
        // - Use Convert methods for safe conversions between types with built-in error handling.

        // Example: Safe conversion with Convert.ToInt32 to ensure that incorrect conversions don't occur.
        string safeStr = "42";
        int safeInt = Convert.ToInt32(safeStr);
        Console.WriteLine($"Safely converted string '42' to integer: {safeInt}");
        
        // Example 8: Parse method for string to int conversion
        string parseStr = "100";
        int parsedInt = int.Parse(parseStr);
        Console.WriteLine($"Parsed string '100' to integer: {parsedInt}");
        
        // Example 9: TryParse method for string to int conversion
        string tryParseStr = "200";
        if (int.TryParse(tryParseStr, out int tryParsedInt))
        {
            Console.WriteLine($"Successfully parsed string '200' to integer: {tryParsedInt}");
        }
        else
        {
            Console.WriteLine("Failed to parse string '200' to integer");
        }

        // Example 10: Convert char to int
        char charValue = 'A';
        int charToInt = Convert.ToInt32(charValue);
        Console.WriteLine($"Char 'A' as integer: {charToInt}");  // 65

        // Example 11: Convert int to char
        int intValue = 66;
        char intToChar = Convert.ToChar(intValue);
        Console.WriteLine($"Integer 66 as char: {intToChar}");  // 'B'

        // Example 12: Convert string to char array
        string str = "Hello";
        char[] charArray = str.ToCharArray();
        Console.WriteLine($"String 'Hello' as char array: {string.Join(", ", charArray)}");  // 'H', 'e', 'l', 'l', 'o'

        // Example 13: Convert char array to string
        char[] chars = { 'W', 'o', 'r', 'l', 'd' };
        string charArrayToStr = new string(chars);
        Console.WriteLine($"Char array 'W', 'o', 'r', 'l', 'd' as string: {charArrayToStr}");  // "World"
    }
}