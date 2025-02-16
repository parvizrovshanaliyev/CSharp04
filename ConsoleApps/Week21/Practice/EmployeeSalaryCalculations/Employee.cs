namespace Practice.EmployeeSalaryCalculations;
/// <summary>
/// Base class for all employee types in the system.
/// The Employee class hierarchy demonstrates dynamic polymorphism through inheritance
/// and method overriding. This allows for different employee types to calculate their
/// salaries in different ways while maintaining a common interface.
/// 
/// The base Employee class provides the foundation with a virtual method that derived
/// classes can override to implement their specific salary calculation logic.
/// Provides a common interface for salary calculation through virtual method.
/// Demonstrates the foundation for dynamic polymorphism.
/// </summary>
public abstract class Employee
{
    private string _name;

    protected Employee()
    {
        
    }

    protected Employee(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    /// <summary>
    /// Calculates the salary for the employee.
    /// This is a virtual method that can be overridden by derived classes.
    /// </summary>
    /// <returns>The calculated salary amount.</returns>
    public virtual double CalculateSalary()
    {
        return 0;
    }
}