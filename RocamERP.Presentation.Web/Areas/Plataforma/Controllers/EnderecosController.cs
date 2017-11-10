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
    public class EnderecosController : Controller
    {
        private readonly IEnderecoApplicationService _enderecoApplicationService;
        private readonly ICidadeApplicationService _cidadeApplicationService;

        public EnderecosController(IEnderecoApplicationService enderecoApplicationService, ICidadeApplicationService cidadeApplicationService)
        {
            _enderecoApplicationService = enderecoApplicationService;
            _cidadeApplicationService = cidadeApplicationService;
        }

        public ActionResult Index()
        {
            var enderecos = _enderecoApplicationService.GetAll();
            var enderecosVM = new List<EnderecoViewModel>();

            Mapper.Map(enderecos, enderecosVM);
            return View(enderecosVM.OrderBy(c => c.Pessoa));
        }

        public ActionResult Details(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        public ActionResult Create(int id)
        {
            ViewBag.TipoEndereco = new SelectList(Enum.GetValues(typeof(ViewModels.TipoEndereco)));
            ViewBag.CidadeId = new SelectList(_cidadeApplicationService.GetAll());
            ViewBag.PessoaId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enderecoVM = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Add(enderecoVM);

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
            }

            ViewBag.TipoEndereco = new SelectList(Enum.GetValues(typeof(ViewModels.TipoEndereco)), model.TipoEndereco);
            ViewBag.CidadeId = new SelectList(_cidadeApplicationService.GetAll(), model.CidadeId);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endereco = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Update(endereco);

                return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
            }

            ViewBag.TipoEndereco = new SelectList(Enum.GetValues(typeof(ViewModels.TipoEndereco)), model.TipoEndereco);
            ViewBag.CidadeId = new SelectList(_cidadeApplicationService.GetAll(), model.CidadeId);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var endereco = _enderecoApplicationService.Get(id);
            var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

            return View(enderecoVM);
        }

        [HttpPost]
        public ActionResult Delete(int id, EnderecoViewModel model)
        {
            _enderecoApplicationService.Delete(id);
            return RedirectToAction("Details", "Pessoas", new { id = model.PessoaId });
        }
    }
}
