using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes
{
    /// <summary>
    /// Represents a triangle implementing IShape interface
    /// </summary>
    public class Triangle : IShape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        /// <summary>
        /// Initializes a new instance of the Triangle class
        /// </summary>
        /// <param name="sideA">Length of first side</param>
        /// <param name="sideB">Length of second side</param>
        /// <param name="sideC">Length of third side</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        /// <summary>
        /// Calculates the area of the triangle using Heron's formula
        /// </summary>
        /// <returns>The area of the triangle</returns>
        public double Area()
        {
            double s = Perimeter() / 2;
            return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
        }

        /// <summary>
        /// Calculates the perimeter of the triangle
        /// </summary>
        /// <returns>The perimeter of the triangle</returns>
        public double Perimeter() => _sideA + _sideB + _sideC;
    }
}