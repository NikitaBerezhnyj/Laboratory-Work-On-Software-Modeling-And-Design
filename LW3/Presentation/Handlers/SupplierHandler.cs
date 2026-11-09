using LW3.Application.Services;
using static LW3.Presentation.ConsoleInput;

namespace LW3.Presentation.Handlers
{
    public class SupplierHandler
    {
        private readonly SupplierService _supplierService;

        public SupplierHandler(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public void ShowSuppliers()
        {
            Console.Clear();

            foreach (var supplier in _supplierService.GetAllSuppliers())
            {
                Console.WriteLine(
                    $"{supplier.Id} | {supplier.Name} | {supplier.Phone}");
            }

            Pause();
        }

        public void AddSupplier()
        {
            Console.Clear();

            try
            {
                var name = ReadString("Supplier name: ");
                var phone = ReadString("Phone number: ");

                _supplierService.AddSupplier(name, phone);

                ShowMessage("Supplier added successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void DeleteSupplier()
        {
            try
            {
                var id = ReadGuid("Supplier ID: ");

                _supplierService.DeleteSupplier(id);

                ShowMessage("Supplier deleted successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }
    }
}