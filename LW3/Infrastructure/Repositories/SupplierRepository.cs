using LW3.Application.Interfaces;
using LW3.Domain.Entities;

namespace LW3.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly List<Supplier> _suppliers = [];

        public IEnumerable<Supplier> GetAll()
        {
            return _suppliers;
        }

        public Supplier? GetById(Guid id)
        {
            return _suppliers.FirstOrDefault(supplier => supplier.Id == id);
        }

        public void Add(Supplier supplier)
        {
            _suppliers.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            var existingSupplier = GetById(supplier.Id);

            if (existingSupplier is null)
                throw new InvalidOperationException("Supplier not found.");

            var index = _suppliers.IndexOf(existingSupplier);
            _suppliers[index] = supplier;
        }

        public void Delete(Guid id)
        {
            var supplier = GetById(id);

            if (supplier is null)
                throw new InvalidOperationException("Supplier not found.");

            _suppliers.Remove(supplier);
        }
    }
}