using LW5.Application.Interfaces;
using LW5.Domain.Entities;

namespace LW5.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> SearchProducts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _productRepository.GetAll();

            return _productRepository.GetAll()
                .Where(product => product.Name.Contains(
                    query, StringComparison.OrdinalIgnoreCase));
        }

        public void AddProduct(string name, string description, decimal price, int quantity)
        {
            var product = new Product(name, description, price, quantity);

            _productRepository.Add(product);
        }

        public void UpdateProduct(Guid id, string name, string description, decimal price)
        {
            var product = GetProductById(id)
                ?? throw new InvalidOperationException("Product not found.");

            product.UpdateInfo(name, description, price);

            _productRepository.Update(product);
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.Delete(id);
        }
    }
}