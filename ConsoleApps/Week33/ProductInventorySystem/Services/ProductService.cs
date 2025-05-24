using System.Collections;
using ProductInventorySystem.Models;
using ProductInventorySystem.Repositories;

namespace ProductInventorySystem.Services
{
    /// <summary>
    /// Implementation of IProductService that handles business logic for product operations
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the ProductService class
        /// </summary>
        /// <param name="repository">The product repository</param>
        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <inheritdoc/>
        public bool AddProduct(string code, string name)
        {
            try
            {
                var product = new Product(code, name);
                return _repository.Add(product);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public ICollection GetAllProducts()
        {
            return _repository.GetAll();
        }

        /// <inheritdoc/>
        public Product GetProductByCode(string code)
        {
            try
            {
                return _repository.GetByCode(code);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public bool UpdateProduct(string code, string newName)
        {
            try
            {
                return _repository.Update(code, newName);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool RemoveProduct(string code)
        {
            try
            {
                return _repository.Remove(code);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool ProductExistsByName(string name)
        {
            try
            {
                return _repository.ExistsByName(name);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public int GetProductCount()
        {
            return _repository.Count();
        }
    }
}