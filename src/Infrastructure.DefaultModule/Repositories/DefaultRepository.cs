using Domain.DefaultModule.Contracts;
using Domain.DefaultModule.Entities.Models;
using Infrastructure.Core;
using Infrastructure.DefaultModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DefaultModule.Repositories
{
    public class DefaultRepository : RepositoryBase, IDefaultRepository
    {
        public DefaultRepository(DbDefaultContext context) : base(context)
        {
        }
    }
}
