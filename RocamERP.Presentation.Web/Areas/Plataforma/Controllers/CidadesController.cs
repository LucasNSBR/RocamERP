using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using RocamERP.Presentation.Web.Exceptions;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class CidadesController : Controller
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;

        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index(string prefix = "", string estado = "")
        {
            ViewBag.Estado = new SelectList(_estadoApplicationService.GetAll());

            var listVM = new List<CidadeViewModel>();
            var list = _cidadeApplicationService.GetAll()
                .Where(c => c.Nome.ToLower().Contains(prefix.ToLower()))
                .Where(c =>
                {
                    if (!string.IsNullOrWhiteSpace(estado))
                    {
                        return c.EstadoId == estado;
                    }

                    return true;
                })
                .OrderBy(c => c.Nome);

            Mapper.Map(list, listVM);
            return View(listVM.OrderBy(c => c.EstadoId));
        }

        public ActionResult Details(string id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(_estadoApplicationService.GetAll(), "Nome", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Add(cidade);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Edit(string id, CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Update(cidade);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(string id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Delete(string id, CidadeViewModel model)
        {
            _cidadeApplicationService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult ValidateCEP(string CEP)
        {
            var cidades = _cidadeApplicationService.GetAll();
            var exists = !cidades.ToList().Any(c => c.CEP == CEP);

            return Json(exists, JsonRequestBehavior.AllowGet);
        }
    }
}
