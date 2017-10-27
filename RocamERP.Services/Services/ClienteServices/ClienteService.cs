using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.RepositoryInterfaces.ClienteRepository;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Services.Services.ClienteServices
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository; 

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
