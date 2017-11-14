using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class BancosController : Controller
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public ActionResult Index()
        {
            var bancos = _bancoApplicationService.GetAll();
            var bancosVM = new List<BancoViewModel>();

            foreach (var banco in bancos)
            {
                bancosVM.Add(Mapper.Map<Banco, BancoViewModel>(banco));
            }

            return View(bancosVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Add(banco);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Edit(string id)
        {
            var banco = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(banco);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Edit(string id, BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Update(banco);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(string id)
        {
            var model = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(model);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Delete(string id, BancoViewModel model)
        {
            _bancoApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

