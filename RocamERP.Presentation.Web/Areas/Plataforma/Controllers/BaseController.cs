using Ninject;
using RocamERP.Domain.Models.Messages;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class BaseController : Controller
    {
        protected void ThrowMessage(BaseMessage message)
        {
            TempData["Message"] = message;
        }
    }
}