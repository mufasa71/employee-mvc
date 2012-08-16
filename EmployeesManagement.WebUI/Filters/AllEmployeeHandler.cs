using System;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Filters
{
    public class AllEmployeeHandler : EmployeeHandler
    {
        public override Func<Employee, bool> HandleRequest(string filter) {
            if (!string.IsNullOrEmpty(filter) && filter != "All" && Successor != null) {
                return Successor.HandleRequest(filter);
            }
            return (e => e.IsActive || e.IsActive == false);
        }
    }
}