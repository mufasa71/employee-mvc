using System;
using System.Text;
using System.Web.Mvc;
using EmployeesManagement.WebUI.Models;

namespace EmployeesManagement.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl) {
            var result = new StringBuilder();
            var listNames = new ListNames();
            var pagingDecorator = new PagingDecorator();
            if (pagingInfo.CurrentPage != 1) {
                pagingDecorator.AppendIntoInnerHtml(new ListItem(listNames.Begin, "1"));
                pagingDecorator.AppendIntoInnerHtml(new ListItem(listNames.Backward, (pagingInfo.CurrentPage - 1).ToString()));
            }

            for (var i = 1; i <= pagingInfo.TotalPages; i++) {
                var li = new ListItem(i.ToString(), i.ToString(), (i == pagingInfo.CurrentPage));
                pagingDecorator.AppendIntoInnerHtml(li);
            }

            if (pagingInfo.CurrentPage != pagingInfo.TotalPages) {
                pagingDecorator.AppendIntoInnerHtml(new ListItem(listNames.Forward, pagingInfo.TotalPages.ToString()));
                pagingDecorator.AppendIntoInnerHtml(new ListItem(listNames.End, (pagingInfo.CurrentPage + 1).ToString()));
            }

            result.Append(pagingDecorator);
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString AjaxPageLinks(this AjaxHelper ajaxHelper, PagingInfo pagingInfo, Func<int, string> pageUrl) {
            var result = new StringBuilder();
            var listNames = new ListNames();
            var pagingDecorator = new PagingDecorator();
            if (pagingInfo.CurrentPage != 1) {
                pagingDecorator.AppendIntoInnerHtml(new AjaxListItem(listNames.Begin, pagingInfo.Filter, "1"));
                pagingDecorator.AppendIntoInnerHtml(new AjaxListItem(listNames.Backward, pagingInfo.Filter, (pagingInfo.CurrentPage - 1).ToString()));
            }

            for (var i = 1; i <= pagingInfo.TotalPages; i++) {
                var li = new AjaxListItem(i.ToString(), pagingInfo.Filter, i.ToString(), (i == pagingInfo.CurrentPage));
                pagingDecorator.AppendIntoInnerHtml(li);
            }

            if (pagingInfo.CurrentPage != pagingInfo.TotalPages) {
                pagingDecorator.AppendIntoInnerHtml(new AjaxListItem(listNames.Forward, pagingInfo.Filter, (pagingInfo.CurrentPage + 1).ToString()));
                pagingDecorator.AppendIntoInnerHtml(new AjaxListItem(listNames.End, pagingInfo.Filter, pagingInfo.TotalPages.ToString()));
            }

            result.Append(pagingDecorator);
            return MvcHtmlString.Create(result.ToString());

        }

    }

    public class ListItem : TagBuilder
    {
        public ListItem(string innerText, string href = "", bool currentPage = false)
            : base("li") {
            var a = new TagBuilder("a");
            a.MergeAttribute("href", "Page" + href);
            a.SetInnerText(innerText);
            if (currentPage) {
                AddCssClass("current");
            }
            InnerHtml = a.ToString();
        }
    }

    public class AjaxListItem : TagBuilder
    {
        public AjaxListItem(string innerText, string filter = "All", string href = "", bool currentPage = false)
            : base("li") {
            var a = new TagBuilder("a");
            a.MergeAttribute("data-ajax", "true");
            a.MergeAttribute("data-ajax-loading", "#loading");
            a.MergeAttribute("data-ajax-mode", "replace");
            a.MergeAttribute("data-ajax-update", "#employees_data");
            a.MergeAttribute("data-ajax-success", "doKickstart");
            a.MergeAttribute("href", filter + "/Page" + href);
            a.SetInnerText(innerText);
            if(currentPage) {
                AddCssClass("current");
            }
            InnerHtml = a.ToString();
        }
    }

    public class ListNames
    {
        public string Begin { get { return "<<"; } }
        public string Backward { get { return "<"; } }
        public string Forward { get { return ">"; } }
        public string End { get { return ">>"; } }
    }
}