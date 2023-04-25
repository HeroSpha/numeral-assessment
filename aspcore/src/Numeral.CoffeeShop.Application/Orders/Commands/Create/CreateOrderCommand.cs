using MediatR;
using ErrorOr;

using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.OrderAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;
using Numeral.CoffeeShop.Domain.OrderAggregate.Enums;

namespace Numeral.CoffeeShop.Application.Orders.Commands.Create;

public record CreateOrderCommand(
    IEnumerable<OrderItemDto> MenuItems,
    string CustomerId
    ) : IRequest<ErrorOr<Order>>;