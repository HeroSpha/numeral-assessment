using Microsoft.EntityFrameworkCore;

using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Data.Seeding;

public interface IDataSeeder
{
    Task SeedAsync(CoffeeShopDbContext context);
}