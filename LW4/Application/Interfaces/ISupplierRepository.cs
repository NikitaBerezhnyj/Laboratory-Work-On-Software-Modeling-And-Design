using LW4.Domain.Entities;

namespace LW4.Application.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier? GetById(Guid id);
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Guid id);
    }
}