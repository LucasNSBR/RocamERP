using RocamERP.Infra.Data.QuerySpecifications.BancoQuerySpecifications;
using RocamERP.Presentation.Web.Areas.Plataforma.Controllers;
using System;
using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Filters
{
    public class SpecificationBindFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BancosController;
            var request = filterContext.RequestContext.HttpContext.Request as HttpRequestBase;

            if(request.QueryString.Get("prefix") != null)
                controller._bancoNomeSpecification = new BancoNomeSpecification(request.QueryString.Get("prefix"));
        }
    }
}