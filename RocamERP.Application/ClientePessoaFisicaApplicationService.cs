using RocamERP.Application.Interfaces.Cliente;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Application
{
    public class ClientePessoaFisicaApplicationService : BaseApplicationService<ClientePessoaFisica>, IClientePessoaFisicaApplicationService
    {
        private readonly IClientePessoaFisicaService _clientePessoaFisicaService;

        public ClientePessoaFisicaApplicationService(IClientePessoaFisicaService clientePessoaFisicaService) : base(clientePessoaFisicaService)
        {
            _clientePessoaFisicaService = clientePessoaFisicaService;
        }
    }
}
