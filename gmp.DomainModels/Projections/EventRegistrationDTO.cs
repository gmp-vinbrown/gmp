using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventRegistration))]
    public class EventRegistrationDTO
    {
        public int EventRegistrationId { get; set; }
        public int EventActivityId { get; set; }
        public int MemberId { get; set; }
        public int? PaymentId { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual MemberDTO Member { get; set; }
        public virtual PaymentDTO Payment { get; set; }
    }
}
