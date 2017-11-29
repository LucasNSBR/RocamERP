using System;
using System.Linq.Expressions;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}
