using System.Collections.Generic;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class PessoaApplicationService : BaseApplicationService<Pessoa>, IPessoaApplicationService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaApplicationService(IPessoaService pessoaService) : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }
    }
}
