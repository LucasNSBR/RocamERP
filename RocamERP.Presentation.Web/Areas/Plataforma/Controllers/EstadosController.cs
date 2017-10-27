using RocamERP.Application;
using RocamERP.Domain.ServiceInterfaces;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class EstadosController : Controller
    {
        private EstadoApplicationService _estadoApplicationService; 

        public EstadosController(IEstadoService estadoApplicationService)
        {
            _estadoApplicationService = new EstadoApplicationService(estadoApplicationService);
        }

        public ActionResult Index()
        {
            _estadoApplicationService.Get();

            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataforma/Estados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plataforma/Estados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plataforma/Estados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plataforma/Estados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plataforma/Estados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
