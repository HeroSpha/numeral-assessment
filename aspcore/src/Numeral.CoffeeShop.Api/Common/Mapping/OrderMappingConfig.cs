using Mapster;

using Numeral.CoffeeShop.Api.Contracts.Orders;
using Numeral.CoffeeShop.Application.Orders.Commands;
using Numeral.CoffeeShop.Application.Orders.Commands.Create;
using Numeral.CoffeeShop.Domain.OrderAggregate;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class OrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateOrderCommand>();
        config.NewConfig<Order, OrderResponse>();
        config.NewConfig<CreateOrderRequest, OrderItemDto>();
    }
}