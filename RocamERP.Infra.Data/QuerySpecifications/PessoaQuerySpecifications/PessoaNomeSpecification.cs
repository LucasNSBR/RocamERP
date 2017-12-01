using RocamERP.Domain.Models;
using System;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.PessoaQuerySpecifications
{
    public class PessoaNomeSpecification : BaseSpecification<Pessoa>
    {
        private readonly string _prefix;

        public PessoaNomeSpecification(string prefix)
        {
            _prefix = prefix;
        }

        public override Expression<Func<Pessoa, bool>> ToExpression()
        {
            return pessoa => !(_prefix.Trim() == string.Empty) ? pessoa.Nome.ToLower().Contains(_prefix.ToLower()) : true;
        }
    }
}
