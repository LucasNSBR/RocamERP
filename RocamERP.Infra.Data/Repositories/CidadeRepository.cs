using System.Collections.Generic;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using System.Linq;

namespace RocamERP.Infra.Data.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public IEnumerable<Cidade> GetByName(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                return dbContext.Cidades.ToList();
            else
                return dbContext.Cidades
                    .Where(c => c.Nome.ToLower()
                    .Contains(prefix.ToLower()))
                    .ToList();
        }
    }
}
