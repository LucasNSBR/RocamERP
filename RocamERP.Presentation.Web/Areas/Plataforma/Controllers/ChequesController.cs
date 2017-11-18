using AutoMapper;
using RocamERP.Application.Interfaces;
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

        public ActionResult Index(int? pessoaId, string prefix = "")
        {
            var chequesVM = new List<ChequeViewModel>();
            var cheques = _chequeApplicationService.GetAll()
                .Where(c =>
                {
                    if (pessoaId != null)
                        return c.PessoaId == pessoaId;
                    else
                        return true;
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
            var bancosVM = Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoViewModel>>(bancos);
            var pessoasVM = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(pessoas);
            
            ChequeViewModel chequeVM = new ChequeViewModel();
            chequeVM.LoadBancosList(bancosVM);
            chequeVM.LoadPessoasList(pessoasVM);
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
            var bancos = _bancoApplicationService.GetAll();
            var pessoas = _pessoaApplicationService.GetAll();
            var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);
            var bancosVM = Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoViewModel>>(bancos);
            var pessoasVM = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(pessoas);

            chequeVM.LoadBancosList(bancosVM);
            chequeVM.LoadPessoasList(pessoasVM);
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
