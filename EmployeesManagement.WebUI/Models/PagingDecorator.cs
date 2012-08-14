using System.Web.Mvc;

namespace EmployeesManagement.WebUI.Models
{
    public class PagingDecorator : AbstractPagingDecorator
    {
        public PagingDecorator() : base("ul") {
            AddCssClass("button-bar");
        }

        public override void AppendIntoInnerHtml(TagBuilder tagBuilder) {
            InnerHtml += tagBuilder;
        }
    }
}