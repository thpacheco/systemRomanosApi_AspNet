using System;
using System.Linq.Expressions;

namespace RomanosApi.Core
{
    public abstract class SpecificationBase<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }
    }
}
