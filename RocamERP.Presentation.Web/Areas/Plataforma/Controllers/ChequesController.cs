using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class ChequesController : Controller
    {
        private readonly IChequeApplicationService _chequeApplicationService;

        public ChequesController(IChequeApplicationService chequeApplicationService)
        {
            _chequeApplicationService = chequeApplicationService;
        }

        public ActionResult Index()
        {
            try
            {
                var cheques = _chequeApplicationService.Get();
                var chequesVM = new List<ChequeViewModel>();

                foreach (var cheque in cheques)
                {
                    chequesVM.Add(Mapper.Map<Cheque, ChequeViewModel>(cheque));
                }

                return View(chequesVM.OrderBy(c => c.Pessoa));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var cheque = _chequeApplicationService.Get(id);
                var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

                return View(chequeVM);
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
        public ActionResult Create(ChequeViewModel model)
        {
            try
            {
                var cheque = Mapper.Map<ChequeViewModel, Cheque>(model);
                _chequeApplicationService.Add(cheque);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var cheque = _chequeApplicationService.Get(id);
                var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

                return View(chequeVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, ChequeViewModel model)
        {
            try
            {
                var cheque = Mapper.Map<ChequeViewModel, Cheque>(model);
                _chequeApplicationService.Update(cheque);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var cheque = _chequeApplicationService.Get(id);
                var chequeVM = Mapper.Map<Cheque, ChequeViewModel>(cheque);

                return View(chequeVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, ChequeViewModel model)
        {
            try
            {
                _chequeApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
