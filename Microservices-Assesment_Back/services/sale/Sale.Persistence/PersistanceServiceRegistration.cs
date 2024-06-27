using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Application.Services.Repositories;
using Sale.Persistence.Contexts;
using Sale.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("Sale"));

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Sale")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
