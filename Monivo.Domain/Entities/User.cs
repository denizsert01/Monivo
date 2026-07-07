using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }
}
