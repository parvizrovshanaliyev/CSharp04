namespace ObjectAndBoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // **Boxing and Unboxing**
            // Boxing: Converting a value type (int) to a reference type (object).
            int number = 42;                     // Value type
            object boxedNumber = number;         // Boxing: 'number' is now treated as an object.
            Console.WriteLine("Boxed Type: " + boxedNumber.GetType()); // Output: System.Int32
            Console.WriteLine("Boxed Value: " + boxedNumber);          // Output: 42

            // Accessing the original value's type directly using GetType().
            Console.WriteLine("Original Type: " + number.GetType());   // Output: System.Int32

            // Unboxing: Converting the boxed reference type back to its original value type.
            if (boxedNumber.GetType() == typeof(int))                  // Type check before unboxing.
            {
                int unBoxedNumber = (int)boxedNumber;                  // Unboxing the object back to int.
                Console.WriteLine("Unboxed Value: " + unBoxedNumber);  // Output: 42
            }

            // **Using ToString()**
            // Demonstrates how the ToString method is overridden for custom objects.
            User user1 = new User
            {
                UserName = "default"                                  // Setting a property for the User object.
            };
            Console.WriteLine("User1 ToString: " + user1.ToString());  // Output: User: default

            // **Using Equals()**
            // Equals method determines equality for both value types and reference types.

            // Value type comparison using Equals
            object obj1 = 42;
            object obj2 = 42;
            Console.WriteLine("Value Type Equals: " + obj1.Equals(obj2)); // Output: True
                                                                          // Value types are compared by their actual values.

            // Reference type comparison using Equals
            User user2 = new User
            {
                UserName = "default"                                  // A new User object with the same property value.
            };
            Console.WriteLine("Reference Type Equals: " + user1.Equals(user2)); // Output: False
                                                                                // Reference types are compared by reference, not by content, unless Equals is overridden.

            // **Using GetHashCode()**
            // Demonstrates how hash codes are unique for different instances.
            Console.WriteLine("User1 HashCode: " + user1.GetHashCode()); // Output: Unique hash code for user1
            Console.WriteLine("User2 HashCode: " + user2.GetHashCode()); // Output: Unique hash code for user2

            // **Using MemberwiseClone()**
            // Creates a shallow copy of an object.
            Console.WriteLine("\n=== MemberwiseClone Example ===");
            User user3 = user1.Clone();                              // Cloning user1 into user3.

            Console.WriteLine("User1 UserName: " + user1.UserName);   // Output: default
            Console.WriteLine("User3 UserName: " + user3.UserName);   // Output: default
            Console.WriteLine("User1 HashCode: " + user1.GetHashCode()); // HashCode for user1
            Console.WriteLine("User3 HashCode: " + user3.GetHashCode()); // Different HashCode for cloned user3

            Console.WriteLine("Are User1 and User3 Equal?: " + user1.Equals(user3)); // Output: False
                                                                                     // They are different objects despite having the same property values.

            // Modifying the cloned object's property
            user3.UserName = "Changed";                              // Changing the property of the cloned object.
            Console.WriteLine("User3 UserName After Change: " + user3.UserName); // Output: Changed
            Console.WriteLine("User1 UserName Remains: " + user1.UserName);      // Output: default

            Console.WriteLine("User3 HashCode After Change: " + user3.GetHashCode()); // HashCode for user3 remains the same
            Console.WriteLine("User1 HashCode Remains: " + user1.GetHashCode());      // HashCode for user1 remains the same

            Console.WriteLine("Are User1 and User3 Equal After Change?: " + user1.Equals(user3)); // Output: False
                                                                                                  // Changes to the cloned object do not affect the original object.
        }
    }
}
