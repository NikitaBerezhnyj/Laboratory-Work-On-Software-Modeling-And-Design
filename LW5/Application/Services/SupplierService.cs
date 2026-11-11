using LW5.Application.Interfaces;
using LW5.Domain.Entities;

namespace LW5.Application.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier? GetSupplierById(Guid id)
        {
            return _supplierRepository.GetById(id);
        }

        public void AddSupplier(string name, string phone)
        {
            var supplier = new Supplier(name, phone);

            _supplierRepository.Add(supplier);
        }

        public void UpdateSupplier(Guid id, string name, string phone)
        {
            var supplier = GetSupplierById(id)
                ?? throw new InvalidOperationException("Supplier not found.");

            supplier.UpdateInfo(name, phone);

            _supplierRepository.Update(supplier);
        }

        public void DeleteSupplier(Guid id)
        {
            _supplierRepository.Delete(id);
        }
    }
}