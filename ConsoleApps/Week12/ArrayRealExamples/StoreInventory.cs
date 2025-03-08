using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a product with a name and price.
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
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Manages store inventory.
    /// </summary>
    public class StoreInventory
    {


        /// <summary>
        /// Manages the inventory of products.
        /// </summary>
        public static void ManageInventory()
        {
            // Initialize an array of products
            Product[] products = new Product[]
            {
            new Product { Name = "Laptop", Price = 999.99m },
            new Product { Name = "Smartphone", Price = 499.99m },
            new Product { Name = "Tablet", Price = 299.99m }
            };

            // Find the most expensive and cheapest product
            var mostExpensive = FindMostExpensive(products);
            var cheapest = FindCheapest(products);
            Console.WriteLine($"Most Expensive: {mostExpensive.Name} - ${mostExpensive.Price}");
            Console.WriteLine($"Cheapest: {cheapest.Name} - ${cheapest.Price}");

            // Sort products by price
            SortProductsByPrice(products);
            Console.WriteLine("Products sorted by price:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}: ${product.Price}");
            }

            // Search for a product by name
            string searchName = "Smartphone";
            Product foundProduct = SearchProductByName(products, searchName);
            if (foundProduct != null)
            {
                Console.WriteLine($"Found {searchName}: ${foundProduct.Price}");
            }
            else
            {
                Console.WriteLine($"{searchName} not found.");
            }
        }

        /// <summary>
        /// Finds the most expensive product in the array.
        /// </summary>
        /// <param name="products">Array of products.</param>
        /// <returns>The most expensive product.</returns>
        private static Product FindMostExpensive(Product[] products)
        {
            Product mostExpensive = products[0];

            for (int i = 1; i < products.Length; i++)
            {
                if (products[i].Price > mostExpensive.Price) mostExpensive = products[i];
            }

            return mostExpensive;
        }

        /// <summary>
        /// Finds the cheapest product in the array.
        /// </summary>
        /// <param name="products">Array of products.</param>
        /// <returns>The cheapest product.</returns>
        private static Product FindCheapest(Product[] products)
        {
            Product cheapest = products[0];

            for (int i = 1; i < products.Length; i++)
            {
                if (products[i].Price < cheapest.Price) cheapest = products[i];
            }

            return cheapest;
        }
        /// <summary>
        /// Sorts the array of products by price using Selection Sort.
        /// </summary>
        /// <param name="products">Array of products to be sorted.</param>
        private static void SortProductsByPrice(Product[] products)
        {
            for (int i = 0; i < products.Length - 1; i++)
            {
                for (int j = i + 1; j < products.Length; j++)
                {
                    if (products[i].Price > products[j].Price)
                    {
                        Product temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for a product by name using Linear Search.
        /// </summary>
        /// <param name="products">Array of products.</param>
        /// <param name="name">Name of the product to search for.</param>
        /// <returns>The product if found, otherwise null.</returns>
        private static Product SearchProductByName(Product[] products, string name)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name == name)
                {
                    return products[i];
                }
            }
            return null;
        }
    }
}
