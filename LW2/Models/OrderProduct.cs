using LW2.Interfaces;

namespace LW2.Models;

internal class OrderProduct : IEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public OrderProduct(int orderId, int productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }
}