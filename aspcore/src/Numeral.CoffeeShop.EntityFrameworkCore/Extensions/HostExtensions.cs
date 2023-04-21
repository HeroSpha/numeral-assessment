using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Numeral.CoffeeShop.EntityFrameworkCore.Data.Seeding;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Extensions;

public static class HostExtensions
{
    public static async Task SeedAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
        await seeder.SeedAsync(scope.ServiceProvider.GetService<CoffeeShopDbContext>());
    }
}