using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class ChequeApplicationService : BaseApplicationService<Cheque>, IChequeApplicationService
    {
        private readonly IChequeService _chequeService;

        public ChequeApplicationService(IChequeService chequeService) : base(chequeService)
        {
            _chequeService = chequeService;
        }
    }
}
