using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces.ClienteRepository;
using RocamERP.Domain.ServiceInterfaces.ClienteServices;

namespace RocamERP.Services.Services.ClienteServices
{
    public class ClientePessoaJuridicaService : BaseService<ClientePessoaJuridica>, IClientePessoaJuridicaService
    {
        private readonly IClientePessoaJuridicaRepository _clienteRepository;

        public ClientePessoaJuridicaService(IClientePessoaJuridicaRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
