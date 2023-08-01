using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employye_Db
{
    public class Department
    {
        [Key]
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }

    public class Employee
    {
        [Key]
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeAge { get; set; }
        public int? DepartmentId { get; set; }

    }

    public class EmployeeSalary
    {
        [Key]
        public int? SalaryId { get; set; }
        public int? Salary { get; set; }
        public int? EmployeeId { get; set; }

    }

    public class SalaryDetails
    {
       
        public string paymenttype { get; set; }
        [Key]
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public int salaryID { get; set; }

    }

}
