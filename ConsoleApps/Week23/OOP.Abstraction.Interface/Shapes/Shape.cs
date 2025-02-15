namespace OOP.Abstraction.Interface.Shapes
{
    /// <summary>
    /// Abstract base class for shapes with protected constructor
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Protected constructor to prevent direct instantiation
        /// </summary>
        protected Shape()
        {
        }

        /// <summary>
        /// Abstract method to calculate shape area
        /// </summary>
        /// <returns>The area of the shape</returns>
        public abstract double Area();

        /// <summary>
        /// Abstract method to calculate shape perimeter
        /// </summary>
        /// <returns>The perimeter of the shape</returns>
        public abstract double Perimeter();
    }
}