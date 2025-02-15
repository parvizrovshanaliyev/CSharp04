using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Implementation
{
    /// <summary>
    /// Demonstrates two different ways to implement an interface in C#.
    /// This class shows both regular (public) and explicit interface implementation.
    /// </summary>
    /// <remarks>
    /// This class demonstrates:
    /// 1. Regular interface implementation using the 'public' keyword
    /// 2. Explicit interface implementation using the interface name
    /// 3. How to implement all required methods from an interface
    /// 
    /// Key Points:
    /// - Regular implementation (Add method) can be called directly on the class
    /// - Explicit implementation (Sub method) requires casting to the interface
    /// - Both methods fulfill the interface contract
    /// </remarks>
    /// <example>
    /// Regular implementation usage:
    /// <code>
    /// var calc = new ImplementationClass();
    /// calc.Add(5, 3);  // Works directly
    /// </code>
    /// 
    /// Explicit implementation usage:
    /// <code>
    /// var calc = new ImplementationClass();
    /// ((ITestInterface1)calc).Sub(10, 3);  // Requires casting
    /// 
    /// // Or using the interface type:
    /// ITestInterface1 calc2 = new ImplementationClass();
    /// calc2.Sub(10, 3);  // No casting needed
    /// </code>
    /// </example>
    public class ImplementationClass : ITestInterface1
    {
        /// <summary>
        /// Implements the Add method from ITestInterface1 using public implementation.
        /// This method can be called directly on the class instance.
        /// </summary>
        /// <param name="num1">First number to add - this will be the left operand</param>
        /// <param name="num2">Second number to add - this will be the right operand</param>
        /// <remarks>
        /// This is a regular (public) implementation of the interface method.
        /// It can be called in two ways:
        /// 1. Directly on the class instance
        /// 2. Through the interface reference
        /// 
        /// The method adds the two numbers and displays the result immediately.
        /// </remarks>
        /// <example>
        /// Usage example:
        /// <code>
        /// var calc = new ImplementationClass();
        /// calc.Add(5, 3);  // Outputs: "Sum of 5 and 3 is 8"
        /// </code>
        /// </example>
        public void Add(int num1, int num2)
        {
            Console.WriteLine($"Sum of {num1} and {num2} is {num1 + num2}");
        }

        /// <summary>
        /// Implements the Sub method from ITestInterface1 using explicit implementation.
        /// This method can only be called through the interface reference.
        /// </summary>
        /// <param name="num1">Number to subtract from (the minuend)</param>
        /// <param name="num2">Number to subtract (the subtrahend)</param>
        /// <remarks>
        /// This is an explicit interface implementation.
        /// It can only be called when:
        /// 1. The object is cast to ITestInterface1
        /// 2. The object is referenced through ITestInterface1
        /// 
        /// The method subtracts num2 from num1 and displays the result immediately.
        /// </remarks>
        /// <example>
        /// Usage example:
        /// <code>
        /// var calc = new ImplementationClass();
        /// ((ITestInterface1)calc).Sub(10, 3);  // Outputs: "Subtraction of 3 from 10 is 7"
        /// 
        /// ITestInterface1 calc2 = new ImplementationClass();
        /// calc2.Sub(10, 3);  // Same output, no casting needed
        /// </code>
        /// </example>
        void ITestInterface1.Sub(int num1, int num2)
        {
            Console.WriteLine($"Subtraction of {num2} from {num1} is {num1 - num2}");
        }
    }
}