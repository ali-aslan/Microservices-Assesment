using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

        builder.Property(o => o.CustomerID).HasColumnName("CustomerID").IsRequired();
        builder.Property(o => o.ProductID).HasColumnName("ProductID");
        builder.Property(o => o.SupplierID).HasColumnName("SupplierID");
        builder.Property(o => o.ShipperID).HasColumnName("ShipperID");
        builder.Property(o => o.SellerID).HasColumnName("SellerID");

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(o => o.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.CustomerID);

        builder.HasOne(o => o.Product)
               .WithMany(p => p.Orders)
               .HasForeignKey(o => o.ProductID);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
