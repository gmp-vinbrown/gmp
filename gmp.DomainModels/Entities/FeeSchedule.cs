using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class FeeSchedule
    {
        public FeeSchedule()
        {
            Member = new HashSet<Member>();
            Payment = new HashSet<Payment>();
        }

        public int FeeScheduleId { get; set; }
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }

        public Program Program { get; set; }
        public ICollection<Member> Member { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
