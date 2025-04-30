using Employee_Management_System.Entities;
using Employee_Management_System.Repositories;

namespace Employee_Management_System.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            _employeeRepository.Delete(employee);
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeeList = _employeeRepository.GetAll();
            return Task.FromResult(employeeList);
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return Task.FromResult(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            ;
        }
    }
}
