using RocamERP.Application.Interfaces;
using System.Web.Mvc;
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

        public ActionResult Index(string prefix = "", bool hideEmptyCidades = false)
        {
            var listVM = new List<EstadoViewModel>();
            var list = _estadoApplicationService.GetAll()
                .Where(e =>
                {
                    return hideEmptyCidades == true ? e.Cidades.Any() : true;
                })
                .Where(e => e.Nome.ToLower().Contains(prefix.ToLower()))
                .OrderByDescending(e => e.Cidades.Count());

            Mapper.Map(list, listVM);
            return View(listVM);
        }
    }
}
