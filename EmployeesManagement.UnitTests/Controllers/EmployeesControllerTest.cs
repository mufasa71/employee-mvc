using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeesManagement.Domain.Abstract;
using EmployeesManagement.Domain.Entities;
using EmployeesManagement.WebUI.Controllers;
using EmployeesManagement.WebUI.Models;
using Moq;
using NUnit.Framework;

namespace EmployeesManagement.UnitTests.Controllers
{
    [TestFixture]
    public class EmployeesControllerTest
    {
        private Mock<IEmployeeRepository> _mock;
        private const string Name1 = "Bill Gates";
        private const double Salary1 = 1000.33;
        private const string Name2 = "Steve Jobs";
        private const double Salary2 = 1223.12;

        [SetUp]
        public void Setup() {
            _mock = new Mock<IEmployeeRepository>();
            _mock.Setup(e => e.Employees).Returns(new List<Employee>
                                                      {
                                                          new Employee {EmployeeId = 1, Name = Name1, Salary = Salary1, IsActive = true}, new Employee { EmployeeId = 2, Name = Name2, Salary = Salary2, IsActive = true }, new Employee { EmployeeId = 3, Name="N1", Salary = 2000, IsActive = false}, new Employee { EmployeeId = 4, Name="N2", IsActive = false}, new Employee{ EmployeeId = 5, Name="N3", IsActive = true}
                                                      }.AsQueryable());
            
        }

        [Test]
        public void EmployeeDataReturnsAListOfEmployees() {
            var employeesController = new EmployeesController(_mock.Object);
            var viewResult = employeesController.EmployeeData();
            Assert.IsNotNull(viewResult, "View Result is null");
            Assert.IsInstanceOf(typeof(EmployeesListViewModel), viewResult.Model, "Wrong view model");
            var employeeEntries = viewResult.ViewData.Model as EmployeesListViewModel;
            Assert.IsNotNull(employeeEntries, "Employees entries is null");
            Assert.AreEqual(4, employeeEntries.Employees.Count(), "Got wrong number of employees");
            var employee1 = employeeEntries.Employees.ToArray()[0];
            Assert.AreEqual(Name1, employee1.Name);
            Assert.AreEqual(Salary1, employee1.Salary);
            var employee2 = employeeEntries.Employees.ToArray()[1];
            Assert.AreEqual(Name2, employee2.Name);
            Assert.AreEqual(Salary2, employee2.Salary);

        }

        [Test]
        public void EmployeeDataCanPaginate() {
            var employeesController = new EmployeesController(_mock.Object);
            employeesController.PageSize = 3;
            var viewResult = employeesController.EmployeeData(page:2);
            var employeesEntries = (viewResult.Model as EmployeesListViewModel).Employees.ToArray();
            Assert.IsTrue(employeesEntries.Length == 2, "Got wrong number of employees");
            Assert.AreEqual(employeesEntries[0].Name, "N2");
            Assert.AreEqual(employeesEntries[1].Name, "N3");
        }

        [Test]
        public void EmployeeDataCanSendPaginationViewModel() {
            var employeesController = new EmployeesController(_mock.Object);
            employeesController.PageSize = 3;
            var viewResult = employeesController.EmployeeData(page:2);
            var pagingInfo = (viewResult.Model as EmployeesListViewModel).PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);  
        }

        [Test]
        public void CanFilterEmployee() {
            var employeesController = new EmployeesController(_mock.Object);
            employeesController.PageSize = 3;
            var viewResult = employeesController.EmployeeData(filter: "Active");
            var employees = (viewResult.Model as EmployeesListViewModel).Employees;
            Assert.AreEqual(employees.Count(), 3);
            Assert.IsTrue(employees.ToArray()[0].IsActive);  
        }

        [Test]
        public void CanEditEmployee() {
            var employeesController = new EmployeesController(_mock.Object);
            var result = employeesController.Edit(1) as ViewResult;
            
            var e1 = result.ViewData.Model as Employee;
            result = employeesController.Edit(2) as ViewResult;
            var e2 = result.ViewData.Model as Employee;
            result = employeesController.Edit(3) as ViewResult;
            var e3 = result.ViewData.Model as Employee;

            Assert.AreEqual(1, e1.EmployeeId);
            Assert.AreEqual(2, e2.EmployeeId);
            Assert.AreEqual(3, e3.EmployeeId);
        }

        [Test]
        public void CannotEditNonexistentEmployee() {
            var employeesController = new EmployeesController(_mock.Object);
            var result = employeesController.Edit(6) as ViewResult;
            Assert.IsNull(result);
        }

        [Test]
        public void CanSaveValidEmployeeChanges() {
            var employeesController = new EmployeesController(_mock.Object);
            var employee = new Employee {Name="Test"};
            var result = employeesController.Edit(employee) as RedirectToRouteResult;
            _mock.Verify(m => m.SaveEmployee(employee));
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void CannotSaveInvalidChanges() {
            var employeesController = new EmployeesController(_mock.Object);
            var employee = new Employee { Name = "Test" };
            employeesController.ModelState.AddModelError("error", "error");
            employeesController.Edit(employee);
            _mock.Verify(x => x.SaveEmployee(employee), Times.Never());
        }

        [Test]
        public void CanCreateANewEmployee() {
            var employeesController = new EmployeesController(_mock.Object);
            var employee = new Employee {Name = "TestName"};
            var viewResult = employeesController.Create(employee) as RedirectToRouteResult;
            Assert.AreEqual("Index", viewResult.RouteValues["action"]);
            _mock.Verify(x => x.SaveEmployee(employee), Times.Once());
        }

        [Test]
        public void CannotCreateAnInvalidEmployee() {
            var employeesController = new EmployeesController(_mock.Object);
            employeesController.ModelState.AddModelError("error", "error");
            var employee = new Employee();
            var viewResult = employeesController.Create(employee) as ViewResult;
            var model = viewResult.Model;
            Assert.AreEqual(model, employee);
            Assert.AreEqual("Create", viewResult.ViewName);
            _mock.Verify(x => x.SaveEmployee(employee), Times.Never());
        }

        [Test]
        public void CanDeleteValidEmployee() {
            var employee = new Employee {EmployeeId = 1, Name = "Test"};
            _mock.Setup(e => e.DeleteEmployee(employee));
            var employeesController = new EmployeesController(_mock.Object);
            var viewResult = employeesController.Delete(employee.EmployeeId) as RedirectToRouteResult;
            Assert.AreEqual("Index", viewResult.RouteValues["action"]);
        }

        [Test]
        public void CannotDeleteNonExistingEmployee() {
            var employee = new Employee { EmployeeId = 100, Name = "Test" };
            _mock.Setup(e => e.DeleteEmployee(employee));
            var employeesController = new EmployeesController(_mock.Object);
            var viewResult = employeesController.Delete(employee.EmployeeId) as HttpNotFoundResult;
            Assert.IsInstanceOf(typeof(HttpNotFoundResult), viewResult);
        }
    }
}
