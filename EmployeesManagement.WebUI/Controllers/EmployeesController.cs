using System.Web.Mvc;
using System.Linq;
using EmployeesManagement.Domain.Abstract;
using EmployeesManagement.Domain.Entities;
using EmployeesManagement.WebUI.Filters;
using EmployeesManagement.WebUI.Models;

namespace EmployeesManagement.WebUI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;
        public int PageSize = 4;

        public EmployeesController(IEmployeeRepository employeeRepository) {
            _repository = employeeRepository;
        }

        public ViewResult Index() {
            return View("Index");
        }

        public ViewResult EmployeeData(string filter = "All", int page = 1) {
            var employeeFilters = new EmployeeFilters();
            var predicate = employeeFilters.HandleRequest(filter);
            var employees =
                _repository.Employees.OrderBy(e => e.EmployeeId).Where(predicate);
            var viewModel = new EmployeesListViewModel()
                                {
                                    Employees = employees.Skip((page - 1) * PageSize).Take(PageSize),
                                    PagingInfo =
                                        new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = employees.Count(), Filter = filter }
                                };
            return View(viewModel);
        }

        public ViewResult Create() {
            return View("Create", new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee employee) {
            try {
                if (!ModelState.IsValid) {
                    return View("Create", employee);
                }
                _repository.SaveEmployee(employee);
                TempData["message"] = string.Format("{0} has been saved", employee.Name);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Edit(int employeeId = 0) {
            var employee = _repository.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null) {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee) {
            if (!ModelState.IsValid) {
                return View(employee);
            }
            _repository.SaveEmployee(employee);
            TempData["message"] = string.Format("{0} has been saved", employee.Name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int employeeId) {
            var employee = _repository.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
            if (employee != null) {
                _repository.DeleteEmployee(employee);
                TempData["message"] = string.Format("{0} was deleted", employee.Name);
            }
            else {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
