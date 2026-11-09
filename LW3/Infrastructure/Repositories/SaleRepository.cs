using LW3.Application.Interfaces;
using LW3.Domain.Entities;

namespace LW3.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = [];

        public IEnumerable<Sale> GetAll()
        {
            return _sales;
        }

        public Sale? GetById(Guid id)
        {
            return _sales.FirstOrDefault(sale => sale.Id == id);
        }

        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }
    }
}