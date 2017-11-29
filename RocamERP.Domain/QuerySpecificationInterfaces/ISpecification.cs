using System;
using System.Linq.Expressions;

namespace RocamERP.Domain.QuerySpecificationInterfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        Expression<Func<T, bool>> ToExpression();
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> Not();
    }
}
