using Dealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Persistence.EntityConfigurations;

public class SupplierConfiguration: IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.ContactName).HasColumnName("ContactName").IsRequired();
        builder.Property(b => b.Phone).HasColumnName("Phone").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Suppliers_Name").IsUnique();

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Supplier> _seeds
    {
        get
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Id = Guid.Parse("5D7DDF1B-1F2F-4A72-AC0A-0106E2912B34"), // Supplier 1
                    Name = "TechSource Supplies",
                    ContactName = "Alice Johnson",
                    Phone = "+1122334455"
                },
                new Supplier
                {
                    Id = Guid.Parse("E462E1A5-B32C-44D3-A74B-FA60C1E76D89"), // Supplier 2
                    Name = "HomeGoods Wholesale",
                    ContactName = "Bob Williams",
                    Phone = "+9988776655"
                }
            };
        }
    }
}
