using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace RocamERP.Infra.Data.QuerySpecifications
{
    public class CidadeSpecificationService : BaseQuerySpecification<Cidade>
    {
        private readonly string _nome; 

        public CidadeSpecificationService(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Cidade, bool>> ToExpression()
        {
            //var p1 = Expression.Parameter(typeof(Cidade), "Nome");
            //var p2 = Expression.Parameter(typeof(string), "CidadeNome");
            //var p2 = Expression.Parameter(typeof(string), "Name");

            //var binary = BinaryExpression.Property()

            return cidade => cidade.Nome.ToLower().Contains(_nome.ToLower());
        }
    }
}
