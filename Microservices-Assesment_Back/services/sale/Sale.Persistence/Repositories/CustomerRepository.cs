using Core.Persistence.Repositories;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using Sale.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Persistence.Repositories;

public class CustomerRepository: EfRepositoryBase<Customer,Guid,BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context):base(context)
    {
        
    }
}
