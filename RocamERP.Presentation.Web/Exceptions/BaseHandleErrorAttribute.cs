using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Exceptions
{
    public class BaseHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exceptionHandleInfo = new HandleErrorInfo(filterContext.Exception, "Controller", "View");

            var context = filterContext;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Default",
            };
        }
    }
}