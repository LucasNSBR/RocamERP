using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.QuerySpecifications.EstadoQuerySpecifications
{
    public class EstadoNomeSpecification : BaseSpecification<Estado>
    {
        private readonly string _estadoNome;

        public EstadoNomeSpecification(string estadoNome)
        {
            _estadoNome = estadoNome;
        }
        
        public override Expression<Func<Estado, bool>> ToExpression()
        {
            return estado => estado.Nome.ToLower().Contains(_estadoNome.ToLower());
        }
    }
}
