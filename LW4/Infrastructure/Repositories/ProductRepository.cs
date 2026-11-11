using LW4.Application.Interfaces;
using LW4.Domain.Entities;

namespace LW4.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = [];

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(Guid id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);

            if (existingProduct is null)
                throw new InvalidOperationException("Product not found.");

            var index = _products.IndexOf(existingProduct);
            _products[index] = product;
        }

        public void Delete(Guid id)
        {
            var product = GetById(id);

            if (product is null)
                throw new InvalidOperationException("Product not found.");

            _products.Remove(product);
        }
    }
}