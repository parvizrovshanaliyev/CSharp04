namespace ObjectAndBoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * === Boxing and Unboxing ===
             * Boxing:
             * - Converts a value type (e.g., int) into a reference type (object).
             * - Useful when you need to store or pass value types in a context that expects objects.
             * 
             * Unboxing:
             * - Converts an object back into its original value type.
             * - Requires explicit casting to ensure type safety.
             * 
             * Why learn this?
             * - Understanding boxing and unboxing helps you write efficient code when working with mixed-type scenarios
             *   or APIs that handle objects.
             */

            Console.WriteLine("=== Boxing, Unboxing, and GetType Demonstration ===\n");

            // Boxing: Convert a value type (int) into an object
            int number = 42;                     // Value type stored on the stack
            object boxedNumber = number;         // Boxing: value copied to the heap and treated as an object
            Console.WriteLine("Boxed Type: " + boxedNumber.GetType()); // Output: System.Int32
            Console.WriteLine("Boxed Value: " + boxedNumber);          // Output: 42

            // Accessing the original type of the value
            Console.WriteLine("Original Type: " + number.GetType());   // Output: System.Int32

            // Unboxing: Convert the object back to a value type
            if (boxedNumber.GetType() == typeof(int))                  // Using GetType() to confirm the type
            {
                int unBoxedNumber = (int)boxedNumber;                  // Casting back to int after type check
                Console.WriteLine("Unboxed Value: " + unBoxedNumber);  // Output: 42
            }

            Console.WriteLine();

            /*
             * === Object Methods ===
             * Every type in C# (both value and reference types) inherits from the base class 'object'.
             * This means that all types have the following methods:
             * 
             * 1. GetType(): Retrieves the runtime type of an object.
             * 2. Equals(): Determines equality between objects.
             * 3. GetHashCode(): Generates a hash code for an object.
             * 4. ToString(): Provides a human-readable string representation of an object.
             * 
             * These methods can be overridden in custom classes to provide more meaningful behavior.
             */

            Console.WriteLine("=== Object Methods Demonstration ===\n");

            /*
             * === GetType Demonstration ===
             * The GetType() method returns the runtime type of an object.
             * Use cases:
             * - Confirming the type of an object before performing operations like unboxing or casting.
             * - Debugging to check the type of objects at runtime.
             */

            Console.WriteLine("--- GetType Demonstration ---\n");

            // Using GetType() with different objects
            Console.WriteLine("Type of number (int): " + number.GetType());              // Output: System.Int32
            Console.WriteLine("Type of boxedNumber (object): " + boxedNumber.GetType()); // Output: System.Int32

            // Using GetType() with custom objects
            User user = new User { UserName = "Alice" };
            Console.WriteLine("Type of user (User object): " + user.GetType());          // Output: ObjectMethodExamples.User

            Console.WriteLine();

            /*
             * === Equals Method ===
             * The Equals() method determines equality between objects.
             * Default Behavior:
             * - For value types: Compares actual values.
             * - For reference types: Compares memory addresses unless overridden.
             * Overridden Behavior:
             * - Logical equality can be defined based on specific properties.
             */

            Console.WriteLine("--- Equals Method Demonstration ---\n");

            // Default Equals for Value Types
            object value1 = 42; // Boxed value type
            object value2 = 42; // Another boxed value type
            Console.WriteLine("Default Equals (Value Type): " + value1.Equals(value2)); // Output: True

            // Default Equals for Reference Types
            User user1 = new User { UserName = "Alice" };
            User user2 = new User { UserName = "Alice" };
            Console.WriteLine("Default Equals (Reference Type): " + user1.Equals(user2)); // Output: False

            // Overridden Equals for Student Class
            Student student1 = new Student { StudentId = 1, Name = "Alice" };
            Student student2 = new Student { StudentId = 1, Name = "alice" }; // Case-insensitive comparison
            Console.WriteLine("Overridden Equals: " + student1.Equals(student2)); // Output: True

            Console.WriteLine();

            /*
             * === ToString Method ===
             * The ToString() method provides a human-readable string representation of an object.
             * Default Behavior:
             * - Returns the fully qualified class name.
             * Overridden Behavior:
             * - Displays meaningful details, such as property values, to aid debugging or logging.
             */

            Console.WriteLine("--- ToString Method Demonstration ---\n");

            // Default ToString for User
            Console.WriteLine("Default ToString: " + user1.ToString()); // Output: ObjectMethodExamples.User

            // Overridden ToString for Student
            Console.WriteLine("Overridden ToString: " + student1.ToString()); // Output: StudentId: 1, Name: Alice

            Console.WriteLine();

            /*
             * === GetHashCode Method ===
             * The GetHashCode() method generates a hash code for an object.
             * Default Behavior:
             * - Generates a unique identifier for each object instance (based on memory address).
             * Overridden Behavior:
             * - Ensures logically equal objects produce the same hash code.
             */

            Console.WriteLine("--- GetHashCode Method Demonstration ---\n");

            // Default GetHashCode for User
            Console.WriteLine("Default GetHashCode (User1): " + user1.GetHashCode());
            Console.WriteLine("Default GetHashCode (User2): " + user2.GetHashCode());

            // Overridden GetHashCode for Student
            Console.WriteLine("Overridden GetHashCode (Student1): " + student1.GetHashCode());
            Console.WriteLine("Overridden GetHashCode (Student2): " + student2.GetHashCode()); // Same hash code as Student1

            Console.WriteLine();

            /*
             * === Value Type vs Reference Type Comparisons ===
             * Value Types:
             * - Compared by their actual data (values).
             * Reference Types:
             * - Compared by memory address unless Equals() is overridden.
             */

            Console.WriteLine("--- Value Type vs Reference Type Comparisons ---\n");

            // Value Type Comparison
            Console.WriteLine("Value Type Comparison (Default Equals): " + value1.Equals(value2)); // Output: True

            // Reference Type Comparison (Default Equals)
            Console.WriteLine("Reference Type Comparison (Default Equals): " + user1.Equals(user2)); // Output: False

            // Overridden Reference Type Comparison
            Console.WriteLine("Reference Type Comparison (Overridden Equals): " + student1.Equals(student2)); // Output: True

            /*
            * === MemberwiseClone Demonstration ===
            * - Creates a shallow copy of the current object.
            * - Only copies the values of the object's fields. If fields are reference types, only the references are copied.
            * 
            * Use cases:
            * - Create a quick copy of an object for scenarios like undo/redo operations, or prototyping data.
            */

            Console.WriteLine("--- MemberwiseClone Demonstration ---\n");

            // Using MemberwiseClone for shallow copying
            User originalUser = new User { UserName = "Alice" };
            User clonedUser = originalUser.Clone();

            // Display original and cloned object details
            Console.WriteLine($"Original User: {originalUser}"); // Output: User: Alice
            Console.WriteLine($"Cloned User: {clonedUser}");     // Output: User: Alice

            // Show that they are different objects
            Console.WriteLine($"Are Original and Cloned User Equal (Reference): {ReferenceEquals(originalUser, clonedUser)}"); // Output: False

            // Modify the cloned object's properties
            clonedUser.UserName = "Bob";
            Console.WriteLine($"Modified Cloned User: {clonedUser}"); // Output: User: Bob
            Console.WriteLine($"Original User Remains Unchanged: {originalUser}"); // Output: User: Alice

            Console.WriteLine();


            /*
             * === Why Do We Need Boxing and Unboxing? ===
             * In C#, certain scenarios require treating value types as objects, such as:
             * 
             * 1. Storing value types in data structures that require objects, like an object array.
             * 2. Passing value types to methods or APIs that accept parameters of type object.
             * 3. Working with collections like `ArrayList` (pre-generic collections in .NET) that only store objects.
             * 
             * Boxing allows value types to be converted into objects, enabling their use in such scenarios.
             * Unboxing helps retrieve the original value types when needed.
             */

            Console.WriteLine("=== Why Boxing and Unboxing? ===");

            // Example: Storing value types in an object array
            object[] mixedArray = new object[3];
            mixedArray[0] = 42;      // Boxing the int
            mixedArray[1] = 3.14;    // Boxing the double
            mixedArray[2] = "Hello"; // No boxing for string (it's already a reference type)

            // Access and unbox values from the array
            int intValue = (int)mixedArray[0];        // Unboxing the int
            double doubleValue = (double)mixedArray[1]; // Unboxing the double
            string stringValue = (string)mixedArray[2]; // Direct cast, no unboxing

            Console.WriteLine($"Array contains: {intValue}, {doubleValue}, {stringValue}");

            Console.WriteLine();

            /*
             * === Advantages of Boxing and Unboxing ===
             * 1. Enables interoperability between value types and reference types.
             * 2. Allows value types to be stored and manipulated in collections or APIs designed for objects.
             * 3. Provides flexibility when working with mixed-type data.
             * 
             * === Disadvantages of Boxing and Unboxing ===
             * 1. Performance Overhead:
             *    - Boxing allocates memory on the heap, which is slower than stack allocation.
             *    - Unboxing involves runtime type checking and conversion, adding overhead.
             * 2. Increased Garbage Collection:
             *    - Frequent boxing and unboxing creates temporary objects on the heap, increasing GC pressure.
             * 3. Type Safety:
             *    - Unboxing requires explicit casting, which can lead to runtime exceptions if types don’t match.
             */

            Console.WriteLine("=== Advantages and Disadvantages of Boxing/Unboxing ===");

            Console.WriteLine("Advantages:");
            Console.WriteLine("- Interoperability between value types and reference types.");
            Console.WriteLine("- Flexibility when working with mixed-type data.");
            Console.WriteLine();

            Console.WriteLine("Disadvantages:");
            Console.WriteLine("- Performance overhead due to heap allocation.");
            Console.WriteLine("- Increased garbage collection workload.");
            Console.WriteLine("- Potential runtime exceptions due to explicit casting.");
            Console.WriteLine();

            /*
             * === How to Reduce and Avoid Boxing/Unboxing ===
             * Modern C# practices help minimize the need for boxing/unboxing:
             * 
             * 1. Use Generics:
             *    - Generic collections like List<T> and Dictionary<K, V> eliminate the need for boxing.
             *    - Instead of object-based collections like ArrayList, use type-safe generic collections.
             * 2. Use Modern .NET APIs:
             *    - Most modern .NET APIs are type-safe and designed to minimize boxing/unboxing.
             * 3. Avoid Mixed-Type Collections:
             *    - Keep collections type-specific to avoid boxing/unboxing overhead.
             * 4. Use ValueTask and Span<T>:
             *    - These modern structures are optimized for performance-critical scenarios.
             */

            Console.WriteLine("=== How to Avoid Boxing/Unboxing Issues ===");

            // Example: Using a generic list instead of an object array to avoid boxing
            Console.WriteLine("--- Using Generics to Avoid Boxing ---");

            // Using a generic list for type safety
            var intList = new System.Collections.Generic.List<int> { 42, 43, 44 }; // No boxing required
            foreach (int item in intList)
            {
                Console.WriteLine(item); // Direct access to value types without boxing
            }

            Console.WriteLine();

            /*
             * === Modern C# Practices ===
             * Modern C# versions (starting from C# 2.0 with Generics) provide better tools to avoid boxing/unboxing:
             * - Use strongly typed generic collections like List<T>.
             * - Avoid legacy non-generic collections like ArrayList, which rely on objects.
             */

            Console.WriteLine("=== Modern C# Practices ===");

            Console.WriteLine("1. Use strongly typed collections like List<T>.");
            Console.WriteLine("2. Avoid ArrayList and other non-generic collections.");
            Console.WriteLine("3. Embrace newer language features for performance.");
        }

    }
}
