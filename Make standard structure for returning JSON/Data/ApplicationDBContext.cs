using Make_standard_structure_for_returning_JSON.Data.ConfigrationType;
using Make_standard_structure_for_returning_JSON.Model;
using Microsoft.EntityFrameworkCore;

namespace Make_standard_structure_for_returning_JSON.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeConfigration().Configure(modelBuilder.Entity<Employee>());
            new DepartmentConfigration().Configure(modelBuilder.Entity<Department>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}