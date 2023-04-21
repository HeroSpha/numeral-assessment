using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.Identity;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<MenuItem> MenuItems { get; set; } 
    public DbSet<Customer> Customers { get; set; } 
    public DbSet<Order> Orders { get; set; } 
    public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; } 
    public DbSet<User> Users { get; set; }
}