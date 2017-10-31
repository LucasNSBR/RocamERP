using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;

namespace RocamERP.Infra.Data.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public Estado Get(string id)
        {
            return dbContext.Estados.Find(id);
        }

        public void Delete(string id)
        {
            var estado = dbContext.Estados.Find(id);
            dbContext.Estados.Remove(estado);
            dbContext.SaveChanges();
        }
    }
}
