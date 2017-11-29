using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class EstadoIdCidadeSpecification : ISpecification<Cidade>
    {
        private readonly int? _estadoId;

        public EstadoIdCidadeSpecification(int? estadoId)
        {
            _estadoId = estadoId;
        }

        public bool IsSatisfiedBy(Cidade entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => _estadoId != null ? cidade.EstadoId == _estadoId : true;
        }

        Expression<Cidade, bool> ISpecification<Cidade>.ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}
