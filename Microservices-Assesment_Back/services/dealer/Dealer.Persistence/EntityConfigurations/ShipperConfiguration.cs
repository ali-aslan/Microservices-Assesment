using Microsoft.EntityFrameworkCore;
using Dealer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dealer.Persistence.EntityConfigurations;

public class ShipperConfiguration: IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.ToTable("Shippers").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();

        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Shippers_Name").IsUnique();

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }


    private IEnumerable<Shipper> _seeds
    {
        get
        {
            return new List<Shipper>
            {
                new Shipper
                {
                    Id = Guid.Parse("B19B03B2-FE50-4C30-BEAC-41A3C648E721"), // Shipper 1
                    Name = "Global Express",
                    Phone = "+123456789"
                },
                new Shipper
                {
                    Id = Guid.Parse("A5A07AAB-706B-4A30-97A5-25B0D37BD6AB"), // Shipper 2
                    Name = "FastTrack Logistics",
                    Phone = "+987654321"
                }
            };
        }
    }

    }
