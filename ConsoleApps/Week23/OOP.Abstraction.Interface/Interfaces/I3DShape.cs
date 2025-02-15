namespace OOP.Abstraction.Interface.Interfaces
{
    /// <summary>
    /// Defines the interface for three-dimensional shapes, extending the basic IShape interface.
    /// This interface adds volume calculation capability to the basic shape operations.
    /// </summary>
    /// <remarks>
    /// This interface demonstrates:
    /// 1. Interface inheritance (extends IShape)
    /// 2. How to add additional functionality to a base interface
    /// 3. The relationship between 2D and 3D shape calculations
    /// 
    /// Key Concepts:
    /// - A 3D shape is still a shape, so it inherits IShape methods
    /// - Area now represents surface area for 3D shapes
    /// - Perimeter might represent different measurements for 3D shapes
    /// - Volume is unique to 3D shapes
    /// 
    /// Common 3D shapes that might implement this interface:
    /// - Sphere (3D circle)
    /// - Cube
    /// - Cylinder
    /// - Cone
    /// - Prism
    /// etc.
    /// </remarks>
    /// <example>
    /// Here's how a Sphere class would implement this interface:
    /// <code>
    /// public class Sphere : I3DShape
    /// {
    ///     public double Radius { get; set; }
    ///     
    ///     public double Area()
    ///     {
    ///         return 4 * Math.PI * Radius * Radius; // Surface area
    ///     }
    ///     
    ///     public double Perimeter()
    ///     {
    ///         return 2 * Math.PI * Radius; // Great circle circumference
    ///     }
    ///     
    ///     public double Volume()
    ///     {
    ///         return (4/3) * Math.PI * Math.Pow(Radius, 3);
    ///     }
    /// }
    /// </code>
    /// </example>
    public interface I3DShape : IShape
    {
        /// <summary>
        /// Calculates the volume of the 3D shape.
        /// Volume is the amount of three-dimensional space enclosed by the shape's boundaries.
        /// </summary>
        /// <returns>The volume of the shape in cubic units</returns>
        /// <remarks>
        /// Different 3D shapes calculate volume differently:
        /// - Sphere: (4/3)πr³
        /// - Cube: side³
        /// - Cylinder: πr²h
        /// - Cone: (1/3)πr²h
        /// 
        /// The implementing class must provide the appropriate formula
        /// for its specific 3D shape type.
        /// 
        /// Note: Volume is always measured in cubic units:
        /// - If dimensions are in meters, volume is in cubic meters (m³)
        /// - If dimensions are in inches, volume is in cubic inches (in³)
        /// </remarks>
        double Volume();
    }
}