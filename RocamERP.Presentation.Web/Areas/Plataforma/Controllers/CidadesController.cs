using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.Extensions;
using RocamERP.Presentation.Web.ViewModels.CidadeViewModels;
using System;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class CidadesController : Controller
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;
        
        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index(int? estadoId, string prefix = "", bool hideEmptyEnderecos = false)
        {
            var cidadesVM = new List<CidadeViewModel>();
            var cidades = _cidadeApplicationService.GetByName(prefix)
                .Where(c =>
                {
                    return estadoId != null ? c.EstadoId == estadoId : true;
                })
                .Where(c =>
                {
                    return hideEmptyEnderecos == true ? c.Enderecos.Any() : true;
                })
                .OrderBy(c => c.EstadoId)
                .ThenBy(c => c.Nome);

            Mapper.Map(cidades, cidadesVM);
            
            return View(new IndexCidadeViewModel()
            {
                CidadeViewModel = cidadesVM,
                EstadosList = _estadoApplicationService.GetAll().ToSelectItemList(model => model.Nome, model => model.EstadoId.ToString())
            });
        }

        public ActionResult Details(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(new DetailsCidadeViewModel()
            {
                CidadeViewModel = cidadeVM,
                Enderecos = cidadeVM.Enderecos.GroupBy(k => new KeyValuePair<int, string>(k.PessoaId, k.Pessoa.Nome))
            });
        }

        public ActionResult Create()
        {
            CidadeViewModel cidadeVM = new CidadeViewModel();
            cidadeVM.EstadosList = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApplicationService.GetAll())
                .ToSelectItemList(model => model.Nome, model => model.EstadoId.ToString());
            
            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Create(CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Add(cidade);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);
            cidadeVM.EstadosList = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApplicationService.GetAll())
                .ToSelectItemList(model => model.Nome, model => model.EstadoId.ToString());
           
           
            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Edit(string id, CidadeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cidade = Mapper.Map<CidadeViewModel, Cidade>(model);
                _cidadeApplicationService.Update(cidade);

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var cidade = _cidadeApplicationService.Get(id);
            var cidadeVM = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, CidadeViewModel model)
        {
            _cidadeApplicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
