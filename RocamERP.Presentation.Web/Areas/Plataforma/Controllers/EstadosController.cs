using RocamERP.Application.Interfaces;
using System.Web.Mvc;
using RocamERP.Presentation.Web.Mappers;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class EstadosController : Controller
    {
        private IEstadoApplicationService _estadoApplicationService; 

        public EstadosController(IEstadoApplicationService estadoApplicationService)
        {
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index()
        {
            var list = _estadoApplicationService.Get();
            var vmList = new List<EstadoViewModel>();

            foreach (Estado estado in list) {
                vmList.Add(AutoMapper.Mapper.Map<Estado, EstadoViewModel>(estado));
            }

            return View(vmList);
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
