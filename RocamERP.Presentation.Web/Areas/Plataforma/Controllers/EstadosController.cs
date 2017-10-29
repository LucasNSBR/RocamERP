using RocamERP.Application.Interfaces;
using System.Web.Mvc;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using AutoMapper;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IEstadoApplicationService _estadoApplicationService; 

        public EstadosController(IEstadoApplicationService estadoApplicationService)
        {
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index()
        {
            var list = _estadoApplicationService.Get();
            var listVM = new List<EstadoViewModel>();

            foreach (Estado estado in list) {
                listVM.Add(Mapper.Map<Estado, EstadoViewModel>(estado));
            }

            return View(listVM);
        }

        public ActionResult Details(string id)
        {
            Estado estado = _estadoApplicationService.Get(id);
            var estadoVM = Mapper.Map<Estado, EstadoViewModel>(estado);

            return View(estadoVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EstadoViewModel model)
        {
            try
            {
                var estado = Mapper.Map<EstadoViewModel, Estado>(model);
                _estadoApplicationService.Add(estado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var estado = _estadoApplicationService.Get(id);
            var estadoVM = Mapper.Map<Estado, EstadoViewModel>(estado);

            return View(estadoVM);
        }

        [HttpPost]
        public ActionResult Edit(string id, EstadoViewModel model)
        {
            try
            {
                var estado = Mapper.Map<EstadoViewModel, Estado>(model);
                _estadoApplicationService.Update(estado);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var estado = _estadoApplicationService.Get(id);
            var estadoVM = Mapper.Map<Estado, EstadoViewModel>(estado);

            return View(estadoVM);
        }

        [HttpPost]
        public ActionResult Delete(string id, EstadoViewModel model)
        {
            try
            {
                _estadoApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
