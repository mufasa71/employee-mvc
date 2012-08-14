using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeesManagement.WebUI.HtmlHelpers
{
    public static class HtmlButtonExtension
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string text, string actionName, object htmlAttributes) {
            var builder = new TagBuilder("button");
            builder.SetInnerText(text);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var formBuilder = new TagBuilder("form");
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            formBuilder.Attributes.Add("action", urlHelper.Action(actionName, null, null));
            formBuilder.InnerHtml = builder.ToString();
            
            return MvcHtmlString.Create(formBuilder.ToString());
        }
    }
}