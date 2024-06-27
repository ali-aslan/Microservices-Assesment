using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Sale.Application.Services.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product, Guid>
    {
    }
}
