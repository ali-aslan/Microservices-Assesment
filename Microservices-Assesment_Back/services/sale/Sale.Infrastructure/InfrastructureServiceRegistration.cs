using Contracts;
using Contracts.Request;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sale.Application.EventHandlers;
using Sale.Application.EventHandlers.GetOrders;

namespace Sale.Infrastructure
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

                busConfigurator.AddConsumer<GetOrderEventConsumer>().Endpoint(e => e.Name = "get-order");

                busConfigurator.AddRequestClient<OrderRequest>(new Uri("exchange:get-order"));

            });

            return services;
        }

    }

}
