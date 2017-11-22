using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class ContatosController : Controller
    {
        private readonly IContatoApplicationService _contatoApplicationService;
        private readonly IPessoaApplicationService _pessoaApplicationService;

        public ContatosController(IContatoApplicationService contatoApplicationService, IPessoaApplicationService pessoaApplicationService)
        {
            _contatoApplicationService = contatoApplicationService;
            _pessoaApplicationService = pessoaApplicationService;
        }

        public ActionResult Create(int id)
        {
            var pessoa = _pessoaApplicationService.Get(id);
            var pessoaVM = Mapper.Map<Pessoa, PessoaViewModel>(pessoa);


            ContatoViewModel contatoVM = new ContatoViewModel()
            {
                PessoaId = id,
                Pessoa = pessoaVM,
            };

            return View(contatoVM);
        }

        [HttpPost]
        public ActionResult Create(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contatoVM = Mapper.Map<ContatoViewModel, Contato>(model);
                _contatoApplicationService.Add(contatoVM);

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
            }

            return View(model);
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

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
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
            return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
        }
    }
}
