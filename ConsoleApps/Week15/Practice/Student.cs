using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Student
    {
        // Properties
        public string Name { get; set; } = "Unknown";
        private int _grade;
        public int Grade
        {
            get => _grade;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Grade must be between 0 and 100.");
                _grade = value;
            }
        }
        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be non-negative.");
                _age = value;
            }
        }
        public string Major { get; set; } = "Undeclared";

        // Constructors
        public Student() { }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Student(string name, int age, int grade, string major)
        {
            Name = name;
            Age = age;
            Grade = grade;
            Major = major;
        }

        // Methods
        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}, Major: {Major}");
        }

        public void ImproveGrade(int amount)
        {
            Grade = Math.Min(Grade + amount, 100);
            Console.WriteLine($"{Name}'s grade has improved to {Grade}.");
        }

        public void ReduceGrade(int amount)
        {
            Grade = Math.Max(Grade - amount, 0);
            Console.WriteLine($"{Name}'s grade has reduced to {Grade}.");
        }

        public void ChangeMajor(string newMajor)
        {
            if (string.IsNullOrWhiteSpace(newMajor))
                throw new ArgumentException("Major cannot be empty or null.");
            Major = newMajor;
            Console.WriteLine($"{Name} has changed their major to {Major}.");
        }
    }
}
