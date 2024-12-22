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
        }
    }
}
