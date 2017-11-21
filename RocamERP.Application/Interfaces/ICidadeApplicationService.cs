using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Application.Interfaces
{
    public interface ICidadeApplicationService : IBaseApplicationService<Cidade>
    {
        IEnumerable<Cidade> GetByName(string prefix);
    }
}
