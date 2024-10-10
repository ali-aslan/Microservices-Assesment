using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities;

public class UserOperationClaim<TId, TUserId, TOperationClaimId> : Entity<TId>
{
    public TUserId UserId { get; set; }

    public TOperationClaimId OperationClaimId { get; set; }

    public UserOperationClaim()
    {
        UserId = default(TUserId);
        OperationClaimId = default(TOperationClaimId);
    }

    public UserOperationClaim(TUserId userId, TOperationClaimId operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }

    public UserOperationClaim(TId id, TUserId userId, TOperationClaimId operationClaimId)
        : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
