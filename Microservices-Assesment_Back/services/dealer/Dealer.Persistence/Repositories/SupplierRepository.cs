using Core.Persistence.Repositories;
using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using Dealer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Persistence.Repositories;

public class SupplierRepository:EfRepositoryBase<Supplier,Guid, BaseDbContext>, ISupplierRepository
{
    public SupplierRepository(BaseDbContext context):base(context)
    {
        
    }
}
