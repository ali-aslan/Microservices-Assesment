using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sale.Domain.Entities;
using Core.Security.Hashing;

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

            builder.HasData(_seeds);
        }


        private IEnumerable<Product> _seeds
        {
            get
            {
                return new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), // Product 1
                    Name = "SmartWatch Pro",
                    CategoryName = "Electronics",
                    Price = 199.99M,
                    StockQuantity = 150,
                    CreatedDate = DateTime.Now, 
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Product
                {
                    Id = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"), // Product 2
                    Name = "UltraGrip 5000 Tires",
                    CategoryName = "Automotive",
                    Price = 149.95M,
                    StockQuantity = 300,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "HealthMaster Blender",
                    CategoryName = "Kitchen Appliances",
                    Price = 79.99M,
                    StockQuantity = 100,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Adventure Backpack",
                    CategoryName = "Outdoor Gear",
                    Price = 129.50M,
                    StockQuantity = 75,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Professional DSLR Camera",
                    CategoryName = "Photography",
                    Price = 1499.99M,
                    StockQuantity = 50,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                }
            };


            }
        }
    }
}
