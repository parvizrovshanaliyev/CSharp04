using System.Diagnostics;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1: Exploring Object Methods ===\n");

            // Create two Person objects with identical Name and Age values
            Person person1 = new Person { Name = "Alice", Age = 25 };
            Person person2 = new Person { Name = "Alice", Age = 25 };

            // === Demonstrating GetType ===
            Console.WriteLine("--- GetType Demonstration ---");
            Console.WriteLine($"Type of person1: {person1.GetType()}"); // Output: Task1ObjectMethods.Person
            Console.WriteLine($"Type of person2: {person2.GetType()}"); // Output: Task1ObjectMethods.Person

            // === Demonstrating Equals ===
            Console.WriteLine("\n--- Equals Method Demonstration ---");
            Console.WriteLine($"Are person1 and person2 equal (using overridden Equals)? {person1.Equals(person2)}");
            // Output: True

            // === Demonstrating ToString ===
            Console.WriteLine("\n--- ToString Method Demonstration ---");
            Console.WriteLine($"String representation of person1: {person1}");
            // Output: Name: Alice, Age: 25

            // === Demonstrating GetHashCode ===
            Console.WriteLine("\n--- GetHashCode Method Demonstration ---");
            Console.WriteLine($"HashCode of person1: {person1.GetHashCode()}");
            Console.WriteLine($"HashCode of person2: {person2.GetHashCode()}");
            // Outputs: Identical hash codes for person1 and person2

            // === Testing Reference Equality ===
            Console.WriteLine("\n--- Reference Equality Test ---");
            Person person3 = person1; // Assign person1 to person3
            Console.WriteLine($"Are person1 and person3 the same instance? {ReferenceEquals(person1, person3)}");
            // Output: True, since person3 references the same object as person1

            // === Testing Value Equality with Modified Person ===
            Console.WriteLine("\n--- Modified Equality Test ---");
            Person person4 = new Person { Name = "Bob", Age = 30 };
            Console.WriteLine($"Are person1 and person4 equal (using overridden Equals)? {person1.Equals(person4)}");
            // Output: False, as their Name and Age properties differ



            /*
             * === Task 3: Measuring Boxing Performance ===
             * 
             * Objective:
             * - Understand the performance impact of boxing and unboxing compared to direct type usage.
             * - Learn how to measure execution time using the Stopwatch class.
             * 
             * Why It Matters:
             * - Boxing involves allocating memory on the heap, which is slower than stack allocation.
             * - Unboxing introduces runtime type checks, further slowing down execution.
             * - Direct type usage avoids these costs, leading to faster and more efficient code.
             */

            Console.WriteLine("=== Task 3: Measuring Boxing Performance ===\n");

            const int size = 1_000_000; // Define the size of the arrays

            // Step 1: Arrays for Testing
            Console.WriteLine("--- Step 1: Setting Up Arrays ---");
            object[] boxedArray = new object[size]; // Array to store boxed values
            int[] intArray = new int[size];         // Array for direct type usage
            Console.WriteLine("Arrays initialized.\n");

            // Step 2: Measuring Boxing Performance
            Console.WriteLine("--- Step 2: Measuring Boxing Performance ---");
            Stopwatch stopwatch = new Stopwatch(); // Create a Stopwatch instance for timing

            stopwatch.Start(); // Start measuring time
            for (int i = 0; i < size; i++)
            {
                boxedArray[i] = i; // Boxing: Converting int to object
            }
            stopwatch.Stop(); // Stop measuring time
            Console.WriteLine($"Time for boxing {size} integers: {stopwatch.ElapsedMilliseconds} ms\n");

            // Step 3: Measuring Unboxing Performance
            Console.WriteLine("--- Step 3: Measuring Unboxing Performance ---");
            stopwatch.Restart(); // Restart the stopwatch for unboxing
            for (int i = 0; i < size; i++)
            {
                int value = (int)boxedArray[i]; // Unboxing: Converting object back to int
            }
            stopwatch.Stop();
            Console.WriteLine($"Time for unboxing {size} integers: {stopwatch.ElapsedMilliseconds} ms\n");

            // Step 4: Measuring Direct Type Usage Performance
            Console.WriteLine("--- Step 4: Measuring Direct Type Usage Performance ---");
            stopwatch.Restart(); // Restart the stopwatch for direct type usage
            for (int i = 0; i < size; i++)
            {
                intArray[i] = i; // Directly assigning values to an int array
            }
            stopwatch.Stop();
            Console.WriteLine($"Time for direct type usage {size} integers: {stopwatch.ElapsedMilliseconds} ms\n");

            /*
             * === Analysis ===
             * - Boxing allocates memory on the heap, which is slower than stack allocation.
             * - Unboxing adds runtime type checks, introducing additional overhead.
             * - Direct type usage avoids these costs, leading to significantly faster performance.
             */

            Console.WriteLine("=== Analysis ===");
            Console.WriteLine("1. Boxing is slow due to heap allocation.");
            Console.WriteLine("2. Unboxing adds runtime type checks, slowing down execution further.");
            Console.WriteLine("3. Direct type usage is faster as it avoids heap allocations and runtime checks.\n");

        }
    }
}
