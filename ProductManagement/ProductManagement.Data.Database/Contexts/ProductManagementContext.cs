using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Data.Database.Contexts
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ProductManagementContext).Assembly);
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
