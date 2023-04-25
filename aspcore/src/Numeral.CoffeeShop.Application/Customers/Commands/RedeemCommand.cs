using MediatR;
using ErrorOr;

using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Application.Customers.Commands;

public record RedeemCommand(string CustomerId) : IRequest<ErrorOr<Customer>>;