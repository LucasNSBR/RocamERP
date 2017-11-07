using System;
using System.Collections.Generic;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using System.Linq;

namespace RocamERP.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public IEnumerable<Pessoa> Get(string prefix)
        {
            return dbContext.Pessoas.Where(p => p.Nome.Contains(prefix)).ToList();
        }
    }
}
