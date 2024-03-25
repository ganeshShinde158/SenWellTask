using SenWellTask.Models;
namespace SenWellTask.Services

{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();


        List<Employee> GetEmployeesByDepartment(string department);


        List<Employee> GetEmployeesSortedBySalary();


        Employee GetEmployeeById(int employeeId);


        void AddEmployee(Employee employee);


        void UpdateEmployee(Employee employee);


        void DeleteEmployee(int employeeId);
    }
}
