using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Extensions
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MessageAlert(this HtmlHelper helper, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"alert alert-dismissible alert-success fade show col-12\">");
            sb.AppendLine($"{message}");
            sb.AppendLine("<button class=\"close\" data-dismiss=\"alert\">");
            sb.AppendLine("<span>&times;</span>");
            sb.AppendLine("</button>");
            sb.AppendLine("</div>");

            return new MvcHtmlString(sb.ToString());
        }

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

        public static MvcHtmlString SubmitButtonExtended(this HtmlHelper helper, string text, object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"form-group row pt-5\">");
            sb.AppendLine("<div class=\"col-12\">");
            sb.Append($"<input value=\"{text}\" ");

            if(htmlAttributes != null) { 
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (var v in htmlAttributes.GetType().GetProperties())
                {
                    values.Add(v.Name, (string)v.GetValue(htmlAttributes, null));
                }

                if (values != null)
                {
                    foreach (var htmlAttributte in values)
                    {
                        sb.Append($"{htmlAttributte.Key} = \"{htmlAttributte.Value}\"");
                    }
                }
            }
            sb.AppendLine("/>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString SubmitButtonOk(this HtmlHelper helper, string text, object htmlAttributes = null)
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (var v in htmlAttributes.GetType().GetProperties())
            {
                values.Add(v.Name, (string)v.GetValue(htmlAttributes, null));
            }

            sb.Append("<button ");
            if (values != null)
            {
                foreach (var htmlAttributte in values)
                {
                    sb.Append($"{htmlAttributte.Key} = \"{htmlAttributte.Value}\"");
                }
            }

            sb.AppendLine($">{text}");
            sb.AppendLine("</button>");
            return new MvcHtmlString(sb.ToString());
        }



        public static MvcHtmlString SearchBar(this HtmlHelper helper, Dictionary<string, string> htmlAttributes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}