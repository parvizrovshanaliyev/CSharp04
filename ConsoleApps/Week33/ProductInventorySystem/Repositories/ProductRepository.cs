using System.Collections;
using ProductInventorySystem.Models;

namespace ProductInventorySystem.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Hashtable for storage
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly Hashtable _products;

        /// <summary>
        /// Initializes a new instance of the ProductRepository class
        /// </summary>
        public ProductRepository()
        {
            _products = new Hashtable();
        }

        /// <inheritdoc/>
        public bool Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_products.ContainsKey(product.Code))
                return false;

            _products.Add(product.Code, product);
            return true;
        }

        /// <inheritdoc/>
        public ICollection GetAll()
        {
            return _products.Values;
        }

        /// <inheritdoc/>
        public Product GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Product code cannot be empty", nameof(code));

            return _products[code] as Product;
        }

        /// <inheritdoc/>
        public bool Update(string code, string newName)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Product code cannot be empty", nameof(code));

            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Product name cannot be empty", nameof(newName));

            if (!_products.ContainsKey(code))
                return false;

            var product = _products[code] as Product;
            product.Name = newName;
            return true;
        }

        /// <inheritdoc/>
        public bool Remove(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Product code cannot be empty", nameof(code));

            if (!_products.ContainsKey(code))
                return false;

            _products.Remove(code);
            return true;
        }

        /// <inheritdoc/>
        public bool Exists(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Product code cannot be empty", nameof(code));

            return _products.ContainsKey(code);
        }

        /// <inheritdoc/>
        public bool ExistsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty", nameof(name));

            foreach (Product product in _products.Values)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public int Count()
        {
            return _products.Count;
        }
    }
}