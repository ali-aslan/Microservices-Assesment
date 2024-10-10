using Core.Persistence.Repositories;
using Identity.Domain.Entities;


namespace Identity.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>
{

}
