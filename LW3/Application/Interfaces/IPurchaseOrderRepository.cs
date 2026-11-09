using LW3.Domain.Entities;

namespace LW3.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder? GetById(Guid id);
        void Add(PurchaseOrder order);
    }
}