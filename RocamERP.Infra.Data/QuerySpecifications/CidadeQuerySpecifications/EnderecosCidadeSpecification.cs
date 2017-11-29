using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class EnderecosCidadeSpecification : ISpecification<Cidade>
    {
        private readonly bool _hideEmptyEnderecos = false;

        public EnderecosCidadeSpecification(bool hideEmptyEnderecos)
        {
            _hideEmptyEnderecos = hideEmptyEnderecos;
        }

        public bool IsSatisfiedBy(Cidade entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => _hideEmptyEnderecos != false ? cidade.Enderecos.Any() : false;
        }
    }
}
