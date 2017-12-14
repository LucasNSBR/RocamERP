using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.CrossCutting.Extensions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using RocamERP.Infra.Data.QuerySpecifications.PessoaQuerySpecifications;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels.PessoaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [Authorize]
    [ExtendedHandleError()]
    public class PessoasController : Controller
    {
        private readonly IPessoaApplicationService _pessoaApplicationService;
        private readonly ICidadeApplicationService _cidadeApplicationService;

        private ISpecification<Pessoa> _pessoaNomeSpecification;
        private ISpecification<Pessoa> _pessoaChequesSpecification;
        private ISpecification<Pessoa> _pessoaCidadeIdSpecification;

        private IEnumerable<SelectListItem> _cidades
        {
            get
            {
                if (_cidadeApplicationService != null)
                    return _cidadeApplicationService.GetAll().ToSelectItemList(c => c.Nome, c => c.CidadeId);

                throw new Exception();
            }
        }

        public PessoasController(IPessoaApplicationService clienteApplicationService, ICidadeApplicationService cidadeApplicationService)
        {
            _pessoaApplicationService = clienteApplicationService;
            _cidadeApplicationService = cidadeApplicationService;
        }

        public ActionResult Index(int? cidadeId, string prefix = "", bool hideEmptyCheques = false)
        {
            _pessoaNomeSpecification = new PessoaNomeSpecification(prefix);
            _pessoaChequesSpecification = new PessoaChequesSpecification(hideEmptyCheques);
            _pessoaCidadeIdSpecification = new PessoaCidadeIdSpecification(cidadeId);

            var pessoasVM = new List<PessoaViewModel>();

            var pessoas = _pessoaApplicationService.GetAll(_pessoaNomeSpecification
                .And(_pessoaChequesSpecification)
                .And(_pessoaCidadeIdSpecification))
                .OrderBy(p => p.Nome);

            Mapper.Map(pessoas, pessoasVM);

            return View(new IndexPessoaViewModel()
            {
                Pessoas = pessoasVM,
                CidadesList = _cidades
            });
        }

        public ActionResult Details(int id)
        {
            var cliente = _pessoaApplicationService.Get(id);
            var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

            return View(clienteVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                _pessoaApplicationService.Add(pessoa);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _pessoaApplicationService.Get(id);
            var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

            return View(clienteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                _pessoaApplicationService.Update(pessoa);

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _pessoaApplicationService.Get(id);
            var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

            return View(clienteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PessoaViewModel model)
        {
            _pessoaApplicationService.Delete(id);
            return RedirectToAction("Index");
        }

        #region Validators
        public JsonResult ValidateCadastroEstadual([Bind(Prefix = "CadastroEstadual.NumeroDocumento")]string value)
        {
            var exists = _pessoaApplicationService.GetAll().Any(p =>
            {
                if (p.CadastroEstadual != null && p.CadastroEstadual.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            return Json(!exists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateCadastroNacional([Bind(Prefix = "CadastroNacional.NumeroDocumento")]string value)
        {
            var exists = _pessoaApplicationService.GetAll().Any(p =>
            {
                if (p.CadastroNacional != null && p.CadastroNacional.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            return Json(!exists, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
