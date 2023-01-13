using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Database.Contexts;

namespace ProductManagement.Configuration
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("ProductManagementSql");
            services.AddDbContext<ProductManagementContext>(options => options.UseSqlServer(connectionstring));
        }
    }
}
