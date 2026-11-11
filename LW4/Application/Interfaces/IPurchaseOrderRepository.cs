using LW4.Domain.Entities;

namespace LW4.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder? GetById(Guid id);
        void Add(PurchaseOrder order);
    }
}