using System;
using System.Linq.Expressions;
using RocamERP.Domain.Models;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications
{
    public class NomeCidadeEspecification : ISpecification<Cidade>
    {
        private readonly string _nome; 

        public NomeCidadeEspecification(string nome)
        {
            _nome = nome;
        }

        public bool IsSatisfiedBy(Cidade entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public Expression<Func<Cidade, bool>> ToExpression()
        {
            return cidade => cidade.Nome.ToLower().Contains(_nome.ToLower());
        }
    }
}
