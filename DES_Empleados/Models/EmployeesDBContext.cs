using Microsoft.EntityFrameworkCore;

namespace DES_Empleados.Models
{
    public class EmployeesDBContext: DbContext
    {
        public EmployeesDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
    }
}
