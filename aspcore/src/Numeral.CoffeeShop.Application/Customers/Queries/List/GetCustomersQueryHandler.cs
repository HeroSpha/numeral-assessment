using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Application.Customers.Queries.List;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
{
    private readonly IRepository<Customer> _customerRepository;

    public GetCustomersQueryHandler(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetAsync();
    }
}