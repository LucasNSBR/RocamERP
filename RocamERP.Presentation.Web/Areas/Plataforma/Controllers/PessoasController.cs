using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class PessoasController : Controller
    {
        IPessoaApplicationService _pessoaApplicationService;

        public PessoasController(IPessoaApplicationService clienteApplicationService)
        {
            _pessoaApplicationService = clienteApplicationService;
        }

        public ActionResult Index(string filter = "")
        {
            try
            {
                var pessoas = _pessoaApplicationService.Get(filter);
                var pessoasVM = new List<PessoaViewModel>();
                
                foreach (var pessoa in pessoas)
                {
                    pessoasVM.Add(Mapper.Map<Pessoa, PessoaViewModel>(pessoa));
                }

                return View(pessoasVM);
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var cliente = _pessoaApplicationService.Get(id);
                var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

                return View(clienteVM);
            }
            catch
            {
                throw;
            }
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
            ViewBag.TipoCadastroEstadual = new SelectList(Enum.GetNames(typeof(TipoCadastroEstadual)), model.CadastroEstadual.TipoCadastroEstadual);
            ViewBag.TipoCadastroNacional = new SelectList(Enum.GetNames(typeof(TipoCadastroNacional)), model.CadastroEstadual.TipoCadastroEstadual);

            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                    _pessoaApplicationService.Add(pessoa);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var cliente = _pessoaApplicationService.Get(id);
                var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);

                return View(clienteVM);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                    _pessoaApplicationService.Update(pessoa);

                    return RedirectToAction("Index");
                }

                return View(model);
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
                var cliente = _pessoaApplicationService.Get(id);
                var clienteVM = Mapper.Map<Pessoa, PessoaViewModel>(cliente);
                return View(clienteVM);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, PessoaViewModel model)
        {
            try
            {
                _pessoaApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult ValidateCadastroEstadual(string value)
        {
            var result = _pessoaApplicationService.Get().Any(p => {
                if (p.CadastroEstadual != null && p.CadastroEstadual.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ValidateCadastroNacional(string value)
        {
            var result = _pessoaApplicationService.Get().Any(p => {
                if (p.CadastroEstadual != null && p.CadastroNacional.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
