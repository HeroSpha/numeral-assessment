using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Numeral.CoffeeShop.Application.Common.Interfaces.Authentication;
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Common.Services;
using Numeral.CoffeeShop.EntityFrameworkCore.Authentication;
using Numeral.CoffeeShop.EntityFrameworkCore.Common;
using Numeral.CoffeeShop.EntityFrameworkCore.Data.Seeding;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Repositories;
using Numeral.CoffeeShop.EntityFrameworkCore.Services;

namespace Numeral.CoffeeShop.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFrameworkCore(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IDataSeeder, DataSeeder>();
        
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<CoffeeShopDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
    private static IServiceCollection AddAuth(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSetting();
        configuration.Bind(JwtSetting.SectioName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        return services;
    }
}