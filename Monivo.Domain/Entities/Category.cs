using Monivo.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Monivo.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public int TypeParameterId { get; set; }  
        
        public User User { get; set; }

        public Parameter TypeParameter { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public ICollection<RecurringTransaction> RecurringTransactions { get; set; } = new List<RecurringTransaction>();
    }
}
