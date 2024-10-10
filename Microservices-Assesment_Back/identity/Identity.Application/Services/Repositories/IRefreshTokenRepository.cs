using Core.Persistence.Repositories;
using Identity.Domain.Entities;

namespace Identity.Application.Services.Repositories;

public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, Guid>
{
    Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userId, int refreshTokenTTL);
}

