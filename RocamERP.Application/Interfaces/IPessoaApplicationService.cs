using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Application.Interfaces
{
    public interface IPessoaApplicationService : IBaseApplicationService<Pessoa>
    {
        IEnumerable<Pessoa> Get(string prefix);
    }
}
