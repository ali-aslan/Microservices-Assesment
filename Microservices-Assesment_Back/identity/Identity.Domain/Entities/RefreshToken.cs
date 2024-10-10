using Core.Security.Entities;

namespace Identity.Domain.Entities;

public class RefreshToken : RefreshToken<Guid, Guid>
{
    public virtual User User { get; set; } = default!;
}
