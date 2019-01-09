using Domain.DefaultModule.Entities.Models;
using Infrastructure.Core;
using Infrastructure.DefaultModule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DefaultModule.UnitOfWork
{
    public class DefaultUnitOfWork : DbDefaultContext, IDefaultUnitOfWork
    {
        #region Miembros IQueryableUnitOfWork

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        // Ya esta definido en el DbContext
        //public void Attach<TEntity>(TEntity item) where TEntity : class
        //{
        //    if (Entry(item).State == EntityState.Detached)
        //    {
        //        base.Set<TEntity>().Attach(item);
        //    }
        //}

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class
        {
            RawSqlString sql = new RawSqlString(sqlQuery);

            return base.Set<TEntity>().FromSql(sql, parameters).ToList();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
        }

        #endregion

        #region Miembros de Unit Of Work

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            var validationContext = new ValidationContext(item);
            Validator.ValidateObject(item, validationContext);

            Entry(item).State = EntityState.Modified;
        }

        public int Commit()
        {

            return base.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                                  .ToList()
                                  .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region DbContext Overrides

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
