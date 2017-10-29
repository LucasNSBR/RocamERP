using RocamERP.Domain.Models;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface ICidadeService : IBaseService<Cidade>
    {
        Cidade Get(string id);
        void Delete(string id);
    }
}
