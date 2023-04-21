using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.ValueObjects;

namespace Numeral.CoffeeShop.Application.Customers.Queries;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ErrorOr<Customer>>
{
    private readonly IRepository<Customer> _customerRepository;

    public GetCustomerQueryHandler(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(CustomerId.Create(request.Id));
    }
}