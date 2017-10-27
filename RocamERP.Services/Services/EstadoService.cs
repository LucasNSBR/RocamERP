using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository; 

        public EstadoService(IEstadoRepository estadoRepository) : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
    }
}
