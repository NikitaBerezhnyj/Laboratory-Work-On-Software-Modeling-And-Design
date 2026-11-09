using LW3.Application.Services;
using LW3.Domain.Enums;

namespace LW3.Presentation
{
    public class ConsoleMenu
    {
        private readonly ProductService _productService;
        private readonly SalesService _salesService;
        private readonly InventoryService _inventoryService;
        private readonly EmployeeService _employeeService;
        private readonly SupplierService _supplierService;
        private readonly ReportService _reportService;
        private readonly OrderService _orderService;
        private readonly ReturnService _returnService;

        public ConsoleMenu(
            ProductService productService,
            SalesService salesService,
            InventoryService inventoryService,
            EmployeeService employeeService,
            SupplierService supplierService,
            ReportService reportService,
            OrderService orderService,
            ReturnService returnService)
        {
            _productService = productService;
            _salesService = salesService;
            _inventoryService = inventoryService;
            _employeeService = employeeService;
            _supplierService = supplierService;
            _reportService = reportService;
            _orderService = orderService;
            _returnService = returnService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== STORE AUTOMATION SYSTEM ===");
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Cashier");
                Console.WriteLine("3. Seller");
                Console.WriteLine("4. Administrator");
                Console.WriteLine("5. Supplier");
                Console.WriteLine("0. Exit");

                switch (ReadInt("Select a role: "))
                {
                    case 1:
                        CustomerMenu();
                        break;
                    case 2:
                        CashierMenu();
                        break;
                    case 3:
                        SellerMenu();
                        break;
                    case 4:
                        AdminMenu();
                        break;
                    case 5:
                        SupplierMenu();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void CustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CUSTOMER MENU ===");
                Console.WriteLine("1. View products");
                Console.WriteLine("2. Search for a product");
                Console.WriteLine("3. Make a purchase");
                Console.WriteLine("4. Return a product");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        SearchProduct();
                        break;
                    case 3:
                        CreateSale();
                        break;
                    case 4:
                        ReturnProduct();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void CashierMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CASHIER MENU ===");
                Console.WriteLine("1. View products");
                Console.WriteLine("2. Check product availability");
                Console.WriteLine("3. Process a sale");
                Console.WriteLine("4. View sales");
                Console.WriteLine("5. Process a product return");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        CheckStock();
                        break;
                    case 3:
                        CreateSale();
                        break;
                    case 4:
                        ShowSales();
                        break;
                    case 5:
                        ReturnProduct();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void SellerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SELLER MENU ===");
                Console.WriteLine("1. View products");
                Console.WriteLine("2. Check product availability");
                Console.WriteLine("3. Update product information");
                Console.WriteLine("4. Receive a delivery");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        CheckStock();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        ReceiveOrder();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ADMINISTRATOR MENU ===");
                Console.WriteLine("1. Product management");
                Console.WriteLine("2. Employee management");
                Console.WriteLine("3. Supplier management");
                Console.WriteLine("4. Generate reports");
                Console.WriteLine("5. View sales statistics");
                Console.WriteLine("6. Create a supplier order");
                Console.WriteLine("7. View orders");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ProductManagementMenu();
                        break;
                    case 2:
                        EmployeeManagementMenu();
                        break;
                    case 3:
                        SupplierManagementMenu();
                        break;
                    case 4:
                        ShowReport();
                        break;
                    case 5:
                        ShowStatistics();
                        break;
                    case 6:
                        CreateOrder();
                        break;
                    case 7:
                        ShowOrders();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void SupplierMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SUPPLIER MENU ===");
                Console.WriteLine("1. View orders");
                Console.WriteLine("2. Confirm order shipment");
                Console.WriteLine("3. Receive an order");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowOrders();
                        break;
                    case 2:
                        SendOrder();
                        break;
                    case 3:
                        ReceiveOrder();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCT LIST ===");

            foreach (var product in _productService.GetAllProducts())
            {
                Console.WriteLine(
                    $"{product.Id} | {product.Name} | {product.Price} UAH | Quantity: {product.Quantity}");
            }

            Pause();
        }

        private void SearchProduct()
        {
            Console.Clear();
            var query = ReadString("Enter product name: ");

            var products = _productService.SearchProducts(query).ToList();

            if (products.Count == 0)
            {
                ShowMessage("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"{product.Name} | {product.Price} UAH | Quantity: {product.Quantity}");
            }

            Pause();
        }

        private void CheckStock()
        {
            Console.Clear();
            var productId = ReadGuid("Enter product ID: ");

            var quantity = _inventoryService.GetStockQuantity(productId);

            if (quantity == null)
            {
                ShowMessage("Product not found.");
                return;
            }

            Console.WriteLine($"Available stock: {quantity}");
            Pause();
        }

        private void UpdateProduct()
        {
            Console.Clear();

            var id = ReadGuid("Enter product ID: ");
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                ShowMessage("Product not found.");
                return;
            }

            var name = ReadString($"New name ({product.Name}): ");
            var description = ReadString($"New description ({product.Description}): ");
            var price = ReadDecimal($"New price ({product.Price}): ");

            _productService.UpdateProduct(id, name, description, price);

            ShowMessage("Product information updated successfully.");
        }

        private void ProductManagementMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PRODUCT MANAGEMENT ===");
                Console.WriteLine("1. View products");
                Console.WriteLine("2. Add a product");
                Console.WriteLine("3. Update a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        DeleteProduct();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            Console.Clear();

            var name = ReadString("Product name: ");
            var description = ReadString("Description: ");
            var price = ReadDecimal("Price: ");
            var quantity = ReadInt("Quantity: ");

            _productService.AddProduct(name, description, price, quantity);

            ShowMessage("Product added successfully.");
        }

        private void DeleteProduct()
        {
            Console.Clear();

            var id = ReadGuid("Product ID: ");

            _productService.DeleteProduct(id);

            ShowMessage("Product deleted successfully.");
        }

        private void CreateSale()
        {
            Console.Clear();

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
                ShowProducts();

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

        private void ShowSales()
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

        private void ReturnProduct()
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
                    var productId = ReadGuid(
                        "Enter product ID (0 to finish): ");

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

                var saleReturn = _returnService.CreateReturn(
                    saleId,
                    employeeId,
                    items);

                Console.WriteLine("\nReturn completed successfully.");
                Console.WriteLine($"Return ID: {saleReturn.Id}");
                Console.WriteLine($"Refund amount: {saleReturn.TotalAmount} UAH");

                ShowMessage("Product stock has been updated.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Return failed: {exception.Message}");
            }
        }

        private void EmployeeManagementMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== EMPLOYEE MANAGEMENT ===");
                Console.WriteLine("1. View employees");
                Console.WriteLine("2. Add an employee");
                Console.WriteLine("3. Delete an employee");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowEmployees();
                        break;
                    case 2:
                        AddEmployee();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void ShowEmployees()
        {
            Console.Clear();

            foreach (var employee in _employeeService.GetAllEmployees())
            {
                Console.WriteLine(
                    $"{employee.Id} | {employee.FullName} | {employee.Role}");
            }

            Pause();
        }

        private void AddEmployee()
        {
            Console.Clear();

            var fullName = ReadString("Employee full name: ");

            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Cashier");
            Console.WriteLine("3. Seller");

            var role = ReadInt("Select a role: ") switch
            {
                1 => EmployeeRole.Administrator,
                2 => EmployeeRole.Cashier,
                3 => EmployeeRole.Seller,
                _ => throw new ArgumentException("Invalid role.")
            };

            _employeeService.AddEmployee(fullName, role);

            ShowMessage("Employee added successfully.");
        }

        private void DeleteEmployee()
        {
            var id = ReadGuid("Employee ID: ");

            _employeeService.DeleteEmployee(id);

            ShowMessage("Employee deleted successfully.");
        }

        private void SupplierManagementMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SUPPLIER MANAGEMENT ===");
                Console.WriteLine("1. View suppliers");
                Console.WriteLine("2. Add a supplier");
                Console.WriteLine("3. Delete a supplier");
                Console.WriteLine("0. Back");

                switch (ReadInt("Select an action: "))
                {
                    case 1:
                        ShowSuppliers();
                        break;
                    case 2:
                        AddSupplier();
                        break;
                    case 3:
                        DeleteSupplier();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }

        private void ShowSuppliers()
        {
            Console.Clear();

            foreach (var supplier in _supplierService.GetAllSuppliers())
            {
                Console.WriteLine(
                    $"{supplier.Id} | {supplier.Name} | {supplier.Phone}");
            }

            Pause();
        }

        private void AddSupplier()
        {
            Console.Clear();

            var name = ReadString("Supplier name: ");
            var phone = ReadString("Phone number: ");

            _supplierService.AddSupplier(name, phone);

            ShowMessage("Supplier added successfully.");
        }

        private void DeleteSupplier()
        {
            var id = ReadGuid("Supplier ID: ");

            _supplierService.DeleteSupplier(id);

            ShowMessage("Supplier deleted successfully.");
        }

        private void CreateOrder()
        {
            Console.Clear();

            ShowSuppliers();

            var supplierId = ReadGuid("Supplier ID: ");

            var items = new List<(Guid ProductId, int Quantity)>();

            while (true)
            {
                var productId = ReadGuid("Product ID (0 to finish): ");

                if (productId == Guid.Empty)
                    break;

                var quantity = ReadInt("Quantity: ");

                items.Add((productId, quantity));

                if (!ReadBool("Add another product?"))
                    break;
            }

            if (items.Count == 0)
            {
                ShowMessage("The order contains no products.");
                return;
            }

            var order = _orderService.CreateOrder(supplierId, items);

            Console.WriteLine($"Order created successfully: {order.Id}");

            Pause();
        }

        private void ShowOrders()
        {
            Console.Clear();
            Console.WriteLine("=== ORDERS ===");

            foreach (var order in _orderService.GetAllOrders())
            {
                Console.WriteLine(
                    $"{order.Id} | Supplier: {order.SupplierId} | Status: {order.Status}");
            }

            Pause();
        }

        private void SendOrder()
        {
            var id = ReadGuid("Order ID: ");

            _orderService.SendOrder(id);

            ShowMessage("Order has been shipped.");
        }

        private void ReceiveOrder()
        {
            var id = ReadGuid("Order ID: ");

            _orderService.ReceiveOrder(id);

            ShowMessage("Delivery received. Stock levels have been updated.");
        }

        private void ShowReport()
        {
            Console.Clear();

            var from = ReadDate("Start date (yyyy-MM-dd): ");
            var to = ReadDate("End date (yyyy-MM-dd): ");

            var revenue = _reportService.GetTotalRevenue(from, to);

            Console.WriteLine($"Total revenue: {revenue} UAH");

            Pause();
        }

        private void ShowStatistics()
        {
            Console.Clear();

            var sales = _salesService.GetAllSales().ToList();

            Console.WriteLine($"Total number of sales: {sales.Count}");
            Console.WriteLine($"Total revenue: {sales.Sum(sale => sale.TotalAmount)} UAH");

            Pause();
        }

        private static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        private static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        private static Guid ReadGuid(string message)
        {
            while (true)
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (input == "0")
                    return Guid.Empty;

                if (Guid.TryParse(input, out var value))
                    return value;

                Console.WriteLine("Please enter a valid GUID or 0 to finish.");
            }
        }

        private static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (DateTime.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a date in yyyy-MM-dd format.");
            }
        }

        private static bool ReadBool(string message)
        {
            Console.Write($"{message} (yes/no): ");
            return Console.ReadLine()?.Trim().ToLower() is "yes" or "y";
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
