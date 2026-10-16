using LW2.Interfaces;

namespace LW2.Models
{
    internal class ProductCategory : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public ProductCategory(int productId, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return $"{Id} {ProductId} {CategoryId}";
        }
    }
}
