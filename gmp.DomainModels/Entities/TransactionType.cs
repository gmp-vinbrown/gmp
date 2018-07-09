using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("TransactionType")]
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
