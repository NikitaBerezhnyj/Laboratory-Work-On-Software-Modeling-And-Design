namespace LW4.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; private set; }
        public string Phone { get; private set; }

        public Supplier(string name, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Supplier name cannot be empty.");

            Name = name;
            Phone = phone;
        }

        public void UpdateInfo(string name, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Supplier name cannot be empty.");

            Name = name;
            Phone = phone;
        }
    }
}
