using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.StudentManagement;

/// <summary>
/// Core student details such as ID, Name, and Date of Birth.
/// This class is marked as <c>partial</c> to allow modular separation of academic and contact details.
/// </summary>
public partial class Student
{
    /// <summary>
    /// Gets or sets the unique identifier for a student.
    /// </summary>
    public int StudentID { get; set; }

    /// <summary>
    /// Gets or sets the full name of the student.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the date of birth of the student.
    /// </summary>
    public DateTime DateOfBirth { get; set; }
}




