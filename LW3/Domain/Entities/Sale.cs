namespace LW3.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; } = Guid.NewGuid();

        public Guid EmployeeId { get; }
        public DateTime Date { get; } = DateTime.Now;

        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        private readonly List<SaleItem> _items = [];

        public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

        public Sale(Guid employeeId, IEnumerable<SaleItem> items)
        {
            if (!items.Any())
                throw new ArgumentException("Sale must contain at least one item.");

            EmployeeId = employeeId;
            _items.AddRange(items);
        }
    }
}
