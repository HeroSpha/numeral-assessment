using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Application.Customers.Queries;

public record GetCustomerQuery(
    string Id) : IRequest<ErrorOr<Customer>>;