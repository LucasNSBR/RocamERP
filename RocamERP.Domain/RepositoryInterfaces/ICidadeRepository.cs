using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        IEnumerable<Cidade> GetByName(string prefix);
    }
}
