using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("FeeSchedule")]
    public partial class FeeSchedule
    {
        public FeeSchedule()
        {
            Members = new HashSet<Member>();
        }

        public int FeeScheduleId { get; set; }
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual Program Program { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
