using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces.ClienteRepository;

namespace RocamERP.Infra.Data.Repositories.ClienteRepository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
    }
}
