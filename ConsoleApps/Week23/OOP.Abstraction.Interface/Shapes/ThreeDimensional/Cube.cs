using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes.ThreeDimensional
{
    /// <summary>
    /// Represents a cube implementing I3DShape interface
    /// </summary>
    public class Cube : I3DShape
    {
        /// <summary>
        /// Gets or sets the length of the cube's side
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Initializes a new instance of the Cube class
        /// </summary>
        /// <param name="side">Length of the cube's side</param>
        public Cube(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates the surface area of the cube
        /// </summary>
        /// <returns>The surface area of the cube</returns>
        public double Area() => 6 * Math.Pow(Side, 2);

        /// <summary>
        /// Calculates the sum of all edge lengths of the cube
        /// </summary>
        /// <returns>The total length of all edges</returns>
        public double Perimeter() => 12 * Side;

        /// <summary>
        /// Calculates the volume of the cube
        /// </summary>
        /// <returns>The volume of the cube</returns>
        public double Volume() => Math.Pow(Side, 3);
    }
}