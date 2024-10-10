using Core.Persistence.Repositories;
using Identity.Domain.Entities;


namespace Identity.Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, Guid>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId);
}
