using LW3.Domain.Enums;

namespace LW3.Domain.Entities
{
    public class PurchaseOrder
    {
        public Guid Id { get; } = Guid.NewGuid();

        public Guid SupplierId { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;

        public OrderStatus Status { get; private set; } = OrderStatus.Created;

        public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();

        private readonly List<PurchaseOrderItem> _items = [];

        public PurchaseOrder(Guid supplierId, IEnumerable<PurchaseOrderItem> items)
        {
            if (!items.Any())
                throw new ArgumentException("Order must contain at least one item.");

            SupplierId = supplierId;
            _items.AddRange(items);
        }

        public void MarkAsSent()
        {
            if (Status != OrderStatus.Created)
                throw new InvalidOperationException("Order cannot be sent.");

            Status = OrderStatus.Sent;
        }

        public void MarkAsReceived()
        {
            if (Status != OrderStatus.Sent)
                throw new InvalidOperationException("Order cannot be received.");

            Status = OrderStatus.Received;
        }
    }
}
