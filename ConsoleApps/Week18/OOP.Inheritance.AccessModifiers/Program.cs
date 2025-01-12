using System;

namespace OOP.Inheritance.AccessModifiers
{
    // Base class demonstrating different access modifiers
    public class Vehicle
    {
        public string Model { get; set; }        // Accessible everywhere
        private int vin;                         // Only within this class
        protected int year;                      // This class and derived classes
        internal string make;                    // Within the same assembly

        public Vehicle(string model, int year)
        {
            Model = model;
            this.year = year;
            vin = new Random().Next(10000, 99999);
        }

        public virtual void StartEngine()
        {
            Console.WriteLine($"{year} {Model}'s engine is starting...");
        }

        protected virtual void ServiceCheck()
        {
            Console.WriteLine($"Performing service check on VIN: {vin}");
        }
    }

    // Derived class showing inheritance and access modifier usage
    public class Car : Vehicle
    {
        private bool isConvertible;

        public Car(string model, int year, bool isConvertible)
            : base(model, year)
        {
            this.isConvertible = isConvertible;
            make = "Generic"; // Can access internal member
        }

        public override void StartEngine()
        {
            Console.WriteLine($"Car: {make} {Model}");
            base.StartEngine();
            if (isConvertible)
            {
                Console.WriteLine("Checking convertible roof system...");
            }
        }

        public void PerformMaintenance()
        {
            Console.WriteLine($"Performing maintenance on {year} {Model}"); // Can access protected year
            ServiceCheck(); // Can access protected method
            // vin is not accessible here as it's private to Vehicle
        }
    }

    // Abstract class example
    public abstract class Shape
    {
        public abstract double GetArea();

        public virtual void Display()
        {
            Console.WriteLine($"Area: {GetArea()}");
        }
    }

    // Concrete implementation of abstract class
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override void Display()
        {
            Console.WriteLine($"Circle with radius {radius}");
            base.Display();
        }
    }

    // Interface example
    public interface IMovable
    {
        void Move(int x, int y);
    }

    // Class implementing both inheritance and interface
    public class MovableCircle : Circle, IMovable
    {
        private int currentX, currentY;

        public MovableCircle(double radius) : base(radius)
        {
            currentX = 0;
            currentY = 0;
        }

        public void Move(int x, int y)
        {
            currentX += x;
            currentY += y;
            Console.WriteLine($"Circle moved to ({currentX}, {currentY})");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance and Access Modifiers Demo\n");

            // Basic inheritance example
            Console.WriteLine("1. Basic Vehicle and Car Example:");
            Car myCar = new Car("Model S", 2023, true);
            myCar.StartEngine();
            myCar.PerformMaintenance();
            Console.WriteLine();

            // Abstract class and interface example
            Console.WriteLine("2. Shape and Circle Example:");
            Circle circle = new Circle(5);
            circle.Display();
            Console.WriteLine();

            // Combined inheritance and interface
            Console.WriteLine("3. Movable Circle Example:");
            MovableCircle movableCircle = new MovableCircle(3);
            movableCircle.Display();
            movableCircle.Move(2, 3);
            Console.WriteLine();

            // Polymorphism example
            Console.WriteLine("4. Polymorphism Example:");
            Shape shape = new Circle(4);
            shape.Display();
            Console.WriteLine();

            // Array of vehicles showing inheritance
            Console.WriteLine("5. Vehicle Array Example:");
            Vehicle[] vehicles = new Vehicle[]
            {
                new Vehicle("Generic Vehicle", 2020),
                new Car("Sports Car", 2023, false),
                new Car("Convertible", 2023, true)
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.StartEngine();
            }
        }
    }
}
