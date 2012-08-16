using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesManagement.Domain.Entities;
using EmployeesManagement.WebUI.Filters;
using EmployeesManagement.WebUI.Presenters;

namespace EmployeesManagement.WebUI.Infrastructure
{
    public class ReportGenerator {
        private readonly IEnumerable<Employee> _employees;
        private const string Intro = "******* Employee Report *******";
        private const string Header = "Name\t\tSalary\tTax\tClear";
        private const string Footer = "Total Salary \\w Tax: $";


        public ReportGenerator(IQueryable<Employee> employees) {
            var filter = new ActiveEmployeeHandler();
            _employees = employees.Where(filter.HandleRequest("Active"));
        }

        public string getReport() {
            var result = new StringBuilder();
            result.AppendLine(Intro);
            result.AppendLine(Header);
            foreach (var employee in _employees) {
                var employeePresenter = new EmployeePresenter(employee);
                result.Append(employeePresenter.Name + "\t");
                result.Append(employeePresenter.Salary + "\t");
                result.Append(employeePresenter.Tax + " %\t");
                result.AppendLine(employeePresenter.SalaryIncludeTax + "\t");
            }
            result.AppendLine("******* ********* *******");
            result.AppendLine(Footer + _employees.Sum(e => e.Salary));
            return result.ToString();
        }
    }
}