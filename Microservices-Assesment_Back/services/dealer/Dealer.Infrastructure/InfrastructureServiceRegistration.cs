using Contracts;
using Contracts.Request;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dealer.Application;

using Dealer.Application.EventHandlers;

namespace Dealer.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    var rabbitMqOptions = configuration.GetSection("MessageBroker");
                    cfg.Host(new Uri(rabbitMqOptions["Host"]), h =>
                    {
                        h.Username(rabbitMqOptions["Username"]);
                        h.Password(rabbitMqOptions["Password"]);
                    });

                    cfg.ConfigureEndpoints(context);
                });
                busConfigurator.AddConsumer<GetShipperEventConsumer>().Endpoint(e => e.Name = "get-shipper");
                busConfigurator.AddRequestClient<ShipperRequest>(new Uri("exchange:get-shipper"));

                busConfigurator.AddConsumer<GetSupplierEventHandler>().Endpoint(e => e.Name = "get-supplier");
                busConfigurator.AddRequestClient<SupplierRequest>(new Uri("exchange:get-supplier"));



            });

            return services;
        }

    }

}
