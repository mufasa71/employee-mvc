using System.Text;
using System.Web.Mvc;

namespace EmployeesManagement.WebUI.Infrastructure
{
    public class ReportFileResult : FileContentResult
    {
        public string Content { get; private set; }
        public string DownloadFileName { get; private set; }
        public ReportFileResult(string content,  string contentType, string downloadFileName) : base(Encoding.ASCII.GetBytes(content), contentType) {
            Content = content;
            DownloadFileName = downloadFileName;

        }

        public override void ExecuteResult(ControllerContext context) {
            context.HttpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + DownloadFileName);

            base.ExecuteResult(context);
        }
    }
}