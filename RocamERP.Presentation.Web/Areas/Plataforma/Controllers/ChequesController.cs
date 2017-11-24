using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.CrossCutting.Extensions;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class ChequesController : Controller
    {
        private readonly IChequeApplicationService _chequeApplicationService;
        private readonly IBancoApplicationService _bancoApplicationService;
        private readonly IPessoaApplicationService _pessoaApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService, IBancoApplicationService bancoApplicationService, IPessoaApplicationService pessoaApplicationService)
        {
            _chequeApplicationService = chequeApplicationService;
            _bancoApplicationService = bancoApplicationService;
            _pessoaApplicationService = pessoaApplicationService;
        }

        public ActionResult Index(int? pessoaId, int? bancoId, string prefix = "")
        {
            var chequesVM = new List<ChequeViewModel>();
            var cheques = _chequeApplicationService.GetAll()
                .Where(c =>
                {
                    return pessoaId != null ? c.PessoaId == pessoaId : true;
                })
                .Where(c =>
                {
                    return bancoId != null ? c.BancoId == bancoId : true; 
                })
                .Where(c => c.NumeroCheque.ToLower().Contains(prefix.ToLower()))
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
            var bancos = _bancoApplicationService.GetAll();
            var pessoas = _pessoaApplicationService.GetAll();

            ChequeViewModel chequeVM = new ChequeViewModel()
            {
                BancosList = bancos.ToSelectItemList(b => b.Nome, b => b.BancoId),
                PessoasList = pessoas.ToSelectItemList(p => p.Nome, p => p.PessoaId),
            };

            return View(chequeVM);
        }

        [HttpPost]
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

            chequeVM.BancosList = _bancoApplicationService.GetAll().ToSelectItemList(b => b.Nome, b => b.BancoId);
            chequeVM.PessoasList = _pessoaApplicationService.GetAll().ToSelectItemList(p => p.Nome, p => p.PessoaId);
            return View(chequeVM);
        }

        [HttpPost]
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
        public ActionResult Delete(int id, ChequeViewModel model)
        {
            _chequeApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
