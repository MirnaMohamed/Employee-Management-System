using Employee_Management_System.DTOs;
using Employee_Management_System.Entities;
using Employee_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //get all employees no pagination
            List<DisplayEmployeeDTO> employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("page/{pageNum}")]
        public IActionResult GetAllEmployees([FromQuery] int? pageSize, int pageNum = 1)
        {
            List<DisplayEmployeeDTO> employees = _employeeService.GetAllEmployees(pageNum, pageSize);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            DisplayEmployeeDTO? employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with ID: {id} is not found");
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _employeeService.AddEmployee(employee);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] AddEmployeeDTO employee)
        {
            // Logic to update employee
            if(_employeeService.GetEmployeeById(id) == null)
            {
                return NotFound($"Employee with ID: {id} is not found");
            }
            else if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _employeeService.UpdateEmployee(id, employee);
                    return NoContent();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            };
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            // Logic to delete employee
            if (id <= 0)
            {
                return BadRequest("Invalid employee ID");
            }
            else
            {
                try
                {
                    _employeeService.DeleteEmployee(id);
                    return NoContent();
                }
                catch(ArgumentException)
                {
                    return NotFound($"Employee with ID {id} not found");
                }
            }
        }
    }
}
