using Microsoft.EntityFrameworkCore;

using Numeral.CoffeeShop.Application.Helpers;
using Numeral.CoffeeShop.Domain.Common.Errors;
using Numeral.CoffeeShop.Domain.Identity;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Data.Seeding;

public class DataSeeder : IDataSeeder
{
    public async Task SeedAsync(CoffeeShopDbContext context)
    {
        try
        {
            var existingUsers =  context.Users;
            var existingPrograms = context.LoyaltyPrograms;
        
            if(!existingPrograms.Any())
            {
                var programs = new List<LoyaltyProgram>
                {
                    LoyaltyProgram.Create(2, 2.5m, "Mega Program"), 
                    LoyaltyProgram.Create(1, 1.5m, "Light Program"),
                };
                context.LoyaltyPrograms.AddRange(programs);
                await context.SaveChangesAsync();
            };
            if (!existingUsers.Any())
            {
                var (salt, password) = PasswordHelper.HashPassword("1q2w3e");
                var users = new List<User>
                {
                    User.Create("Admin", "Admin", "admin@numeralcoffee.co.oza", password ,salt, "Admin" ),
                    User.Create("Customer", "Customer", "customer@numeralcoffee.co.za", password ,salt, "Customer" ),
                };
                context.Users.AddRange(users);
                await context.SaveChangesAsync();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}