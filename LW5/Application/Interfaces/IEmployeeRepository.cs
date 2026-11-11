using LW5.Domain.Entities;

namespace LW5.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(Guid id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Guid id);
    }
}