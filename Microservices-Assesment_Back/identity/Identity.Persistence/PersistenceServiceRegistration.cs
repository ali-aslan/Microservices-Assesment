using Identity.Application.Services.Repositories;
using Identity.Persistence.Contexts;
using Identity.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Identity.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDb")));

        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


        return services;
    }
}