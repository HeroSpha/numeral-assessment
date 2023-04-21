using MediatR;

using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Application.Customers.Queries.List;

public record GetCustomersQuery() : IRequest<IEnumerable<Customer>>;