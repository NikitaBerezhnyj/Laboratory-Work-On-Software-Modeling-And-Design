using LW3.Application.Services;
using static LW3.Presentation.ConsoleInput;

namespace LW3.Presentation.Handlers
{
    public class ProductHandler
    {
        private readonly ProductService _productService;
        private readonly InventoryService _inventoryService;

        public ProductHandler(
            ProductService productService,
            InventoryService inventoryService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
        }

        public void ShowProducts()
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

        public void SearchProduct()
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

        public void CheckStock()
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

        public void AddProduct()
        {
            Console.Clear();

            try
            {
                var name = ReadString("Product name: ");
                var description = ReadString("Description: ");
                var price = ReadDecimal("Price: ");
                var quantity = ReadInt("Quantity: ");

                _productService.AddProduct(name, description, price, quantity);

                ShowMessage("Product added successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void UpdateProduct()
        {
            Console.Clear();

            try
            {
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
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void DeleteProduct()
        {
            Console.Clear();

            try
            {
                var id = ReadGuid("Product ID: ");

                _productService.DeleteProduct(id);

                ShowMessage("Product deleted successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }
    }
}