using Mapster;

using Numeral.CoffeeShop.Api.Contracts.Customers;
using Numeral.CoffeeShop.Domain.CustomerAggregate;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerResponse>()
            .ConstructUsing(src => new CustomerResponse(src.FirstName, src.LastName, src.Email, src.Id.Value.ToString()));

    }
}