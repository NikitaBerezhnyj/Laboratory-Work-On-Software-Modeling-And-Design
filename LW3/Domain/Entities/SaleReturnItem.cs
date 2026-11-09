namespace LW3.Domain.Entities
{
    public class SaleReturnItem
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public SaleReturnItem(SaleItem saleItem, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Return quantity must be greater than zero.");

            if (quantity > saleItem.Quantity)
                throw new ArgumentException("Return quantity exceeds purchased quantity.");

            ProductId = saleItem.ProductId;
            ProductName = saleItem.ProductName;
            UnitPrice = saleItem.UnitPrice;
            Quantity = quantity;
        }
    }
}