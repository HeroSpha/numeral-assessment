using System.Collections.ObjectModel;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;
using Numeral.CoffeeShop.Domain.OrderAggregate.Entities;
using Numeral.CoffeeShop.Domain.OrderAggregate.Enums;
using Numeral.CoffeeShop.Domain.OrderAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Domain.OrderAggregate;

public class Order : AggregateRoot<OrderId, Guid>
{
    public CustomerId CustomerId { get; set; }
    public decimal OrderTotal { get; private set; }
    public DateTime OrderDate { get; private set; }

    public OrderStatus Status { get; private set; }
    
    private readonly List<OrderItem> _orderItems = new();
   
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    private Order(OrderId id, DateTime orderDate, OrderStatus orderStatus, IEnumerable<OrderItem> orderItems, CustomerId customerId) : base(id)
    {
        if (customerId.Value == Guid.Empty)
        {
            throw new Exception("Customer cannot be null.");
        }

        var items = orderItems as OrderItem[] ?? orderItems.ToArray();
        CheckOrderItems(items);
        
        OrderTotal = CalculateOrderTotal(items);
        OrderDate = orderDate;
        CustomerId = customerId;
        Status = orderStatus;
        _orderItems = new List<OrderItem>(items);
    }

    private void CheckOrderItems(IEnumerable<OrderItem> orderItems)
    {
        if (!orderItems.Any())
        {
            throw new Exception("Order items cannot be empty");
        }
    }

    private decimal CalculateOrderTotal(IEnumerable<OrderItem> orderItems)
    {
        var items = orderItems as OrderItem[] ?? orderItems.ToArray();
        CheckOrderItems(items);
        return items.Sum(item => item.Price * item.Quantity);
    }

    public static Order Create(
        DateTime orderDate,
        OrderStatus orderStatus,
        IEnumerable<OrderItem> orderItems,
        CustomerId customerId)
    {
        return new(OrderId.CreateUnique(), orderDate, orderStatus, orderItems, customerId);
    }

#pragma warning disable CS8618
    public Order(){}
#pragma warning restore CS8618
}