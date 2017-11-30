using RocamERP.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.PessoaQuerySpecifications
{
    public class PessoaChequesSpecification : BaseSpecification<Pessoa>
    {
        private readonly bool _hideEmpty;

        public PessoaChequesSpecification(bool hideEmpty)
        {
            _hideEmpty = hideEmpty;
        }

        public override Expression<Func<Pessoa, bool>> ToExpression()
        {
            return pessoa => _hideEmpty ? pessoa.Cheques.Any() : true;
        }
    }
}
