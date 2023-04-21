
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Common.Persistence;

public interface IUserRepository 
{
    Task<User> GetUserByEmail(string email);
}