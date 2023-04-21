namespace Numeral.CoffeeShop.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}