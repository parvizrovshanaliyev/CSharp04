namespace OOP.Abstraction.Interface.Interfaces
{
    /// <summary>
    /// Defines the basic interface for all 2D geometric shapes.
    /// This interface establishes the minimum functionality that any 2D shape must provide.
    /// </summary>
    /// <remarks>
    /// This interface demonstrates:
    /// 1. How to define a contract for geometric shapes
    /// 2. The principle of abstraction - focusing on what a shape can do, not how it does it
    /// 3. The common operations that all 2D shapes must support
    /// 
    /// Key Concepts:
    /// - Every 2D shape must be able to calculate its area
    /// - Every 2D shape must be able to calculate its perimeter
    /// - The actual calculations will depend on the specific shape
    /// 
    /// Common shapes that might implement this interface:
    /// - Circle
    /// - Rectangle
    /// - Triangle
    /// - Square
    /// - Pentagon
    /// etc.
    /// </remarks>
    /// <example>
    /// Here's how a Circle class would implement this interface:
    /// <code>
    /// public class Circle : IShape
    /// {
    ///     public double Radius { get; set; }
    ///     
    ///     public double Area()
    ///     {
    ///         return Math.PI * Radius * Radius;
    ///     }
    ///     
    ///     public double Perimeter()
    ///     {
    ///         return 2 * Math.PI * Radius;
    ///     }
    /// }
    /// </code>
    /// </example>
    public interface IShape
    {
        /// <summary>
        /// Calculates the area of the shape.
        /// The area is the amount of space inside the shape's boundaries.
        /// </summary>
        /// <returns>The area of the shape in square units</returns>
        /// <remarks>
        /// Different shapes calculate area differently:
        /// - Circle: πr²
        /// - Rectangle: width × height
        /// - Triangle: ½ × base × height
        /// 
        /// The implementing class must provide the appropriate formula
        /// for its specific shape type.
        /// </remarks>
        double Area();

        /// <summary>
        /// Calculates the perimeter of the shape.
        /// The perimeter is the total length of all the shape's boundaries.
        /// </summary>
        /// <returns>The perimeter of the shape in linear units</returns>
        /// <remarks>
        /// Different shapes calculate perimeter differently:
        /// - Circle: 2πr (circumference)
        /// - Rectangle: 2(width + height)
        /// - Triangle: sum of all three sides
        /// 
        /// The implementing class must provide the appropriate formula
        /// for its specific shape type.
        /// </remarks>
        double Perimeter();
    }
}