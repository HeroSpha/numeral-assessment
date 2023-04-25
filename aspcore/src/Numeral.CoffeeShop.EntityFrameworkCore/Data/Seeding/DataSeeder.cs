using Numeral.CoffeeShop.Application.Helpers;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.Identity;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
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
            var existingMenuItems = context.MenuItems;

            if(!existingPrograms.Any())
            {
                var programs = new List<LoyaltyProgram>
                {
                    LoyaltyProgram.Create(0.1, 2.5m, "Mega Program"), 
                    LoyaltyProgram.Create(0.1, 1.5m, "Light Program"),
                };
                context.LoyaltyPrograms.AddRange(programs);
                
                if (programs.Any())
                {
                    var menuItems = new List<MenuItem>
                    {
                        MenuItem.Create("Macchiato", "Macchiato", 23.45m, "https://images.pexels.com/photos/1036444/pexels-photo-1036444.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[0].Id),
                        MenuItem.Create("Irish Coffee", "Irish Coffee", 20.00m, "https://images.pexels.com/photos/3932545/pexels-photo-3932545.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[1].Id),
                        MenuItem.Create("Espresso", "Espresso", 100.00m, "https://images.pexels.com/photos/685527/pexels-photo-685527.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[0].Id),
                        MenuItem.Create("Drip Coffee", "Drip Coffee", 5.50m, "https://images.pexels.com/photos/4787603/pexels-photo-4787603.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[1].Id),
                        MenuItem.Create("Cafe Latte", "Cafe Latte", 40.00m, "https://images.pexels.com/photos/2836945/pexels-photo-2836945.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[0].Id),
                        MenuItem.Create("Double Espresso", "Double Espresso", 70.30m, "https://images.pexels.com/photos/4792698/pexels-photo-4792698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[1].Id),
                        MenuItem.Create("Affagatto", "Affagatto", 20.00m, "https://images.pexels.com/photos/4792698/pexels-photo-4792698.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[0].Id),
                        MenuItem.Create("Mocha", "Mocha", 8.00m, "https://images.pexels.com/photos/851555/pexels-photo-851555.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[1].Id),
                        MenuItem.Create("Cortado", "Cortado", 60.00m, "https://media.istockphoto.com/id/1479604688/photo/barista-preparing-a-delicious-organic-coffee-flat-white-or-cortado-coffee.jpg?s=612x612&w=is&k=20&c=bjLEVXL9TFc0S9kD7klfI2LiBbFzx-YQnnF3Og8oNvw=", true, programs[0].Id),
                        MenuItem.Create("Black Eye", "Black Eye", 13.00m, "https://images.pexels.com/photos/3799124/pexels-photo-3799124.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[1].Id),
                        MenuItem.Create("Cappuccino", "Cappuccino", 21.98m, "https://images.pexels.com/photos/302899/pexels-photo-302899.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", true, programs[0].Id),
                    };
                    context.MenuItems.AddRange(menuItems);
                }
                
                await context.SaveChangesAsync();
            };
            
            if (!existingUsers.Any())
            {
                var (salt, password) = PasswordHelper.HashPassword("1q2w3e");
                var users = new List<User>
                {
                    User.Create("Admin", "Admin", "admin@numeralcoffee.co.za", password ,salt, "Admin" ),
                    User.Create("Customer", "Customer", "customer@numeralcoffee.co.za", password ,salt, "Customer" ),
                    
                };
                var customerUsers = users.Where(x => x.Role == "Customer");
                foreach (var customerUser in customerUsers)
                {
                    var customer = Customer.Create(customerUser.Id.Value, customerUser.FirstName, customerUser.LastName, customerUser.Email);
                   await context.Customers.AddAsync(customer);
                }
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