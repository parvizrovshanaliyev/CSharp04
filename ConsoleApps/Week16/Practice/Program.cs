using System.Diagnostics;

namespace Practice
{
     class Program
    {
        static void Main(string[] args)
        {
            DemonstratingObjectMethods();

            DemonstratingBoxingAndUnboxing();

            MeasuringBoxingPerformance();

            EmployeeManagementSystem();

            Sum(5, "salam");
        }

        static int Sum(object a, object b)
        {
            if (a.GetType() == b.GetType())
            {
                return (int)a + (int)b;
            }

            return 0;
        }

        private static void EmployeeManagementSystem()
        {
            /*
             * === Task 4: Employee Management System ===
             * 
             * Objective:
             * - Create an encapsulated Employee class to manage employee data securely.
             * - Implement methods to update employee details with validation.
             * - Demonstrate operations such as setting salary, updating performance ratings, and changing departments.
             */
            Console.WriteLine("=== Task 4: Employee Management System ===\n");
            Employee employee = new Employee(1, "John Doe", "IT");

            // Display initial details
            Console.WriteLine("--- Initial Employee Details ---");
            employee.GetDetails();

            // Set salary
            Console.WriteLine("--- Setting Salary ---");

            //employee._salary = 3000;
            employee.SetSalary(3000);
            employee.GetDetails();

            // Update performance rating
            Console.WriteLine("--- Updating Performance Rating ---");
            employee.UpdatePerformanceRating(4);
            employee.GetDetails();

            // Change department
            Console.WriteLine("--- Changing Department ---");
            employee.ChangeDepartment("HR");
            employee.GetDetails();

            // Attempt invalid operations
            Console.WriteLine("--- Attempting Invalid Operations ---");
            employee.SetSalary(-500); // Invalid salary
            employee.UpdatePerformanceRating(6); // Invalid rating
            employee.ChangeDepartment(""); // Invalid department

            // Display final details
            Console.WriteLine("--- Final Employee Details ---");
            employee.GetDetails();

        }

        private static void MeasuringBoxingPerformance()
        {
            /*
             * === Task 3: Measuring Boxing Performance ===
             * 
             * Objective:
             * - Measure and compare the performance of boxing, unboxing, and direct type usage.
             * - Understand the overhead of boxing and unboxing operations.
             * - Analyze why direct type usage is more efficient.
             */
            Console.WriteLine("\n=== Task 3: Measuring Boxing Performance ===\n");

            const int size = 1_000_000; // Define the size of the arrays

            // Step 1: Arrays for Testing
            Console.WriteLine("--- Step 1: Setting Up Arrays ---");
            object[] boxedArray = new object[size]; // Array to store boxed values
            int[] intArray = new int[size]; // Array for direct type usage
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
        }

        private static void DemonstratingBoxingAndUnboxing()
        {
            /*
             * === Task 2: Demonstrating Boxing and Unboxing ===
             * 
             * Objective:
             * - Understand how value types are boxed into objects.
             * - Learn how to unbox values from objects back to value types.
             * - Demonstrate type safety issues that can occur during unboxing.
             */
            Console.WriteLine("\n=== Task 2: Demonstrating Boxing and Unboxing ===\n");

            // Small-scale example of boxing and unboxing
            int num = 42; // Value type
            object boxedNum = num; // Boxing
            Console.WriteLine($"Boxed value: {boxedNum} (Type: {boxedNum.GetType()})");

            int unboxedNum = (int)boxedNum; // Unboxing
            Console.WriteLine($"Unboxed value: {unboxedNum} (Type: {unboxedNum.GetType()})");

            // Demonstrating type mismatch error during unboxing
            try
            {
                double invalidUnbox = (double)boxedNum; // Invalid unboxing
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error during unboxing: {ex.Message}");
            }
        }

        private static void DemonstratingObjectMethods()
        {
            /*
             * === Task 1: Exploring Object Methods ===
             * 
             * Objective:
             * - Understand and utilize key methods inherited from the object base class in C#.
             * - Learn how GetType(), ToString(), Equals(), and GetHashCode() methods work.
             * - Demonstrate their usage and observe the differences between reference and value equality.
             */
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
        }
    }
}
