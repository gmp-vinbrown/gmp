using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventRegistration))]
    public class EventRegistrationDTO : AuditableEntity
    {
        public int EventRegistrationId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public int? PaymentId { get; set; }
        public bool Deleted { get; set; }

        public virtual EventDTO Event { get; set; }

        [JsonIgnore]
        public virtual MemberDTO Member { get; set; }

        public virtual PaymentDTO Payment { get; set; }
    }
}
