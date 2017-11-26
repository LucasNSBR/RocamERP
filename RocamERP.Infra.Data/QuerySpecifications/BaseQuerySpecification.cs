using System;
using System.Linq.Expressions;
using RocamERP.Domain.QuerySpecificationInterfaces;

namespace RocamERP.Infra.Data.QuerySpecifications
{
    public abstract class BaseQuerySpecification<T> : IBaseQuerySpecification<T>
    {
        public bool IsSatisfied(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
