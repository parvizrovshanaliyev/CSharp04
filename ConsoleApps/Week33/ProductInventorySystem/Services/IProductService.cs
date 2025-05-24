using System.Collections;
using ProductInventorySystem.Models;

namespace ProductInventorySystem.Services
{
    /// <summary>
    /// Defines the contract for product service operations
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Adds a new product to the inventory
        /// </summary>
        /// <param name="code">The product code</param>
        /// <param name="name">The product name</param>
        /// <returns>True if the product was added successfully, false if a product with the same code already exists</returns>
        bool AddProduct(string code, string name);

        /// <summary>
        /// Gets all products in the inventory
        /// </summary>
        /// <returns>A collection of all products</returns>
        ICollection GetAllProducts();

        /// <summary>
        /// Gets a product by its code
        /// </summary>
        /// <param name="code">The product code</param>
        /// <returns>The product if found, null otherwise</returns>
        Product GetProductByCode(string code);

        /// <summary>
        /// Updates a product's name
        /// </summary>
        /// <param name="code">The product code</param>
        /// <param name="newName">The new product name</param>
        /// <returns>True if the product was updated successfully, false if the product was not found</returns>
        bool UpdateProduct(string code, string newName);

        /// <summary>
        /// Removes a product from the inventory
        /// </summary>
        /// <param name="code">The product code</param>
        /// <returns>True if the product was removed successfully, false if the product was not found</returns>
        bool RemoveProduct(string code);

        /// <summary>
        /// Checks if a product exists by its name
        /// </summary>
        /// <param name="name">The product name</param>
        /// <returns>True if the product exists, false otherwise</returns>
        bool ProductExistsByName(string name);

        /// <summary>
        /// Gets the total number of products in the inventory
        /// </summary>
        /// <returns>The number of products</returns>
        int GetProductCount();
    }
}