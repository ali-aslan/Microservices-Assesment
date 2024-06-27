using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Admin.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
