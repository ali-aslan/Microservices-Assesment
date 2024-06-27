using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealer.Domain.Entities;

namespace Dealer.Application.Services.Repositories
{
    public interface IShipperRepository : IAsyncRepository<Shipper, Guid>
    {
    }
}
