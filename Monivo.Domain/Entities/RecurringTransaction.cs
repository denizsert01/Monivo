using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class RecurringTransaction : BaseEntity
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int TypeParameterId { get; set; }

        public string Title { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public int FrequencyParameterId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime NextDueDate { get; set; }

        public bool IsActive { get; set; }


        public User User { get; set; }

        public Category Category { get; set; }

        public Parameter TypeParameter { get; set; }

        public Parameter FrequencyParameter { get; set; }
    }
}
