using Practice.Repositories;
using Practice.Services;
using Practice.Models;
using System.Collections;

namespace Practice
{
    /// <summary>
    /// Main program class that handles the user interface and program flow.
    /// This class implements the console-based user interface for the Student Grade Management System.
    /// </summary>
    internal class Program
    {
        // Static service instance for the entire application
        private static readonly StudentService _studentService;

        /// <summary>
        /// Static constructor to initialize the service layer.
        /// Sets up dependency injection for the StudentService.
        /// </summary>
        static Program()
        {
            var repository = new StudentRepository();
            _studentService = new StudentService(repository);
        }

        /// <summary>
        /// Main entry point of the application.
        /// Implements the main program loop and menu system.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                var choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayAllStudents();
                        break;
                    case 3:
                        DisplayAverageGrade();
                        break;
                    case 4:
                        RemoveStudent();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("===== Student Grade System =====");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Show all students");
            Console.WriteLine("3. Show average grade");
            Console.WriteLine("4. Remove student by name");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        /// <summary>
        /// Gets and validates the user's menu choice.
        /// </summary>
        /// <returns>The validated menu choice as an integer.</returns>
        private static int GetUserChoice()
        {
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
        }

        /// <summary>
        /// Handles the process of adding a new student.
        /// Includes input validation and user feedback.
        /// </summary>
        private static void AddStudent()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter grade: ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                Console.WriteLine("Invalid grade format!");
                return;
            }

            if (_studentService.AddStudent(name, grade))
            {
                Console.WriteLine("✅ Student added!");
            }
            else
            {
                Console.WriteLine("❌ Failed to add student. Check if name is valid and not duplicate, and grade is between 0-100.");
            }
        }

        /// <summary>
        /// Displays all students in the system, sorted by grade.
        /// </summary>
        private static void DisplayAllStudents()
        {
            var students = _studentService.GetAllStudents();
            if (students.Count() == 0)
            {
                Console.WriteLine("No students registered.");
                return;
            }

            Console.WriteLine("📋 Students (sorted by grade):");
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name,-8} | Grade: {student.Grade:F1}");
            }
        }

        /// <summary>
        /// Displays the average grade of all students.
        /// </summary>
        private static void DisplayAverageGrade()
        {
            var average = _studentService.GetAverageGrade();
            Console.WriteLine($"📊 Average Grade: {average:F2}");
        }

        /// <summary>
        /// Handles the process of removing a student by name.
        /// Includes input validation and user feedback.
        /// </summary>
        private static void RemoveStudent()
        {
            Console.Write("Enter name to remove: ");
            var name = Console.ReadLine();

            if (_studentService.RemoveStudent(name))
            {
                Console.WriteLine($"✅ Student '{name}' removed from list.");
            }
            else
            {
                Console.WriteLine("❌ Student not found or invalid name.");
            }
        }
    }
}
