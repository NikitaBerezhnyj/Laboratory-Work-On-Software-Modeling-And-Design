using LW9.Application.Interfaces;
using LW9.Domain.Entities;
using LW9.Domain.Enums;

namespace LW9.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee? GetEmployeeById(Guid id)
        {
            return _employeeRepository.GetById(id);
        }

        public void AddEmployee(string fullName, EmployeeRole role)
        {
            var employee = new Employee(fullName, role);

            _employeeRepository.Add(employee);
        }

        public void UpdateEmployee(Guid id, string fullName, EmployeeRole role)
        {
            var employee = GetEmployeeById(id)
                ?? throw new InvalidOperationException("Employee not found.");

            employee.UpdateInfo(fullName, role);

            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(Guid id)
        {
            _employeeRepository.Delete(id);
        }
    }
}