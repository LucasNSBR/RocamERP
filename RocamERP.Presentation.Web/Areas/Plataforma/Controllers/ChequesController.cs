using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.CrossCutting.Extensions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using RocamERP.Infra.Data.QuerySpecifications.BancoQuerySpecifications;
using RocamERP.Infra.Data.QuerySpecifications.ChequeQuerySpecifications;
using RocamERP.Infra.Data.QuerySpecifications.PessoaQuerySpecifications;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [Authorize]
    [ExtendedHandleError()]
    public class ChequesController : Controller
    {
        private readonly IChequeApplicationService _chequeApplicationService;
        private readonly IBancoApplicationService _bancoApplicationService;
        private readonly IPessoaApplicationService _pessoaApplicationService;

        private ISpecification<Cheque> _chequePessoaIdSpecification;
        private ISpecification<Cheque> _chequeBancoIdSpecification;
        private ISpecification<Cheque> _chequeNumeroSpecification;
        private ISpecification<Cheque> _chequeVencidoSpecification;

        public ChequesController(IChequeApplicationService chequeApplicationService, IBancoApplicationService bancoApplicationService, IPessoaApplicationService pessoaApplicationService)
        {
            _chequeApplicationService = chequeApplicationService;
            _bancoApplicationService = bancoApplicationService;
            _pessoaApplicationService = pessoaApplicationService;
        }

        public ActionResult Index(int? pessoaId, int? bancoId, string numeroCheque = "", bool vencidos = false)
        {
            _chequePessoaIdSpecification = new ChequePessoaIdSpecification(pessoaId);
            _chequeBancoIdSpecification = new ChequeBancoIdSpecification(bancoId);
            _chequeNumeroSpecification = new ChequeNumeroSpecification(numeroCheque);
            _chequeVencidoSpecification = new ChequeVencidoSpecification(vencidos);

            var chequesVM = new List<ChequeViewModel>();
            var cheques = _chequeApplicationService.GetAll(_chequeNumeroSpecification.And(_chequeBancoIdSpecification).And(_chequePessoaIdSpecification))
                .Where(c => _chequeVencidoSpecification.IsSatisfiedBy(c))
                .OrderBy(c => c.PessoaId);

            Mapper.Map(cheques, chequesVM);
            return View(chequesVM);
        }

        public ActionResult Details(int id)
        {
            var cheque = _chequeApplicationService.Get(id);
            var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

            return View(chequeVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChequeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cheque = Mapper.Map<ChequeViewModel, Cheque>(model);
                _chequeApplicationService.Add(cheque);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cheque = _chequeApplicationService.Get(id);
            var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

            return View(chequeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ChequeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cheque = Mapper.Map<ChequeViewModel, Cheque>(model);
                _chequeApplicationService.Update(cheque);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var cheque = _chequeApplicationService.Get(id);
            var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

            return View(chequeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ChequeViewModel model)
        {
            _chequeApplicationService.Delete(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetPessoas(string pessoaPrefix = "")
        {
            ISpecification<Pessoa> pessoaNomeSpecification = new PessoaNomeSpecification(pessoaPrefix);
            return PartialView("_PartialViews/_pessoasInformation", _pessoaApplicationService.GetAll(pessoaNomeSpecification));
        }

        public PartialViewResult GetBancos(string bancoPrefix = "")
        {
            ISpecification<Banco> bancoNomeSpecification = new BancoNomeSpecification(bancoPrefix);
            return PartialView("_PartialViews/_bancosInformation", _bancoApplicationService.GetAll(bancoNomeSpecification));
        }
    }
}
