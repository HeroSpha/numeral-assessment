using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.OrderAggregate;

namespace Numeral.CoffeeShop.Application.Orders.Queries.list;

public record GetOrderListQuery(string CustomerId) : IRequest<IEnumerable<Order>>;