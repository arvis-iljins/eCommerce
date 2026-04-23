using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the core services with the dependency injection container.
    /// </summary> <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
