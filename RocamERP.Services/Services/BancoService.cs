using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Services.Services
{
    public class BancoService : BaseService<Banco>, IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository) : base(bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public Banco Get(string id)
        {
            return _bancoRepository.Get(id);
        }

        public void Delete(string id)
        {
            _bancoRepository.Delete(id);
        }
    }
}
