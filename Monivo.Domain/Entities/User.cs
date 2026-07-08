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

        // collection properties
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public ICollection<RecurringTransaction> RecurringTransactions { get; set; } = new List<RecurringTransaction>();

        public ICollection<MonthlyBudget> MonthlyBudgets { get; set; } = new List<MonthlyBudget>();
    }
}
