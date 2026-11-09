using LW3.Domain.Enums;

namespace LW3.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string FullName { get; private set; }
        public EmployeeRole Role { get; private set; }

        public Employee(string fullName, EmployeeRole role)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Employee name cannot be empty.");

            FullName = fullName;
            Role = role;
        }

        public void UpdateInfo(string fullName, EmployeeRole role)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Employee name cannot be empty.");

            FullName = fullName;
            Role = role;
        }
    }
}
