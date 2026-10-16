using LW2.Data;
using LW2.Models;

namespace LW2.Services;

internal class StoreService
{
    private readonly StoreDatabase db;

    public StoreService(StoreDatabase db)
    {
        this.db = db;
    }

    public void PrintProducts()
    {
        Console.WriteLine("\n========== ТОВАРИ ==========");

        foreach (Product product in db.Products.Items)
        {
            Console.WriteLine($"\n{product}");

            var description = db.Descriptions.Items
                .Find(d => d.ProductId == product.Id);

            Console.WriteLine(
                $"Опис: {description?.Text ?? "Не вказано"}");

            var categoryIds = db.ProductCategories.Items
                .Where(pc => pc.ProductId == product.Id)
                .Select(pc => pc.CategoryId)
                .ToList();

            var categories = db.Categories.Items
                .Where(c => categoryIds.Contains(c.Id))
                .Select(c => c.Name)
                .ToList();

            Console.WriteLine(
                $"Категорії: {string.Join(", ", categories)}");
        }
    }

    public void PrintOrders()
    {
        Console.WriteLine("\n========== ЗАМОВЛЕННЯ ==========");

        foreach (Order order in db.Orders.Items)
        {
            var customer = db.Customers.GetById(order.CustomerId);
            var employee = db.Employees.GetById(order.EmployeeId);

            var productIds = db.OrderProducts.Items
                .Where(op => op.OrderId == order.Id)
                .Select(op => op.ProductId)
                .ToList();

            var products = db.Products.Items
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            double totalPrice = products.Sum(p => p.Price);

            Console.WriteLine($"\n{order.OrderName}");
            Console.WriteLine(
                $"Покупець: {customer?.Name ?? "Не знайдено"}");
            Console.WriteLine(
                $"Працівник: {employee?.Name ?? "Не знайдено"}");

            Console.WriteLine("Товари:");

            foreach (Product product in products)
            {
                Console.WriteLine($"- {product.Name}: {product.Price:F2} грн");
            }

            Console.WriteLine($"Загальна сума: {totalPrice:F2} грн");
        }
    }
}