using Mapster;

using Numeral.CoffeeShop.Api.Contracts.MenuItems;
using Numeral.CoffeeShop.Application.MenuItems.Commands.CreateMenuItem;
using Numeral.CoffeeShop.Domain.MenuItemAggregate;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class MenuItemsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //throw new NotImplementedException();
        config.NewConfig<CreateMenuItemRequest, MenuItemCommand>()
            .Map(dest => dest.LoyaltyProgramId, scr => scr.LoyaltyProgramId);
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, scr => scr.Id.Value)
            .Map(dest => dest.LoyaltyProgramId, scr => scr.Id.Value);
    }
}