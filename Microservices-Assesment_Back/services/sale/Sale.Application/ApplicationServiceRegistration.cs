using Core.CrossCuttingConcerns.Serilog.Logger;
using Core.CrossCuttingConcerns.Serilog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Core.Application.Pipelines.Validation;

namespace Sale.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));


        });

        services.AddSingleton<LoggerServiceBase, MsSqlLogger>();

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}
