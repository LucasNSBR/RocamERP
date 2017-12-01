using AutoMapper;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using RocamERP.Infra.Data.QuerySpecifications.EstadoQuerySpecifications;
using RocamERP.Presentation.Web.Exceptions;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    [ExtendedHandleError()]
    public class EstadosController : Controller
    {
        private readonly IEstadoApplicationService _estadoApplicationService;

        private ISpecification<Estado> _estadoNomeSpecification;
        private ISpecification<Estado> _estadoCidadesSpecification;


        public EstadosController(IEstadoApplicationService estadoApplicationService)
        {
            _estadoApplicationService = estadoApplicationService;
        }

        public ActionResult Index(string prefix = "", bool hideEmptyCidades = false)
        {
            _estadoNomeSpecification = new EstadoNomeSpecification(prefix);
            _estadoCidadesSpecification = new EstadoCidadesSpecification(hideEmptyCidades);

            var listVM = new List<EstadoViewModel>();
            var list = _estadoApplicationService.GetAll(_estadoNomeSpecification.And(_estadoCidadesSpecification))
                .OrderByDescending(e => e.Cidades.Count());

            Mapper.Map(list, listVM);
            return View(listVM);
        }
    }
}
