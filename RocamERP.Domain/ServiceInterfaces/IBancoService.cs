using RocamERP.Domain.Models;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface IBancoService : IBaseService<Banco> 
    {
        Banco Get(string id);
        void Delete(string id);
    }
}
