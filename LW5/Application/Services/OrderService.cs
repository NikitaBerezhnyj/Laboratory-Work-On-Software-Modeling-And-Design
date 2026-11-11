using LW5.Application.Interfaces;
using LW5.Domain.Entities;

namespace LW5.Application.Services
{
    public class OrderService
    {
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            IPurchaseOrderRepository orderRepository,
            ISupplierRepository supplierRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<PurchaseOrder> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public PurchaseOrder? GetOrderById(Guid id)
        {
            return _orderRepository.GetById(id);
        }

        public PurchaseOrder CreateOrder(
            Guid supplierId,
            IEnumerable<(Guid ProductId, int Quantity)> items)
        {
            var supplier = _supplierRepository.GetById(supplierId)
                ?? throw new InvalidOperationException("Supplier not found.");

            var requestedItems = items.ToList();

            if (requestedItems.Count == 0)
                throw new ArgumentException("Order must contain at least one item.");

            var orderItems = new List<PurchaseOrderItem>();

            foreach (var item in requestedItems)
            {
                if (item.Quantity <= 0)
                    throw new ArgumentException("Quantity must be positive.");

                var product = _productRepository.GetById(item.ProductId)
                    ?? throw new InvalidOperationException("Product not found.");

                orderItems.Add(new PurchaseOrderItem(product, item.Quantity));
            }

            var order = new PurchaseOrder(supplier.Id, orderItems);

            _orderRepository.Add(order);

            return order;
        }

        public void SendOrder(Guid orderId)
        {
            var order = GetOrderById(orderId)
                ?? throw new InvalidOperationException("Order not found.");

            order.MarkAsSent();
        }

        public void ReceiveOrder(Guid orderId)
        {
            var order = GetOrderById(orderId)
                ?? throw new InvalidOperationException("Order not found.");

            var products = order.Items
                .Select(item =>
                {
                    var product = _productRepository.GetById(item.ProductId)
                        ?? throw new InvalidOperationException("Product not found.");

                    return (Product: product, item.Quantity);
                })
                .ToList();

            order.MarkAsReceived();

            foreach (var item in products)
            {
                item.Product.IncreaseStock(item.Quantity);
            }
        }
    }
}