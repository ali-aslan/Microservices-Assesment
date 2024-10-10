using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Domain.Entities;

namespace Identity.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);


        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = Guid.NewGuid();
    public static Guid SaleId { get; } = Guid.NewGuid();
    public static Guid DealerId { get; } = Guid.NewGuid();
    public static Guid SellerId { get; } = Guid.Parse("F65A5E9F-621D-4E5C-91F9-0A8E357929B2");  // Seller 1
    public static Guid CustomerOneId { get; } = Guid.Parse("C9BF9E57-1685-4C89-BDCF-5698F00A4D78"); // Customer 1
    public static Guid CustomerTwoId { get; } = Guid.Parse("1D44B7F4-BA6D-4F7A-A5A3-8AE3C9AEB5A1"); // Customer 2

    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "P@ssw0rd_1234!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );

            User adminUser =
                new()
                {
                    Id = AdminId,
                    Email = "admin@test.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CreatedDate = DateTime.Now
                };
            yield return adminUser;

            User saleUser = new()
            {
                Id = SaleId,
                Email = "sale@test.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };
            yield return saleUser;

            User dealerUser = new()
            {
                Id = DealerId,
                Email = "dealer@test.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };
            yield return dealerUser;

            User sellerUser = new()
            {
                Id = SellerId,
                Email = "seller@test.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };
            yield return sellerUser;

            User customerUserOne = new()
            {
                Id = CustomerOneId,
                Email = "customer_one@test.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };
            yield return customerUserOne;

            User customerUserTwo = new()
            {
                Id = CustomerTwoId,
                Email = "customer_two@test.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now
            };
            yield return customerUserTwo;


        }
    }
}
