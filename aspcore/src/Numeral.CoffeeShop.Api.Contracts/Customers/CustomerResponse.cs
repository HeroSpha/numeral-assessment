namespace Numeral.CoffeeShop.Api.Contracts.Customers;

public record CustomerResponse(string FirstName, string LastName, string Email, string Id, IEnumerable<RewardResponse> Rewards, double Points, decimal Cash);