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
    public class ContatosController : Controller
    {
        private readonly IContatoApplicationService _contatoApplicationService;

        public ContatosController(IContatoApplicationService contatoApplicationService)
        {
            _contatoApplicationService = contatoApplicationService;
        }

        public ActionResult Index()
        {
            var contatos = _contatoApplicationService.GetAll();
            var contatosVM = new List<ContatoViewModel>();

            Mapper.Map(contatos, contatosVM);

            return View(contatosVM.OrderBy(c => c.PessoaId));
        }

        public ActionResult Details(int id)
        {
            var contato = _contatoApplicationService.Get(id);
            var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

            return View(contatoVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContatoViewModel model)
        {
            var contatoVM = Mapper.Map<ContatoViewModel, Contato>(model);
            _contatoApplicationService.Add(contatoVM);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var contato = _contatoApplicationService.Get(id);
            var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

            return View(contatoVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contato = Mapper.Map<ContatoViewModel, Contato>(model);
                _contatoApplicationService.Update(contato);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var contato = _contatoApplicationService.Get(id);
            var contatoVM = Mapper.Map<Contato, ContatoViewModel>(contato);

            return View(contatoVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, ContatoViewModel model)
        {
            _contatoApplicationService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
