using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class ContatoService : BaseService<Contato>, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository) : base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
    }
}
