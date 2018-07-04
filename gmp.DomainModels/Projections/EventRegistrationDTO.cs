using System;
using System.Collections.Generic;
using System.Text;
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

        public EventDTO Event { get; set; }
        public MemberDTO Member { get; set; }
        public PaymentDTO Payment { get; set; }
    }
}
