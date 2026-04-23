using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the infrastructure services with the dependency injection container.
    /// </summary> <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
