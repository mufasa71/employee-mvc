using System;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Filters
{
    public class EmployeeFilters : EmployeeHandler
    {
     public override Func<Employee, bool> HandleRequest(string filter) {
            var allEmployeeHandler = new AllEmployeeHandler();
            var activeEmployeeHandler = new ActiveEmployeeHandler();
            allEmployeeHandler.SetSuccessor(activeEmployeeHandler);
            var deactiveEmployeeHandler = new DeactiveEmployeeHandler();
            activeEmployeeHandler.SetSuccessor(deactiveEmployeeHandler);
            return allEmployeeHandler.HandleRequest(filter);
        }
    }
}