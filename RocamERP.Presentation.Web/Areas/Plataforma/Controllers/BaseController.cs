using RocamERP.CrossCutting.MessagerInterfaces;
using RocamERP.Presentation.Web.Messager;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class BaseController : Controller
    {
        protected void SendMessage(BaseMessage message)
        {
            TempData["Message"] = message;
        }
    }
}