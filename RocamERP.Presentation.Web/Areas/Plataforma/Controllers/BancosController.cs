using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class BancosController : BaseController
    {
        private readonly IBancoApplicationService _bancoApplicationService;

        public BancosController(IBancoApplicationService bancoApplicationService)
        {
            _bancoApplicationService = bancoApplicationService;
        }

        public ActionResult Index(string prefix = "", bool? hideEmptyCheques = false)
        {
            var bancosVM = new List<BancoViewModel>();
            var bancos = _bancoApplicationService.GetAll()
                .Where(b =>
                {
                    return hideEmptyCheques == true ? b.Cheques.Any() : true;
                })
                .Where(b => b.Nome.ToLower().Contains(prefix.ToLower()))
                .OrderByDescending(b => b.Cheques.Count)
                .ThenBy(b => b.Nome);

            Mapper.Map(bancos, bancosVM);
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


        public ActionResult Edit(int id)
        {
            var banco = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(banco);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var banco = Mapper.Map<BancoViewModel, Banco>(model);
                _bancoApplicationService.Update(banco);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _bancoApplicationService.Get(id);
            var bancoVM = Mapper.Map<Banco, BancoViewModel>(model);

            return View(bancoVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, BancoViewModel model)
        {
            _bancoApplicationService.Delete(id);
            return RedirectToAction("Index");
        }

        #region Validators
        public ActionResult ValidateBancoNome(string nome, string initialNomeValue = "")
        {
            if (_bancoApplicationService.GetAll().Any(b => b.Nome == nome))
            {
                if (initialNomeValue != null && initialNomeValue == nome)
                    return Json(true, JsonRequestBehavior.AllowGet);

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateCodigoBanco(int codigoCompensacao, int? initialCodigoCompensacaoValue)
        {
            if (_bancoApplicationService.GetAll().Any(b => b.CodigoCompensacao == codigoCompensacao))
            {
                if (initialCodigoCompensacaoValue != null && codigoCompensacao == initialCodigoCompensacaoValue)
                    return Json(true, JsonRequestBehavior.AllowGet);

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

