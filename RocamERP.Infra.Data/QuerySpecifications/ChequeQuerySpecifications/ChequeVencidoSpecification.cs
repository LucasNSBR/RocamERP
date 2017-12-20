using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.ChequeQuerySpecifications
{
    public class ChequeVencidoSpecification : BaseSpecification<Cheque>
    {
        private readonly bool _vencidos;

        public ChequeVencidoSpecification(bool vencidos)
        {
            _vencidos = vencidos;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            return cheque => _vencidos ? cheque.ChequeVencido() : true;
        }
    }
}
