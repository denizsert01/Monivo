using MediatR;

namespace Monivo.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<Unit>
    {
        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
