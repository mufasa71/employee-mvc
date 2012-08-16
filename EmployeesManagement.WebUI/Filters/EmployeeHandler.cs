using System;
using EmployeesManagement.Domain.Entities;

namespace EmployeesManagement.WebUI.Filters
{
    public abstract class EmployeeHandler {
        protected EmployeeHandler Successor;
        public void SetSuccessor(EmployeeHandler successor) {
            Successor = successor;
        }

        public abstract Func<Employee, bool> HandleRequest(string filter);
    }
}