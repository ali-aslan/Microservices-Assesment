using Core.Security.Constants;
using Identity.Application.Features.Users.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Domain.Entities;
using Identity.Application.Features.Auth.Constants;
using Identity.Application.Features.OperationClaims.Constants;
using Identity.Application.Features.UserOperationClaims.Constants;

namespace Identity.Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    public static int SaleId { get; set; } = 1;
    public static int DealerId { get; set; } = 1;
    public static int SellerId { get; set; } = 1;
    public static int CustomerId { get; set; } = 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            int lastId = AdminId;

            // Admin
            yield return new() { Id = lastId, Name = GeneralOperationClaims.Admin };
            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(lastId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
            lastId += featureOperationClaims.Count() + 1;
            SaleId = lastId;

            // Sale
            yield return new() { Id = lastId, Name = GeneralOperationClaims.Sale };
            IEnumerable<OperationClaim> saleFeatureOperationClaims = getFeatureOperationClaimsForCostumUsers(lastId, GeneralOperationClaims.Sale);
            foreach (OperationClaim claim in saleFeatureOperationClaims)
                yield return claim;
            lastId += saleFeatureOperationClaims.Count() + 1;
            DealerId = lastId;

            // Dealer
            yield return new() { Id = lastId, Name = GeneralOperationClaims.Dealer };
            IEnumerable<OperationClaim> dealerFeatureOperationClaims = getFeatureOperationClaimsForCostumUsers(lastId, GeneralOperationClaims.Dealer);
            foreach (OperationClaim claim in dealerFeatureOperationClaims)
                yield return claim;
            lastId += saleFeatureOperationClaims.Count() + 1;
            SellerId = lastId;

            // Seller
            yield return new() { Id = lastId, Name = GeneralOperationClaims.Seller };
            IEnumerable<OperationClaim> sellerFeatureOperationClaims = getFeatureOperationClaimsForCostumUsers(lastId, GeneralOperationClaims.Seller);
            foreach (OperationClaim claim in sellerFeatureOperationClaims)
                yield return claim;
            lastId += saleFeatureOperationClaims.Count() + 1;
            CustomerId = lastId;

            // Customer
            yield return new() { Id = lastId, Name = GeneralOperationClaims.Customer };
            IEnumerable<OperationClaim> customerFeatureOperationClaims = getFeatureOperationClaimsForCostumUsers(lastId, GeneralOperationClaims.Customer);
            foreach (OperationClaim claim in customerFeatureOperationClaims)
                yield return claim;
        }
    }

    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(new List<OperationClaim>
        {
        new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
        new() { Id = ++lastId, Name = AuthOperationClaims.Read },
        new() { Id = ++lastId, Name = AuthOperationClaims.Write },
        new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
        });
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(new List<OperationClaim>
        {
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
        new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
        });
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(new List<OperationClaim>
        {
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
        new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
        });
        #endregion

        #region Users
        featureOperationClaims.AddRange(new List<OperationClaim>
        {
        new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
        new() { Id = ++lastId, Name = UsersOperationClaims.Read },
        new() { Id = ++lastId, Name = UsersOperationClaims.Write },
        new() { Id = ++lastId, Name = UsersOperationClaims.Create },
        new() { Id = ++lastId, Name = UsersOperationClaims.Update },
        new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
        });
        #endregion

        return featureOperationClaims;
    }

    private IEnumerable<OperationClaim> getFeatureOperationClaimsForCostumUsers(int initialId, string role)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        var claimsCostumUsers = new UsersOperationClaimsCostumUsers(role);

        #region Costum Users
        featureOperationClaims.AddRange(new List<OperationClaim>
        {
        new() { Id = ++lastId, Name = claimsCostumUsers.Admin },
        new() { Id = ++lastId, Name = claimsCostumUsers.Read },
        new() { Id = ++lastId, Name = claimsCostumUsers.Write },
        new() { Id = ++lastId, Name = claimsCostumUsers.Create },
        new() { Id = ++lastId, Name = claimsCostumUsers.Update },
        new() { Id = ++lastId, Name = claimsCostumUsers.Delete },
        });
        #endregion

        return featureOperationClaims;
    }
}