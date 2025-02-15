using OOP.Abstraction.Interface.Interfaces;

namespace OOP.Abstraction.Interface.Shapes
{
    /// <summary>
    /// Represents a circle that can be drawn and resized
    /// </summary>
    public class DrawableCircle : Circle, IDrawable, IResizable
    {
        /// <summary>
        /// Initializes a new instance of the DrawableCircle class
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public DrawableCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Draws the circle
        /// </summary>
        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }

        /// <summary>
        /// Resizes the circle by a given factor
        /// </summary>
        /// <param name="factor">The scaling factor</param>
        public void Resize(double factor)
        {
            Radius *= factor;
            Console.WriteLine($"Circle resized. New radius: {Radius}");
        }
    }
}