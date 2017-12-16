using System.Net;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState as ModelStateDictionary;

            //if (!modelState.IsValid)
            //    OnResultExecuting(filterContext.Result);
        }
    }
}