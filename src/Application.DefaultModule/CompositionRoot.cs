using Application.DefaultModule.Intefaces;
using Domain.DefaultModule.Contracts;
using Infrastructure.DefaultModule.Models;
using Infrastructure.DefaultModule.Repositories;
using Infrastructure.DefaultModule.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DefaultModule
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, string conexionString)
        {
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<DbDefaultContext>();

            services.AddScoped<IDefaultUnitOfWork, DefaultUnitOfWork>();

            // Services
            services.AddTransient<ITableDefaultService, TableDefaultService>();
            
            // Repositories
            services.AddScoped<ITableDefaultRepository, TableDefaultRepository>();

            // Database context
            services.AddDbContext<DbDefaultContext>(options => options.UseSqlServer(conexionString));

            return services;
        }
    }
}
