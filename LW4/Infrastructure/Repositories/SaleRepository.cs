using LW4.Application.Interfaces;
using LW4.Domain.Entities;

namespace LW4.Infrastructure.Repositories
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