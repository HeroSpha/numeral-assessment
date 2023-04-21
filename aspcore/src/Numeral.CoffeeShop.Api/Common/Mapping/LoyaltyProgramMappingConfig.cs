using Mapster;

using Numeral.CoffeeShop.Api.Contracts.LoyaltyProgram;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Commands.Create;
using Numeral.CoffeeShop.Application.LoyaltyPrograms.Queries.Get;
using Numeral.CoffeeShop.Domain.LoyaltyProgramAggregate;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class LoyaltyProgramMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateLoyaltyProgramRequest, CreateLoyaltyProgramCommand>();
        config.NewConfig<string, GetLoyaltyProgramQuery>()
            .Map(dest => dest.LoyaltyProgramId, src => src);
        config.NewConfig<LoyaltyProgram, LoyaltyProgramResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());
    }
}