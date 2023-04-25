using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Application.Customers.Commands;

public class RedeemCommandHandler : IRequestHandler<RedeemCommand, ErrorOr<Customer>>
{
    private readonly IRepository<Customer> _customerRepository;

    public RedeemCommandHandler(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(RedeemCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(CustomerId.Create(request.CustomerId));
        customer.RedeemPoints();
        await _customerRepository.UpdateAsync(customer);
        return customer;
    }
}