using System;
using System.Collections.Generic;
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

        public static MvcHtmlString SearchBar(this HtmlHelper helper, Dictionary<string, string> htmlAttributes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString DisplayForCurrency<T>(this HtmlHelper helper, Func<T, string> expression) where T : class, new()
        {   
            return new MvcHtmlString("");
        }

        public static MvcHtmlString DisplayForCEP<T>(this HtmlHelper helper, Func<T, string> expression) where T : class, new()
        {
            return new MvcHtmlString(""); 
        }
    }
}