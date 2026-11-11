using LW5.Domain.Entities;

namespace LW5.Application.Interfaces
{
    public interface IReturnRepository
    {
        IEnumerable<SaleReturn> GetAll();
        SaleReturn? GetById(Guid id);
        IEnumerable<SaleReturn> GetBySaleId(Guid saleId);
        void Add(SaleReturn saleReturn);
    }
}