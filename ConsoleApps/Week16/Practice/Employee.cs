using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice;

class Employee
{
    // Private fields for encapsulation
    private readonly int _employeeId; // Immutable field
    private string _name;
    private string _department;
    private decimal _salary;
    private int _performanceRating;

    // Constructor to initialize mandatory fields
    public Employee(int id, string name, string department)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentException("Department cannot be empty.");
        }

        _employeeId = id;
        this._name = name;
        this._department = department;
        this._salary = 0;
        this._performanceRating = 0;
    }

    // Method to set salary with validation
    public void SetSalary(decimal salary)
    {
        if (salary <= 0)
        {
            Console.WriteLine("Error: Salary must be positive.");
            return;
        }

        this._salary = salary;
        Console.WriteLine("Salary updated successfully.");
    }

    // Method to update performance rating with validation
    public void UpdatePerformanceRating(int rating)
    {
        if (rating < 1 || rating > 5)
        {
            Console.WriteLine("Error: Performance rating must be between 1 and 5.");
            return;
        }

        this._performanceRating = rating;
        Console.WriteLine("Performance rating updated successfully.");
    }

    // Method to change department with validation
    public void ChangeDepartment(string newDepartment)
    {
        if (string.IsNullOrWhiteSpace(newDepartment))
        {
            Console.WriteLine("Error: Department name cannot be empty.");
            return;
        }

        this._department = newDepartment;
        Console.WriteLine("Department updated successfully.");
    }

    // Method to display all employee details
    public void GetDetails()
    {
        Console.WriteLine($"Employee ID: {_employeeId}\n" +
                          $"Name: {_name}\n" +
                          $"Department: {_department}\n" +
                          $"Salary: {_salary:C}\n" +
                          $"Performance Rating: {_performanceRating}\n");
    }
}