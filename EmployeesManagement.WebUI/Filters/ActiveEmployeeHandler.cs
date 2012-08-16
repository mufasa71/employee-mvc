using System;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Filters
{
    public class ActiveEmployeeHandler : EmployeeHandler
    {
        public override Func<Employee, bool> HandleRequest(string filter) {
            if (!string.IsNullOrEmpty(filter) && filter == "Active") {
                return (e => e.IsActive);
            }
            if (Successor != null) {
                return Successor.HandleRequest(filter);
            }
            return (e => e.IsActive || e.IsActive == false);
        }
    }
}