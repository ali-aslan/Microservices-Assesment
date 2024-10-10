using Core.Security.Entities;

namespace Identity.Domain.Entities;

public class User : User<Guid>
{
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;

}