namespace Practice.ProductSystemDemo;
/// <summary>
/// Represents food products in the inventory.
/// Extends the base Product class with expiration date information.
/// Food extends Product to handle food items with expiration dates.
/// This demonstrates how the same base class can be extended to handle
/// very different types of products while maintaining a consistent interface.
/// The expiration date handling shows how specialized behavior can be added.
/// </summary>
public class Food : Product
{
    /// <summary>
    /// Gets or sets the expiration date of the food product.
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Displays the details of a food product, including its expiration date.
    /// </summary>
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Expiration Date: {ExpirationDate.ToShortDateString()}");
    }
}