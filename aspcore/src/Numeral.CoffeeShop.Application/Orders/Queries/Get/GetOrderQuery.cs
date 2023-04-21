using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Domain.OrderAggregate;

namespace Numeral.CoffeeShop.Application.Orders.Queries.Get;

public record GetOrderQuery(string OrderId) : IRequest<ErrorOr<Order>>;