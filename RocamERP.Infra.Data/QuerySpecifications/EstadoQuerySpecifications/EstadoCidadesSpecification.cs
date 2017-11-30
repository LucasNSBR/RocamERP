using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RocamERP.Infra.Data.QuerySpecifications.EstadoQuerySpecifications
{
    public class EstadoCidadesSpecification : BaseSpecification<Estado>, ISpecification<Estado>
    {
        private readonly bool _hideEmpty = false;

        public EstadoCidadesSpecification(bool hideEmpty)
        {
            _hideEmpty = hideEmpty;
        }

        public override Expression<Func<Estado, bool>> ToExpression()
        {
            return estado => _hideEmpty ? estado.Cidades.Any() : true;
        }
    }
}
