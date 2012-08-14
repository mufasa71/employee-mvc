using System.Web.Mvc;
using System.Linq;
using EmployeesManagement.Domain.Abstract;
using EmployeesManagement.Domain.Entities;
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

        //
        // GET: /Employees/

        public ActionResult Index(int page = 1) {
            var viewModel = new EmployeesListViewModel
                                {
                                    Employees =
                                        _repository.Employees.OrderBy(e => e.EmployeeId).Skip((page - 1) * PageSize).Take(
                                            PageSize),
                                    PagingInfo = new PagingInfo
                                                     {
                                                         CurrentPage = page,
                                                         ItemsPerPage = PageSize,
                                                         TotalItems = _repository.Employees.Count()
                                                     }
                                };
            return View(viewModel);
        }

        public ActionResult Create() {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                //TODO Add insert logic
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Edit(int employeeId = 0) {
            var employee = _repository.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if(employee == null) {
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
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete behavior
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
