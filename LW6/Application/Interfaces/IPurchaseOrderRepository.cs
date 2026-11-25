using LW6.Domain.Entities;

namespace LW6.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder? GetById(Guid id);
        void Add(PurchaseOrder order);
    }
}