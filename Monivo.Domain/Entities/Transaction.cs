using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int? RecurringTransactionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Description { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }

        public RecurringTransaction? RecurringTransaction { get; set; }
    }
}
