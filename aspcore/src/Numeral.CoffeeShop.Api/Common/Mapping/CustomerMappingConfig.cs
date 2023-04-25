using Mapster;

using Numeral.CoffeeShop.Api.Contracts.Customers;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.CustomerAggregate.Entities;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerResponse>();
        config.NewConfig<Reward, RewardResponse>();
    }
}