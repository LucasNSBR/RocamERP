using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoApplicationService _enderecoApplicationService;

        public EnderecoController(IEnderecoApplicationService enderecoApplicationService)
        {
            _enderecoApplicationService = enderecoApplicationService;
        }

        public ActionResult Index()
        {
            try
            {
                var enderecos = _enderecoApplicationService.Get();
                var enderecosVM = new List<EnderecoViewModel>();

                Mapper.Map(enderecos, enderecosVM);

                return View(enderecosVM.OrderBy(c => c.Pessoa));
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
                var endereco = _enderecoApplicationService.Get(id);
                var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

                return View(enderecoVM);
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
        public ActionResult Create(EnderecoViewModel model)
        {
            try
            {
                var enderecoVM = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Add(enderecoVM);

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
                var endereco = _enderecoApplicationService.Get(id);
                var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

                return View(enderecoVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, EnderecoViewModel model)
        {
            try
            {
                var endereco = Mapper.Map<EnderecoViewModel, Endereco>(model);
                _enderecoApplicationService.Update(endereco);

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
                var endereco = _enderecoApplicationService.Get(id);
                var enderecoVM = Mapper.Map<Endereco, EnderecoViewModel>(endereco);

                return View(enderecoVM);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, EnderecoViewModel model)
        {
            try
            {
                _enderecoApplicationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
