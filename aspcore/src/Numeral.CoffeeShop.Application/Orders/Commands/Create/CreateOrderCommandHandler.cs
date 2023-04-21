using ErrorOr;
using MediatR;
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Common.Services;
using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Enums;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.OrderAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;

namespace Numeral.CoffeeShop.Application.Orders.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<Order>>
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly ILoyaltyProgramService _loyaltyProgramService;
    private readonly IDateTimeProvider _dateTimeProvider;
    public CreateOrderCommandHandler(IRepository<Order> orderRepository, ILoyaltyProgramService loyaltyProgramService, IDateTimeProvider dateTimeProvider, IRepository<Customer> customerRepository)
    {
        _orderRepository = orderRepository;
        _loyaltyProgramService = loyaltyProgramService;
        _dateTimeProvider = dateTimeProvider;
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId = CustomerId.Create(request.CustomerId);
        var order = Order.Create(
            _dateTimeProvider.UtcNow,
               request.OrderStatus,
            request.OrderItems.Select(x
                    => OrderItem.Create(x.Quantity, x.Price, MenuItemId.Create(x.Id.Value))),
            customerId
            );
        await _orderRepository.InsertAsync(order);
        var customer = await _customerRepository.GetByIdAsync(order);
        var rewards = await _loyaltyProgramService.CalculateRewards(order.OrderItems);
        customer.AddRewards(rewards.Select(r => Reward.Create(r.ProgramName, CustomerRewardEnum.Earned, r.CashValue, r.Points)));
        return order;
    }
}