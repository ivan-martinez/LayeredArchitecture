using Domain.DefaultModule.Entities.Models;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DefaultModule.UnitOfWork
{
    public interface IDefaultUnitOfWork : IQueryableUnitOfWork
    {
        DbSet<TableDefault> TableDefaults { get; }
    }
}
