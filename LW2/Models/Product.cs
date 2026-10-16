using LW2.Interfaces;

namespace LW2.Models
{
    internal class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }
    }
}
