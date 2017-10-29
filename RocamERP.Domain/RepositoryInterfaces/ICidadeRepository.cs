using RocamERP.Domain.Models;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Cidade Get(string id);
        void Delete(string id);
    }
}
