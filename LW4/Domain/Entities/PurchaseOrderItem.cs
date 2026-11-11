namespace LW4.Domain.Entities
{
    public class PurchaseOrderItem
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }

        public PurchaseOrderItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            ProductId = product.Id;
            ProductName = product.Name;
            Quantity = quantity;
        }
    }
}
