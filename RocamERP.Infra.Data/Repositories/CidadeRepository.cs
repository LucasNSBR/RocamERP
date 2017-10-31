using System;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;

namespace RocamERP.Infra.Data.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public Cidade Get(string id)
        {
            return dbContext.Cidades.Find(id);
        }

        public void Delete(string id)
        {
            var cidade = dbContext.Cidades.Find(id);
            dbContext.Cidades.Remove(cidade);
            dbContext.SaveChanges();
        }
    }
}
