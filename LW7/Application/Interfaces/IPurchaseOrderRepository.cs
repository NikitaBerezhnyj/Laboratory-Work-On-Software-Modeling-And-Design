using LW7.Domain.Entities;

namespace LW7.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> GetAll();
        PurchaseOrder? GetById(Guid id);
        void Add(PurchaseOrder order);
    }
}