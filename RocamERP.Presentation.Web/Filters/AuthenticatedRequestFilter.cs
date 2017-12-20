using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Filters
{
    public class AuthenticatedRequestFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var redirectUrl = "http://localhost:57756/manage/overview";

            if (filterContext.HttpContext.Request.IsAuthenticated)
                filterContext.Result = new RedirectResult(redirectUrl);
        }
    }
}