using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes
{
    /// <summary>
    /// Represents a circle implementing IShape interface
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Gets or sets the radius of the circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the Circle class
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates the area of the circle using πr²
        /// </summary>
        /// <returns>The area of the circle</returns>
        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <summary>
        /// Calculates the perimeter (circumference) of the circle using 2πr
        /// </summary>
        /// <returns>The perimeter of the circle</returns>
        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}