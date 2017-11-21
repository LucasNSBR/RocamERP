using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface ICidadeService : IBaseService<Cidade>
    {
        IEnumerable<Cidade> GetByName(string prefix);
    }
}
