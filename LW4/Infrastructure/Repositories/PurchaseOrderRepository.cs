using LW4.Application.Interfaces;
using LW4.Domain.Entities;

namespace LW4.Infrastructure.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly List<PurchaseOrder> _orders = [];

        public IEnumerable<PurchaseOrder> GetAll()
        {
            return _orders;
        }

        public PurchaseOrder? GetById(Guid id)
        {
            return _orders.FirstOrDefault(order => order.Id == id);
        }

        public void Add(PurchaseOrder order)
        {
            _orders.Add(order);
        }
    }
}