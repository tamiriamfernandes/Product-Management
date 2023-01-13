using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Data.Database.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey("Id");

            builder.Property(c => c.Description).IsRequired().HasColumnType("varchar(200)");
            builder.Property(c => c.Active).IsRequired();
            builder.Property(c => c.DateFabrication).HasColumnType("Date");
            builder.Property(c => c.DateValidity).HasColumnType("Date");
        }
    }
}
