using RocamERP.Domain.Models;

namespace RocamERP.Application.Interfaces
{
    public interface ICidadeApplicationService : IBaseApplicationService<Cidade>
    {
        Cidade Get(string id);
        void Delete(string id);
    }
}
