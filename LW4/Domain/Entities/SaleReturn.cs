namespace LW4.Domain.Entities
{
    public class SaleReturn
    {
        public Guid Id { get; } = Guid.NewGuid();

        public Guid SaleId { get; }
        public Guid EmployeeId { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;

        public IReadOnlyCollection<SaleReturnItem> Items => _items.AsReadOnly();

        private readonly List<SaleReturnItem> _items = [];

        public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

        public SaleReturn(
            Guid saleId,
            Guid employeeId,
            IEnumerable<SaleReturnItem> items)
        {
            var returnItems = items.ToList();

            if (returnItems.Count == 0)
                throw new ArgumentException("Return must contain at least one item.");

            SaleId = saleId;
            EmployeeId = employeeId;

            _items.AddRange(returnItems);
        }
    }
}