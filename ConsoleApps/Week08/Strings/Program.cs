using System.Text;

namespace Strings;

class Program
{
    static void Main()
    {
        // 1. Creating Strings
        string greeting = "Hello, World!";
        Console.WriteLine(greeting); // Output: Hello, World!

        // 2. String Concatenation
        string firstName = "John";
        string lastName = "Doe";
        string fullName = firstName + " " + lastName;
        string fullNameConcat = string.Concat(firstName, " ", lastName);
        string fullNameFormat = string.Format("{0} {1}", firstName, lastName);
        Console.WriteLine(fullName);        // Output: John Doe
        Console.WriteLine(fullNameConcat);  // Output: John Doe
        Console.WriteLine(fullNameFormat);  // Output: John Doe
        Console.WriteLine("{0} {1}", firstName, lastName);  // Output: John Doe

        // 3. String Interpolation
        string name = "Alice";
        int age = 25;
        string message = $"Name: {name}, Age: {age}";
        Console.WriteLine(message); // Output: Name: Alice, Age: 25

        // 4. Accessing Characters in a String
        string text = "Hello";
        char firstChar = text[0];
        Console.WriteLine(firstChar); // Output: H

        // 5. Common String Methods
        string sample = " Hello, World! ";
        Console.WriteLine(sample.Length);           // Output: 15
        Console.WriteLine(sample.ToUpper());        // Output: " HELLO, WORLD! "
        Console.WriteLine(sample.Trim());           // Output: "Hello, World!"
        Console.WriteLine(sample.Substring(7, 5));  // Output: "World"
        Console.WriteLine(sample.Replace("World", "C#")); // Output: " Hello, C#! "

        // 6. Checking if a String Contains or Starts/Ends With Another String
        string sentence = "C# Programming is fun!";
        Console.WriteLine(sentence.Contains("Programming")); // Output: True
        Console.WriteLine(sentence.StartsWith("C#"));        // Output: True
        Console.WriteLine(sentence.EndsWith("fun!"));        // Output: True

        // 7. Splitting and Joining Strings
        string fruits = "apple,banana,orange";
        string[] fruitArray = fruits.Split(',');
        Console.WriteLine(fruitArray[0]); // Output: apple

        string[] words = { "Hello", "World" };
        string joinedText = string.Join(" ", words);
        Console.WriteLine(joinedText); // Output: Hello World

        // 8. Checking for Null or Empty Strings
        string emptyText = " ";
        Console.WriteLine(string.IsNullOrEmpty(emptyText));      // Output: False
        Console.WriteLine(string.IsNullOrWhiteSpace(emptyText)); // Output: True

        // 9. Comparing Strings
        string text1 = "hello";
        string text2 = "Hello";
        Console.WriteLine(text1 == text2);  // Output: False
        Console.WriteLine(string.Equals(text1, text2, StringComparison.OrdinalIgnoreCase)); // Output: True

        // 10. Formatting Strings
        int quantity = 3;
        double price = 5.99;
        string formatted = string.Format("You bought {0} items at ${1:0.00} each.", quantity, price);
        Console.WriteLine(formatted); // Output: You bought 3 items at $5.99 each.

        // 11. Escaping Special Characters
        string quote = "He said, \"Hello!\"";
        Console.WriteLine(quote); // Output: He said, "Hello!"

        // Verbatim string (useful for file paths)
        string path = @"C:\Users\Name\Documents";
        string path2 = "C:\\Users\\Asus\\Documents\\Github\\charp-04-lessons\\CSharp04";
        Console.WriteLine(path); // Output: C:\Users\Name\Documents

        // 12. Multi-line Strings (C# 11 or newer)
        //string multiLine = """
        //    Line one
        //    Line two
        //    Line three
        //    """;

        string multiLine = @"
            Line one
            Line two
            Line three
            ";

        Console.WriteLine(multiLine);

        // 13. StringBuilder for Efficient String Manipulation
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(" World");
        sb.Replace("World", "C#");
        Console.WriteLine(sb.ToString()); // Output: Hello C#

        // Difference between String and StringBuilder in C# ********
        //************************************************************

        /* 
     * 1. Mutability:
     * - String: Immutable; any modification creates a new instance.
     * - StringBuilder: Mutable; allows modifications without creating new instances.
     */
        string text3 = "Hello";
        text3 += " World"; // Creates a new String object in memory
        Console.WriteLine("Using String: " + text3); // Output: Hello World

        StringBuilder sb2 = new StringBuilder("Hello");
        sb2.Append(" World"); // Modifies the existing StringBuilder object
        Console.WriteLine("Using StringBuilder: " + sb2.ToString()); // Output: Hello World

        /* 
     * 2. Performance:
     * - String: Slow for multiple modifications because each change creates a new object.
     * - StringBuilder: Fast for multiple modifications as it modifies the existing object.
     * Below is a performance test showing the difference.
     */
        int repeat = 10000;

        // Using String (slower for repetitive modifications)
        string str = "Hello";
        DateTime startString = DateTime.Now;
        for (int i = 0; i < repeat; i++)
        {
            str += " World";
        }
        DateTime endString = DateTime.Now;
        Console.WriteLine($"String Time: {(endString - startString).TotalMilliseconds} ms");

        // Using StringBuilder (faster for repetitive modifications)
        StringBuilder sbPerf = new StringBuilder("Hello");
        DateTime startStringBuilder = DateTime.Now;
        for (int i = 0; i < repeat; i++)
        {
            sbPerf.Append(" World");
        }
        DateTime endStringBuilder = DateTime.Now;
        Console.WriteLine($"StringBuilder Time: {(endStringBuilder - startStringBuilder).TotalMilliseconds} ms");

        /* 
     * 3. Memory Usage:
     * - String: Higher memory usage due to creation of new objects during modification.
     * - StringBuilder: Lower memory usage because it modifies data within the same memory block.
     */

        /* 
     * 4. Thread Safety:
     * - String: Thread-safe due to immutability. Multiple threads can safely access the same String instance.
     * - StringBuilder: Not thread-safe; synchronization is required in multi-threaded scenarios.
     */

        /* 
     * 5. Use Cases:
     * - String: Ideal for text that does not change often or needs minimal modification (e.g., constant values or messages).
     * - StringBuilder: Suitable for scenarios with frequent modifications, such as building dynamic strings in loops.
     */

        /* 
     * 6. Common Operations:
     * - String: Includes methods like `Replace`, `Substring`, `Trim`, and concatenation (`+`).
     * - StringBuilder: Includes methods like `Append`, `Insert`, `Remove`, `Clear`, and `Replace`.
     */

        // Example with common String operations
        string greeting1 = "Hello";
        greeting1 = greeting1.Replace("Hello", "Hi"); // Creates a new String instance
        Console.WriteLine("String after Replace: " + greeting1); // Output: Hi

        // Example with common StringBuilder operations
        StringBuilder sbExample = new StringBuilder("Hello");
        sbExample.Replace("Hello", "Hi"); // Modifies the existing StringBuilder instance
        Console.WriteLine("StringBuilder after Replace: " + sbExample.ToString()); // Output: Hi
    }
}