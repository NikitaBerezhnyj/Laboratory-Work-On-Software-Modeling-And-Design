namespace LW5.Domain.Entities
{
    public class SaleItem
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }

        public decimal TotalPrice => UnitPrice * Quantity;

        public SaleItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            ProductId = product.Id;
            ProductName = product.Name;
            UnitPrice = product.Price;
            Quantity = quantity;
        }
    }
}
