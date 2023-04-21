using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.OrderAggregate;

namespace Numeral.CoffeeShop.Application.Orders.Queries.list;

public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IEnumerable<Order>>
{
    private readonly IRepository<Order> _orderRepository;
    public GetOrderListQueryHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAsync();
        return orders;
    }
}