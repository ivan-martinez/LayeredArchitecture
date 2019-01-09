using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Infrastructure.DefaultModule.Models
{
    public partial class DbDefaultContext
    {
        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public override EntityEntry Update(object entity)
        {
            System.Diagnostics.Debugger.Log(1, "", "customContext");

            return base.Update(entity);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override object Find(Type entityType, params object[] keyValues)
        {
            return base.Find(entityType, keyValues);
        }

        public override DbQuery<TQuery> Query<TQuery>()
        {
            System.Diagnostics.Debugger.Log(1, "", "Query");

            return base.Query<TQuery>();
        }
    }
}
