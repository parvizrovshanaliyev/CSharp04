using System;

namespace OOP.Inheritance.MethodOverriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Method Overriding Examples\n");

            // 1. Basic Method Overriding
            Console.WriteLine("1. Basic Method Overriding:");
            Animal[] animals = { new Animal(), new Dog(), new Cat() };
            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
            Console.WriteLine();

            // 2. Base Method Calling
            Console.WriteLine("2. Base Method Calling:");
            Employee manager = new Manager();
            manager.CalculateSalary();
            Console.WriteLine();

            // 3. Method Hiding
            Console.WriteLine("3. Method Hiding (new keyword):");
            Parent parent = new Parent();
            Child child = new Child();
            Parent parentRef = new Child();

            parent.Display();     // Calls Parent's Display
            child.Display();      // Calls Child's Display
            parentRef.Display();  // Calls Parent's Display (due to hiding)
            Console.WriteLine();

            // 4. Abstract Methods
            Console.WriteLine("4. Abstract Methods:");
            Shape circle = new Circle { Radius = 5 };
            Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
            Console.WriteLine();

            // 5. Sealed Methods
            Console.WriteLine("5. Sealed Methods:");
            Animal mammal = new Mammal();
            mammal.Breathe();
            Console.WriteLine();

            // 6. Multiple Level Overriding
            Console.WriteLine("6. Multiple Level Overriding:");
            Vehicle[] vehicles =
            {
                new Vehicle(),
                new Car(),
                new ElectricCar()
            };
            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
            }
            Console.WriteLine();

            // 7. Document Processing Example
            Console.WriteLine("7. Document Processing:");
            Document pdfDoc = new PdfDocument();
            pdfDoc.Open();
            pdfDoc.Process();
            pdfDoc.Close();
            Console.WriteLine();

            // 8. Payment Processing Example
            Console.WriteLine("8. Payment Processing:");
            PaymentProcessor creditCard = new CreditCardProcessor
            {
                CardNumber = "1234-5678-9012-3456",
                Amount = 100.50m
            };
            creditCard.ProcessPayment();
        }
    }

    // 1. Basic Method Overriding
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }

        public virtual void Breathe()
        {
            Console.WriteLine("Animal breathing");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks: Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows: Meow!");
        }
    }

    // 2. Base Method Calling
    public class Employee
    {
        public virtual void CalculateSalary()
        {
            Console.WriteLine("Calculating base salary...");
        }
    }

    public class Manager : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("Adding manager bonus...");
        }
    }

    // 3. Method Hiding
    public class Parent
    {
        public void Display()
        {
            Console.WriteLine("Parent's Display");
        }
    }

    public class Child : Parent
    {
        public new void Display()
        {
            Console.WriteLine("Child's Display");
        }
    }

    // 4. Abstract Methods
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // 5. Sealed Methods
    public class Mammal : Animal
    {
        public sealed override void Breathe()
        {
            Console.WriteLine("Breathing through lungs");
        }
    }

    // 6. Multiple Level Overriding
    public class Vehicle
    {
        public virtual void Start()
        {
            Console.WriteLine("Vehicle starting");
        }
    }

    public class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car engine starting");
        }
    }

    public class ElectricCar : Car
    {
        public override void Start()
        {
            Console.WriteLine("Electric car powering up");
        }
    }

    // 7. Document Processing
    public abstract class Document
    {
        public virtual void Open()
        {
            Console.WriteLine("Opening document...");
        }

        public abstract void Process();

        public virtual void Close()
        {
            Console.WriteLine("Closing document...");
        }
    }

    public class PdfDocument : Document
    {
        public override void Open()
        {
            base.Open();
            Console.WriteLine("Loading PDF reader...");
        }

        public override void Process()
        {
            Console.WriteLine("Processing PDF content...");
        }

        public override void Close()
        {
            Console.WriteLine("Saving PDF changes...");
            base.Close();
        }
    }

    // 8. Payment Processing
    public abstract class PaymentProcessor
    {
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }

        public virtual void ValidatePayment()
        {
            if (Amount <= 0)
                throw new ArgumentException("Invalid amount");
        }

        public abstract void ProcessPayment();
    }

    public class CreditCardProcessor : PaymentProcessor
    {
        public override void ValidatePayment()
        {
            base.ValidatePayment();
            if (string.IsNullOrEmpty(CardNumber))
                throw new ArgumentException("Invalid card number");
        }

        public override void ProcessPayment()
        {
            ValidatePayment();
            Console.WriteLine($"Processing ${Amount} via Credit Card: {CardNumber}");
        }
    }
}
