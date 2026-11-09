using LW3.Application.Interfaces;
using LW3.Domain.Entities;
using LW3.Domain.Enums;

namespace LW3.Application.Services
{
    public class SalesService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public SalesService(
            ISaleRepository saleRepository,
            IProductRepository productRepository,
            IEmployeeRepository employeeRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _saleRepository.GetAll();
        }

        public Sale? GetSaleById(Guid id)
        {
            return _saleRepository.GetById(id);
        }

        public Sale CreateSale(Guid employeeId, IEnumerable<(Guid ProductId, int Quantity)> items)
        {
            var employee = _employeeRepository.GetById(employeeId)
                ?? throw new InvalidOperationException("Employee not found.");

            if (employee.Role != EmployeeRole.Cashier)
                throw new InvalidOperationException("Employee is not a cashier.");

            var requestedItems = items.ToList();

            if (requestedItems.Count == 0)
                throw new ArgumentException("Sale must contain at least one item.");

            var groupedItems = requestedItems
                .GroupBy(item => item.ProductId)
                .Select(group => (
                    ProductId: group.Key,
                    Quantity: group.Sum(item => item.Quantity)))
                .ToList();

            var products = new List<(Product Product, int Quantity)>();

            foreach (var item in groupedItems)
            {
                if (item.Quantity <= 0)
                    throw new ArgumentException("Quantity must be positive.");

                var product = _productRepository.GetById(item.ProductId)
                    ?? throw new InvalidOperationException("Product not found.");

                if (product.Quantity < item.Quantity)
                    throw new InvalidOperationException(
                        $"Insufficient stock for product: {product.Name}.");

                products.Add((product, item.Quantity));
            }

            var saleItems = products
                .Select(item => new SaleItem(item.Product, item.Quantity))
                .ToList();

            var sale = new Sale(employeeId, saleItems);

            foreach (var item in products)
            {
                item.Product.DecreaseStock(item.Quantity);
            }

            _saleRepository.Add(sale);

            return sale;
        }
    }
}