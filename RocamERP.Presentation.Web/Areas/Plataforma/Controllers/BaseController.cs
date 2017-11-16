using RocamERP.CrossCutting.MessagerInterfaces;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class BaseController : Controller
    {
        protected void SendMessage(string message)
        {
            TempData["Message"] = message;
        }
    }
}