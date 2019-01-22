using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IBaseService<TEntity, TEntityDTO>
        where TEntity : class, new()
        where TEntityDTO : class, new()
    {
        TEntityDTO Add(TEntity entity);
        Task<TEntityDTO> AddAsync(TEntity entity);
        IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntityDTO> GetAll();
        TEntityDTO GetById(params object[] keys);
        int Modify(ICollection<TEntity> items);
        TEntityDTO Modify(TEntity entity);
        Task<int> ModifyAsync(ICollection<TEntity> items);
        Task<TEntityDTO> ModifyAsync(TEntity entity);
        int Remove(params object[] keys);
        Task<int> RemoveAsync(params object[] keys);
    }
}