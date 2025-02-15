using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes.ThreeDimensional
{
    /// <summary>
    /// Represents a 3D circle (sphere) implementing I3DShape interface
    /// </summary>
    public class Circle3D : I3DShape
    {
        /// <summary>
        /// Gets or sets the radius of the sphere
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the Circle3D class
        /// </summary>
        /// <param name="radius">The radius of the sphere</param>
        public Circle3D(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates the surface area of the sphere using 4πr²
        /// </summary>
        /// <returns>The surface area of the sphere</returns>
        public double Area() => 4 * Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Calculates the circumference of the sphere's great circle using 2πr
        /// </summary>
        /// <returns>The circumference of the sphere's great circle</returns>
        public double Perimeter() => 2 * Math.PI * Radius;

        /// <summary>
        /// Calculates the volume of the sphere using (4/3)πr³
        /// </summary>
        /// <returns>The volume of the sphere</returns>
        public double Volume() => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }
}