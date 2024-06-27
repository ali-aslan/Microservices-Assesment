using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealer.Application.Services.Repositories;
using Dealer.Persistence.Context;
using Dealer.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dealer.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("Dealer"));

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Dealer")));

        services.AddScoped<IShipperRepository, ShipperRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        return services;
    }
}