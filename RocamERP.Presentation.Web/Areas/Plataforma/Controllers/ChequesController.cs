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

        public ChequesController(IChequeApplicationService chequeApplicationService)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        public ActionResult Index()
        {
            var cheques = _chequeApplicationService.GetAll();
            var chequesVM = new List<ChequeViewModel>();

            foreach (var cheque in cheques)
            {
                chequesVM.Add(Mapper.Map<Cheque, ChequeViewModel>(cheque));
            }

            return View(chequesVM.OrderBy(c => c.Pessoa));
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
