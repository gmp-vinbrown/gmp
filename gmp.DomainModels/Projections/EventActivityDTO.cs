using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventActivity))]
    public class EventActivityDTO
    {
        public EventActivityDTO()
        {
            MemberEventActivity = new HashSet<MemberEventActivityDTO>();
        }

        public int EventActivityId { get; set; }
        public int EventId { get; set; }
        public int EventActivityTypeId { get; set; }

        public EventDTO Event { get; set; }
        public EventActivityTypeDTO EventActivityType { get; set; }
        public ICollection<MemberEventActivityDTO> MemberEventActivity { get; set; }
    }
}
