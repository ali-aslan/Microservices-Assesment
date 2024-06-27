using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Dealer.Domain.Entities;

namespace Dealer.Application.Services.Repositories
{
    public interface ISupplierRepository : IAsyncRepository<Supplier, Guid>
    {
    }
}
