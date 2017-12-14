using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.CrossCutting.Extensions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [Authorize]
    [ExtendedHandleError()]
    public class CidadesController : Controller
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;
        private readonly IPessoaApplicationService _pessoaApplicationService;

        private ISpecification<Cidade> _cidadeNomeSpecification;
        private ISpecification<Cidade> _cidadePessoasSpecification;
        private ISpecification<Cidade> _cidadeEstadoIdSpecification;
         
        private IEnumerable<SelectListItem> _estados
        {
            get
            {
                if (_estadoApplicationService != null)
                    return _estadoApplicationService.GetAll().ToSelectItemList(e => e.Nome, e => e.EstadoId);

                throw new Exception();
            }
        }

        private IEnumerable<SelectListItem> _pessoas
        {
            get
            {
                if (_pessoaApplicationService != null)
                    return _pessoaApplicationService.GetAll().ToSelectItemList(p => p.Nome, p => p.PessoaId);

                throw new Exception();
            }
        }

        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService, IPessoaApplicationService pessoaApplicationService)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
            _pessoaApplicationService = pessoaApplicationService;
        }

        public ActionResult Index(int? estadoId, string prefix = "", bool hideEmptyPessoas = false)
        {
            _cidadeNomeSpecification = new CidadeNomeSpecification(prefix);
            _cidadePessoasSpecification = new CidadePessoasSpecification(hideEmptyPessoas);
            _cidadeEstadoIdSpecification = new CidadeEstadoIdSpecification(estadoId);

            var cidadesVM = new List<CidadeViewModel>();
            var cidades = _cidadeApplicationService.GetAll(_cidadeNomeSpecification.And(_cidadePessoasSpecification))
                .OrderBy(c => c.EstadoId)
                .ThenBy(c => c.Nome);

            Mapper.Map(cidades, cidadesVM);

            cidadesVM.ForEach(c => c.PessoasCidadeCount = _pessoaApplicationService.GetAll().Count(e => e.Enderecos.Any(en => en.CidadeId == c.CidadeId)));

            return View(new IndexCidadeViewModel()
            {
                Cidades = cidadesVM,
                EstadosList = _estados,
            });
        }

        public ActionResult Create()
        {
            CidadeViewModel cidadeVM = new CidadeViewModel()
            {
                EstadosList = _estados,
            };

            return View(cidadeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Add(cidade);

                return RedirectToAction("Index");
            }

            model.EstadosList = _estados;
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            cidadeVM.EstadosList = _estados;
            return View(cidadeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Update(cidade);

                return RedirectToAction("Index");
            }

            model.EstadosList = _estados;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CidadeViewModel model)
        {
            _cidadeApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
