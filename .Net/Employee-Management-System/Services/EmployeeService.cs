using AutoMapper;
using Employee_Management_System.DTOs;
using Employee_Management_System.Entities;
using Employee_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public void AddEmployee(AddEmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {

            Employee employee = _employeeRepository.GetById(id);
            if(employee == null)
            {
                throw new ArgumentException(nameof(employee), "Employee not found");
            }
            else
            {
                _employeeRepository.Delete(employee);
                _employeeRepository.SaveChanges();
            }
        }

        public List<DisplayEmployeeDTO> GetAllEmployees()
        {
            IEnumerable<Employee> employeeList = _employeeRepository.GetAll();
            List<DisplayEmployeeDTO> employeeDTO = new List<DisplayEmployeeDTO>();
            foreach (var employee in employeeList)
            {
                var employeeData = _mapper.Map<DisplayEmployeeDTO>(employee);
                employeeDTO.Add(employeeData);
            }
            return employeeDTO;
        }

        public List<DisplayEmployeeDTO> GetAllEmployees(int pageNum, int? pageSize)
        {
            IEnumerable<Employee> employeeList;
            if ( pageNum > 0 && pageSize == null)
            {
                employeeList = _employeeRepository.GetAll(pageNum);
            }
            else if(pageNum > 0 && pageSize > 0)
            {
                employeeList = _employeeRepository.GetAll(pageNum, pageSize.Value);
            }
            else
            {
                throw new ArgumentException("Page number and page size must be greater than zero");
            }
            List<DisplayEmployeeDTO> employeeDTO = new List<DisplayEmployeeDTO>();
            foreach (var employee in employeeList)
            {
                var employeeData = _mapper.Map<DisplayEmployeeDTO>(employee);
                employeeDTO.Add(employeeData);
            }
            return employeeDTO;
        }

        public DisplayEmployeeDTO? GetEmployeeById(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            if(employee == null)
            {
                return null;
            }
            DisplayEmployeeDTO employeeDTO = _mapper.Map<DisplayEmployeeDTO>(employee);
            return employeeDTO;
        }

        public void UpdateEmployee(int id, AddEmployeeDTO employee)
        {
            Employee existingEmployee = _mapper.Map<Employee>(employee);
            existingEmployee.Id = id;
            _employeeRepository.Update(id, existingEmployee);
            _employeeRepository.SaveChanges();
        }
    }
}
