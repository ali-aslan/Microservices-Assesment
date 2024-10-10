using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");


        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Customers_Name").IsUnique();

        builder.HasMany(b => b.Orders)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerID);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Customer> _seeds
    {
        get
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = Guid.Parse("C9BF9E57-1685-4C89-BDCF-5698F00A4D78"), // Customer 1
                    Name = "John Doe",
                    Email = "customer_one@test.com",
                    Phone = "+1234567890",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Customer
                {
                    Id = Guid.Parse("1D44B7F4-BA6D-4F7A-A5A3-8AE3C9AEB5A1"), // Customer 2
                    Name = "Jane Smith",
                    Email = "customer_two@test.com",
                    Phone = "+1987654321",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    Phone = "+1098765432",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob Williams",
                    Email = "bob.williams@example.com",
                    Phone = "+1122334455",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Charlie Brown",
                    Email = "charlie.brown@example.com",
                    Phone = "+1223344556",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    DeletedDate = null
                }
            };
        }
    }

}
