using LW2.Interfaces;

namespace LW2.Models;

internal class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }
}