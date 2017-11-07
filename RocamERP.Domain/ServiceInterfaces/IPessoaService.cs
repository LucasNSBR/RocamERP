using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Domain.ServiceInterfaces
{
    public interface IPessoaService : IBaseService<Pessoa>
    {
        IEnumerable<Pessoa> Get(string prefix);
    }
}
