using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DefaultModule.Intefaces;
using Domain.DefaultModule.Contracts;
using Domain.DefaultModule.Entities.Models;

namespace Application.DefaultModule
{
    internal class TableDefaultService : ITableDefaultService
    {
        private readonly ITableDefaultRepository _repository;

        public TableDefaultService(ITableDefaultRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TableDefault> GetAll(Expression<Func<TableDefault, bool>> predicate)
        {
            var list = new List<TableDefault>();

            list = _repository.GetAll().ToList();

            return list;
        }
    }
}
