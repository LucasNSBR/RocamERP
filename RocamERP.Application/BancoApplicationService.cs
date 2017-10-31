using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class BancoApplicationService : BaseApplicationService<Banco>, IBancoApplicationService
    {
        private readonly IBancoService _bancoService;

        public BancoApplicationService(IBancoService bancoService) : base(bancoService)
        {
            _bancoService = bancoService;
        }

        public Banco Get(string id)
        {
            return _bancoService.Get(id);
        }

        public void Delete(string id)
        {
            _bancoService.Delete(id);
        }
    }
}
