using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.ShoppingCartSystem;

/// <summary>
/// Interface for shopping cart operations.
/// This interface provides a contract that different shopping cart implementations must follow.
/// Using an interface allows for flexibility, as different types of carts (e.g., online cart, in-store cart) can implement this contract.
/// </summary>
public interface IShoppingCart
{
    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    /// <param name="product">The product to add.</param>
    void AddProduct(IProduct product);

    /// <summary>
    /// Removes a product from the shopping cart.
    /// </summary>
    /// <param name="product">The product to remove.</param>
    void RemoveProduct(IProduct product);

    /// <summary>
    /// Calculates the total cost of all products in the cart.
    /// </summary>
    /// <returns>The total price of the cart.</returns>
    decimal CalculateTotal();

    /// <summary>
    /// Processes the checkout and finalizes the purchase.
    /// </summary>
    void Checkout();
}

/// <summary>
/// Interface for product properties.
/// This allows multiple product types to share a common structure.
/// </summary>
public interface IProduct
{
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    decimal Price { get; }
}

/// <summary>
/// Represents a basic product with a name and price.
/// Implements the <see cref="IProduct"/> interface.
/// </summary>
public class BasicProduct : IProduct
{
    public string Name { get; }
    public decimal Price { get; }

    public BasicProduct(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

/// <summary>
/// Represents a digital product with an additional download link.
/// </summary>
public class DigitalProduct : IProduct
{
    public string Name { get; }
    public decimal Price { get; }
    public string DownloadLink { get; }

    public DigitalProduct(string name, decimal price, string downloadLink)
    {
        Name = name;
        Price = price;
        DownloadLink = downloadLink;
    }
}

/// <summary>
/// Represents a physical product with an additional weight attribute.
/// </summary>
public class PhysicalProduct : IProduct
{
    public string Name { get; }
    public decimal Price { get; }
    public double Weight { get; }

    public PhysicalProduct(string name, decimal price, double weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
}

/// <summary>
/// Represents a shopping cart where products can be added, removed, and purchased.
/// Implements the <see cref="IShoppingCart"/> interface.
/// Uses an array to store up to 10 products.
/// </summary>
public class ShoppingCart : IShoppingCart
{
    private IProduct[] products = new IProduct[10];
    private int count = 0;

    /// <summary>
    /// Adds a product to the cart if space is available.
    /// </summary>
    /// <param name="product">The product to add.</param>
    public void AddProduct(IProduct product)
    {
        if (count < products.Length)
        {
            products[count++] = product;
            Console.WriteLine($"Added {product.Name} to the cart.");
        }
        else
        {
            Console.WriteLine("Shopping cart is full.");
        }
    }

    /// <summary>
    /// Removes a product from the cart if it exists.
    /// </summary>
    /// <param name="product">The product to remove.</param>
    public void RemoveProduct(IProduct product)
    {
        int index = Array.IndexOf(products, product, 0, count);
        if (index >= 0)
        {
            for (int i = index; i < count - 1; i++)
            {
                products[i] = products[i + 1];
            }
            products[--count] = null;
            Console.WriteLine($"Removed {product.Name} from the cart.");
        }
        else
        {
            Console.WriteLine($"{product.Name} not found in the cart.");
        }
    }

    /// <summary>
    /// Calculates the total cost of products in the cart.
    /// </summary>
    /// <returns>Total price of the products in the cart.</returns>
    public decimal CalculateTotal()
    {
        decimal total = 0;
        for (int i = 0; i < count; i++)
        {
            total += products[i].Price;
        }
        return total;
    }

    /// <summary>
    /// Finalizes the checkout process by displaying the total price and resetting the cart.
    /// </summary>
    public void Checkout()
    {
        Console.WriteLine("Processing checkout...");
        Console.WriteLine($"Total amount: ${CalculateTotal():F2}");
        Console.WriteLine("Thank you for your purchase!");
        count = 0;
    }
}