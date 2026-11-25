using LW6.Domain.Entities;

namespace LW6.Application.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        void Add(Sale sale);
    }
}