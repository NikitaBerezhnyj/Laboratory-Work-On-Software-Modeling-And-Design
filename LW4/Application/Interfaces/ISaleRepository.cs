using LW4.Domain.Entities;

namespace LW4.Application.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        void Add(Sale sale);
    }
}