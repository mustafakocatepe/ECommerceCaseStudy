using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer("Server=ms-sql-server,1433;Database=ECommerceCaseStudy;User Id=SA;Password=Password@12345;"));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVariantRepository, VariantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
