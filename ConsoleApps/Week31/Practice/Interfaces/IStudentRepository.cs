using Practice.Models;
using System.Collections;

namespace Practice.Interfaces
{
    /// <summary>
    /// Defines the contract for student data storage operations.
    /// This interface follows the Repository pattern to abstract data access.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Adds a new student to the repository.
        /// </summary>
        /// <param name="student">The student object to add.</param>
        void AddStudent(Student student);

        /// <summary>
        /// Removes a student from the repository by their name.
        /// </summary>
        /// <param name="name">The name of the student to remove.</param>
        void RemoveStudent(string name);

        /// <summary>
        /// Retrieves all students from the repository.
        /// </summary>
        /// <returns>An ArrayList containing all student objects.</returns>
        ArrayList GetAllStudents();

        /// <summary>
        /// Calculates the average grade of all students.
        /// </summary>
        /// <returns>The average grade as a double value.</returns>
        double CalculateAverageGrade();

        /// <summary>
        /// Checks if a student with the given name exists in the repository.
        /// </summary>
        /// <param name="name">The name to check for.</param>
        /// <returns>True if a student with the given name exists, false otherwise.</returns>
        bool StudentExists(string name);
    }
}