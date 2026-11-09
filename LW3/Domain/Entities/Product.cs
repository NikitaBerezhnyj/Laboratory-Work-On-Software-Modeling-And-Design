namespace LW3.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, string description, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public void UpdateInfo(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            Name = name;
            Description = description;
            Price = price;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0 || quantity > Quantity)
                throw new InvalidOperationException("Insufficient product stock.");

            Quantity -= quantity;
        }

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            Quantity += quantity;
        }
    }
}
