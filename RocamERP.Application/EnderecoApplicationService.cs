using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;
using RocamERP.Services.Services;

namespace RocamERP.Application
{
    public class EnderecoApplicationService : BaseApplicationService<Endereco>, IEnderecoApplicationService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoApplicationService(IEnderecoService enderecoService) : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
    }
}
