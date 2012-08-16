using System.Web.Mvc;
using System.Web.Routing;
using EmployeesManagement.WebUI.Infrastructure;

namespace EmployeesManagement.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "{filter}/Page{page}",
                new { controller = "Employees", action = "EmployeeData" });
            routes.MapRoute(
                null,
                "Employees/Create",
                new { controller = "Employees", action = "Create" });
            routes.MapRoute(
                null,
                "Employees/Edit/{EmployeeId}",
                new { controller = "Employees", action = "Edit"});
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}", // URL with parameters
                new { controller = "Employees", action = "Index" } // Parameter defaults
            );
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}