using System.Linq;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.Domain.Abstract // Code to interfaces not to implementation
{
    // Interface can obtain Employe objects without knowing where they are from
    public interface IEmployeeRepository 
    {
        IQueryable<Employee> Employees { get; set; }
        void SaveEmployee(Employee employee);
    }
}
