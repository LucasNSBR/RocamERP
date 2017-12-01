using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.CrossCutting.Extensions;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class EnderecosController : Controller
    {
        private readonly IEnderecoApplicationService _enderecoApplicationService;
        private readonly ICidadeApplicationService _cidadeApplicationService;

        private IEnumerable<SelectListItem> _cidades
        {
            get
            {
                if (_cidadeApplicationService != null)
                    return _cidadeApplicationService.GetAll().ToSelectItemList(c => c.Nome, c => c.CidadeId);

                throw new Exception();
            }
        }

        public EnderecosController(IEnderecoApplicationService enderecoApplicationService, ICidadeApplicationService cidadeApplicationService)
        {
            _enderecoApplicationService = enderecoApplicationService;
            _cidadeApplicationService = cidadeApplicationService;
        }

        public ActionResult Details(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        public ActionResult Create(int id)
        {
            var EnderecoVM = new EnderecoViewModel()
            {
                PessoaId = id,
                CidadesList = _cidades,
            };

            return View(EnderecoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enderecoVM = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Add(enderecoVM);

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endereco = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Update(endereco);

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EnderecoViewModel model)
        {
            _enderecoApplicationService.Delete(id);
            return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
        }

        #region Validators
        public ActionResult ValidateCEP(string CEP, string initialCEPValue = null)
        {
            if (_enderecoApplicationService.GetAll().Any(e => e.CEP == CEP))
            {
                if (initialCEPValue != null && CEP == initialCEPValue)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

