using Mapster;

using Numeral.CoffeeShop.Api.Contracts.Authentication;
using Numeral.CoffeeShop.Application.Authentication.Common;
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.FirstName, scr => scr.User.FirstName)
            .Map(dest => dest.LastName, scr => scr.User.LastName)
            .Map(dest => dest.Email, scr => scr.User.Email)
            .Map(dest => dest.Role, scr => scr.User.Role)
            .Map(dest => dest.Id, scr => scr.User.Id.Value);
        
        config.NewConfig<User, GetUserResponse>()
            .Map(dest => dest.FirstName, scr => scr.FirstName)
            .Map(dest => dest.LastName, scr => scr.LastName)
            .Map(dest => dest.Email, scr => scr.Email)
            .Map(dest => dest.Role, scr => scr.Role)
            .Map(dest => dest.Id, scr => scr.Id.Value);
    }
}