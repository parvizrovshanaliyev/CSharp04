using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes.ThreeDimensional
{
    /// <summary>
    /// Represents a cylinder implementing I3DShape interface
    /// </summary>
    public class Cylinder : I3DShape
    {
        /// <summary>
        /// Gets or sets the radius of the cylinder
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the height of the cylinder
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the Cylinder class
        /// </summary>
        /// <param name="radius">Radius of the cylinder</param>
        /// <param name="height">Height of the cylinder</param>
        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        /// <summary>
        /// Calculates the surface area of the cylinder
        /// </summary>
        /// <returns>The surface area of the cylinder</returns>
        public double Area() => 2 * Math.PI * Radius * (Radius + Height);

        /// <summary>
        /// Calculates the perimeter of the cylinder's base
        /// </summary>
        /// <returns>The circumference of the base circle</returns>
        public double Perimeter() => 2 * Math.PI * Radius;

        /// <summary>
        /// Calculates the volume of the cylinder
        /// </summary>
        /// <returns>The volume of the cylinder</returns>
        public double Volume() => Math.PI * Math.Pow(Radius, 2) * Height;
    }
}