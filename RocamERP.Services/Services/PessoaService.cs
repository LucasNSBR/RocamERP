using System;
using System.Collections.Generic;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository; 

        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
    }
}
