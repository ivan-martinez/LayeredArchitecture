using Domain.DefaultModule.Contracts;
using Domain.DefaultModule.Entities.Models;
using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DefaultModule.Repositories
{
    public class TableDefaultRepository : Repository<TableDefault>, ITableDefaultRepository
    {
        public TableDefaultRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
