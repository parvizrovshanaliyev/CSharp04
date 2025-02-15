namespace Practice.ProductSystemDemo;
/// <summary>
/// Represents electronic products in the inventory.
/// Extends the base Product class with warranty information.
/// Electronics extends Product to handle electronic items with warranty information.
/// It demonstrates how a derived class can add its own properties while still
/// maintaining the base class interface. The DisplayDetails override shows how
/// additional information can be displayed while reusing base class functionality.
/// </summary>
public class Electronics : Product
{
    /// <summary>
    /// Gets or sets the warranty period in months.
    /// </summary>
    public int WarrantyPeriod { get; set; }

    /// <summary>
    /// Displays the details of an electronic product, including its warranty period.
    /// </summary>
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Warranty Period: {WarrantyPeriod} months");
    }
}