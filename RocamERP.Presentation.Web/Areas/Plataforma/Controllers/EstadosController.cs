using RocamERP.Application.Interfaces;
using System.Web.Mvc;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using AutoMapper;
using RocamERP.Presentation.Web.Exceptions;
using System.Linq;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class EstadosController : Controller
    {
        private readonly IEstadoApplicationService _estadoApplicationService;

        public EstadosController(IEstadoApplicationService estadoApplicationService)
        {
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index(string prefix = "")
        {
            var list = _estadoApplicationService.GetAll()
                .Where(e => e.Nome.ToLower().Contains(prefix.ToLower()))
                .OrderByDescending(e => e.Cidades.Count());

            var listVM = new List<EstadoViewModel>();
            Mapper.Map(list, listVM);

            return View(listVM);
        }
    }
}
