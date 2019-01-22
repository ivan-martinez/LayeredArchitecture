using Application.Core;
using Application.DefaultModule.DtoModels;
using Application.DefaultModule.Intefaces;
using AutoMapper;
using Domain.DefaultModule.Contracts;
using Domain.DefaultModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.DefaultModule
{
    internal class TableDefaultService : BaseService<TableDefault, TableDefaultDto>, ITableDefaultService
    {
        public TableDefaultService(IDefaultRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public IEnumerable<TableDefaultDto> GetAll(Expression<Func<TableDefault, bool>> predicate)
        {
            var list = base.GetAll().ToList();

            return list;
        }
    }
}
