using LW7.Domain.Entities;

namespace LW7.Application.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        void Add(Sale sale);
    }
}