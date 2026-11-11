using LW5.Domain.Entities;

namespace LW5.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder? GetById(Guid id);
        void Add(PurchaseOrder order);
    }
}