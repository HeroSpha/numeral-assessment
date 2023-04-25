using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
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
        if (string.IsNullOrEmpty(request.CustomerId))
        {
            return await _orderRepository.GetAsync();
        }

        return await _orderRepository.GetAsync(x => x.CustomerId.Equals(CustomerId.Create(request.CustomerId)));

    }
}