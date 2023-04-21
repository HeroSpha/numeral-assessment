using Numeral.CoffeeShop.Api.Common.Mapping;

namespace Numeral.CoffeeShop.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMappings();
        return services;
    }
}