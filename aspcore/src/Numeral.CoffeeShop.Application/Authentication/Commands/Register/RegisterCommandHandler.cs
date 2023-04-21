using ErrorOr;
using MediatR;
using Numeral.CoffeeShop.Application.Authentication.Common;
using Numeral.CoffeeShop.Application.Common.Interfaces.Authentication;
using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.Application.Helpers;
using Numeral.CoffeeShop.Domain.Common.Errors;
using Numeral.CoffeeShop.Domain.CustomerAggregate;
using Numeral.CoffeeShop.Domain.Identity;

namespace Numeral.CoffeeShop.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IUserRepository _repository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IRepository<User> userRepository, IUserRepository repository, IRepository<Customer> customerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _repository = repository;
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        
        //check if the user already exists (Validation)
        var user = await _repository.GetUserByEmail(command.Email);
        if (!Object.Equals(user, null))
        {
            return  Errors.User.DuplicateEmail;
        }
        var (salt, hashedPassword) = PasswordHelper.HashPassword(command.Password);

        user = User.Create(
            command.FirstName, 
            command.LastName,
            command.Email,
            hashedPassword,
            salt,
            command.Role);

        await _userRepository.InsertAsync(user);
        //create user
        if (user.Role == "Customer")
        {
            var customer = Customer.Create(user.Id.Value, user.FirstName, user.LastName, user.Email);
            await _customerRepository.InsertAsync(customer);
        }
        
        //create token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
        //return default;
    }
}