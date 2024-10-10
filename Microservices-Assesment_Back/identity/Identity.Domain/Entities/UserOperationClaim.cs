using Core.Security.Entities;

namespace Identity.Domain.Entities;


public class UserOperationClaim : UserOperationClaim<Guid, Guid, int>
{
    public virtual User User { get; set; } = default!;
    public virtual OperationClaim OperationClaim { get; set; } = default!;
}
