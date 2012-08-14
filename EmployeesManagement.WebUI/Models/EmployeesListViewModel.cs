using System.Collections.Generic;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Models
{
    public class EmployeesListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}