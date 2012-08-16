using EmployeesManagement.Domain.Entities;
using EmployeesManagement.WebUI.Infrastructure;

namespace EmployeesManagement.WebUI.Presenters
{
    public class EmployeePresenter {
        private readonly Employee _employee;
        public EmployeePresenter(Employee employee) {
            _employee = employee;
        }

        public string Name {
            get { return _employee.Name; }
        }

        public string Active {
            get { return _employee.IsActive ? "Yes" : "No"; }
        }

        public string Salary {
            get { return "$ " + _employee.Salary; }
        }

        public double Tax { get { return new ConcreteTaxHandler().HandleTax(_employee.Salary); } }

        public string SalaryIncludeTax {
            get { return "$ " + (_employee.Salary - ((_employee.Salary * Tax) / 100)); }
        }
    }
}