using LW2.Models;
using LW2.Repository;

namespace LW2.Data;

internal class StoreDatabase
{
    public DBItem<Product> Products { get; } = new();
    public DBItem<Category> Categories { get; } = new();
    public DBItem<Description> Descriptions { get; } = new();
    public DBItem<ProductCategory> ProductCategories { get; } = new();

    public DBItem<Customer> Customers { get; } = new();
    public DBItem<Employee> Employees { get; } = new();

    public DBItem<Order> Orders { get; } = new();
    public DBItem<OrderProduct> OrderProducts { get; } = new();
}