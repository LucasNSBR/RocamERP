using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;

        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index()
        {
            var list = _cidadeApplicationService.Get();
            var listVM = new List<CidadeViewModel>();

            foreach (Cidade cidade in list)
            {
                listVM.Add(Mapper.Map<Cidade, CidadeViewModel>(cidade));
            }

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
            ViewBag.EstadoId = new SelectList(_estadoApplicationService.Get(), "Nome", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CidadeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                    _cidadeApplicationService.Add(cidade);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                    _cidadeApplicationService.Update(cidade);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
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
            try
            {
                _cidadeApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ValidateCEP(string CEP)
        {
            var cidades = _cidadeApplicationService.Get();
            var exists = !cidades.ToList().Any(c => c.CEP == CEP);

            return Json(exists, JsonRequestBehavior.AllowGet);
        }
    }
}
