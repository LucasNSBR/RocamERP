using System;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository) : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public Cidade Get(string id)
        {
            return _cidadeRepository.Get(id);
        }

        public void Delete(string id)
        {
            _cidadeRepository.Delete(id);
        }

    }
}
