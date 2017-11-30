using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace RocamERP.Infra.Data.QuerySpecifications.BancoQuerySpecifications
{
    public class BancoChequesSpecification : BaseSpecification<Banco>
    {
        private readonly bool _hideEmpty;

        public BancoChequesSpecification(bool hideEmpty)
        {
            _hideEmpty = hideEmpty;
        }

        public override Expression<Func<Banco, bool>> ToExpression()
        {
            return banco => _hideEmpty ? banco.Cheques.Any() : true;
        }
    }
}
