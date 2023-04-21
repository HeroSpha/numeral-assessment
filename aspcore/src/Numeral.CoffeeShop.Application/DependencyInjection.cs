using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Numeral.CoffeeShop.Application.Common.Behaviors;
using Numeral.CoffeeShop.Application.Configurations;
using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;

namespace Numeral.CoffeeShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<ILoyaltyProgramService, LoyaltyProgramService>();
        services.Configure<JwtIdentityOption>(configuration.GetSection(JwtIdentityOption.SectionName));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}