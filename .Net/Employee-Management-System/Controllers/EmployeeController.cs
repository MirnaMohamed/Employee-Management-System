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
            List<Employee> employees = _employeeService.GetAllEmployees().Result.ToList();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _employeeService.GetEmployeeById(id).Result;
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            else
            {
                if(ModelState.IsValid)
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
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Logic to update employee
            if (employee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _employeeService.UpdateEmployee(employee);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            return NoContent();
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
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            return NoContent();
        }
    }
}
