using System.Data.Entity;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
