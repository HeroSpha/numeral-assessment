using System.Linq.Expressions;
using System.Reflection.Metadata;

using Microsoft.EntityFrameworkCore;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.Common.Errors;
using Numeral.CoffeeShop.Domain.Identity;
using Numeral.CoffeeShop.EntityFrameworkCore.Common;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CoffeeShopDbContext context) : base(context)
    {
    }

    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            var user = await  _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}