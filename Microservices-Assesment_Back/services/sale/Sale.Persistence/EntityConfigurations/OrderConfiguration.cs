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

        builder.HasData(_seeds);
    }


    private IEnumerable<Order> _seeds
    {
        get
        {
            return new List<Order>
            {
               new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerID = Guid.Parse("C9BF9E57-1685-4C89-BDCF-5698F00A4D78"), // Customer 1
                    ProductID = Guid.Parse("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), // Product 1
                    SupplierID = Guid.Parse("5D7DDF1B-1F2F-4A72-AC0A-0106E2912B34"), // Supplier 1
                    ShipperID = Guid.Parse("B19B03B2-FE50-4C30-BEAC-41A3C648E721"), // Shipper 1
                    SellerID = Guid.Parse("F65A5E9F-621D-4E5C-91F9-0A8E357929B2"),  // Seller 1
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerID = Guid.Parse("1D44B7F4-BA6D-4F7A-A5A3-8AE3C9AEB5A1"), // Customer 2
                    ProductID = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"), // Product 2
                    SupplierID = Guid.Parse("E462E1A5-B32C-44D3-A74B-FA60C1E76D89"), // Supplier 2
                    ShipperID = Guid.Parse("A5A07AAB-706B-4A30-97A5-25B0D37BD6AB"), // Shipper 2
                    SellerID = Guid.Parse("F65A5E9F-621D-4E5C-91F9-0A8E357929B2"),  // Seller 1
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                }
            };
        }
    }
}
