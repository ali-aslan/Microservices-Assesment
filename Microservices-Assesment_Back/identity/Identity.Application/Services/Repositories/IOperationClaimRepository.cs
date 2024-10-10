using Core.Persistence.Repositories;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int> 
{

}
