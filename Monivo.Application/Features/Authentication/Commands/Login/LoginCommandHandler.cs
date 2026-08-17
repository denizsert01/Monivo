using MediatR;
using Microsoft.AspNetCore.Identity;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new InvalidOperationException(
                    "Email or password is incorrect.");
            }
            var result = _passwordHasher.VerifyHashedPassword(
               user,
               user.PasswordHash,
               request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidOperationException(
                    "Email or password is incorrect.");
            }

            // Modernize hash if it's old
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash =
                    _passwordHasher.HashPassword(user, request.Password);

                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();
            }

            return user.Id;
        }
    }
}
