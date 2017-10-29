using RocamERP.Domain.Models;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface IEstadoRepository : IBaseRepository<Estado>
    {
        Estado Get(string id);
        void Delete(string id);
    }
}
