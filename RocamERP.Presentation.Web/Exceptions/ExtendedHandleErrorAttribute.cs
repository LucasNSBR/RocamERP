using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Exceptions
{
    public class ExtendedHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exceptionHandleInfo = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            var context = filterContext;
            filterContext.ExceptionHandled = true;
            
            filterContext.Result = new ViewResult()
            {
                ViewName = View,
                ViewData = new ViewDataDictionary(exceptionHandleInfo),
            };
        }
    }
}