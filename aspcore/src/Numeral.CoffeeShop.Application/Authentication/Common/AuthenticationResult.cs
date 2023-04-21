using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);