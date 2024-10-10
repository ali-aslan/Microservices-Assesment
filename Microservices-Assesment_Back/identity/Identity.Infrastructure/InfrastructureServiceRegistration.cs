using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddMassTransit(busConfigurator =>
        //{
        //    busConfigurator.SetKebabCaseEndpointNameFormatter();
        //    busConfigurator.UsingRabbitMq((context, cfg) =>
        //    {
        //        var rabbitMqOptions = configuration.GetSection("MessageBroker");
        //        cfg.Host(new Uri(rabbitMqOptions["Host"]), h =>
        //        {
        //            h.Username(rabbitMqOptions["Username"]);
        //            h.Password(rabbitMqOptions["Password"]);
        //        });

        //        cfg.ConfigureEndpoints(context);
        //    });

        //    busConfigurator.AddConsumer<GetUserByIdEventConsumer>().Endpoint(e => e.Name = "get-user");

        //    busConfigurator.AddRequestClient<SellerRequest>(new Uri("exchange:get-user"));

        //});

        return services;
    }
}
