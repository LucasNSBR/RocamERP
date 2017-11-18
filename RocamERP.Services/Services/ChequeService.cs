using System.Collections.Generic;
using RocamERP.Domain.Models;
using RocamERP.Domain.RepositoryInterfaces;
using RocamERP.Domain.ServiceInterfaces;
using System.Linq;

namespace RocamERP.Services.Services
{
    public class ChequeService : BaseService<Cheque>, IChequeService
    {
        private readonly IChequeRepository _chequeRepository;

        public ChequeService(IChequeRepository chequeRepository) : base(chequeRepository)
        {
            _chequeRepository = chequeRepository;
        }
    }
}
