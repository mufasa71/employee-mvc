using EmployeesManagement.Domain.Entities;

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
    }
}