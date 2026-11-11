using LW4.Application.Interfaces;
using LW4.Domain.Entities;

namespace LW4.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = [];

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(Guid id)
        {
            return _employees.FirstOrDefault(employee => employee.Id == id);
        }

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existingEmployee = GetById(employee.Id);

            if (existingEmployee is null)
                throw new InvalidOperationException("Employee not found.");

            var index = _employees.IndexOf(existingEmployee);
            _employees[index] = employee;
        }

        public void Delete(Guid id)
        {
            var employee = GetById(id);

            if (employee is null)
                throw new InvalidOperationException("Employee not found.");

            _employees.Remove(employee);
        }
    }
}