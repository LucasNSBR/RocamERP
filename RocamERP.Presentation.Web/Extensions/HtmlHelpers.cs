using System.Text;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Extensions
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string text, object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"form-group row pt-5\">");
            sb.AppendLine("<div class=\"col-12\">");
            sb.AppendLine($"<input type=\"submit\" value=\"{text}\" class=\"btn btn-primary\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}