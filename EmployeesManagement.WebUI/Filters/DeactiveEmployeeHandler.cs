using System;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Filters
{
    public class DeactiveEmployeeHandler : EmployeeHandler
    {
        public override Func<Employee, bool> HandleRequest(string filter) {
            if (!string.IsNullOrEmpty(filter) && filter == "Deactive") {
                return (e => e.IsActive == false);
            }
            if (Successor != null) {
                Successor.HandleRequest(filter);
            }
            return (e => e.IsActive || e.IsActive == false);
        }
    }
}