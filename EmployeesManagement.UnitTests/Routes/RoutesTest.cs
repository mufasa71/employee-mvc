using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using EmployeesManagement.WebUI;
using Moq;
using NUnit.Framework;

namespace EmployeesManagement.UnitTests.Routes
{
    [TestFixture]
    public class RoutesTest
    {
        [Test]
        public void TestIncomingRoutes() {
            TestRouteMatch("~/", "Employees", "Index");
            TestRouteMatch("~/Employees", "Employees", "Index");
            TestRouteMatch("~/All/Page1", "Employees", "EmployeeData");
            TestRouteMatch("~/Employees/Index", "Employees", "Index");
            TestRouteMatch("~/Employees/Edit/1", "Employees", "Edit");

            TestRouteFail("~/Employees/Index/All");
            TestRouteFail("~/Employees/Delete/1");
        } 

        private static HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET") {
            // create the mock request  
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response 
            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response 
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context 
            return mockContext.Object;
        } 

        private static void TestRouteMatch(string url, string controller, string action, object  
    routeProperties = null, string httpMethod = "GET") {
            // Arrange 
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            // Act - process the route 
            var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));
            // Assert 
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private static bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null) {

            Func<object, object, bool> valCompare = (v1, v2) => StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;

            var result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null) {
                var propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo) {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name],
                                pi.GetValue(propertySet, null)))) {

                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        private static void TestRouteFail(string url) {
            // Arrange 
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            // Act - process the route 
            var result = routes.GetRouteData(CreateHttpContext(url));
            // Assert 
            Assert.IsTrue(result == null || result.Route == null);
        } 
    }
}
