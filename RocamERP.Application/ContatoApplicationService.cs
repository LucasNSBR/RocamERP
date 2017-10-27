using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class ContatoApplicationService : BaseApplicationService<Contato>, IContatoApplicationService
    {
        private readonly IContatoService _contatoService;

        public ContatoApplicationService(IContatoService contatoService) : base(contatoService)
        {
            _contatoService = contatoService;
        }
    }
}
