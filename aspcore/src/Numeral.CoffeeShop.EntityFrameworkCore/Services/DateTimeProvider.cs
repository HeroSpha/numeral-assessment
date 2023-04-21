using Numeral.CoffeeShop.Application.Common.Services;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}