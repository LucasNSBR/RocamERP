using RocamERP.Application.Interfaces.ClienteApplicationService;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Application
{
    public class ClienteApplicationService : BaseApplicationService<Cliente>, IClienteApplicationService
    {
        private readonly IClienteService _clienteService;

        public ClienteApplicationService(IClienteService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }
    }
}
