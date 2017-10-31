using RocamERP.Domain.Models;

namespace RocamERP.Application.Interfaces
{
    public interface IBancoApplicationService : IBaseApplicationService<Banco>
    {
        Banco Get(string id);
        void Delete(string id);
    }
}
