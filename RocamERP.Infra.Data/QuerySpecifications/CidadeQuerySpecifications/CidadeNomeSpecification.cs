using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class CidadeNomeSpecification : BaseSpecification<Cidade>
    {
        private readonly string _prefix; 

        public CidadeNomeSpecification(string prefix)
        {
            _prefix = prefix;
        }

        public override Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => cidade.Nome.ToLower().Contains(_prefix.ToLower());
        }
    }
}
