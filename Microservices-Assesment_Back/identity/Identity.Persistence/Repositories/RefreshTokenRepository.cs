using Core.Persistence.Repositories;
using Identity.Application.Services.Repositories;
using Identity.Domain.Entities;
using Identity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, Guid, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context)
        : base(context) { }

    public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userId, int refreshTokenTtl)
    {
        List<RefreshToken> tokens = await Query()
            .AsNoTracking()
            .Where(r =>
                r.UserId == userId
                && r.RevokedDate == null
                && r.ExpirationDate >= DateTime.UtcNow
                && r.CreatedDate.AddDays(refreshTokenTtl) <= DateTime.UtcNow
            )
            .ToListAsync();

        return tokens;
    }
}
