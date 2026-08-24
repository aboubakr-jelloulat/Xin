using BuildingBlock.Messaging.MassTransit;
using BuildingBlocks.Behavior;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));

        });

        services.AddFeatureManagement();

        services.AddMessageBroker(configuration, assembly); // Add MassTransit

        return (services);
    }
}
