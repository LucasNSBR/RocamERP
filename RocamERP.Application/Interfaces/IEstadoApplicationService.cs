using RocamERP.Domain.Models;

namespace RocamERP.Application.Interfaces
{
    public interface IEstadoApplicationService : IBaseApplicationService<Estado>
    {
        Estado Get(string id);
        void Delete(string id);
    }
}
