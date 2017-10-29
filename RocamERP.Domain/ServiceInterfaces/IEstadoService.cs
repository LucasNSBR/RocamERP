using RocamERP.Domain.Models;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface IEstadoService : IBaseService<Estado>
    {
        Estado Get(string id);
        void Delete(string id);
    }
}
