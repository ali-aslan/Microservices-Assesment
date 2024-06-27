using Core.Persistence.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Services.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order, Guid>
    {
    }
}
