namespace OOP.Abstraction.Interface.Interfaces
{
    /// <summary>
    /// Defines an interface for objects that can be drawn on a display or console.
    /// This interface represents the concept of "drawable" behavior.
    /// </summary>
    /// <remarks>
    /// This interface demonstrates:
    /// 1. Single Responsibility Principle - focuses only on drawing behavior
    /// 2. Interface Segregation Principle - keeps the interface small and focused
    /// 3. How to define behavior without specifying implementation details
    /// 
    /// Key Concepts:
    /// - Drawing is a behavior that many different objects might need
    /// - The actual drawing implementation can vary (console, graphics, etc.)
    /// - This interface can be combined with other interfaces (multiple interface implementation)
    /// 
    /// Common uses:
    /// - Shapes that can be drawn
    /// - UI elements
    /// - Game objects
    /// - Visualization components
    /// </remarks>
    /// <example>
    /// Here's how a class might implement this interface:
    /// <code>
    /// public class DrawableCircle : IDrawable
    /// {
    ///     public double Radius { get; set; }
    ///     
    ///     public void Draw()
    ///     {
    ///         Console.WriteLine($"Drawing circle with radius {Radius}");
    ///         // Actual drawing implementation would go here
    ///     }
    /// }
    /// </code>
    /// 
    /// Using multiple interfaces:
    /// <code>
    /// public class DrawableShape : IShape, IDrawable
    /// {
    ///     // Implements both shape calculations and drawing behavior
    /// }
    /// </code>
    /// </example>
    public interface IDrawable
    {
        /// <summary>
        /// Draws the object using the appropriate drawing mechanism.
        /// This method should handle all aspects of rendering the object.
        /// </summary>
        /// <remarks>
        /// The implementing class decides how to draw the object:
        /// - Could write to the console
        /// - Could draw on a graphics surface
        /// - Could render in a game engine
        /// - Could output to a printer
        /// 
        /// The implementation should:
        /// 1. Prepare any necessary drawing resources
        /// 2. Perform the actual drawing operation
        /// 3. Clean up any resources if needed
        /// </remarks>
        void Draw();
    }
}