using System;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Documentation()
        {
            return View();
        }

        public ActionResult BugReport()
        {
            return View();
        }
    }
}