﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Domain.Entities;

namespace Identity.Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    private IEnumerable<UserOperationClaim> _seeds
    {
        get
        {
            //Admin
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.AdminId,
                OperationClaimId = OperationClaimConfiguration.AdminId
            };

            //Sale
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.SaleId,
                OperationClaimId = OperationClaimConfiguration.SaleId
            };

            //Dealer
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.DealerId,
                OperationClaimId = OperationClaimConfiguration.DealerId
            };

            //Seller
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.SellerId,
                OperationClaimId = OperationClaimConfiguration.SellerId
            };

            //Customer 1
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.CustomerOneId,
                OperationClaimId = OperationClaimConfiguration.CustomerId
            };

            //Customer 2
            yield return new()
            {
                Id = Guid.NewGuid(),
                UserId = UserConfiguration.CustomerTwoId,
                OperationClaimId = OperationClaimConfiguration.CustomerId
            };
        }
    }
}
