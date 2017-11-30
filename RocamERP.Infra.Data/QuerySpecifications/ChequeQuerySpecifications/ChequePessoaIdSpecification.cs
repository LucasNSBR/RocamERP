using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.ChequeQuerySpecifications
{
    public class ChequePessoaIdSpecification : BaseSpecification<Cheque>
    {
        private readonly int? _pessoaId;

        public ChequePessoaIdSpecification(int? pessoaId)
        {
            _pessoaId = pessoaId;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_pessoaId != null)
                return cheque => cheque.PessoaId == _pessoaId;

            return cheque => true;
        }
    }
}
