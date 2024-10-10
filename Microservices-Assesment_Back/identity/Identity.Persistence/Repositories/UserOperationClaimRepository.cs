using Identity.Application.Services.Repositories;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Persistence.Repositories;
using Identity.Persistence.Contexts;


namespace Identity.Persistence.Repositories;

public class UserOperationClaimRepository: EfRepositoryBase<UserOperationClaim, Guid, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context) { }

    public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId)
    {
        List<OperationClaim> operationClaims = await Query()
            .AsNoTracking()
            .Where(p => p.UserId.Equals(userId))
            .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
            .ToListAsync();
        return operationClaims;
    }
}
