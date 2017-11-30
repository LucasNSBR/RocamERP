using RocamERP.Domain.Models;
using System.Linq.Expressions;
using System;

namespace RocamERP.Infra.Data.QuerySpecifications.BancoQuerySpecifications
{
    public class BancoNomeSpecification : BaseSpecification<Banco>
    {
        private readonly string _prefix;

        public BancoNomeSpecification(string prefix)
        {
            _prefix = prefix;
        }

        public override Expression<Func<Banco, bool>> ToExpression()
        {
            return banco => banco.Nome.ToLower().Contains(_prefix.ToLower());
        }
    }
}
