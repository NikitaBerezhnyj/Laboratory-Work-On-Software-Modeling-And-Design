using LW9.Domain.Entities;

namespace LW9.Application.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}