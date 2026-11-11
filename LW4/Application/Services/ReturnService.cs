using LW4.Application.Interfaces;
using LW4.Domain.Entities;
using LW4.Domain.Enums;

namespace LW4.Application.Services
{
    public class ReturnService
    {
        private readonly IReturnRepository _returnRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ReturnService(
            IReturnRepository returnRepository,
            ISaleRepository saleRepository,
            IProductRepository productRepository,
            IEmployeeRepository employeeRepository)
        {
            _returnRepository = returnRepository;
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<SaleReturn> GetAllReturns()
        {
            return _returnRepository.GetAll();
        }

        public SaleReturn? GetReturnById(Guid id)
        {
            return _returnRepository.GetById(id);
        }

        public IEnumerable<SaleReturn> GetReturnsBySaleId(Guid saleId)
        {
            return _returnRepository.GetBySaleId(saleId);
        }

        public SaleReturn CreateReturn(
            Guid saleId,
            Guid employeeId,
            IEnumerable<(Guid ProductId, int Quantity)> requestedItems)
        {
            var sale = _saleRepository.GetById(saleId)
                ?? throw new InvalidOperationException("Sale not found.");

            var employee = _employeeRepository.GetById(employeeId)
                ?? throw new InvalidOperationException("Employee not found.");

            if (employee.Role != EmployeeRole.Cashier)
                throw new InvalidOperationException(
                    "Only a cashier can process returns.");

            var items = requestedItems
                .GroupBy(item => item.ProductId)
                .Select(group => (
                    ProductId: group.Key,
                    Quantity: group.Sum(item => item.Quantity)))
                .ToList();

            if (items.Count == 0)
                throw new ArgumentException("Return must contain at least one item.");

            if (items.Any(item => item.Quantity <= 0))
                throw new ArgumentException(
                    "Return quantities must be greater than zero.");

            var previousReturns = _returnRepository
                .GetBySaleId(saleId)
                .SelectMany(saleReturn => saleReturn.Items)
                .GroupBy(item => item.ProductId)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(item => item.Quantity));

            var returnItems = new List<SaleReturnItem>();
            var productsToUpdate = new List<Product>();

            foreach (var requestedItem in items)
            {
                var saleItem = sale.Items.FirstOrDefault(
                    item => item.ProductId == requestedItem.ProductId);

                if (saleItem == null)
                    throw new InvalidOperationException(
                        "Product was not included in this sale.");

                previousReturns.TryGetValue(
                    requestedItem.ProductId,
                    out var alreadyReturned);

                var availableForReturn = saleItem.Quantity - alreadyReturned;

                if (requestedItem.Quantity > availableForReturn)
                    throw new InvalidOperationException(
                        $"Cannot return {requestedItem.Quantity} units. " +
                        $"Only {availableForReturn} units are available for return.");

                var product = _productRepository.GetById(
                    requestedItem.ProductId)
                    ?? throw new InvalidOperationException(
                        $"Product '{saleItem.ProductName}' not found.");

                returnItems.Add(
                    new SaleReturnItem(saleItem, requestedItem.Quantity));

                productsToUpdate.Add(product);
            }

            var saleReturn = new SaleReturn(
                saleId,
                employeeId,
                returnItems);

            foreach (var item in returnItems)
            {
                var product = productsToUpdate.First(
                    product => product.Id == item.ProductId);

                product.IncreaseStock(item.Quantity);
                _productRepository.Update(product);
            }

            _returnRepository.Add(saleReturn);

            return saleReturn;
        }
    }
}