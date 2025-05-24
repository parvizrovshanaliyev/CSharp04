using System;

namespace Practice.Models
{
    /// <summary>
    /// Represents a student with their name and grade.
    /// Implements IComparable for sorting students by grade in descending order.
    /// </summary>
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the grade of the student (0-100).
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="grade">The grade of the student (0-100).</param>
        public Student(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }

        /// <summary>
        /// Compares this student's grade with another student's grade.
        /// </summary>
        /// <param name="other">The student to compare with.</param>
        /// <returns>
        /// A value that indicates the relative order of the students being compared.
        /// Returns a negative number if this student's grade is higher (descending order).
        /// </returns>
        public int CompareTo(Student other)
        {
            return other.Grade.CompareTo(Grade); // Descending order
        }
    }
}