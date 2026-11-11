using LW5.Domain.Entities;

namespace LW5.Application.Interfaces
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