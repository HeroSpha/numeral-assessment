namespace Numeral.CoffeeShop.Api.Contracts.Customers;

public record RewardResponse(decimal CashValue, double Points, string ProgramName, string CustomerRewardEnum);