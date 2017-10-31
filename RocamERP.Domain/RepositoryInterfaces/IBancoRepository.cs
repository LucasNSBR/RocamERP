using RocamERP.Domain.Models;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface IBancoRepository : IBaseRepository<Banco>
    {
        Banco Get(string id);
        void Delete(string id);
    }
}
