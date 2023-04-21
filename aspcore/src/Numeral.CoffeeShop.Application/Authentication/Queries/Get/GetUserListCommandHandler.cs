using ErrorOr;

using MediatR;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Queries.Get;

public class GetUserListCommandHandler : IRequestHandler<GetUserListCommand, IEnumerable<User>>
{
    private readonly IRepository<User> _userRepository;

    public GetUserListCommandHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(GetUserListCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAsync();
        return users;
    }
}