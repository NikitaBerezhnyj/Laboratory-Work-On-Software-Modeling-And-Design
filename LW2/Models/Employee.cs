using LW2.Interfaces;

namespace LW2.Models;

internal class Employee : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }
}