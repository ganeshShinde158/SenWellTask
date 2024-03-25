using System;
using System.Collections.Generic;

namespace SenWellTask.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DeptName { get; set; }

    public string? Address { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? JoinDate { get; set; }

    public double? Salary { get; set; }
}
