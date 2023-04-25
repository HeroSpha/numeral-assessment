using ErrorOr;
using MediatR;
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Common.Services;
using Numeral.CoffeeShop.Application.Services.LoyaltyPrograms;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Enums;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;
using Numeral.CoffeeShop.Domain.MenuItemAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.OrderAggregate;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;
using Numeral.CoffeeShop.Domain.OrderAggregate.Enums;

namespace Numeral.CoffeeShop.Application.Orders.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<Order>>
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<MenuItem> _menuItemsRepository;
    private readonly ILoyaltyProgramService _loyaltyProgramService;
    private readonly IDateTimeProvider _dateTimeProvider;
    public CreateOrderCommandHandler(IRepository<Order> orderRepository, ILoyaltyProgramService loyaltyProgramService, IDateTimeProvider dateTimeProvider, IRepository<Customer> customerRepository, IRepository<MenuItem> menuItemsRepository)
    {
        _orderRepository = orderRepository;
        _loyaltyProgramService = loyaltyProgramService;
        _dateTimeProvider = dateTimeProvider;
        _customerRepository = customerRepository;
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<ErrorOr<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId = CustomerId.Create(request.CustomerId);
        var orderItems = await GetOrderItems(request.MenuItems);

        var items = orderItems as (int quantity, decimal price, LoyaltyProgramId loyaltyProgramId)[] ?? orderItems.ToArray();
        var order = Order.Create(
            _dateTimeProvider.UtcNow,
               OrderStatus.Paid,
                items.Select(o => OrderItem.Create(o.quantity, o.price)),
                customerId
            );
        await _orderRepository.InsertAsync(order);
        var customer = await _customerRepository.GetByIdAsync(customerId);
        var rewards = await _loyaltyProgramService.CalculateRewards(items.Select(o => o.loyaltyProgramId));
        customer.AddRewards(rewards.Select(r => Reward.Create(r.ProgramName, CustomerRewardEnum.Earned, r.CashValue, r.Points)));
        await _customerRepository.UpdateAsync(customer);
        return order;
    }

    private async Task<IEnumerable<(int quantity, decimal price, LoyaltyProgramId loyaltyProgramId)>> GetOrderItems(IEnumerable<OrderItemDto> menuItems)
    {
        var list = new List<(int quantity, decimal price, LoyaltyProgramId loyaltyProgramId)>();
        foreach (var menuItem in menuItems)
        {
            var item = await _menuItemsRepository.GetByIdAsync(MenuItemId.Create(menuItem.MenuItemId));
            //var orderItem = OrderItem.Create(menuItem.Quantity, item.Price);
            list.Add((menuItem.Quantity, item.Price, item.LoyaltyProgramId));
        }

        return list;
    }
}