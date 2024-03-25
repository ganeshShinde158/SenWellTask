using Microsoft.EntityFrameworkCore;
using SenWellTask.Models;

namespace SenWellTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        SenwellDbContext _dbContext;
        public EmployeeService(SenwellDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee emp = _dbContext.Employees.Find(employeeId);
            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _dbContext.Employees.Find(employeeId);
        }

        public List<Employee> GetEmployeesByDepartment(string department)
        {
            return _dbContext.Employees.Where(e => e.DeptName == department).ToList();

        }

        public List<Employee> GetEmployeesSortedBySalary()
        {
            return _dbContext.Employees.OrderBy(e => e.Salary).ToList();

        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Entry<Employee>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();


        }
    }
}
