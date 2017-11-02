using System;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Extensions
{
    public static class HtmlHelpers
    {
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