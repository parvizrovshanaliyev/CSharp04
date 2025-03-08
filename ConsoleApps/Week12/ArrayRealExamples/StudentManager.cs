using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a student with a name and grade.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the grade of the student.
        /// </summary>
        public int Grade { get; set; }
    }


    /// <summary>
    /// Manages student grades.
    /// </summary>
    public class StudentManager
    {

        /// <summary>
        /// Manages the list of students, calculates statistics, sorts, and searches.
        /// </summary>
        public static void ManageStudents()
        {
            // Initialize an array of students with predefined names and grades.
            Student[] students = new Student[]
            {
            new Student { Name = "Alice", Grade = 85 },
            new Student { Name = "Bob", Grade = 92 },
            new Student { Name = "Charlie", Grade = 78 }
            };

            // Calculate and display statistics.
            CalculateAndDisplayStatistics(students);

            // Sort the students by grade.
            SortStudentsByGrade(students);

            // Output the sorted list of students.
            Console.WriteLine("Students sorted by grade:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }

            // Search for a student by name.
            string searchName = "Bob";
            SearchAndDisplayStudent(students, searchName);
        }

        /// <summary>
        /// Calculates and displays the highest, lowest, and average grades of the students.
        /// </summary>
        /// <param name="students">An array of students.</param>
        private static void CalculateAndDisplayStatistics(Student[] students)
        {
            int highestGrade = students[0].Grade;
            int lowestGrade = students[0].Grade;
            int totalGrades = 0;

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Grade > highestGrade) highestGrade = students[i].Grade;
                if (students[i].Grade < lowestGrade) lowestGrade = students[i].Grade;
                totalGrades += students[i].Grade;
            }

            double averageGrade = (double)totalGrades / students.Length;

            Console.WriteLine($"Highest Grade: {highestGrade}");
            Console.WriteLine($"Lowest Grade: {lowestGrade}");
            Console.WriteLine($"Average Grade: {averageGrade:F2}");
        }

        /// <summary>
        /// Sorts the students by their grades in ascending order.
        /// </summary>
        /// <param name="students">An array of students.</param>
        private static void SortStudentsByGrade(Student[] students)
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[i].Grade > students[j].Grade)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for a student by name and displays their grade.
        /// </summary>
        /// <param name="students">An array of students.</param>
        /// <param name="searchName">The name of the student to search for.</param>
        private static void SearchAndDisplayStudent(Student[] students, string searchName)
        {
            Student foundStudent = null;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Name == searchName)
                {
                    foundStudent = students[i];
                    break;
                }
            }

            if (foundStudent != null)
            {
                Console.WriteLine($"Found {searchName}: {foundStudent.Grade}");
            }
            else
            {
                Console.WriteLine($"{searchName} not found.");
            }
        }
    }
}
