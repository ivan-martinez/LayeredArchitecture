using Application.Core;
using Application.DefaultModule.DtoModels;
using Domain.DefaultModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.DefaultModule.Intefaces
{
    public interface ITableDefaultService : IBaseService<TableDefault, TableDefaultDto>
    {
        IEnumerable<TableDefaultDto> GetAll(Expression<Func<TableDefault, bool>> predicate);
    }
}
