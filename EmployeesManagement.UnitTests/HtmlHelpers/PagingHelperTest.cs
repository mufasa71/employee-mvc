using System;
using System.Web.Mvc;
using EmployeesManagement.WebUI.HtmlHelpers;
using EmployeesManagement.WebUI.Models;
using NUnit.Framework;

namespace EmployeesManagement.UnitTests.HtmlHelpers
{
    [TestFixture]
    public class PagingHelperTest
    {
        [Test]
        public void CanGeneratePageLinks() {
            HtmlHelper helper = null;

            var pagingInfo = new PagingInfo
                                        {
                                            CurrentPage = 2,
                                            TotalItems = 28,
                                            ItemsPerPage = 10
                                        };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            var result = helper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<ul class=""button-bar""><li><a href=""Page1"">&lt;&lt;</" + @"a></li><li><a href=""Page1"">&lt;</a></li><li><a href=""Page1"">1</a></li><li class=""current""><a" + @" href=""Page2"">2</a></li><li><a href=""Page3"">3</a></li><li><a href=""Page3"">&gt;</a></li><li><a" + @" href=""Page3"">&gt;&gt;</a></li></ul>");
        }
    }
}
