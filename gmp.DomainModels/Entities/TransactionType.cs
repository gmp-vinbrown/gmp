using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Payment = new HashSet<Payment>();
        }

        public int TransactionTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
