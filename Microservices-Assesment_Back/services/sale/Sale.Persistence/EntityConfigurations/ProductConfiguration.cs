using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Persistence.EntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");


            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Products_Name").IsUnique();

            builder.HasMany(p => p.Orders)
                   .WithOne(o => o.Product)
                   .HasForeignKey(o => o.ProductID);


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

    }
}
