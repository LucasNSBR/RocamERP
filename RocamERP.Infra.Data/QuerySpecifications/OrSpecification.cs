using System;
using System.Linq.Expressions;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications
{
    internal class OrSpecification<T> : BaseSpecification<T>, ISpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            ParameterExpression param = Expression.Parameter(typeof(T));

            var leftExpr = _left.ToExpression();
            var left = new ParameterReplacer(leftExpr.Parameters[0], param).Visit(leftExpr);

            var rightExpr = _right.ToExpression();
            var right = new ParameterReplacer(leftExpr.Parameters[0], param).Visit(leftExpr);

            Expression body = Expression.Or(left, right);
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body, param);

            return expression;
        }
    }
}