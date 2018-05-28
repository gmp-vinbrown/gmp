using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class FeeSchedule
    {
        public FeeSchedule()
        {
            Member = new HashSet<Member>();
        }

        public int FeeScheduleId { get; set; }
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Program Program { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
