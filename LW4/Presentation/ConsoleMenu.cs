using LW4.Presentation.Handlers;
using static LW4.Presentation.ConsoleInput;

namespace LW4.Presentation
{
    public class ConsoleMenu
    {
        private readonly ProductHandler _products;
        private readonly SalesHandler _sales;
        private readonly EmployeeHandler _employees;
        private readonly SupplierHandler _suppliers;
        private readonly OrderHandler _orders;
        private readonly ReportHandler _reports;

        public ConsoleMenu(
            ProductHandler products,
            SalesHandler sales,
            EmployeeHandler employees,
            SupplierHandler suppliers,
            OrderHandler orders,
            ReportHandler reports)
        {
            _products = products;
            _sales = sales;
            _employees = employees;
            _suppliers = suppliers;
            _orders = orders;
            _reports = reports;
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
                        _products.ShowProducts();
                        break;
                    case 2:
                        _products.SearchProduct();
                        break;
                    case 3:
                        _sales.CreateSale();
                        break;
                    case 4:
                        _sales.ReturnProduct();
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
                        _products.ShowProducts();
                        break;
                    case 2:
                        _products.CheckStock();
                        break;
                    case 3:
                        _sales.CreateSale();
                        break;
                    case 4:
                        _sales.ShowSales();
                        break;
                    case 5:
                        _sales.ReturnProduct();
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
                        _products.ShowProducts();
                        break;
                    case 2:
                        _products.CheckStock();
                        break;
                    case 3:
                        _products.UpdateProduct();
                        break;
                    case 4:
                        _orders.ReceiveOrder();
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
                        _reports.ShowReport();
                        break;
                    case 5:
                        _reports.ShowStatistics();
                        break;
                    case 6:
                        _orders.CreateOrder();
                        break;
                    case 7:
                        _orders.ShowOrders();
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
                        _orders.ShowOrders();
                        break;
                    case 2:
                        _orders.SendOrder();
                        break;
                    case 3:
                        _orders.ReceiveOrder();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
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
                        _products.ShowProducts();
                        break;
                    case 2:
                        _products.AddProduct();
                        break;
                    case 3:
                        _products.UpdateProduct();
                        break;
                    case 4:
                        _products.DeleteProduct();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
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
                        _employees.ShowEmployees();
                        break;
                    case 2:
                        _employees.AddEmployee();
                        break;
                    case 3:
                        _employees.DeleteEmployee();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
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
                        _suppliers.ShowSuppliers();
                        break;
                    case 2:
                        _suppliers.AddSupplier();
                        break;
                    case 3:
                        _suppliers.DeleteSupplier();
                        break;
                    case 0:
                        return;
                    default:
                        ShowMessage("Invalid menu option.");
                        break;
                }
            }
        }
    }
}