using System;
using RocamERP.Application.Interfaces;
using RocamERP.Domain.Models;
using RocamERP.Domain.ServiceInterfaces;

namespace RocamERP.Application
{
    public class CidadeApplicationService : BaseApplicationService<Cidade>, ICidadeApplicationService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeApplicationService(ICidadeService cidadeService) : base(cidadeService)
        {
            _cidadeService = cidadeService;
        }
    }
}
