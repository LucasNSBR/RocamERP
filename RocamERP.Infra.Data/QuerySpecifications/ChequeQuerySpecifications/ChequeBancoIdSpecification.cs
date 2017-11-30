using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.ChequeQuerySpecifications
{
    public class ChequeBancoIdSpecification : BaseSpecification<Cheque>
    {
        private readonly int? _bancoId;

        public ChequeBancoIdSpecification(int? bancoId)
        {
            _bancoId = bancoId;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_bancoId != null)
                return cheque => cheque.BancoId == _bancoId;

            return cheque => true;
        }
    }
}
