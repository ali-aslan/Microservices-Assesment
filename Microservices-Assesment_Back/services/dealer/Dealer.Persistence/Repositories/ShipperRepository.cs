using Core.Persistence.Repositories;
using Dealer.Domain.Entities;
using Dealer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealer.Application.Services.Repositories;

namespace Dealer.Persistence.Repositories
{
    public class ShipperRepository :EfRepositoryBase<Shipper,Guid,BaseDbContext>, IShipperRepository
    {
        public ShipperRepository(BaseDbContext context):base(context)
        {
            
        }
    }
}
