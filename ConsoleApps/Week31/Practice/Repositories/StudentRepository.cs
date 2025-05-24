using Practice.Interfaces;
using Practice.Models;
using System.Collections;

namespace Practice.Repositories
{
    /// <summary>
    /// Implements the IStudentRepository interface using ArrayList for data storage.
    /// This class handles all data persistence operations for Student objects.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        // Using ArrayList as per task requirements, though List<Student> would be more type-safe
        private readonly ArrayList _students;

        /// <summary>
        /// Initializes a new instance of the StudentRepository class.
        /// Creates an empty ArrayList to store students.
        /// </summary>
        public StudentRepository()
        {
            _students = new ArrayList();
        }

        /// <summary>
        /// Adds a new student to the repository.
        /// </summary>
        /// <param name="student">The student object to add.</param>
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        /// <summary>
        /// Removes a student from the repository by their name.
        /// The search is case-insensitive.
        /// </summary>
        /// <param name="name">The name of the student to remove.</param>
        public void RemoveStudent(string name)
        {
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i] is Student student &&
                    student.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    _students.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Retrieves all students from the repository.
        /// </summary>
        /// <returns>An ArrayList containing all student objects.</returns>
        public ArrayList GetAllStudents()
        {
            return _students;
        }

        /// <summary>
        /// Calculates the average grade of all students.
        /// Returns 0 if there are no students.
        /// </summary>
        /// <returns>The average grade as a double value.</returns>
        public double CalculateAverageGrade()
        {
            if (_students.Count == 0)
                return 0;

            double sum = 0;
            foreach (Student student in _students)
            {
                sum += student.Grade;
            }
            return sum / _students.Count;
        }

        /// <summary>
        /// Checks if a student with the given name exists in the repository.
        /// The search is case-insensitive.
        /// </summary>
        /// <param name="name">The name to check for.</param>
        /// <returns>True if a student with the given name exists, false otherwise.</returns>
        public bool StudentExists(string name)
        {
            return _students.Cast<Student>()
                .Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}