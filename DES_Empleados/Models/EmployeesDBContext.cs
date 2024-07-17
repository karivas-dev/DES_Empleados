using Microsoft.EntityFrameworkCore;

namespace DES_Empleados.Models
{
    public class EmployeesDBContext: DbContext
    {
        public EmployeesDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
