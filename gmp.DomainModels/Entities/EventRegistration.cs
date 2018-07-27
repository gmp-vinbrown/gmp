using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventRegistration")]
    public partial class EventRegistration : AuditableEntity
    {
        public int EventRegistrationId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public int? EventFeeGroupId { get; set; }
        public int? PaymentId { get; set; }
        public bool Deleted { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventFeeGroup FeeGroup { get; set; }
        public virtual Member Member { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
