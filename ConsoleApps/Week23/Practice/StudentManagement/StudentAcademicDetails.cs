using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.StudentManagement;

/// <summary>
/// Academic details of a student such as major, GPA, and enrolled courses.
/// </summary>
public partial class Student
{
    public string Major { get; set; }
    public double GPA { get; set; }
    private string[] Courses { get; set; } = new string[10];
    private int courseCount = 0;

    public void AddCourse(string course)
    {
        if (courseCount < Courses.Length)
        {
            Courses[courseCount++] = course;
            CourseRegisteredNotification(course);
        }
        else
        {
            Console.WriteLine("Course list is full.");
        }
    }

    public void DisplayCourses()
    {
        Console.WriteLine("Courses Enrolled:");
        for (int i = 0; i < courseCount; i++)
        {
            Console.WriteLine(" - " + Courses[i]);
        }
    }

    /// <summary>
    /// Partial method for course registration notification.
    /// </summary>
    partial void CourseRegisteredNotification(string course);
}
