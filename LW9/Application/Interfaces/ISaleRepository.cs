using LW9.Domain.Entities;

namespace LW9.Application.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        void Add(Sale sale);
    }
}