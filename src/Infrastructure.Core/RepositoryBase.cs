using Domain.Core;
using Domain.Core.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Core
{
    /// <summary>
    /// Clase base de repositorios.
    /// </summary>
    /// <typeparam name="TEntity">El tipo de entidad del repositorio.</typeparam>
    public class RepositoryBase : IRepositoryBase
    {
        public DbContext UnitOfWork { get; private set; } = null;

        /// <summary>
        /// Crea una nueva instancia del repositorio.
        /// </summary>
        /// <param name="unitOfWork">Asociado con el "Unit Of Work".</param>
        public RepositoryBase(DbContext unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add<TEntity>(TEntity item) where TEntity : class, new()
        {
            if (item != null)
            {
                GetSet<TEntity>().Add(item);
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove<TEntity>(TEntity item) where TEntity : class, new()
        {
            if (item != null)
            {
                UnitOfWork.Attach(item);
                GetSet<TEntity>().Remove(item);
            }
        }

        /// <summary>
        /// <see cref="Domain.Core.IRepository"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Modify<TEntity>(TEntity item) where TEntity : class, new()
        {
            if (item != null)
            {
                UnitOfWork.Update(item);
            }
        }

        public virtual int Modify<TEntity>(ICollection<TEntity> items) where TEntity : class, new()
        {
            //for each element in collection apply changes
            EntityEntry result = null;
            foreach (TEntity item in items)
            {
                if (item != null)
                {
                    result = UnitOfWork.Update(items);
                    if (result.State == EntityState.Unchanged)
                    {
                        return 0;
                    }
                }
            }

            return UnitOfWork.SaveChanges();
        }

        public virtual void Attach<TEntity>(TEntity item) where TEntity : class, new()
        {
            UnitOfWork.Attach(item);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, new()
        {
            return GetSet<TEntity>();
        }

        public TEntity GetById<TEntity>(params object[] keys) where TEntity : class, new()
        {
            return GetSet<TEntity>().Find(keys);
        }

        public IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, new()
        {
            return GetSet<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetBySpecification<TEntity>(ISpecification<TEntity> specification) where TEntity : class, new()
        {
            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            return GetSet<TEntity>().Where(specification.SatisfiedBy()).AsEnumerable();
        }

        public IEnumerable<TEntity> GetPagedElements<TEntity, S>(int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderByExpression, bool ascending) where TEntity : class, new()
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("Invalido indice de página.", "pageIndex");
            }

            if (pageCount <= 0)
            {
                throw new ArgumentException("Cantidad de páginas inválidas.", "pageCount");
            }

            if (orderByExpression == null)
            {
                throw new ArgumentNullException("orderByExpression", "La expresión no puede ser null.");
            }

            return (ascending ? GetSet<TEntity>().OrderBy(orderByExpression).Skip(pageIndex * pageCount).Take(pageCount).ToList()
                : GetSet<TEntity>().OrderByDescending(orderByExpression).Skip(pageIndex * pageCount).Take(pageCount).ToList());
        }

        DbSet<TEntity> GetSet<TEntity>() where TEntity : class, new()
        {
            return UnitOfWork.Set<TEntity>();
        }

        #region Miembros IDisposable

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                    UnitOfWork = null;
                }
            }
        }

        #endregion
    }
}
