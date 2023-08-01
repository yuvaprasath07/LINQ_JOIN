using Microsoft.EntityFrameworkCore;

namespace Employye_Db
{
    public class Empoyee_DB: DbContext
    {
        public Empoyee_DB(DbContextOptions<Empoyee_DB> options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeSalary> Employeesalary { get; set; }

        public DbSet<SalaryDetails> salaryDetails { get; set; }

    }
}