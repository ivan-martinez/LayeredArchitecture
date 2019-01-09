using Domain.DefaultModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.DefaultModule.Intefaces
{
    public interface ITableDefaultService
    {
        IEnumerable<TableDefault> GetAll(Expression<Func<TableDefault, bool>> predicate);
    }
}
