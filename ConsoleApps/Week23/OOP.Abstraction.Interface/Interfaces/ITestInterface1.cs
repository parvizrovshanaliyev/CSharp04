namespace OOP.Abstraction.Interface.Interfaces
{
    /// <summary>
    /// Defines a test interface with basic arithmetic operations.
    /// An interface is like a contract that defines what methods a class must implement.
    /// Think of it as a blueprint that any class implementing this interface must follow.
    /// </summary>
    /// <remarks>
    /// This interface demonstrates:
    /// 1. How to define method signatures without implementations
    /// 2. How to create a contract for basic arithmetic operations
    /// 3. The naming convention for interfaces (starting with 'I')
    /// 
    /// When a class implements this interface, it MUST provide implementations
    /// for both the Add and Sub methods.
    /// </remarks>
    /// <example>
    /// Here's how a class would implement this interface:
    /// <code>
    /// public class Calculator : ITestInterface1
    /// {
    ///     public void Add(int num1, int num2)
    ///     {
    ///         Console.WriteLine($"Sum is {num1 + num2}");
    ///     }
    ///     
    ///     public void Sub(int num1, int num2)
    ///     {
    ///         Console.WriteLine($"Difference is {num1 - num2}");
    ///     }
    /// }
    /// </code>
    /// </example>
    public interface ITestInterface1
    {
        /// <summary>
        /// Adds two numbers and displays the result.
        /// This is a method signature without an implementation.
        /// </summary>
        /// <param name="num1">First number to add - this will be the left operand</param>
        /// <param name="num2">Second number to add - this will be the right operand</param>
        /// <remarks>
        /// The implementing class must provide the actual addition logic.
        /// For example, it might add the numbers and display them, or it might
        /// store them in a calculation history.
        /// </remarks>
        void Add(int num1, int num2);

        /// <summary>
        /// Subtracts two numbers and displays the result.
        /// This is a method signature without an implementation.
        /// </summary>
        /// <param name="num1">Number to subtract from (the minuend)</param>
        /// <param name="num2">Number to subtract (the subtrahend)</param>
        /// <remarks>
        /// The implementing class must provide the actual subtraction logic.
        /// The calculation should perform: num1 - num2
        /// For example, if num1 = 10 and num2 = 3, the result should be 7
        /// </remarks>
        void Sub(int num1, int num2);
    }
}