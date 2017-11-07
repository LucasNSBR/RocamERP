using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Domain.RepositoryInterfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        IEnumerable<Pessoa> Get(string prefix);
    }
}
