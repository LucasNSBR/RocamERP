using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
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

        public ActionResult Index()
        {
            try
            {
                var pessoas = _pessoaApplicationService.Get();
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            try
            {
                var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                _pessoaApplicationService.Add(pessoa);

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
                var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(model);
                _pessoaApplicationService.Update(pessoa);

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
    }
}
