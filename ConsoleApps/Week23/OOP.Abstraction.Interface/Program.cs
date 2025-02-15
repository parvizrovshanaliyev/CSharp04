using OOP.Abstraction.Interface.Implementation;
using OOP.Abstraction.Interface.Interfaces;
using OOP.Abstraction.Interface.Shapes;
using OOP.Abstraction.Interface.Shapes.ThreeDimensional;

namespace OOP.Abstraction.Interface
{
    /// <summary>
    /// Demonstrates interface implementation and abstraction concepts in C#
    /// This program shows various examples of how interfaces work in practice
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interface Implementation Examples\n");

            /*
             * Example 1: Basic Circle Implementation
             * This demonstrates how a simple Circle class implements the IShape interface
             * We create a circle with radius 5 and calculate its area and perimeter
             */
            Console.WriteLine("1. Basic Circle Implementation:");
            Circle circle = new Circle(5);
            Console.WriteLine($"Circle Area: {circle.Area():F2}");
            Console.WriteLine($"Circle Perimeter: {circle.Perimeter():F2}\n");

            /*
             * Example 2: Interface Implementation with Explicit Implementation
             * Shows two ways to work with interfaces:
             * 1. Using the concrete class directly
             * 2. Using the interface type with explicit casting
             * This demonstrates interface flexibility and polymorphism
             */
            Console.WriteLine("2. Interface Implementation with Explicit Implementation:");
            ImplementationClass obj1 = new ImplementationClass();
            obj1.Add(10, 20);
            ((ITestInterface1)obj1).Sub(100, 20);

            ITestInterface1 obj2 = new ImplementationClass();
            obj2.Add(200, 50);
            obj2.Sub(200, 50);

            /*
             * Example 3: Shape Hierarchy and Interface Implementation
             * Creates an array of different shapes that all implement IShape
             * Shows how we can treat different shapes uniformly through their interface
             * This is a practical example of polymorphism - treating different objects 
             * through a common interface
             */
            Console.WriteLine("\n3. Shape Hierarchy and Interface Implementation:");
            IShape[] shapes = new IShape[]
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4, 5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"\n{shape.GetType().Name} Properties:");
                Console.WriteLine($"Area: {shape.Area():F2}");
                Console.WriteLine($"Perimeter: {shape.Perimeter():F2}");
            }

            /*
             * Example 4: 3D Shapes Implementation
             * Demonstrates how interfaces can be used with more complex shapes
             * Shows how 3D shapes can implement additional functionality (Volume)
             * while still maintaining the basic shape properties
             */
            Console.WriteLine("\n4. 3D Shapes Implementation:");
            I3DShape[] shapes3D = new I3DShape[]
            {
                new Circle3D(3),
                new Cube(4),
                new Cylinder(2, 5)
            };

            foreach (var shape in shapes3D)
            {
                Console.WriteLine($"\n{shape.GetType().Name} Properties:");
                Console.WriteLine($"Surface Area: {shape.Area():F2}");
                Console.WriteLine($"Perimeter/Circumference: {shape.Perimeter():F2}");
                Console.WriteLine($"Volume: {shape.Volume():F2}");
            }

            /*
             * Example 5: Multiple Interface Implementation
             * Shows how a single class can implement multiple interfaces
             * The DrawableCircle class implements both IShape and IDrawable interfaces
             * This demonstrates interface composition and how objects can have multiple behaviors
             */
            Console.WriteLine("\n5. Multiple Interface Implementation:");
            var drawableShape = new DrawableCircle(4);
            drawableShape.Draw();
            Console.WriteLine($"Area: {drawableShape.Area():F2}");
            drawableShape.Resize(1.5);
            Console.WriteLine($"Area after resize: {drawableShape.Area():F2}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

}
