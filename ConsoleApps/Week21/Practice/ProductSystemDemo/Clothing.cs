namespace Practice.ProductSystemDemo;

/// <summary>
/// Represents clothing items in the inventory.
/// Extends the base Product class with size information.
/// Clothing extends Product to handle clothing items with size information.
/// This class shows another example of specialization while maintaining
/// the common Product interface. It demonstrates how different product types
/// can have their own unique attributes while still being treated as Products.
/// </summary>
public class Clothing : Product
{
    /// <summary>
    /// Gets or sets the size of the clothing item.
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// Displays the details of a clothing item, including its size.
    /// </summary>
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Size: {Size}");
    }
}