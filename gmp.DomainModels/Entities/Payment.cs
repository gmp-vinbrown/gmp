using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Registration = new HashSet<Registration>();
        }

        public int PaymentId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? FeeScheduleId { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public FeeSchedule FeeSchedule { get; set; }
        public TransactionType TransactionType { get; set; }
        public ICollection<Registration> Registration { get; set; }
    }
}
