using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class CidadeEstadoIdSpecification : BaseSpecification<Cidade>
    {
        private readonly int? _estadoId;

        public CidadeEstadoIdSpecification(int? estadoId)
        {
            _estadoId = estadoId;
        }

        public override Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => _estadoId != null ? cidade.EstadoId == _estadoId : true;
        }
    }
}
