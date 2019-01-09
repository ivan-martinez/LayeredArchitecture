using System;
using System.Linq.Expressions;

namespace Domain.Core.Specification
{
    public interface ISpecification<TEntity>
        where TEntity : class, new()
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
