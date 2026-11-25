using LW7.Domain.Entities;

namespace LW7.Application.Interfaces
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