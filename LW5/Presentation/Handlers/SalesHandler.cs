using LW5.Application.Services;
using LW5.Domain.Enums;
using static LW5.Presentation.ConsoleInput;

namespace LW5.Presentation.Handlers
{
    public class SalesHandler
    {
        private readonly SalesService _salesService;
        private readonly ReturnService _returnService;
        private readonly EmployeeService _employeeService;
        private readonly ProductHandler _productHandler;

        public SalesHandler(
            SalesService salesService,
            ReturnService returnService,
            EmployeeService employeeService,
            ProductHandler productHandler)
        {
            _salesService = salesService;
            _returnService = returnService;
            _employeeService = employeeService;
            _productHandler = productHandler;
        }

        public void CreateSale()
        {
            Console.Clear();

            try
            {
                var cashiers = _employeeService.GetAllEmployees()
                    .Where(employee => employee.Role == EmployeeRole.Cashier)
                    .ToList();

                if (cashiers.Count == 0)
                {
                    ShowMessage("There are no registered cashiers in the system.");
                    return;
                }

                Console.WriteLine("Available cashiers:");

                foreach (var cashier in cashiers)
                {
                    Console.WriteLine($"{cashier.Id} | {cashier.FullName}");
                }

                var employeeId = ReadGuid("Cashier ID: ");

                if (!cashiers.Any(employee => employee.Id == employeeId))
                {
                    ShowMessage("Cashier not found.");
                    return;
                }

                var items = new List<(Guid ProductId, int Quantity)>();

                while (true)
                {
                    Console.WriteLine();
                    _productHandler.ShowProducts();

                    var productId = ReadGuid("Product ID (enter 0 to finish): ");

                    if (productId == Guid.Empty)
                        break;

                    var quantity = ReadInt("Quantity: ");

                    items.Add((productId, quantity));

                    if (!ReadBool("Add another product?"))
                        break;
                }

                if (items.Count == 0)
                {
                    ShowMessage("The sale contains no products.");
                    return;
                }

                var sale = _salesService.CreateSale(employeeId, items);

                Console.WriteLine($"Sale completed. Sale ID: {sale.Id}");
                Console.WriteLine($"Total amount: {sale.TotalAmount} UAH");

                ShowMessage("Payment has been confirmed (simulated).");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void ShowSales()
        {
            Console.Clear();
            Console.WriteLine("=== SALES LIST ===");

            foreach (var sale in _salesService.GetAllSales())
            {
                Console.WriteLine(
                    $"{sale.Id} | {sale.Date} | Total: {sale.TotalAmount} UAH");
            }

            Pause();
        }

        public void ReturnProduct()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCT RETURN ===");

            try
            {
                var saleId = ReadGuid("Enter sale ID: ");

                var sale = _salesService.GetSaleById(saleId);

                if (sale == null)
                {
                    ShowMessage("Sale not found.");
                    return;
                }

                Console.WriteLine("\nItems in this sale:");

                foreach (var item in sale.Items)
                {
                    Console.WriteLine(
                        $"{item.ProductId} | {item.ProductName} | " +
                        $"Quantity: {item.Quantity} | Price: {item.UnitPrice}");
                }

                var employeeId = ReadGuid("\nEnter cashier ID: ");

                var items = new List<(Guid ProductId, int Quantity)>();

                while (true)
                {
                    var productId = ReadGuid("Enter product ID (0 to finish): ");

                    if (productId == Guid.Empty)
                        break;

                    var quantity = ReadInt("Enter return quantity: ");

                    items.Add((productId, quantity));

                    if (!ReadBool("Add another product?"))
                        break;
                }

                if (items.Count == 0)
                {
                    ShowMessage("No products selected for return.");
                    return;
                }

                var saleReturn = _returnService.CreateReturn(saleId, employeeId, items);

                Console.WriteLine("\nReturn completed successfully.");
                Console.WriteLine($"Return ID: {saleReturn.Id}");
                Console.WriteLine($"Refund amount: {saleReturn.TotalAmount} UAH");

                ShowMessage("Product stock has been updated.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }
    }
}