using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications.EstadoQuerySpecifications
{
    public class NomeEstadoSpecification : ISpecification<Estado>
    {
        private readonly string _estadoNome;

        public NomeEstadoSpecification(string estadoNome)
        {
            _estadoNome = estadoNome;
        }

        public bool IsSatisfiedBy(Estado entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public Expression<Func<Estado, bool>> ToExpression()
        {
            return estado => estado.Nome.ToLower().Contains(_estadoNome.ToLower());
        }
    }
}
