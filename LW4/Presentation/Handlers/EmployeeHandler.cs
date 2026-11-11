using LW4.Application.Services;
using LW4.Domain.Enums;
using static LW4.Presentation.ConsoleInput;

namespace LW4.Presentation.Handlers
{
    public class EmployeeHandler
    {
        private readonly EmployeeService _employeeService;

        public EmployeeHandler(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void ShowEmployees()
        {
            Console.Clear();

            foreach (var employee in _employeeService.GetAllEmployees())
            {
                Console.WriteLine(
                    $"{employee.Id} | {employee.FullName} | {employee.Role}");
            }

            Pause();
        }

        public void AddEmployee()
        {
            Console.Clear();

            try
            {
                var fullName = ReadString("Employee full name: ");

                Console.WriteLine("1. Administrator");
                Console.WriteLine("2. Cashier");
                Console.WriteLine("3. Seller");

                var role = ReadInt("Select a role: ") switch
                {
                    1 => EmployeeRole.Administrator,
                    2 => EmployeeRole.Cashier,
                    3 => EmployeeRole.Seller,
                    _ => throw new ArgumentException("Invalid role.")
                };

                _employeeService.AddEmployee(fullName, role);

                ShowMessage("Employee added successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void DeleteEmployee()
        {
            try
            {
                var id = ReadGuid("Employee ID: ");

                _employeeService.DeleteEmployee(id);

                ShowMessage("Employee deleted successfully.");
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }
    }
}