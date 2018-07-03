using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Registration = new HashSet<EventRegistration>();
        }

        public int PaymentId { get; set; }
        public int TransactionTypeId { get; set; }
        public int MemberId { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public Member Member { get; set; }
        public TransactionType TransactionType { get; set; }
        public ICollection<EventRegistration> Registration { get; set; }
    }
}
