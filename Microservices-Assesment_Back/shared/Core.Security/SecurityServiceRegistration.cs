using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Core.Security.OtpAuthenticator.OtpNet;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices<TUserId, TOperationClaimId, TRefreshTokenId>(this IServiceCollection services, TokenOptions tokenOptions)
    {
        TokenOptions tokenOptions2 = tokenOptions;
        services.AddScoped<ITokenHelper<TUserId, TOperationClaimId, TRefreshTokenId>, JwtHelper<TUserId, TOperationClaimId, TRefreshTokenId>>((IServiceProvider _) => new JwtHelper<TUserId, TOperationClaimId, TRefreshTokenId>(tokenOptions2));
        return services;
    }

}