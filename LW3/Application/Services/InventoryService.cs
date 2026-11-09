using LW3.Application.Interfaces;

namespace LW3.Application.Services
{
    public class InventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int GetStockQuantity(Guid productId)
        {
            var product = _productRepository.GetById(productId)
                ?? throw new InvalidOperationException("Product not found.");

            return product.Quantity;
        }

        public bool IsAvailable(Guid productId, int quantity)
        {
            if (quantity <= 0)
                return false;

            var product = _productRepository.GetById(productId);

            return product is not null && product.Quantity >= quantity;
        }
    }
}