using Application.DefaultModule.DtoModels;
using Application.DefaultModule.Intefaces;
using AutoMapper;
using Domain.DefaultModule.Contracts;
using Infrastructure.DefaultModule.Models;
using Infrastructure.DefaultModule.Repositories;
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Services
            services.AddTransient<ITableDefaultService, TableDefaultService>();

            // Repositories
            services.AddScoped<IDefaultRepository, DefaultRepository>();

            // Database context
            services.AddDbContext<DbDefaultContext>(options => options.UseSqlServer(conexionString));

            return services;
        }
    }
}
