using AutoMapper;
using RocamERP.Application.Interfaces;
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
    public class PessoasController : Controller
    {
        IPessoaApplicationService _pessoaApplicationService;

        public PessoasController(IPessoaApplicationService clienteApplicationService)
        {
            _pessoaApplicationService = clienteApplicationService;
        }

        public ActionResult Index(string prefix = "", bool hideEmptyCheques = false)
        {
            var pessoasVM = new List<PessoaViewModel>();
            var pessoas = _pessoaApplicationService.GetAll()
                .Where(p =>
                {
                    return hideEmptyCheques == true ? p.Cheques.Any() : true;
                })
                .Where(p => p.Nome.ToLower().Contains(prefix.ToLower()))
                .OrderBy(p => p.Nome);

            Mapper.Map(pessoas, pessoasVM);
            return View(pessoasVM);
        }

        public ActionResult Details(int id)
        {
            var cliente = _pessoaApplicationService.Get(id);
            var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

            return View(clienteVM);
        }

        public ActionResult Create()
        {
            ViewBag.TipoCadastroEstadual = new SelectList(Enum.GetNames(typeof(TipoCadastroEstadual)));
            ViewBag.TipoCadastroNacional = new SelectList(Enum.GetNames(typeof(TipoCadastroNacional)));
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                _pessoaApplicationService.Add(pessoa);

                return RedirectToAction("Index");
            }

            ViewBag.TipoCadastroEstadual = new SelectList(Enum.GetNames(typeof(TipoCadastroEstadual)), model.CadastroEstadual.TipoCadastroEstadual);
            ViewBag.TipoCadastroNacional = new SelectList(Enum.GetNames(typeof(TipoCadastroNacional)), model.CadastroEstadual.TipoCadastroEstadual);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _pessoaApplicationService.Get(id);
            var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

            return View(clienteVM);
        }

        [HttpPost]
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
        public ActionResult Delete(int id, PessoaViewModel model)
        {
            _pessoaApplicationService.Delete(id);
            return RedirectToAction("Index");
        }

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
    }
}
