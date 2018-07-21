using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Payment")]
    public partial class Payment
    {
        public Payment()
        {
            Registrations = new HashSet<EventRegistration>();
        }

        public int PaymentId { get; set; }
        public int TransactionTypeId { get; set; }
        public int MemberId { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool Deleted { get; set; }

        public virtual Member Member { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual ICollection<EventRegistration> Registrations { get; set; }
    }
}
