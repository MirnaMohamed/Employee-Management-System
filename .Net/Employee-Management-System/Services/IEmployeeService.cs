using Employee_Management_System.DTOs;
using Employee_Management_System.Entities;

namespace Employee_Management_System.Services
{
    public interface IEmployeeService
    {
        List<DisplayEmployeeDTO> GetAllEmployees();
        List<DisplayEmployeeDTO> GetAllEmployees(int pageNum, int? pageSize);
        DisplayEmployeeDTO? GetEmployeeById(int id);
        void AddEmployee(AddEmployeeDTO employee);
        void UpdateEmployee(int id, AddEmployeeDTO employee);
        void DeleteEmployee(int id);
    }
}
