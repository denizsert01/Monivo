using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class MonthlyBudget : BaseEntity
    {
        public int UserId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public decimal BudgetAmount { get; set; }

        public decimal LimitAmount { get; set; }
        public User User { get; set; }
    }
}
