using System;

namespace ProductInventorySystem.Models
{
    /// <summary>
    /// Represents a product in the inventory system
    /// </summary>
    public class Product
    {
        private string _code;
        private string _name;

        /// <summary>
        /// Gets or sets the product code
        /// </summary>
        public string Code
        {
            get => _code;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product code cannot be empty", nameof(value));
                _code = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product name cannot be empty", nameof(value));
                _name = value.Trim();
            }
        }

        /// <summary>
        /// Initializes a new instance of the Product class
        /// </summary>
        /// <param name="code">The product code</param>
        /// <param name="name">The product name</param>
        public Product(string code, string name)
        {
            Code = code;
            Name = name;
        }

        /// <summary>
        /// Returns a string representation of the product
        /// </summary>
        public override string ToString()
        {
            return $"Code: {Code} | Name: {Name}";
        }
    }
}