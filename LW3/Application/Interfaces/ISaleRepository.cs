using LW3.Domain.Entities;

namespace LW3.Application.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        void Add(Sale sale);
    }
}