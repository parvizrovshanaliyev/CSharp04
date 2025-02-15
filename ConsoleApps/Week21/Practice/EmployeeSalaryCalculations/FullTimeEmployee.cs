namespace Practice.EmployeeSalaryCalculations;
/// <summary>
/// Represents a full-time employee with a fixed monthly salary.
/// Inherits from the Employee base class and overrides the salary calculation.
/// FullTimeEmployee represents employees with a fixed monthly salary.
/// It overrides the CalculateSalary method to return the monthly salary directly.
/// This demonstrates how derived classes can provide their own implementation
/// of the virtual method defined in the base class.
/// </summary>
public class FullTimeEmployee : Employee
{
    /// <summary>
    /// Gets or sets the monthly salary for the full-time employee.
    /// </summary>
    public double MonthlySalary { get; set; }

    /// <summary>
    /// Calculates the salary for a full-time employee based on their monthly salary.
    /// </summary>
    /// <returns>The monthly salary amount.</returns>
    public override double CalculateSalary()
    {
        return MonthlySalary;
    }
}