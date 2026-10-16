using LW2.Interfaces;

namespace LW2.Models
{
    internal class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
