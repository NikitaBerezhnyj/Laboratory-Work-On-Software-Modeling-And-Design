using LW3.Application.Services;
using static LW3.Presentation.ConsoleInput;

namespace LW3.Presentation.Handlers
{
    public class OrderHandler
    {
        private readonly OrderService _orderService;
        private readonly SupplierHandler _supplierHandler;

        public OrderHandler(
            OrderService orderService,
            SupplierHandler supplierHandler)
        {
            _orderService = orderService;
            _supplierHandler = supplierHandler;
        }

        public void CreateOrder()
        {
            Console.Clear();

            try
            {
                _supplierHandler.ShowSuppliers();

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
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void ShowOrders()
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

        public void SendOrder()
        {
            try
            {
                var id = ReadGuid("Order ID: ");

                _orderService.SendOrder(id);

                ShowMessage("Order has been shipped.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void ReceiveOrder()
        {
            try
            {
                var id = ReadGuid("Order ID: ");

                _orderService.ReceiveOrder(id);

                ShowMessage("Delivery received. Stock levels have been updated.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }
    }
}