using System;
using System.Linq.Expressions;

namespace RocamERP.Domain.QuerySpecificationInterfaces
{
    public interface IBaseQuerySpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
        bool IsSatisfied(T entity);
    }
}
