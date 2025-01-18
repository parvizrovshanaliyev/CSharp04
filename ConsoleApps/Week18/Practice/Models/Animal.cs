namespace Practice.Models
{
    /// <summary>
    /// Represents the base class in a multi-level inheritance hierarchy.
    /// This is the topmost class in the Animal -> Bird -> Parrot hierarchy.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Simulates the movement of an animal.
        /// This is the most basic behavior available to all animals.
        /// </summary>
        public void Move()
        {
            /* Base class method that provides fundamental movement behavior.
             * This method is inherited by all derived classes in the hierarchy.
             */
            Console.WriteLine("The animal is moving.");
        }
    }

    /// <summary>
    /// Represents a bird, demonstrating the second level in the inheritance hierarchy.
    /// Inherits from Animal and adds flying capability.
    /// </summary>
    public class Bird : Animal
    {
        /// <summary>
        /// Simulates the flying behavior specific to birds.
        /// This method is available to Bird and its derived classes.
        /// </summary>
        public void Fly()
        {
            /* Bird-specific method that adds flying behavior.
             * This demonstrates adding new functionality in a derived class
             * while maintaining access to base class methods.
             */
            Console.WriteLine("The bird is flying.");
        }
    }

    /// <summary>
    /// Represents a parrot, demonstrating the third level in the inheritance hierarchy.
    /// Inherits from Bird (which inherits from Animal) and adds talking capability.
    /// </summary>
    public class Parrot : Bird
    {
        /// <summary>
        /// Simulates the talking behavior specific to parrots.
        /// This method is only available to Parrot instances.
        /// </summary>
        public void Talk()
        {
            /* Parrot-specific method that adds talking behavior.
             * This demonstrates how each level in the inheritance hierarchy
             * can add its own unique functionality while maintaining
             * access to all methods from parent classes.
             */
            Console.WriteLine("The parrot is talking.");
        }
    }
}