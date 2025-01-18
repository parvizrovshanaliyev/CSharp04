using Practice.Models;

namespace Practice
{
    /// <summary>
    /// Main program class that demonstrates various inheritance concepts.
    /// Each section demonstrates a different aspect of inheritance in C#.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Demonstrates access modifiers (private, protected, public)
            Console.WriteLine("Task 1: Access Modifiers");
            var book = new Book("B001", "The Great Gatsby", "F. Scott Fitzgerald");
            book.PrintAccessibleMembers(); // Shows which members are accessible
            Console.WriteLine();

            // Task 2: Demonstrates basic inheritance with properties and methods
            Console.WriteLine("Task 2: Basic Inheritance");
            var mobile = new Mobile("Samsung", "Galaxy S21");
            mobile.DisplayDetails(); // Shows inheritance of DisplayManufacturer
            Console.WriteLine();

            // Task 3: Demonstrates method overriding and polymorphism
            Console.WriteLine("Task 3: Method Overriding");
            

            Notification[] notifications = new Notification[]
            {
                new Notification(),      // Base class
                new EmailNotification(), // Derived class 1
                new SMSNotification()    // Derived class 2
            };



            foreach (var notification in notifications)
            {
                notification.Send(); // Demonstrates polymorphic behavior
            }
            Console.WriteLine();

            // Task 4: Demonstrates constructor chaining using base
            Console.WriteLine("Task 4: Constructor Chaining");
            var apartment = new Apartment("Residential", 5);
            Console.WriteLine();

            // Task 5: Demonstrates multi-level inheritance
            Console.WriteLine("Task 5: Multi-Level Inheritance");
            var parrot = new Parrot();
            parrot.Move();  // From Animal class
            parrot.Fly();   // From Bird class
            parrot.Talk();  // From Parrot class
            Console.WriteLine();

            // Task 6: Demonstrates real-world inheritance example
            Console.WriteLine("Task 6: Real-World Inheritance");
            var doctor = new Doctor("Dr. Smith", 35, "Cardiology");
            var engineer = new Engineer("John Doe", 28, "Software");
            doctor.GetDoctorDetails();     // Shows inheritance and extension
            engineer.GetEngineerDetails(); // Shows parallel inheritance
            Console.WriteLine();

            // Task 7: Demonstrates composition vs inheritance approaches
            Console.WriteLine("Task 7: Composition vs Inheritance");
            var laptop = new Laptop();  // Uses composition
            var desktop = new Desktop(); // Uses inheritance

            Console.WriteLine("Laptop (Composition):");
            laptop.DisplayScreenInfo();  // Delegates to contained Screen

            Console.WriteLine("Desktop (Inheritance):");
            desktop.ShowResolution();    // Inherited directly from Screen
        }
    }
}
