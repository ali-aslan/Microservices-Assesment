using Core.Persistence.Repositories;
using Identity.Application.Services.Repositories;
using Identity.Domain.Entities;
using Identity.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context) { }
}
