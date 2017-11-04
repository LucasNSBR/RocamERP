
using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoApplicationService _contatoApplicationService;

        public ContatoController(IContatoApplicationService contatoApplicationService)
        {
            _contatoApplicationService = contatoApplicationService;
        }
        
        public ActionResult Index()
        {
            try
            {
                var contatos = _contatoApplicationService.Get();
                var contatosVM = new List<ContatoViewModel>();

                Mapper.Map(contatos, contatosVM);

                return View(contatosVM.OrderBy(c => c.PessoaId));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var contato = _contatoApplicationService.Get(id);
                var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

                return View(contatoVM);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContatoViewModel model)
        {
            try
            {
                var contatoVM = Mapper.Map<ContatoViewModel, Contato>(model);
                _contatoApplicationService.Add(contatoVM);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var contato = _contatoApplicationService.Get(id);
                var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

                return View(contatoVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, ContatoViewModel model)
        {
            try
            {
                var contato = Mapper.Map<ContatoViewModel, Contato>(model);
                _contatoApplicationService.Update(contato);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var contato = _contatoApplicationService.Get(id);
                var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

                return View(contatoVM);
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult Delete(int id, ContatoViewModel model)
        {
            try
            {
                _contatoApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
