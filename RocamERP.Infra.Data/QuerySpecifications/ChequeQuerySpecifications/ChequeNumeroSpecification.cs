using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.ChequeQuerySpecifications
{
    public class ChequeNumeroSpecification : BaseSpecification<Cheque>
    {
        private readonly string _numeroCheque;

        public ChequeNumeroSpecification(string numeroCheque)
        {
            _numeroCheque = numeroCheque;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            return cheque => cheque.NumeroCheque.ToLower().Contains(_numeroCheque.ToLower());
        }
    }
}
