namespace OOP.Abstraction.Interface.Interfaces
{
    /// <summary>
    /// Defines an interface for objects that can be resized.
    /// This interface represents the ability to change an object's size dynamically.
    /// </summary>
    /// <remarks>
    /// This interface demonstrates:
    /// 1. Single Responsibility Principle - focuses only on resizing behavior
    /// 2. Interface Segregation Principle - keeps the interface small and focused
    /// 3. How to define scalable behavior for objects
    /// 
    /// Key Concepts:
    /// - Resizing is a common operation for many types of objects
    /// - The scaling factor determines how much larger or smaller the object becomes
    /// - A factor > 1 makes the object larger
    /// - A factor between 0 and 1 makes the object smaller
    /// - A factor of 1 leaves the size unchanged
    /// 
    /// Common uses:
    /// - Geometric shapes
    /// - UI elements
    /// - Images
    /// - Game objects
    /// - Window management
    /// </remarks>
    /// <example>
    /// Here's how a class might implement this interface:
    /// <code>
    /// public class ResizableCircle : IResizable
    /// {
    ///     public double Radius { get; set; }
    ///     
    ///     public void Resize(double factor)
    ///     {
    ///         // A factor of 2.0 doubles the radius
    ///         // A factor of 0.5 halves the radius
    ///         Radius *= factor;
    ///     }
    /// }
    /// </code>
    /// 
    /// Using with multiple interfaces:
    /// <code>
    /// public class ResizableDrawableShape : IShape, IDrawable, IResizable
    /// {
    ///     // Implements shape calculations, drawing, and resizing behavior
    /// }
    /// </code>
    /// </example>
    public interface IResizable
    {
        /// <summary>
        /// Resizes the object by applying a scaling factor to its dimensions.
        /// </summary>
        /// <param name="factor">
        /// The scaling factor to apply:
        /// - factor > 1: enlarges the object (e.g., 2.0 doubles the size)
        /// - factor = 1: no change in size
        /// - 0 &lt; factor &lt; 1: shrinks the object (e.g., 0.5 halves the size)
        /// </param>
        /// <remarks>
        /// Implementation guidelines:
        /// 1. Validate the factor (should be positive)
        /// 2. Apply the scaling to all relevant dimensions
        /// 3. Update any dependent calculations
        /// 4. Consider minimum and maximum size constraints
        /// 
        /// Common scaling operations:
        /// - Shapes: scale dimensions (radius, width, height)
        /// - Images: scale width and height
        /// - UI: scale size and position
        /// 
        /// Note: The scaling should maintain the object's proportions
        /// unless specifically designed to do otherwise.
        /// </remarks>
        void Resize(double factor);
    }
}