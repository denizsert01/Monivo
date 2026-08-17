using MediatR;
using Microsoft.AspNetCore.Identity;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler
       : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser =
                await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    "A user with this email address already exists.");
            }

            var user = new User
            {
                UserName = request.UserName,
                UserSurname = request.UserSurname,
                BirthDate = request.BirthDate,
                Email = request.Email
            };
            user.PasswordHash =
                _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
