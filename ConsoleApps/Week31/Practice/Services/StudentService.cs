using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services
{
    /// <summary>
    /// Provides business logic and validation for student operations.
    /// This class acts as a service layer between the UI and data access layer.
    /// </summary>
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Initializes a new instance of the StudentService class.
        /// </summary>
        /// <param name="studentRepository">The repository to use for data operations.</param>
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Adds a new student with validation.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="grade">The grade of the student (0-100).</param>
        /// <returns>True if the student was added successfully, false otherwise.</returns>
        /// <remarks>
        /// Validation rules:
        /// - Name must not be empty or whitespace
        /// - Grade must be between 0 and 100
        /// - Student name must not already exist in the repository
        /// </remarks>
        public bool AddStudent(string name, double grade)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (grade < 0 || grade > 100)
                return false;

            if (_studentRepository.StudentExists(name))
                return false;

            var student = new Student(name, grade);
            _studentRepository.AddStudent(student);
            return true;
        }

        /// <summary>
        /// Removes a student by name with validation.
        /// </summary>
        /// <param name="name">The name of the student to remove.</param>
        /// <returns>True if the student was removed successfully, false otherwise.</returns>
        /// <remarks>
        /// Validation rules:
        /// - Name must not be empty or whitespace
        /// - Student must exist in the repository
        /// </remarks>
        public bool RemoveStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (!_studentRepository.StudentExists(name))
                return false;

            _studentRepository.RemoveStudent(name);
            return true;
        }

        /// <summary>
        /// Retrieves all students sorted by grade in descending order.
        /// </summary>
        /// <returns>An ArrayList of students sorted by grade.</returns>
        public ArrayList GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            students.Sort();
            return students;
        }

        /// <summary>
        /// Calculates and returns the average grade of all students.
        /// </summary>
        /// <returns>The average grade as a double value.</returns>
        public double GetAverageGrade()
        {
            return _studentRepository.CalculateAverageGrade();
        }
    }
}