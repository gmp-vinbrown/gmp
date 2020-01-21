using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventActivity))]
    public class EventActivityDTO
    {
        public EventActivityDTO()
        {
            MemberEventActivities = new HashSet<MemberEventActivityDTO>();
        }

        public int EventActivityId { get; set; }
        public int EventId { get; set; }
        public int EventActivityTypeId { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public EventDTO Event { get; set; }

        public EventActivityTypeDTO EventActivityType { get; set; }

        [JsonIgnore]
        public ICollection<MemberEventActivityDTO> MemberEventActivities { get; set; }
    }
}
