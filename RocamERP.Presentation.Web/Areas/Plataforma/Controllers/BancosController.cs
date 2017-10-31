using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class BancosController : Controller 
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService) 
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public ActionResult Index()
        {
            try
            {
                var bancos = _bancoApplicationService.Get();
                var bancosVM = new List<BancoViewModel>();

                foreach (var banco in bancos)
                {
                    bancosVM.Add(Mapper.Map<Banco, BancoViewModel>(banco));
                }

                return View(bancosVM);
            }
            catch
            { 
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            id = Uri.UnescapeDataString(id);

            try
            {
                var banco = _bancoApplicationService.Get(id);
                var bancoVM = Mapper.Map<Banco, BancoViewModel>(banco);

                return View(bancoVM);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BancoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var banco = Mapper.Map<BancoViewModel, Banco>(model);
                    _bancoApplicationService.Add(banco);

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
            try
            {
                var banco = _bancoApplicationService.Get(id);
                var bancoVM = Mapper.Map<Banco, BancoViewModel>(banco);

                return View(bancoVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, BancoViewModel model)
        {
            try
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Update(banco);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                var model = _bancoApplicationService.Get(id);
                var bancoVM = Mapper.Map<Banco, BancoViewModel>(model);

                return View(bancoVM); 
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string id, BancoViewModel model)
        {
            try
            {
                _bancoApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
