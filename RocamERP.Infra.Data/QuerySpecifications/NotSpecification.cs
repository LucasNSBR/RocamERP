using System;
using System.Linq.Expressions;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications
{
    internal class NotSpecification<T> : BaseSpecification<T>, ISpecification<T>
    {
        private ISpecification<T> _specification;

        public NotSpecification(BaseSpecification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var specificationExpr = _specification.ToExpression();
            Expression body = Expression.Not(specificationExpr.Body);
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body, specificationExpr.Parameters[0]);

            return expression; 
        }
    }
}