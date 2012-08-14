using System;
using System.Web.Mvc;
using EmployeesManagement.Domain.Abstract;
using EmployeesManagement.Domain.Concrete;
using Ninject;

namespace EmployeesManagement.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory() {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType) {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBindings() {
            //var mock = new Mock<IEmployeeRepository>();
            //mock.Setup(m => m.Employees).Returns(new List<Employee>
            //                                        {
            //                                            new Employee {Name = "Bill Gates", Salary = 2000.00, IsActive = true},
            //                                            new Employee {Name = "Steve Jobs", Salary = 2500.00, IsActive = true}
            //                                        }.AsQueryable());
            //_ninjectKernel.Bind<IEmployeeRepository>().ToConstant(mock.Object);

            _ninjectKernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
        }
    }
}