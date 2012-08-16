using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeesManagement.WebUI.HtmlHelpers
{
    public static class HtmlButtonExtension
    {
        public static TagBuilder FormForButton(this HtmlHelper helper,  FormMethod method, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null) {
            var formBuilder = new TagBuilder("form");
            formBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            formBuilder.MergeAttribute("method", method.ToString());
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            formBuilder.Attributes.Add("action", urlHelper.Action(actionName, controllerName, routeValues));
            return formBuilder;
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string text, string actionName, object htmlAttributes, string controllerName = null, object routeValues = null) {
            var buttonBuilder = new TagBuilder("button");
            buttonBuilder.SetInnerText(text);
            buttonBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            var formBuilder = FormForButton(helper, FormMethod.Get, actionName, controllerName, routeValues);
            formBuilder.InnerHtml = buttonBuilder.ToString();
                return MvcHtmlString.Create(formBuilder.ToString());
        }

        public static MvcHtmlString DeleteButton(this HtmlHelper helper, string text, string actionName, object htmlAttributes, object routeValues = null, string controllerName = null) {
            var deleteButtonBuilder = new TagBuilder("a");
            deleteButtonBuilder.MergeAttribute("href", "#");
            deleteButtonBuilder.MergeAttribute("onclick", "parentNode.submit()");
            var spanBuilder = new TagBuilder("span");
            spanBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            deleteButtonBuilder.InnerHtml = spanBuilder.ToString();

            var formBuilder = FormForButton(helper, FormMethod.Post, actionName, controllerName, routeValues, new { style = "display: inline-block;"});
            formBuilder.InnerHtml = deleteButtonBuilder.ToString();
            return MvcHtmlString.Create(formBuilder.ToString());
        }
    }
}