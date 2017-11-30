using RocamERP.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class CidadePessoasSpecification : BaseSpecification<Cidade>
    {
        private readonly bool hideEmptyPessoas;

        public CidadePessoasSpecification(bool hideEmptyEnderecos)
        {
            hideEmptyPessoas = hideEmptyEnderecos;
        }

        public override Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => hideEmptyPessoas ? cidade.Enderecos.Any() : true;
        }
    }
}
