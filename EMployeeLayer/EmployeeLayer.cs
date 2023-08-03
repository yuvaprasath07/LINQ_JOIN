using Employye_Db;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EMployeeLayer
{
    public class EmployeeLayer : IEmployee
    {
        private readonly Empoyee_DB _DB;
        public EmployeeLayer(Empoyee_DB dB)
        {
            _DB = dB;
        }
        public object get()
        {
            var Departments = _DB.Department.ToList();
            var Employees = _DB.Employee.ToList();
            var EmployeeSalarys = _DB.Employeesalary.ToList();
            var salaryDetails = _DB.salaryDetails.ToList();




            var result = from e in Employees
                         join d in Departments on e.DepartmentId equals d.DepartmentId
                         join es in EmployeeSalarys on e.EmployeeId equals es.EmployeeId
                         join sd in salaryDetails on es.SalaryId equals sd.salaryID
                         select new
                         {
                             e.EmployeeName,
                             e.EmployeAge,
                             d.DepartmentName,
                             es.Salary,
                             sd.paymenttype,
                             sd.AccountNumber,
                             sd.BankName
                         };

            return result;
        }



        public object leftjoin()

        {
            var Departments = _DB.Department.ToList();
            var Employees = _DB.Employee.ToList();
            var EmployeeSalarys = _DB.Employeesalary.ToList();
            var salaryDetails = _DB.salaryDetails.ToList();


            var lEftJoin = from emp in Employees
                        join salary in EmployeeSalarys on emp.EmployeeId equals salary.EmployeeId into empSalaryGroup
                        from empSalary in empSalaryGroup.DefaultIfEmpty()
                        join details in salaryDetails on empSalary?.SalaryId equals details.salaryID into salaryDetailsGroup
                        from salaryDetail in salaryDetailsGroup.DefaultIfEmpty()
                        select new
                        {
                            EmployeeName = emp.EmployeeName,
                            EmployeAge = emp.EmployeAge,
                            Salary = empSalary?.Salary ?? 0,
                            PaymentType = salaryDetail?.paymenttype,
                            AccountNumber = salaryDetail?.AccountNumber,
                            BankName = salaryDetail?.BankName
                        };
            return lEftJoin;
        }
        public object groupJoin()
        {
            var Departments = _DB.Department.ToList();
            var Employees = _DB.Employee.ToList();
            var EmployeeSalarys = _DB.Employeesalary.ToList();
            var salaryDetails = _DB.salaryDetails.ToList();

            var employeeWithSalaryDetails = Employees.GroupJoin(
                EmployeeSalarys,
                emp=>emp.EmployeeId,
                sal=>sal.EmployeeId,
                (emp, sal) => new
                {
                    Employee = emp,
                    Salaries = sal
                }
                )
                .GroupJoin(
                salaryDetails,
                empSal => empSal.Salaries.FirstOrDefault()?.SalaryId,
                sd => sd.salaryID,
                (empSal, sd) => new
                {
                    Employee = empSal.Employee,
                    Salaries = empSal.Salaries,
                    SalaryDetails = sd.FirstOrDefault()
                })
                            .Select(result => new
                            {
                                result.Employee.EmployeeId,
                                result.Employee.EmployeeName,
                                result.Employee.EmployeAge,
                                result.Employee.DepartmentId,
                                Salary = result.Salaries.FirstOrDefault()?.Salary ?? 0,
                                PaymentType = result.SalaryDetails?.paymenttype,
                                result.SalaryDetails?.AccountNumber,
                                result.SalaryDetails?.BankName
                            });
            return employeeWithSalaryDetails;
        }
    }
}