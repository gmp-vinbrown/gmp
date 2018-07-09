using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventRegistration")]
    public partial class EventRegistration
    {
        public int EventRegistrationId { get; set; }
        public int EventActivityId { get; set; }
        public int MemberId { get; set; }
        public int? PaymentId { get; set; }
        public bool Deleted { get; set; }

        public virtual Event Event { get; set; }
        public virtual Member Member { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
