using System.Data;
using System.Linq;
using EmployeesManagement.Domain.Abstract;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EFDbContext context = new EFDbContext();
 
        public IQueryable<Employee> Employees {
            get { return context.Employees; }
            set { }
        }

        public void SaveEmployee(Employee employee) {
            if(employee.EmployeeId == 0) {
                context.Employees.Add(employee);
            }
            else {
                context.Entry(employee).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
