namespace Practice.ProductSystemDemo;
/// <summary>
/// The Product class hierarchy demonstrates polymorphism in a real-world inventory system.
/// It shows how different types of products can share common properties while also
/// having their own specific attributes and behaviors.
/// 
/// The base Product class defines the common structure and behavior that all
/// products share, while allowing for specialization in derived classes.
/// 
/// Base class for all products in the inventory system.
/// Provides common properties and virtual method for displaying details.
/// Demonstrates polymorphism in a real-world scenario.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Displays the basic details of the product.
    /// This method can be overridden by derived classes to show additional information.
    /// </summary>
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Product: {Name}, Price: ${Price}");
    }
}