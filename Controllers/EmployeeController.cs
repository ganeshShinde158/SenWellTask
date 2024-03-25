using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenWellTask.Models;
using SenWellTask.Services;

namespace SenWellTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("api/Employee")]
        public List<Employee> GetAllEmployees()
        {

            return _employeeService.GetAllEmployees();
        }

        [HttpGet("{employeeId}")]
        public string GetEmployeeById(int employeeId)
        {
            var employee = _employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return "Employee not found";
            }

            return $"Employee with ID {employeeId}: {employee.FirstName} {employee.LastName}"; 
        }

        [HttpGet("department/{department}")]
        public string GetEmployeesByDepartment(string department)
        {
            var employees = _employeeService.GetEmployeesByDepartment(department);
            return $"List of employees in department {department}"; 
        }

        [HttpGet("sortbysalary")]
        public string GetEmployeesSortedBySalary()
        {
            var employees = _employeeService.GetEmployeesSortedBySalary();
            return "List of employees sorted by salary";
        }

        [HttpPost]
        public string AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return "Invalid employee data";
            }

            _employeeService.AddEmployee(employee);

            return $"Employee added successfully. Employee ID: {employee.EmployeeId}"; 
        }

        [HttpPut("{employeeId}")]
        public string UpdateEmployee(int employeeId, [FromBody] Employee employee)
        {
            if (employee == null || employeeId != employee.EmployeeId)
            {
                return "Invalid data";
            }

            var existingEmployee = _employeeService.GetEmployeeById(employeeId);
            if (existingEmployee == null)
            {
                return "Employee not found";
            }

            _employeeService.UpdateEmployee(employee);

            return $"Employee with ID {employeeId} updated successfully"; 
        }

        [HttpDelete("{employeeId}")]
        public string DeleteEmployee(int employeeId)
        {
            var existingEmployee = _employeeService.GetEmployeeById(employeeId);

            if (existingEmployee == null)
            {
                return "Employee not found";
            }

            _employeeService.DeleteEmployee(employeeId);

            return $"Employee with ID {employeeId} deleted successfully"; 
        }
    }
}