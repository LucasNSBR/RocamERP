using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;

namespace RocamERP.Infra.Data.Repositories
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository
    {
        public Banco Get(string id)
        {
            return dbContext.Bancos.Find(id);
        }

        public void Delete(string id)
        {
            var banco = dbContext.Bancos.Find(id);
            dbContext.Bancos.Remove(banco);
        }

    }
}
