namespace Practice.EmployeeSalaryCalculations;
/// <summary>
/// Represents a part-time employee paid based on hours worked.
/// Inherits from the Employee base class and overrides the salary calculation.
/// PartTimeEmployee represents employees paid by the hour.
/// It overrides the CalculateSalary method to calculate salary based on
/// hours worked and hourly rate. This shows another implementation of
/// the same virtual method, handling a different payment structure.
/// </summary>
public class PartTimeEmployee : Employee
{
    /// <summary>
    /// Gets or sets the hourly rate for the part-time employee.
    /// </summary>
    public double HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the number of hours worked by the part-time employee.
    /// </summary>
    public int HoursWorked { get; set; }

    /// <summary>
    /// Calculates the salary for a part-time employee based on hours worked and hourly rate.
    /// </summary>
    /// <returns>The calculated salary based on hours worked multiplied by hourly rate.</returns>
    public override double CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}