using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class EstadoApplicationService : BaseApplicationService<Estado>, IEstadoApplicationService
    {
        private readonly IEstadoService _estadoService;

        public EstadoApplicationService(IEstadoService estadoService) : base(estadoService)
        {
            _estadoService = estadoService;
        }
    }
}
