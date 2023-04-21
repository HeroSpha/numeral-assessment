using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.Identity;
using Numeral.CoffeeShop.Domain.Identity.ValueObjects;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, ErrorOr<User>>
{
    private readonly IRepository<User> _userRepository;

    public GetUserCommandHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(UserId.Create(request.Id));
        return user;
    }
}