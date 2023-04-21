
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}