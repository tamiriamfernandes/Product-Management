using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Data.Database.Contexts;
using ProductManagement.Data.Database.Repositories;
using ProductManagement.Data.Database.UnitOfWork;
using ProductManagement.Domain.Contracts;
using ProductManagement.Domain.Core.Contracts.Repositories;
using ProductManagement.Domain.Core.Contracts.UnitOfWork;
using ProductManagement.Domain.Services;

namespace ProductManagement.Common.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork<ProductManagementContext>>();

        services.AddTransient<DbContext, ProductManagementContext>();

        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
