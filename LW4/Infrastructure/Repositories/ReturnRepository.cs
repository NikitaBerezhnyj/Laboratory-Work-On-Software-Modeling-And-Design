using LW4.Application.Interfaces;
using LW4.Domain.Entities;

namespace LW4.Infrastructure.Repositories
{
    public class ReturnRepository : IReturnRepository
    {
        private readonly List<SaleReturn> _returns = [];

        public IEnumerable<SaleReturn> GetAll()
        {
            return _returns;
        }

        public SaleReturn? GetById(Guid id)
        {
            return _returns.FirstOrDefault(saleReturn => saleReturn.Id == id);
        }

        public IEnumerable<SaleReturn> GetBySaleId(Guid saleId)
        {
            return _returns.Where(saleReturn => saleReturn.SaleId == saleId);
        }

        public void Add(SaleReturn saleReturn)
        {
            _returns.Add(saleReturn);
        }
    }
}