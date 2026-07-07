using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int UserId { get; set; }

        public string CategoryName { get; set; }

        public int TypeParameterId { get; set; }  
        
        public User User { get; set; }

        public Parameter TypeParameter { get; set; }
    }
}
