using RocamERP.Application.Interfaces.ClienteApplicationService;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Application
{
    public class ClientePessoaJuridicaApplicationService : BaseApplicationService<ClientePessoaJuridica>, IClientePessoaJuridicaApplicationService
    {
        private readonly IClientePessoaJuridicaService _clientePessoaJuridicaService;

        public ClientePessoaJuridicaApplicationService(IClientePessoaJuridicaService clientePessoaJuridicaService) : base(clientePessoaJuridicaService)
        {
            _clientePessoaJuridicaService = clientePessoaJuridicaService;
        }
    }
}
