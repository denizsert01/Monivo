using MediatR;

namespace Monivo.Application.Features.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<int>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
