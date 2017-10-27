using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces.ClienteRepository;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Services.Services.ClienteServices
{
    public class ClientePessoaFisicaService : BaseService<ClientePessoaFisica>, IClientePessoaFisicaService
    {
        private readonly IClientePessoaFisicaRepository _clienteRepository;

        public ClientePessoaFisicaService(IClientePessoaFisicaRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
