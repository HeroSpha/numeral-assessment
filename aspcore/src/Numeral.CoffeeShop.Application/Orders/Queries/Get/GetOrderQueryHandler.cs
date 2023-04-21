using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.OrderAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Application.Orders.Queries.Get;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, ErrorOr<Order>>
{
    private readonly IRepository<Order> _orderRepository;

    public GetOrderQueryHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(OrderId.Create(request.OrderId));
        return order;
    }
}