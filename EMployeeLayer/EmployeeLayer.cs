using Employye_Db;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EMployeeLayer
{
    public class EmployeeLayer: IEmployee
    {
        private readonly Empoyee_DB _DB;
        public EmployeeLayer(Empoyee_DB dB)
        {
            _DB = dB;
        }
        public object get()
        {
            var Departments=_DB.Department.ToList();
            var Employees = _DB.Employee.ToList();
            var EmployeeSalarys=_DB.Employeesalary.ToList();
            var salaryDetails = _DB.salaryDetails.ToList();

            //var result = from department in Departments join employee in Employees on department.

           
            var result = from e in Employees
                         join d in Departments on e.DepartmentId equals d.DepartmentId
                         join es in EmployeeSalarys on e.EmployeeId equals es.EmployeeId
                         join sd in salaryDetails on es.SalaryId equals sd.salaryID
                         select new
                         {
                             e.EmployeeName,
                             d.DepartmentName,
                             es.Salary,
                             PaymentType = sd.paymenttype,
                             sd.AccountNumber,
                             sd.BankName
                         };

            return result;
        }
    }
}