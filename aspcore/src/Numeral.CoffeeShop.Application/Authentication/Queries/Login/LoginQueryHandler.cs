using MediatR;
using ErrorOr;
using Numeral.CoffeeShop.Application.Authentication.Common;
using Numeral.CoffeeShop.Application.Common.Interfaces.Authentication;
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Helpers;
using Numeral.CoffeeShop.Domain.Common.Errors;
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(command.Email);
        if (Object.Equals(user, null))
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (!PasswordHelper.VerifyPassword(command.Password, user.Salt, user.PasswordHash))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}