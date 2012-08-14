using System.Web.Mvc;

namespace EmployeesManagement.WebUI.Models
{
    public abstract class AbstractPagingDecorator : TagBuilder {

        protected AbstractPagingDecorator(string tagName) : base(tagName) {}

        public abstract void AppendIntoInnerHtml(TagBuilder tagBuilder);
    }
}