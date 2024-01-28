using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddControllersFromPresentation(this IServiceCollection services)
    {

        services.AddControllers();

        return services;
    }
}
